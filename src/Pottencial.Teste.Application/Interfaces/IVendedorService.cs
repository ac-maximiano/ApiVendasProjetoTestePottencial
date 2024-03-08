using Pottencial.Teste.Application.DTOs;

namespace Pottencial.Teste.Application.Interfaces
{
    public interface IVendedorService
    {
        Task<Guid> AdicionarAsync(VendedorDto dto);
        Task<VendedorDto> BuscarPorIdAsync(Guid id);
        Task<IEnumerable<VendedorDto>> BuscarAsync(int take = 1, int skip = 0);
        Task AtualizarAsync(VendedorDto dto);
        Task RemoverAsync(Guid id);
    }
}
