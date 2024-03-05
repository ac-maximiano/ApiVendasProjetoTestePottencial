using AutoMapper;
using Pottencial.Teste.Application.DTOs;
using Pottencial.Teste.Application.Interfaces;
using Pottencial.Teste.Domain.Entities;
using Pottencial.Teste.Domain.Enums;
using Pottencial.Teste.Domain.Interfaces;
using Pottencial.Teste.DomainService;
using Pottencial.Teste.DomainService.Services;

namespace Pottencial.Teste.Application.Services
{
    /*
 * Registrar venda: Recebe os dados do vendedor + itens vendidos. Registra venda com status "Aguardando pagamento";
    Buscar venda: Busca pelo Id da venda;
    Atualizar venda: Permite que seja atualizado o status da venda.

    OBS.: Possíveis status: Pagamento aprovado | Enviado para transportadora | Entregue | Cancelada.
 * 
 */
    public class VendaService : IVendaService
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly IVendedorRepository _vendedorRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public VendaService(IVendaRepository vendaRepository, IVendedorRepository vendedorRepository,
            IProdutoRepository produtoRepository, IMapper mapper)
        {
            _vendaRepository = vendaRepository;
            _vendedorRepository = vendedorRepository;
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task<Guid> RegistrarVendaAsync(VendaDto venda)
        {
            var vendedor = await _vendedorRepository.GetByIdAsync(venda.VendedorId);

            if (vendedor == null) throw new ApplicationException("Vendedor não encontrado");
            if (!vendedor.Ativo) throw new ApplicationException("Este vendedor não está ativo no sistema");
            if (venda.Itens.Count < 1) throw new ApplicationException("A lista de itens está vazia");

            foreach (ItemVendaDto item in venda.Itens)
            {
                var produto = await _produtoRepository.GetByIdAsync(item.ProdutoId);

                if (produto == null) throw new ApplicationException($"Item {item.Id} não encontrado");

                AplicarPoliticaPreco(item, produto);
            }

            var vendaEntity = _mapper.Map<Venda>(venda);
            var result = await _vendaRepository.CreateAsync(vendaEntity);

            return result.Id;
        }
        public async Task<VendaDto> ConsultarVendaAsync(Guid id)
        {
            var entity = await _vendaRepository.GetByIdAsync(id, x => x.Itens, x => x.Vendedor);

            var vendaDto = _mapper.Map<VendaDto>(entity);

            return vendaDto;
        }
        public async Task<IEnumerable<VendaDto>> ObterVendasAsync(int take = 1, int skip = 0)
        {
            var results = await _vendaRepository.GetAllAsync(_ => true, take,
                skip, v => v.Vendedor, v => v.Itens);

            return _mapper.Map<IEnumerable<VendaDto>>(results);
        }
        public async Task QualificarVenda(Guid id)
        {
            var venda = await _vendaRepository.GetByIdAsync(id);
            var fluxoQualificacaoNormal = new VendaQualificador(venda);

            var vendaQualificada = fluxoQualificacaoNormal
                .AdicionarFluxo(new ItemQualificacao<VendaStatus>(VendaStatus.AguardandoPagamento, VendaStatus.PagamentoAprovado))
                .AdicionarFluxo(new ItemQualificacao<VendaStatus>(VendaStatus.PagamentoAprovado, VendaStatus.EnviadoParaTransportadora))
                .AdicionarFluxo(new ItemQualificacao<VendaStatus>(VendaStatus.EnviadoParaTransportadora, VendaStatus.Entregue))
                .Executar();

            await _vendaRepository.UpdateAsync(vendaQualificada);
        }
        public async Task CancelarVenda(Guid id)
        {
            var venda = await _vendaRepository.GetByIdAsync(id);

            var fluxoCancelamento = new VendaQualificador(venda);

            var vendaCancelada = fluxoCancelamento
                .AdicionarFluxo(new ItemQualificacao<VendaStatus>(VendaStatus.AguardandoPagamento, VendaStatus.Cancelado))
                .AdicionarFluxo(new ItemQualificacao<VendaStatus>(VendaStatus.PagamentoAprovado, VendaStatus.Cancelado))
                .Executar();

            await _vendaRepository.UpdateAsync(vendaCancelada);

        }

        private static void AplicarPoliticaPreco(ItemVendaDto item, Produto produto)
        {
            if (item.PrecoVenda == null || item.PrecoVenda == 0)
            {
                item.PrecoVenda = produto.PrecoReferencia;
            }
            else
            {
                item.PrecoVenda = item.PrecoVenda >= produto.PrecoReferencia ?
                    item.PrecoVenda
                    : produto.PrecoReferencia;
            }
        }

    }
}