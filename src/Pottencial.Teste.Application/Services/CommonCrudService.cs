using AutoMapper;
using Pottencial.Teste.Domain.Entities.Base;
using Pottencial.Teste.Domain.Interfaces;

namespace Pottencial.Teste.Application.Services
{
    public abstract class CommonCrudService<TDto, TEntity>
        where TEntity : Entidade
    {
        protected IMapper _mapper;
        protected IRepositoryBase<TEntity> _repository;

        protected CommonCrudService(IRepositoryBase<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<Guid> AdicionarAsync(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            var result = await _repository.CreateAsync(entity);

            return result.Id;
        }
        public virtual async Task<TDto> BuscarPorIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);

            return _mapper.Map<TDto>(entity);
        }
        public virtual async Task<IEnumerable<TDto>> BuscarAsync(int take = 1, int skip = 0)
        {
            var results = await _repository.GetAllAsync(_ => true, take, skip, null);

            return _mapper.Map<IEnumerable<TDto>>(results);
        }
        public virtual async Task AtualizarAsync(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);

            await _repository.UpdateAsync(entity);
        }
        public virtual async Task RemoverAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);

            await _repository.RemoveAsync(entity);
        }
    }
}
