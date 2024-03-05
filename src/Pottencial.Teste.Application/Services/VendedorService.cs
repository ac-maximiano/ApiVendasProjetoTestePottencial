using AutoMapper;
using Pottencial.Teste.Application.DTOs;
using Pottencial.Teste.Application.Interfaces;
using Pottencial.Teste.Domain.Entities;
using Pottencial.Teste.Domain.Interfaces;

namespace Pottencial.Teste.Application.Services
{
    public class VendedorService : CommonCrudService<VendedorDto, Vendedor>, IVendedorService
    {
        public VendedorService(IVendedorRepository repository, IMapper mapper) : base(repository, mapper) { }

        public override async Task<VendedorDto> BuscarPorIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id, v => v.Pedidos);

            return _mapper.Map<VendedorDto>(entity);
        }
        public override async Task RemoverAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);

            entity.Inativar();

            await _repository.UpdateAsync(entity);
        }
    }
}
