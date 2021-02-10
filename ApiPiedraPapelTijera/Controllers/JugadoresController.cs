using ApiPiedraPapelTijera.Models.DTO;
using ApiPiedraPapelTijera.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPiedraPapelTijera.Controllers
{
	[Route("api/Jugadores")]
	[ApiController]
	public class JugadoresController : ControllerBase
	{
		private readonly IJugadorRepository _ctJugador;
		private readonly IMapper _mapper;
		public JugadoresController(IJugadorRepository ctJugador, IMapper mapper)
		{
			_ctJugador = ctJugador;
			_mapper = mapper;
		}
		/// <summary>
		/// Obtener todas las categorias
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public IActionResult GetJugadores()
		{
			var listaJugadores = _ctJugador.GetJugadores();
			var listaJugadoresDTO = new List<JugadorDto>();
			foreach (var lista in listaJugadores)
			{
				listaJugadoresDTO.Add(_mapper.Map<JugadorDto>(lista));
			}
			return Ok(listaJugadoresDTO);
		}
	}
}
