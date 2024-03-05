namespace Pottencial.Teste.Domain.Entities.Base
{
    public abstract class Entidade
    {
        public Entidade()
        {
            Id = Guid.NewGuid();
            CriadoEm = DateTime.Now;
        }

        public Guid Id { get; private set; }
        public DateTime CriadoEm { get; private set; }
    }
}
