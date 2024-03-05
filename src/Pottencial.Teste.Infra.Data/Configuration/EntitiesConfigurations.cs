using Microsoft.EntityFrameworkCore;
using Pottencial.Teste.Domain.Entities;

namespace Pottencial.Teste.Infra.Data.Configuration
{
    public static class EntitiesConfigurations
    {
        public static ModelBuilder AddEntitiesConfigurations(this ModelBuilder builder)
        {
            #region VendaConfiguration
            builder.Entity<Venda>().HasKey("Id");
            builder.Entity<Venda>().Property(p => p.Status).IsRequired();
            builder.Entity<Venda>()
                .HasOne(p => p.Vendedor)
                .WithMany(v => v.Pedidos)
                .HasForeignKey(p => p.VendedorId);
            builder.Entity<Venda>()
                .HasMany(v => v.Itens)
                .WithOne(iv => iv.Venda)
                .HasForeignKey(iv => iv.VendaId);
            #endregion

            #region ItemVendaConfiguration
            builder.Entity<ItemVenda>().HasKey("Id");
            builder.Entity<ItemVenda>().Property(i => i.PrecoVenda)
                .HasPrecision(10, 2);
            builder.Entity<ItemVenda>().Property(i => i.Quantidade)
                .IsRequired();
            builder.Entity<ItemVenda>().HasOne(i => i.Produto)
                .WithMany(p => p.Itens)
                .HasForeignKey(i => i.ProdutoId);
            builder.Entity<ItemVenda>().HasOne(i => i.Venda)
                .WithMany(p => p.Itens)
                .HasForeignKey(i => i.VendaId);
            #endregion

            #region ProdutoConfiguration
            builder.Entity<Produto>().HasKey("Id");
            builder.Entity<Produto>().Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(50);
            builder.Entity<Produto>().Property(p => p.Descricao)
                .IsRequired()
                .HasMaxLength(256);
            builder.Entity<Produto>().Property(p => p.PrecoReferencia)
                .HasPrecision(10, 2);

            builder.Entity<Produto>().HasData(
                new Produto("Camiseta", "Camiseta de algodão", 25.99m),
                new Produto("Notebook", "Notebook com processador i7", 1200.50m),
                new Produto("Sapato", "Sapato social preto", 49.90m),
                new Produto("Livro", "Livro de ficção científica", 15.75m),
                new Produto("Celular", "Smartphone Android", 499.99m),
                new Produto("Cadeira", "Cadeira de escritório", 79.95m),
                new Produto("Fone de Ouvido", "Fone de ouvido sem fio", 39.99m),
                new Produto("Relógio", "Relógio analógico", 29.50m),
                new Produto("Bicicleta", "Bicicleta urbana", 199.99m),
                new Produto("Mochila", "Mochila resistente à água", 45.00m)
                );
            #endregion

            #region VendedorConfiguration
            builder.Entity<Vendedor>().HasKey("Id");
            builder.Entity<Vendedor>().Property(v => v.Ativo)
                .IsRequired();
            builder.Entity<Vendedor>().HasData(
                new Vendedor("João Silva", "123.456.789-01", "joao@email.com", "(11) 1234-5678"),
                new Vendedor("Maria Oliveira", "987.654.321-00", "maria@email.com", "(22) 8765-4321"),
                new Vendedor("Carlos Santos", "111.222.333-44", "carlos@email.com", "(33) 5555-5555"),
                new Vendedor("Ana Souza", "555.666.777-88", "ana@email.com", "(44) 9876-5432"),
                new Vendedor("Rafaela Lima", "999.888.777-66", "rafaela@email.com", "(55) 1234-5678"),
                new Vendedor("Pedro Costa", "444.333.222-11", "pedro@email.com", "(66) 7654-3210"),
                new Vendedor("Camila Pereira", "777.888.999-00", "camila@email.com", "(77) 1122-3344"),
                new Vendedor("Fernando Oliveira", "333.222.111-00", "fernando@email.com", "(88) 4455-6677"),
                new Vendedor("Mariana Silva", "666.555.444-33", "mariana@email.com", "(99) 9876-5432"),
                new Vendedor("Lucas Santos", "222.333.444-55", "lucas@email.com", "(10) 1234-5678")
            );
            #endregion


            return builder;
        }
    }
}
