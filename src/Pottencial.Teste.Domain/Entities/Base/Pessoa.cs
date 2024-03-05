using Pottencial.Teste.Domain.Validation;
using System.Text.RegularExpressions;

namespace Pottencial.Teste.Domain.Entities.Base
{
    public abstract class Pessoa : Entidade
    {
        protected Pessoa(string nome, string cpf, string email, string telefone)
            => ValidateDomain(nome, cpf, email, telefone);

        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }

        private void ValidateDomain(string nome, string cpf, string email, string telefone)
        {
            var emailRegex = new Regex(@"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$");
            var telefoneRegex = new Regex(@"^\(\d{2,}\) \d{4,}-\d{4}$");
            var cpfRegex = new Regex(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$");

            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "Uma pessoa deve possuir um nome");
            DomainExceptionValidation.When(nome.Length < 3, "O nome de uma pessoa deve possuir ao menos 3 caracteres");
            DomainExceptionValidation.When(string.IsNullOrEmpty(cpf), "O CPF é requerido");
            DomainExceptionValidation.When(!cpfRegex.IsMatch(cpf), "O valor informado não corresponde a um CPF válido");
            DomainExceptionValidation.When(string.IsNullOrEmpty(email), "Um endereço de email é requerido");
            DomainExceptionValidation.When(!emailRegex.IsMatch(email), "O valor informado não corresponde a um endereço de email válido");
            DomainExceptionValidation.When(string.IsNullOrEmpty(telefone), "Um número de telefone deve ser informado");
            DomainExceptionValidation.When(!telefoneRegex.IsMatch(telefone), "O valor informado não corresponde a um telefone válido");

            Nome = nome;
            Cpf = cpf;
            Email = email;
            Telefone = telefone;
        }
    }
}
