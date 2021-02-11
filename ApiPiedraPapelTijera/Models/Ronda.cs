using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPiedraPapelTijera.Models
{
	public class Ronda
	{
		[Key]
		public int IdRonda { get; set; }
		public enum Movimiento { Piedra, Papel, Tijera }
		public Movimiento MovimientoJ1 { get; set; }
		public Movimiento MovimientoJ2 { get; set; }
		public enum Victoria { Jugador1, Jugador2,Empate }
		public Victoria Ganador { get; set; }

		//Llave foranea con la tabla Categoria
		public int Idpartida { get; set; }
		[ForeignKey("Idpartida")]
		public Partida Partida { get; set; }
	}
}
