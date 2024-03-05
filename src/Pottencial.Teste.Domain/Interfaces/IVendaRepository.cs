using Pottencial.Teste.Domain.Entities;

namespace Pottencial.Teste.Domain.Interfaces
{
    public interface IVendaRepository : IRepositoryBase<Venda>
    {
        /*
         * Embora não haja aqui quaisquer abstrações, estas interfaces possibilitam a definição
         * de métodos a serem implementados em seus respectivos repositórios que dizem respeito 
         * somente ao negócio de cada entidade de domínio aqui representada.
         * 
         * Um exemplo de aderência ao princípio de Segregação de Interfaces do SOLID
         */
    }
}
