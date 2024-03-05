namespace Pottencial.Teste.Infra.Data.Common
{
    public class PersistenceException : Exception
    {
        public PersistenceException(string message) : base(message) { }

        public PersistenceException(string operation, Exception innerException)
            : base($"Erro na execução da operação '{operation}'", innerException) { }
    }
}
