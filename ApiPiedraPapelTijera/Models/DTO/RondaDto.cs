using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static ApiPiedraPapelTijera.Models.Ronda;

namespace ApiPiedraPapelTijera.Models.DTO
{
	public class RondaDto
	{
		public int IdRonda { get; set; }

		[Required(ErrorMessage = "El MovimientoJugador1 es obligatorio")]
		public Movimiento MovimientoJ1 { get; set; }

		[Required(ErrorMessage = "El MovimientoJugador2 es obligatorio")]
		public Movimiento MovimientoJ2 { get; set; }

		public Victoria Ganador { get; set; }

		//Llave foranea con la tabla Categoria
		public int Idpartida { get; set; }
		[ForeignKey("Idpartida")]
		public Partida Partida { get; set; }
	}
}
