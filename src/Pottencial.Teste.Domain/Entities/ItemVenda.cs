using Pottencial.Teste.Domain.Entities.Base;
using Pottencial.Teste.Domain.Validation;

namespace Pottencial.Teste.Domain.Entities
{
    public sealed class ItemVenda : Entidade
    {
        public ItemVenda(int quantidade, Guid produtoId, decimal? precoVenda = null)
        {
            ValidateDomain(quantidade);
            PrecoVenda = precoVenda;
            ProdutoId = produtoId;
        }

        public int Quantidade { get; private set; }
        public decimal? PrecoVenda { get; private set; }

        #region NavigationProps
        public Produto Produto { get; set; }
        public Guid ProdutoId { get; set; }
        public Venda Venda { get; set; }
        public Guid VendaId { get; set; }
        #endregion

        private void ValidateDomain(int quantidade)
        {
            DomainExceptionValidation.When(quantidade <= 0, "Não é permitido itens com quantidade inferior a 1");
            Quantidade = quantidade;
        }
    }
}
