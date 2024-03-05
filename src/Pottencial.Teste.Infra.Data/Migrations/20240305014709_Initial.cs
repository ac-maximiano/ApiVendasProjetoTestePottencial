using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Pottencial.Teste.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    PrecoReferencia = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: false),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vendedores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Cpf = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendedores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    VendedorId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendas_Vendedores_VendedorId",
                        column: x => x.VendedorId,
                        principalTable: "Vendedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItensVendas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Quantidade = table.Column<int>(type: "INTEGER", nullable: false),
                    PrecoVenda = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: true),
                    ProdutoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    VendaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensVendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensVendas_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItensVendas_Vendas_VendaId",
                        column: x => x.VendaId,
                        principalTable: "Vendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "Ativo", "CriadoEm", "Descricao", "Nome", "PrecoReferencia" },
                values: new object[,]
                {
                    { new Guid("471709d4-7ec6-4eab-a7d2-fbc69b210e49"), true, new DateTime(2024, 3, 4, 22, 47, 9, 478, DateTimeKind.Local).AddTicks(9941), "Relógio analógico", "Relógio", 29.50m },
                    { new Guid("4a676cb9-a9a6-416e-996c-e2cdd57db4af"), true, new DateTime(2024, 3, 4, 22, 47, 9, 478, DateTimeKind.Local).AddTicks(9934), "Livro de ficção científica", "Livro", 15.75m },
                    { new Guid("51396c6f-1217-40c1-86a9-df97040c5df1"), true, new DateTime(2024, 3, 4, 22, 47, 9, 478, DateTimeKind.Local).AddTicks(9939), "Fone de ouvido sem fio", "Fone de Ouvido", 39.99m },
                    { new Guid("5992e574-16e9-4654-ad5d-93fe4d6d89eb"), true, new DateTime(2024, 3, 4, 22, 47, 9, 478, DateTimeKind.Local).AddTicks(9937), "Cadeira de escritório", "Cadeira", 79.95m },
                    { new Guid("72073684-ad02-4ef0-b753-f9fda4dbc08f"), true, new DateTime(2024, 3, 4, 22, 47, 9, 478, DateTimeKind.Local).AddTicks(9946), "Mochila resistente à água", "Mochila", 45.00m },
                    { new Guid("7b759bb1-0816-455c-8261-ebbddcefe38a"), true, new DateTime(2024, 3, 4, 22, 47, 9, 478, DateTimeKind.Local).AddTicks(9935), "Smartphone Android", "Celular", 499.99m },
                    { new Guid("a6ac012d-1c02-409f-9cf8-a48210399cc8"), true, new DateTime(2024, 3, 4, 22, 47, 9, 478, DateTimeKind.Local).AddTicks(9929), "Notebook com processador i7", "Notebook", 1200.50m },
                    { new Guid("b2fbc193-c3e6-4fa8-a147-8b5a26a6c8ce"), true, new DateTime(2024, 3, 4, 22, 47, 9, 478, DateTimeKind.Local).AddTicks(9932), "Sapato social preto", "Sapato", 49.90m },
                    { new Guid("b51ac7ec-6bc7-495a-bd14-816e918ef9c2"), true, new DateTime(2024, 3, 4, 22, 47, 9, 478, DateTimeKind.Local).AddTicks(9942), "Bicicleta urbana", "Bicicleta", 199.99m },
                    { new Guid("cdeb16a8-479c-48ac-a68b-2876323e906b"), true, new DateTime(2024, 3, 4, 22, 47, 9, 478, DateTimeKind.Local).AddTicks(9904), "Camiseta de algodão", "Camiseta", 25.99m }
                });

            migrationBuilder.InsertData(
                table: "Vendedores",
                columns: new[] { "Id", "Ativo", "Cpf", "CriadoEm", "Email", "Nome", "Telefone" },
                values: new object[,]
                {
                    { new Guid("223847c7-1cf0-4d02-8786-6a7dfc6025aa"), true, "111.222.333-44", new DateTime(2024, 3, 4, 22, 47, 9, 479, DateTimeKind.Local).AddTicks(867), "carlos@email.com", "Carlos Santos", "(33) 5555-5555" },
                    { new Guid("2401519a-d89e-4e5d-99ec-092aac0a6c20"), true, "222.333.444-55", new DateTime(2024, 3, 4, 22, 47, 9, 479, DateTimeKind.Local).AddTicks(2053), "lucas@email.com", "Lucas Santos", "(10) 1234-5678" },
                    { new Guid("3ccd1256-50db-429c-b2cf-6da53fbe5dbb"), true, "987.654.321-00", new DateTime(2024, 3, 4, 22, 47, 9, 479, DateTimeKind.Local).AddTicks(683), "maria@email.com", "Maria Oliveira", "(22) 8765-4321" },
                    { new Guid("70d8e681-446f-4a2e-9064-8249453e0976"), true, "777.888.999-00", new DateTime(2024, 3, 4, 22, 47, 9, 479, DateTimeKind.Local).AddTicks(1554), "camila@email.com", "Camila Pereira", "(77) 1122-3344" },
                    { new Guid("76754909-707b-47f0-b21c-b37292fd23af"), true, "333.222.111-00", new DateTime(2024, 3, 4, 22, 47, 9, 479, DateTimeKind.Local).AddTicks(1715), "fernando@email.com", "Fernando Oliveira", "(88) 4455-6677" },
                    { new Guid("77a2e783-6d4b-4173-813a-58e1c1e22c95"), true, "444.333.222-11", new DateTime(2024, 3, 4, 22, 47, 9, 479, DateTimeKind.Local).AddTicks(1395), "pedro@email.com", "Pedro Costa", "(66) 7654-3210" },
                    { new Guid("7d8a1a94-1fd2-456f-89cd-2bdb33b1254e"), true, "999.888.777-66", new DateTime(2024, 3, 4, 22, 47, 9, 479, DateTimeKind.Local).AddTicks(1233), "rafaela@email.com", "Rafaela Lima", "(55) 1234-5678" },
                    { new Guid("865b56f2-70da-4b76-b2f7-a76922d3bf12"), true, "666.555.444-33", new DateTime(2024, 3, 4, 22, 47, 9, 479, DateTimeKind.Local).AddTicks(1871), "mariana@email.com", "Mariana Silva", "(99) 9876-5432" },
                    { new Guid("cc2642b7-a6b7-460e-968b-69061b94caa6"), true, "123.456.789-01", new DateTime(2024, 3, 4, 22, 47, 9, 479, DateTimeKind.Local).AddTicks(203), "joao@email.com", "João Silva", "(11) 1234-5678" },
                    { new Guid("d28b5f3a-f07e-41b8-9cbf-d5a78e7a8d38"), true, "555.666.777-88", new DateTime(2024, 3, 4, 22, 47, 9, 479, DateTimeKind.Local).AddTicks(1056), "ana@email.com", "Ana Souza", "(44) 9876-5432" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItensVendas_ProdutoId",
                table: "ItensVendas",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensVendas_VendaId",
                table: "ItensVendas",
                column: "VendaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_VendedorId",
                table: "Vendas",
                column: "VendedorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItensVendas");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Vendas");

            migrationBuilder.DropTable(
                name: "Vendedores");
        }
    }
}
