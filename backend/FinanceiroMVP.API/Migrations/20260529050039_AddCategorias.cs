using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FinanceiroMVP.API.Migrations
{
    /// <inheritdoc />
    public partial class AddCategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Transacoes",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Cor = table.Column<string>(type: "text", nullable: true),
                    Icone = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transacoes_CategoriaId",
                table: "Transacoes",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transacoes_Categorias_CategoriaId",
                table: "Transacoes",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transacoes_Categorias_CategoriaId",
                table: "Transacoes");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropIndex(
                name: "IX_Transacoes_CategoriaId",
                table: "Transacoes");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Transacoes");
        }
    }
}
