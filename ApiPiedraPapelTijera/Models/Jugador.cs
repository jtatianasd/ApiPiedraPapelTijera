using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPiedraPapelTijera.Models
{
	public class Jugador
	{
		[Key]
		public int Id { get; set; }
		public string Nombre { get; set; }
		public enum TipoJugador { Jugador1, Jugador2}
		public TipoJugador Tipo { get; set; }

	}
}
