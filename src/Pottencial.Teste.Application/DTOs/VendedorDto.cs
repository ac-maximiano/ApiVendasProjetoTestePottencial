namespace Pottencial.Teste.Application.DTOs
{
    public class VendedorDto
    {
        public VendedorDto() { }

        public Guid Id { get; set; }
        public bool Ativo { get; set; }
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
    }
}
