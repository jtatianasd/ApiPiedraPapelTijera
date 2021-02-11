using ApiPiedraPapelTijera.Models;
using ApiPiedraPapelTijera.Models.DTO;
using AutoMapper;

namespace ApiPiedraPapelTijera.JuegoMappers
{
	public class JuegoMappers : Profile
	{
		public JuegoMappers()
		{
			CreateMap<Jugador, JugadorDto>().ReverseMap();
			CreateMap<Partida, PartidaDto>().ReverseMap();
			CreateMap<Ronda, RondaDto>().ReverseMap();
		}
	}
}
