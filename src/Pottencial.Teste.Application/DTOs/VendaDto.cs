using Pottencial.Teste.Domain.Enums;

namespace Pottencial.Teste.Application.DTOs
{
    public class VendaDto
    {
        public VendaDto() { }

        public Guid Id { get; set; }
        public VendaStatus Status { get; set; }
        public Guid VendedorId { get; set; }
        public VendedorDto Vendedor { get; set; }
        public IList<ItemVendaDto> Itens { get; set; }
    }
}
