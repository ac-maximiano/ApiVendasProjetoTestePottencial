using Pottencial.Teste.Domain.Entities;
using Pottencial.Teste.Domain.Interfaces;
using Pottencial.Teste.Infra.Data.Context;
using Pottencial.Teste.Infra.Data.Repository.Base;

namespace Pottencial.Teste.Infra.Data.Repository
{
    public class ItemVendaRepository : RespositoryBase<ItemVenda>, IItemVendaRepository
    {
        public ItemVendaRepository(AppDbContext context) : base(context) { }
    }
}
