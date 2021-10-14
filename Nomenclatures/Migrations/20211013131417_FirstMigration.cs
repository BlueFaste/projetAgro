using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nomenclatures.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FamilleMatierePremiere",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DureeOptimaleUtilisation = table.Column<TimeSpan>(type: "time", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilleMatierePremiere", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MatierePremieres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PourcentageHumidite = table.Column<int>(type: "int", nullable: false),
                    PoidsUnitaire = table.Column<double>(type: "float", nullable: false),
                    DureeConservation = table.Column<TimeSpan>(type: "time", nullable: true),
                    FamilleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatierePremieres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatierePremieres_FamilleMatierePremiere_FamilleId",
                        column: x => x.FamilleId,
                        principalTable: "FamilleMatierePremiere",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MatierePremieres_FamilleId",
                table: "MatierePremieres",
                column: "FamilleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatierePremieres");

            migrationBuilder.DropTable(
                name: "FamilleMatierePremiere");
        }
    }
}
