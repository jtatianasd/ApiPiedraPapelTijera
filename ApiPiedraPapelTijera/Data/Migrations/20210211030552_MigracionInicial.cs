using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiPiedraPapelTijera.Migrations
{
    public partial class MigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jugador",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Tipo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jugador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Partida",
                columns: table => new
                {
                    Idpartida = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdJugador1 = table.Column<int>(nullable: false),
                    IdJugador2 = table.Column<int>(nullable: false),
                    FechaCreacion = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partida", x => x.Idpartida);
                });

            migrationBuilder.CreateTable(
                name: "Ronda",
                columns: table => new
                {
                    IdRonda = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovimientoJ1 = table.Column<int>(nullable: false),
                    MovimientoJ2 = table.Column<int>(nullable: false),
                    Ganador = table.Column<int>(nullable: false),
                    Idpartida = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ronda", x => x.IdRonda);
                    table.ForeignKey(
                        name: "FK_Ronda_Partida_Idpartida",
                        column: x => x.Idpartida,
                        principalTable: "Partida",
                        principalColumn: "Idpartida",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ronda_Idpartida",
                table: "Ronda",
                column: "Idpartida");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jugador");

            migrationBuilder.DropTable(
                name: "Ronda");

            migrationBuilder.DropTable(
                name: "Partida");
        }
    }
}
