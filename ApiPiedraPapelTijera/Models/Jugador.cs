using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPiedraPapelTijera.Models
{
	public class Jugador
	{
		[Key]
		public string Id { get; set; }
		public string Nombre { get; set; }
	}
}
