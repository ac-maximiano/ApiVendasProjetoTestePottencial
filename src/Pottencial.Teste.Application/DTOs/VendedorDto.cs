namespace Pottencial.Teste.Application.DTOs
{
    public class VendedorDto
    {
        public VendedorDto() { }

        public Guid Id { get; set; }
        public bool Ativo { get; private set; }
        public string? Nome { get; private set; }
        public string? Cpf { get; private set; }
        public string? Email { get; private set; }
        public string? Telefone { get; private set; }
    }
}
