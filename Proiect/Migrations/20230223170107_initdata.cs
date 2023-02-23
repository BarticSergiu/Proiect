using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect.Migrations
{
    /// <inheritdoc />
    public partial class initdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persoana",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persoana", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sarcina",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denumire = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descriere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prioritate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipSarcina = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OreEstimate = table.Column<int>(type: "int", nullable: false),
                    PersoanaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sarcina", x => x.id);
                    table.ForeignKey(
                        name: "FK_Sarcina_Persoana_PersoanaId",
                        column: x => x.PersoanaId,
                        principalTable: "Persoana",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pontaj",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<int>(type: "int", nullable: false),
                    Durata = table.Column<int>(type: "int", nullable: false),
                    SarcinaId = table.Column<int>(type: "int", nullable: false),
                    Observatii = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pontaj", x => x.id);
                    table.ForeignKey(
                        name: "FK_Pontaj_Sarcina_SarcinaId",
                        column: x => x.SarcinaId,
                        principalTable: "Sarcina",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pontaj_SarcinaId",
                table: "Pontaj",
                column: "SarcinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Sarcina_PersoanaId",
                table: "Sarcina",
                column: "PersoanaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pontaj");

            migrationBuilder.DropTable(
                name: "Sarcina");

            migrationBuilder.DropTable(
                name: "Persoana");
        }
    }
}
