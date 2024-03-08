using Pottencial.Teste.Domain.Interfaces;

namespace Pottencial.Teste.DomainService.Services
{
    public abstract class Qualificador<TEntity, TEnum>
        where TEntity : IQualificavel<TEnum>
    {
        public TEntity Entity { get; private set; }
        protected IList<ItemQualificacao<TEnum>> _fluxo;

        protected Qualificador(TEntity entity)
        {
            Entity = entity;
            _fluxo = new List<ItemQualificacao<TEnum>>();
        }

        public virtual Qualificador<TEntity, TEnum> AdicionarFluxo(ItemQualificacao<TEnum> item)
        {
            _fluxo.Add(item);

            return this;
        }

        public abstract TEntity Executar();
    }
}
