namespace Pottencial.Teste.Application.DTOs
{
    public class ProdutoDto
    {
        public ProdutoDto() { }
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal PrecoReferencia { get; set; }
        public bool Ativo { get; set; }
    }
}
