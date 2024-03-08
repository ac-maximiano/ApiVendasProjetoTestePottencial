using Pottencial.Teste.Domain.Entities.Base;
using Pottencial.Teste.Domain.Interfaces;

namespace Pottencial.Teste.Domain.Entities
{
    public sealed class Vendedor : Pessoa, IInativavel
    {
        public Vendedor(string nome, string cpf, string email, string telefone, bool ativo = true)
            : base(nome, cpf, email, telefone) => Ativo = ativo;

        public bool Ativo { get; private set; }

        public void Inativar() => this.Ativo = false;

        #region NavigationProps
        public ICollection<Venda>? Pedidos { get; set; }

        #endregion
    }
}
