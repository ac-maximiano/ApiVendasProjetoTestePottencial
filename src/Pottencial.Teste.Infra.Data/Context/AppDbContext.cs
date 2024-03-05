using Microsoft.EntityFrameworkCore;
using Pottencial.Teste.Domain.Entities;
using Pottencial.Teste.Infra.Data.Configuration;

namespace Pottencial.Teste.Infra.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<ItemVenda> ItensVendas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.AddEntitiesConfigurations();

            base.OnModelCreating(builder);
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
