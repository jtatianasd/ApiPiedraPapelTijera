using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPiedraPapelTijera.Models
{
	public class Partida
	{
		[Key]
		public int Idpartida { get; set; }
		public int IdJugador1 { get; set; }
		public int IdJugador2 { get; set; }
		public DateTime FechaCreacion { get; set; }

	}
}
