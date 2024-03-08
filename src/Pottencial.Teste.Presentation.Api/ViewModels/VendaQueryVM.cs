namespace Pottencial.Teste.Presentation.Api.ViewModels
{
    public class VendaQueryVM
    {
        public Guid Id { get; set; }
        public string? Status { get; set; }
        public Guid VendedorId { get; set; }
        public string? VendedorNome { get; set; }
        public List<ItemVendaVM>? Itens { get; set; }
    }
}
