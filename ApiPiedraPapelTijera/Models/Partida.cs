using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPiedraPapelTijera.Models
{
	public class Partida
	{
		[Key]
		public int Idpartida { get; set; }
		public enum Movimiento{ Piedra, Papel, Tijera }
		public Movimiento MovimientoJ1 { get; set; }
		public Movimiento MovimientoJ2 { get; set; }
		public string IdJugador1 { get; set; }

		public string IdJugador2 { get; set; }


	}
}
