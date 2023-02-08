using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alura.Challenge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class semana2categoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CategoriaId",
                table: "Videos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "Cor", "Titulo" },
                values: new object[] { 1L, "Verde", "Livre" });

            migrationBuilder.CreateIndex(
                name: "IX_Videos_CategoriaId",
                table: "Videos",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Categorias_CategoriaId",
                table: "Videos",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Categorias_CategoriaId",
                table: "Videos");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropIndex(
                name: "IX_Videos_CategoriaId",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Videos");
        }
    }
}
