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
	[Route("api/Partidas")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public class PartidasController : ControllerBase
	{
		private readonly IPartidaRepository _ctPartida;
		private readonly IMapper _mapper;
		public PartidasController(IPartidaRepository ctPartida, IMapper mapper)
		{
			_ctPartida = ctPartida;
			_mapper = mapper;
		}
		/// <summary>
		/// Obtener todas las partidas
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		[ProducesResponseType(200, Type = typeof(List<PartidaDto>))]
		[ProducesResponseType(400)]
		public IActionResult GetPartidas()
		{
			var listaPartidas = _ctPartida.GetPartidas();
			var listaPartidasDTO = new List<PartidaDto>();
			foreach (var lista in listaPartidas)
			{
				listaPartidasDTO.Add(_mapper.Map<PartidaDto>(lista));
			}
			return Ok(listaPartidasDTO);
		}

		/// <summary>
		///Obtener una partida individual
		/// </summary>
		/// <param name="PartidaId"> </param>
		/// <returns></returns>
		[HttpGet("{partidaId:int}", Name = "GetPartida")]
		[ProducesResponseType(200, Type = typeof(PartidaDto))]
		[ProducesResponseType(404)]
		[ProducesDefaultResponseType]
		public IActionResult GetPartida(int partidaId)
		{
			var itemPartida = _ctPartida.GetPartida(partidaId);
			if (itemPartida == null)
			{
				return NotFound();
			}
			else
			{
				var itemPartidaDTO = _mapper.Map<PartidaDto>(itemPartida);
				return Ok(itemPartidaDTO);
			}

		}

		/// <summary>
		/// Crear una nueva partida
		/// </summary>
		/// <param name="PartidaDto"></param>
		/// <returns></returns>
		[HttpPost]
		[ProducesResponseType(201, Type = typeof(PartidaDto))]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult CrearPartida([FromBody] PartidaDto PartidaDto)
		{
			if (PartidaDto == null)
			{
				return BadRequest(ModelState);
			}
			if (_ctPartida.ExistePartida(PartidaDto.Idpartida))
			{
				ModelState.AddModelError("", "La Partida ya existe");
				return StatusCode(404, ModelState);
			}

			var partida = _mapper.Map<Partida>(PartidaDto);
			if (!_ctPartida.CrearPartida(partida))
			{
				ModelState.AddModelError("", $"Algo Salio mal guardando el registro{partida.Idpartida}");
				return StatusCode(500, ModelState);
			}
			return CreatedAtRoute("GetPartida", new { partidaId = partida.Idpartida }, partida);
		}

		/// <summary>
		/// Actualizar una partida existente
		/// </summary>
		/// <param name="Idpartida"></param>
		/// <param name="PartidaDto"></param>
		/// <returns></returns>
		[HttpPatch("{PartidaId:int}", Name = "ActualizarPartida")]
		[ProducesResponseType(204)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult ActualizarPartida(int Idpartida, [FromBody] PartidaDto partidaDto)
		{
			if (partidaDto == null || Idpartida != partidaDto.Idpartida)
			{
				return BadRequest(ModelState);
			}
			var partida = _mapper.Map<Partida>(partidaDto);
			if (!_ctPartida.ActualizarPartida(partida))
			{
				ModelState.AddModelError("", $"Algo Salio mal actualizando el registro{partida.Idpartida}");
				return StatusCode(500, ModelState);
			}
			return CreatedAtRoute("GetPartida", new { Idpartida = partida.Idpartida }, partida);
		}

		/// <summary>
		/// Borrar una partida existente
		/// </summary>
		/// <param name="Idpartida"></param>
		/// <returns></returns>
		[HttpDelete("{PartidaId:int}", Name = "BorrarPartida")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status409Conflict)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesDefaultResponseType]
		public IActionResult BorrarPartida(int Idpartida)
		{
			if (!_ctPartida.ExistePartida(Idpartida))
			{
				return NotFound();
			}
			var partida = _ctPartida.GetPartida(Idpartida);
			if (!_ctPartida.BorrarPartida(partida))
			{
				ModelState.AddModelError("", $"Algo Salio mal borrando el registro{partida.Idpartida}");
				return StatusCode(500, ModelState);
			}
			return NoContent();
		}
	}
}
