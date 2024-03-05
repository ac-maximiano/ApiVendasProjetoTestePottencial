using FluentAssertions;
using Pottencial.Teste.Domain.Entities;

namespace Pottencial.Teste.Tests.Domain.Tests
{
    public class VendedorUnitTest
    {
        [Fact]
        public void CriarVendedor_ComNomeVazio_ResultObjectValidState()
        {
            Action action = () => new Vendedor("", "123.456.789-00", "teste@email.com", "(22) 1111-2222");

            action.Should()
                .Throw<Pottencial.Teste.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Uma pessoa deve possuir um nome");
        }

        [Fact]
        public void CriarVendedor_ComCPFVazio_ResultObjectValidState()
        {
            Action action = () => new Vendedor("aaa", "", "teste@email.com", "(22) 1111-2222");

            action.Should()
                .Throw<Pottencial.Teste.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("O CPF é requerido");
        }

        [Fact]
        public void CriarVendedor_ComTelefoneVazio_ResultObjectValidState()
        {
            Action action = () => new Vendedor("aaa", "123.456.789-00", "teste@email.com", "");

                action.Should()
                .Throw<Pottencial.Teste.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Um número de telefone deve ser informado");
        }

        [Fact]
        public void CriarVendedor_NomeComprimentoIncorreto_ResultObjectValidState()
        {
            Action action = () => new Vendedor("a", "123.456.789-00", "teste@email.com", "(22) 1111-2222");

            action.Should()
                .Throw<Pottencial.Teste.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CriarVendedor_CpfForaDoPadrao_ResultObjectValidState()
        {
            Action action = () => new Vendedor("aaa", "12345678900abd", "teste@email.com", "(22) 1111-2222");

            action.Should()
                .Throw<Pottencial.Teste.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CriarVendedor_EmailForaDoPadrao_ResultObjectValidState()
        {
            Action action = () => new Vendedor("aaa", "12345678900", "teste.email.com", "(22) 1111-2222");

            action.Should()
                .Throw<Pottencial.Teste.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CriarVendedor_TelefoneForaDoPadrao_ResultObjectValidState()
        {
            Action action = () => new Vendedor("aaa", "12345678900", "teste@email.com", "-2222");

            action.Should()
                .Throw<Pottencial.Teste.Domain.Validation.DomainExceptionValidation>();
        }

    }
}
