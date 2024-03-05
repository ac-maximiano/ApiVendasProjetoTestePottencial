namespace Pottencial.Teste.Domain.Interfaces
{
    public interface IQualificavel<TEnum>
    {
        void Qualificar(TEnum status);
    }
}
