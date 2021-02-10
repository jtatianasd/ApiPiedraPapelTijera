using ApiPiedraPapelTijera.Models;
using Microsoft.EntityFrameworkCore;


namespace ApiPiedraPapelTijera.Data
{
	public class ApplicationDbContext:DbContext
	{
		public ApplicationDbContext()
		{

		}
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
		{
		}
		public DbSet<Jugador> Jugador { get; set; }
		public DbSet<Partida> Partida { get; set; }
	}
}
