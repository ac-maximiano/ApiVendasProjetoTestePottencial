using Pottencial.Teste.Application.CustomAttributes;
using System.ComponentModel.DataAnnotations;

namespace Pottencial.Teste.Presentation.Api.ViewModels
{
    public class VendaCommandVM
    {
        [Required]
        public Guid VendedorId { get; set; }

        [ListHasElements(ErrorMessage = "Uma venda deve possuir ao menos 1 item")]
        public List<ItemVendaVM> Itens { get; set; }
    }
}
