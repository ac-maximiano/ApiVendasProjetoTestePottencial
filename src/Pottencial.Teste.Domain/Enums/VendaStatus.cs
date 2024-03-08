using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Pottencial.Teste.Domain.Enums
{
    public enum VendaStatus
    {
        [Display(Name = "Aguardando Pagamento")]
        AguardandoPagamento = 0,
        [Display(Name = "Pagamento Aprovado")]
        PagamentoAprovado = 10,
        [Display(Name = "Enviado para Transporte")]
        EnviadoParaTransportadora = 20,
        [Display(Name = "Entregue")]
        Entregue = 30,
        [Display(Name = "Cancelado")]
        Cancelado = 100,
    }


    public static class EnumHelper
    {
        public static string GetDisplayName(Enum value)
        {
            FieldInfo? field = value.GetType().GetField(value.ToString());
            DisplayAttribute displayAttribute = (DisplayAttribute)Attribute.GetCustomAttribute(field, typeof(DisplayAttribute));

            return displayAttribute?.Name ?? value.ToString();
        }
    }
}
