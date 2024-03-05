namespace Pottencial.Teste.Presentation.Api.ViewModels
{
    public class VendedorVM
    {
        public  Guid Id { get; set; }
        public string? Nome { get; private set; }
        public string? Cpf { get; private set; }
        public string? Email { get; private set; }
        public string? Telefone { get; private set; }
        public bool Ativo { get; set; }
    }
}
