using Pottencial.Teste.Domain.Entities.Base;
using Pottencial.Teste.Domain.Interfaces;
using Pottencial.Teste.Domain.Validation;

namespace Pottencial.Teste.Domain.Entities
{
    public sealed class Produto : Entidade, IInativavel
    {
        public Produto(string nome, string descricao, decimal precoReferencia)
        {
            ValidateDomain(nome, descricao, precoReferencia);
            Ativo = true;
        }

        public string? Nome { get; private set; }
        public string? Descricao { get; private set; }
        public decimal PrecoReferencia { get; private set; }
        public bool Ativo { get; private set; }

        public void Inativar() => this.Ativo = false;

        #region NavigationProps
        public ICollection<ItemVenda>? Itens { get; set; }
        #endregion

        private void ValidateDomain(string nome, string descricao, decimal precoReferencia)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "Um produto deve ter um nome");
            DomainExceptionValidation.When(nome.Length < 3, "O nome de um produto deve conter no mínimo 3 caracteres");
            DomainExceptionValidation.When(string.IsNullOrEmpty(descricao), "Um produto deve ter alguma descrição");
            DomainExceptionValidation.When(descricao.Length < 5, "A descrição de um produto deve conter no mínimo 5 caracteres");
            DomainExceptionValidation.When(precoReferencia <= 0, "Preço de referência inválido");

            Nome = nome;
            Descricao = descricao;
            PrecoReferencia = precoReferencia;
        }
    }
}
