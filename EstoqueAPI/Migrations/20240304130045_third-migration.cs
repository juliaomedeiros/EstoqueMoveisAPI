using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstoqueAPI.Migrations
{
    /// <inheritdoc />
    public partial class thirdmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataDeCriação",
                table: "ProdutosEstoque",
                newName: "DataDeCriacao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataDeCriacao",
                table: "ProdutosEstoque",
                newName: "DataDeCriação");
        }
    }
}
