using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VisTuApp.Migrations
{
    public partial class ModelMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tubulacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomeTubulacao = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tubulacoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Avarias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomeAvaria = table.Column<string>(type: "text", nullable: false),
                    Grau = table.Column<string>(type: "text", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    TubulacaoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avarias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Avarias_Tubulacoes_TubulacaoId",
                        column: x => x.TubulacaoId,
                        principalTable: "Tubulacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vistorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TubulacaoId = table.Column<int>(type: "integer", nullable: false),
                    DataVistoria = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsuarioVistoria = table.Column<string>(type: "text", nullable: false),
                    DataReparo = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Observação = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vistorias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vistorias_Tubulacoes_TubulacaoId",
                        column: x => x.TubulacaoId,
                        principalTable: "Tubulacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Avarias_TubulacaoId",
                table: "Avarias",
                column: "TubulacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Vistorias_TubulacaoId",
                table: "Vistorias",
                column: "TubulacaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avarias");

            migrationBuilder.DropTable(
                name: "Vistorias");

            migrationBuilder.DropTable(
                name: "Tubulacoes");
        }
    }
}
