using Pottencial.Teste.Application.DTOs;

namespace Pottencial.Teste.Application.Interfaces
{
    public interface IVendaService
    {
        Task<Guid> RegistrarVendaAsync(VendaDto venda);
        Task<VendaDto> ConsultarVendaAsync(Guid id);
        Task<IEnumerable<VendaDto>> ObterVendasAsync(int take = 1, int skip = 0);
        Task QualificarVenda(Guid id);
        Task CancelarVenda(Guid id);
    }
}
