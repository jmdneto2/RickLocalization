using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RickLocalization.Repository.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dimensao",
                columns: table => new
                {
                    DimensaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DimensaoNome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dimensao", x => x.DimensaoId);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QtdMaxPorCliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.ProdutoId);
                });

            migrationBuilder.CreateTable(
                name: "Venda",
                columns: table => new
                {
                    VendaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorTotalDescontos = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venda", x => x.VendaID);
                });

            migrationBuilder.CreateTable(
                name: "Personagem",
                columns: table => new
                {
                    PersonagemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonagemNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonagemDimensaoDimensaoId = table.Column<int>(type: "int", nullable: true),
                    ImagemPersonagem = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personagem", x => x.PersonagemId);
                    table.ForeignKey(
                        name: "FK_Personagem_Dimensao_PersonagemDimensaoDimensaoId",
                        column: x => x.PersonagemDimensaoDimensaoId,
                        principalTable: "Dimensao",
                        principalColumn: "DimensaoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Promocao",
                columns: table => new
                {
                    PromocaoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Produto1Id = table.Column<int>(type: "int", nullable: true),
                    Produto2Id = table.Column<int>(type: "int", nullable: true),
                    Produto3Id = table.Column<int>(type: "int", nullable: true),
                    Produto1Qtd = table.Column<int>(type: "int", nullable: true),
                    Produto2Qtd = table.Column<int>(type: "int", nullable: true),
                    Produto3Qtd = table.Column<int>(type: "int", nullable: true),
                    ValorDescP1 = table.Column<int>(type: "int", nullable: true),
                    ValorDescP2 = table.Column<int>(type: "int", nullable: true),
                    ValorDescP3 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promocao", x => x.PromocaoID);
                    table.ForeignKey(
                        name: "FK_Promocao_Produto_Produto1Id",
                        column: x => x.Produto1Id,
                        principalTable: "Produto",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Promocao_Produto_Produto2Id",
                        column: x => x.Produto2Id,
                        principalTable: "Produto",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Promocao_Produto_Produto3Id",
                        column: x => x.Produto3Id,
                        principalTable: "Produto",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    PedidoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VendaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.PedidoId);
                    table.ForeignKey(
                        name: "FK_Pedido_Venda_VendaID",
                        column: x => x.VendaID,
                        principalTable: "Venda",
                        principalColumn: "VendaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Viagem",
                columns: table => new
                {
                    ViagemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonagemId = table.Column<int>(type: "int", nullable: true),
                    OrigemDimensaoId = table.Column<int>(type: "int", nullable: true),
                    DestinoDimensaoId = table.Column<int>(type: "int", nullable: true),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viagem", x => x.ViagemId);
                    table.ForeignKey(
                        name: "FK_Viagem_Dimensao_DestinoDimensaoId",
                        column: x => x.DestinoDimensaoId,
                        principalTable: "Dimensao",
                        principalColumn: "DimensaoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Viagem_Dimensao_OrigemDimensaoId",
                        column: x => x.OrigemDimensaoId,
                        principalTable: "Dimensao",
                        principalColumn: "DimensaoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Viagem_Personagem_PersonagemId",
                        column: x => x.PersonagemId,
                        principalTable: "Personagem",
                        principalColumn: "PersonagemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PedidoId = table.Column<int>(type: "int", nullable: true),
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Item_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "PedidoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Item_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Item_PedidoId",
                table: "Item",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_ProdutoId",
                table: "Item",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_VendaID",
                table: "Pedido",
                column: "VendaID");

            migrationBuilder.CreateIndex(
                name: "IX_Personagem_PersonagemDimensaoDimensaoId",
                table: "Personagem",
                column: "PersonagemDimensaoDimensaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Promocao_Produto1Id",
                table: "Promocao",
                column: "Produto1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Promocao_Produto2Id",
                table: "Promocao",
                column: "Produto2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Promocao_Produto3Id",
                table: "Promocao",
                column: "Produto3Id");

            migrationBuilder.CreateIndex(
                name: "IX_Viagem_DestinoDimensaoId",
                table: "Viagem",
                column: "DestinoDimensaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Viagem_OrigemDimensaoId",
                table: "Viagem",
                column: "OrigemDimensaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Viagem_PersonagemId",
                table: "Viagem",
                column: "PersonagemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Promocao");

            migrationBuilder.DropTable(
                name: "Viagem");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Personagem");

            migrationBuilder.DropTable(
                name: "Venda");

            migrationBuilder.DropTable(
                name: "Dimensao");
        }
    }
}
