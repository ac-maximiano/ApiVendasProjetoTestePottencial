using System.Linq.Expressions;

namespace Pottencial.Teste.Domain.Interfaces
{
    public interface IRepositoryBase<TEntity>
    {
        Task<TEntity> CreateAsync(TEntity entidade);
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter,  int take = 1, 
            int skip = 0, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> GetByIdAsync(Guid id);
        Task<TEntity> GetByIdAsync(Guid id, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> RemoveAsync(TEntity entidade);
        Task<TEntity> UpdateAsync(TEntity entidade);
    }
}
