using Pottencial.Teste.Domain.Enums;

namespace Pottencial.Teste.DomainService
{
    public class ItemQualificacao<TEnum>
    {
        public ItemQualificacao(TEnum statusAtual, TEnum proximoStatus)
        {
            StatusAtual = statusAtual;
            ProximoStatus = proximoStatus;
        }

        public TEnum StatusAtual { get; set; }
        public TEnum ProximoStatus { get; set; }
    }
}
