using FluentAssertions;
using Pottencial.Teste.Domain.Entities;

namespace Pottencial.Teste.Tests.Domain.Tests
{
    public class ItemVendaUnitTest
    {
        [Fact]
        public void CriarItemVenda_ComQuantidadeNegativa_ResultObjectValidState()
        {
            Action action = () => new ItemVenda(-2, Guid.NewGuid());

            action.Should()
                .Throw<Pottencial.Teste.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Não é permitido itens com quantidade inferior a 1");
        }
    }
}
