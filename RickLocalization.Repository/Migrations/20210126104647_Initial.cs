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

            migrationBuilder.CreateIndex(
                name: "IX_Personagem_PersonagemDimensaoDimensaoId",
                table: "Personagem",
                column: "PersonagemDimensaoDimensaoId");

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
                name: "Viagem");

            migrationBuilder.DropTable(
                name: "Personagem");

            migrationBuilder.DropTable(
                name: "Dimensao");
        }
    }
}
