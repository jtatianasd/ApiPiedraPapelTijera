using System.ComponentModel.DataAnnotations;
using static ApiPiedraPapelTijera.Models.Jugador;

namespace ApiPiedraPapelTijera.Models.DTO
{
	public class JugadorDto
	{

		public int Id { get; set; }

		[Required(ErrorMessage = "El nombre es obligatorio")]
		public string Nombre { get; set; }

		public TipoJugador Tipo { get; set; }
	}
}
