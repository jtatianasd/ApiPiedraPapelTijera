using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static ApiPiedraPapelTijera.Models.Partida;

namespace ApiPiedraPapelTijera.Models.DTO
{
	public class PartidaDto
	{
		public int Idpartida { get; set; }

		[Required(ErrorMessage = "El MovimientoJugador1 es obligatorio")]
		public Movimiento MovimientoJ1 { get; set; }

		[Required(ErrorMessage = "El MovimientoJugador2 es obligatorio")]
		public Movimiento MovimientoJ2 { get; set; }

		[Required(ErrorMessage = "El IdJugador1 es obligatorio")]
		public string IdJugador1 { get; set; }

		[Required(ErrorMessage = "El IdJugador2 es obligatorio")]
		public string IdJugador2 { get; set; }
	}
}
