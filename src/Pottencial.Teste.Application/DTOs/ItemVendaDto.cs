namespace Pottencial.Teste.Application.DTOs
{
    public class ItemVendaDto
    {
        public ItemVendaDto() { }

        public Guid Id { get; set; }
        public int Quantidade { get; set; }
        public decimal? PrecoVenda { get; set; }
        public Guid ProdutoId { get; set; }
    }
}
