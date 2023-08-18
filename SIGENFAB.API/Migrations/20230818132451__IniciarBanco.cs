using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIGENFAB.API.Migrations
{
    /// <inheritdoc />
    public partial class _IniciarBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Deficiencias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deficiencias", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Deficiencias_Nome",
                table: "Deficiencias",
                column: "Nome",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deficiencias");
        }
    }
}
