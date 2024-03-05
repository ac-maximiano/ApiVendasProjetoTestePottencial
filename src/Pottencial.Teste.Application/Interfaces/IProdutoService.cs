using Pottencial.Teste.Application.DTOs;

namespace Pottencial.Teste.Application.Interfaces
{
    public interface IProdutoService
    {
        Task<Guid> AdicionarAsync(ProdutoDto dto);
        Task<ProdutoDto> BuscarPorIdAsync(Guid id);
        Task<IEnumerable<ProdutoDto>> BuscarAsync(int take = 1, int skip = 0);
        Task AtualizarAsync(ProdutoDto dto);
        Task RemoverAsync(Guid id);
    }
}
