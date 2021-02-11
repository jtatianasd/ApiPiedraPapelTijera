using ApiPiedraPapelTijera.Models.DTO;
using ApiPiedraPapelTijera.Models;
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
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
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
		/// Obtener todos los jugadores
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		[ProducesResponseType(200, Type = typeof(List<JugadorDto>))]
		[ProducesResponseType(400)]
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

		/// <summary>
		///Obtener un jugador individual
		/// </summary>
		/// <param name="jugadorId"> </param>
		/// <returns></returns>
		[HttpGet("{JugadorId:int}", Name = "GetJugador")]
		[ProducesResponseType(200, Type = typeof(JugadorDto))]
		[ProducesResponseType(404)]
		[ProducesDefaultResponseType]
		public IActionResult GetJugador(int jugadorId)
		{
			var itemJugador = _ctJugador.GetJugador(jugadorId);
			if (itemJugador == null)
			{
				return NotFound();
			}
			else
			{
				var itemJugadorDTO = _mapper.Map<JugadorDto>(itemJugador);
				return Ok(itemJugadorDTO);
			}

		}

		/// <summary>
		/// Crear un nuevo jugador
		/// </summary>
		/// <param name="JugadorDto"></param>
		/// <returns></returns>
		[HttpPost]
		[ProducesResponseType(201, Type = typeof(JugadorDto))]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult CrearJugador([FromBody] JugadorDto JugadorDto)
		{
			if (JugadorDto == null)
			{
				return BadRequest(ModelState);
			}
			if (_ctJugador.ExisteJugador(JugadorDto.Nombre))
			{
				ModelState.AddModelError("", "La Jugador ya existe");
				return StatusCode(404, ModelState);
			}

			var jugador = _mapper.Map<Jugador>(JugadorDto);
			if (!_ctJugador.CrearJugador(jugador))
			{
				ModelState.AddModelError("", $"Algo Salio mal guardando el registro{jugador.Nombre}");
				return StatusCode(500, ModelState);
			}
			return CreatedAtRoute("GetJugador", new { jugadorId = jugador.Id }, jugador);
		}

		/// <summary>
		/// Actualizar un jugador existente
		/// </summary>
		/// <param name="jugadorId"></param>
		/// <param name="JugadorDto"></param>
		/// <returns></returns>
		[HttpPatch("{JugadorId:int}", Name = "ActualizarJugador")]
		[ProducesResponseType(204)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult ActualizarJugador(int jugadorId, [FromBody] JugadorDto jugadorDto)
		{
			if (jugadorDto == null || jugadorId != jugadorDto.Id)
			{
				return BadRequest(ModelState);
			}
			var jugador = _mapper.Map<Jugador>(jugadorDto);
			if (!_ctJugador.ActualizarJugador(jugador))
			{
				ModelState.AddModelError("", $"Algo Salio mal actualizando el registro{jugador.Nombre}");
				return StatusCode(500, ModelState);
			}
			return CreatedAtRoute("GetJugador", new { jugadorId = jugador.Id }, jugador);
		}

		/// <summary>
		/// Borrar un jugador existente
		/// </summary>
		/// <param name="jugadorId"></param>
		/// <returns></returns>
		[HttpDelete("{JugadorId:int}", Name = "BorrarJugador")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status409Conflict)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesDefaultResponseType]
		public IActionResult BorrarJugador(int jugadorId)
		{
			if (!_ctJugador.ExisteJugador(jugadorId))
			{
				return NotFound();
			}
			var jugador = _ctJugador.GetJugador(jugadorId);
			if (!_ctJugador.BorrarJugador(jugador))
			{
				ModelState.AddModelError("", $"Algo Salio mal borrando el registro{jugador.Nombre}");
				return StatusCode(500, ModelState);
			}
			return NoContent();
		}


	}
}
