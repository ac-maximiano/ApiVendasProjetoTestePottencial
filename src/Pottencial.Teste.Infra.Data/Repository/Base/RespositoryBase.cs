﻿using Microsoft.EntityFrameworkCore;
using Pottencial.Teste.Domain.Entities.Base;
using Pottencial.Teste.Infra.Data.Common;
using Pottencial.Teste.Infra.Data.Context;
using System.Linq.Expressions;

namespace Pottencial.Teste.Infra.Data.Repository.Base
{
    public abstract class RespositoryBase<TEntity>
        where TEntity : Entidade
    {
        const int MAX_TAKE_RECORDS = 100;

        protected readonly AppDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        protected RespositoryBase(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<TEntity> CreateAsync(TEntity entidade)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    _dbSet.Add(entidade);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    return entidade;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new PersistenceException("Salvar registro", ex);
                }
            }

        }
        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter, int take = 1, int skip = 0, params Expression<Func<TEntity, object>>[] includes)
        {
            if (take > MAX_TAKE_RECORDS) take = MAX_TAKE_RECORDS;
            if (skip <= 0) skip = 0;

            var query = _dbSet
                .AsNoTracking()
                .AsQueryable();

            try
            {
                if (includes != null)
                {
                    foreach (var item in includes)
                    {
                        query = query.Include(item);
                    }
                }

                var result = await query
                    .Where(filter)
                    .Skip(skip)
                    .Take(take)
                    .ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw new PersistenceException("Obter todos registros", ex);
            }
        }
        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            try
            {
                var result = await _dbSet.AsNoTracking()
                    .SingleOrDefaultAsync(x => x.Id == id);

                return result;
            }
            catch (Exception ex)
            {
                throw new PersistenceException("Obter um registro pelo id", ex);
            }
        }
        public async Task<TEntity> GetByIdAsync(Guid id, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _dbSet
                .AsNoTracking()
                .AsQueryable();

            try
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }

                var result = await query.SingleOrDefaultAsync(x => x.Id == id);

                return result;
            }
            catch (Exception ex)
            {
                throw new PersistenceException("Obter um registro pelo id", ex);
            }
        }
        public async Task<TEntity> RemoveAsync(TEntity entidade)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    _dbSet.Remove(entidade);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    return entidade;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new PersistenceException("Remover registro", ex);
                }
            }
        }
        public async Task<TEntity> UpdateAsync(TEntity entidade)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    _dbSet.Update(entidade);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    return entidade;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new PersistenceException("Atualizar registro", ex);
                }
            }
        }
    }
}
