using Microsoft.EntityFrameworkCore.Migrations;

namespace Nomenclatures.Migrations
{
    public partial class ajoutduprix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Prix",
                table: "Produits",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prix",
                table: "Produits");
        }
    }
}
