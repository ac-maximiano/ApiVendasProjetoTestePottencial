using AutoMapper;
using Pottencial.Teste.Application.DTOs;
using Pottencial.Teste.Application.Interfaces;
using Pottencial.Teste.Domain.Entities;
using Pottencial.Teste.Domain.Interfaces;

namespace Pottencial.Teste.Application.Services
{
    public class ProdutoService : CommonCrudService<ProdutoDto, Produto>, IProdutoService
    {
        public ProdutoService(IProdutoRepository repository, IMapper mapper) : base(repository, mapper) { }

        public override async Task<ProdutoDto> BuscarPorIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id, p => p.Itens);

            return _mapper.Map<ProdutoDto>(entity);
        }
        public override async Task RemoverAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);

            entity.Inativar();

            await _repository.UpdateAsync(entity);
        }
    }
}
