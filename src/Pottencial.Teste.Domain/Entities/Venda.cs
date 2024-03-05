using Pottencial.Teste.Domain.Entities.Base;
using Pottencial.Teste.Domain.Enums;
using Pottencial.Teste.Domain.Interfaces;

namespace Pottencial.Teste.Domain.Entities
{
    public sealed class Venda : Entidade, IQualificavel<VendaStatus>
    {
        public Venda() => Status = VendaStatus.AguardandoPagamento;

        public VendaStatus Status { get; private set; }

        #region NavigationProps
        public Vendedor? Vendedor { get; set; }
        public Guid VendedorId { get; set; }
        public ICollection<ItemVenda> Itens { get; set; }
        #endregion

        public void Qualificar(VendaStatus status) => this.Status = status;

    }
}