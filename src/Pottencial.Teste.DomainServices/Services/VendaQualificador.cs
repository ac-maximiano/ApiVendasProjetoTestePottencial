using Pottencial.Teste.Domain.Entities;
using Pottencial.Teste.Domain.Enums;

namespace Pottencial.Teste.DomainService.Services
{
    public class VendaQualificador : Qualificador<Venda, VendaStatus>
    {
        public VendaQualificador(Venda entity) : base(entity) { }

        public override Venda Executar()
        {
            if (_fluxo.Count == 0) throw new ApplicationException("Não foi informado um fluxo de qualificação");

            var statusAtual = Entity.Status;

            foreach (var item in _fluxo)
            {
                if (item.StatusAtual == statusAtual)
                {
                    Entity.Qualificar(item.ProximoStatus);

                    return Entity;
                }
            }

            throw new QualificadorException($"A venda não pôde ser qualificada devido o seu status inicial: '{EnumHelper.GetDisplayName(statusAtual)}'");
        }
    }
}
