using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplicacaoProdutoAPI.Migrations
{
    /// <inheritdoc />
    public partial class Migration02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FazendaId",
                table: "Aplicacoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SafraId",
                table: "Aplicacoes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FazendaId",
                table: "Aplicacoes");

            migrationBuilder.DropColumn(
                name: "SafraId",
                table: "Aplicacoes");
        }
    }
}
