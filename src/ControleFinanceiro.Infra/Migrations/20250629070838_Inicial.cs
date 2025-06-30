using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleFinanceiro.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", unicode: false, nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrcamentosMensais",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Mes = table.Column<int>(type: "int", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrcamentosMensais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Termometros",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ValorInicial = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    ValorFinal = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Cor = table.Column<string>(type: "varchar(7)", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Termometros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrcamentosDiarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Data = table.Column<DateTime>(type: "timestamp", nullable: false),
                    OrcamentoMensalId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrcamentosDiarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrcamentoDiario_OrcamentoMensal_OrcamentoMensalId",
                        column: x => x.OrcamentoMensalId,
                        principalTable: "OrcamentosMensais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lancamentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Valor = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", unicode: false, nullable: false),
                    Data = table.Column<DateTime>(type: "timestamp", nullable: false),
                    CategoriaId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrcamentoDiarioId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lancamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lancamentos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lancamentos_OrcamentosDiarios_OrcamentoDiarioId",
                        column: x => x.OrcamentoDiarioId,
                        principalTable: "OrcamentosDiarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lancamentos_CategoriaId",
                table: "Lancamentos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Lancamentos_OrcamentoDiarioId",
                table: "Lancamentos",
                column: "OrcamentoDiarioId");

            migrationBuilder.CreateIndex(
                name: "IX_OrcamentosDiarios_OrcamentoMensalId",
                table: "OrcamentosDiarios",
                column: "OrcamentoMensalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lancamentos");

            migrationBuilder.DropTable(
                name: "Termometros");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "OrcamentosDiarios");

            migrationBuilder.DropTable(
                name: "OrcamentosMensais");
        }
    }
}
