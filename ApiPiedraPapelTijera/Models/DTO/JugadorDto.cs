using System.ComponentModel.DataAnnotations;

namespace ApiPiedraPapelTijera.Models.DTO
{
	public class JugadorDto
	{


		[Required(ErrorMessage = "El Id es obligatorio")]
		public string Id { get; set; }

		[Required(ErrorMessage = "El nombre es obligatorio")]
		public string Nombre { get; set; }
	}
}
