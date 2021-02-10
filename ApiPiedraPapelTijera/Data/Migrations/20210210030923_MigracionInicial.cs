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
                    Id = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(nullable: true)
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
                    MovimientoJ1 = table.Column<int>(nullable: false),
                    MovimientoJ2 = table.Column<int>(nullable: false),
                    IdJugador1 = table.Column<string>(nullable: true),
                    IdJugador2 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partida", x => x.Idpartida);
                    table.ForeignKey(
                        name: "FK_Partida_Jugador_IdJugador2",
                        column: x => x.IdJugador2,
                        principalTable: "Jugador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Partida_IdJugador2",
                table: "Partida",
                column: "IdJugador2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Partida");

            migrationBuilder.DropTable(
                name: "Jugador");
        }
    }
}
