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
	[Route("api/Rondas")]
	[ApiController]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public class RondasController : ControllerBase
	{
		private readonly IRondaRepository _rondasRepo;
		private readonly IMapper _mapper;

		public RondasController(IRondaRepository rondasRepo, IMapper mapper )

		{
			_rondasRepo = rondasRepo;
			_mapper = mapper;
		
		}

		/// <summary>
		/// Obtener todas las rondas
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		[ProducesResponseType(200, Type = typeof(List<RondaDto>))]
		[ProducesResponseType(400)]
		public IActionResult GetRondas()
		{
			var listaRondas = _rondasRepo.GetRondas();
			var listaRondasDTO = new List<RondaDto>();
			foreach (var lista in listaRondas)
			{
				listaRondasDTO.Add(_mapper.Map<RondaDto>(lista));
			}
			return Ok(listaRondasDTO);
		}

		/// <summary>
		/// Obtener una ronda individual
		/// </summary>
		/// <param name="rondaId"> </param>
		/// <returns></returns>
		[HttpGet("{rondaId:int}", Name = "GetRonda")]
		[ProducesResponseType(200, Type = typeof(RondaDto))]
		[ProducesResponseType(404)]
		[ProducesDefaultResponseType]
		public IActionResult GetRonda(int rondaId)
		{
			var itemPelicula = _rondasRepo.GetRonda(rondaId);
			if (itemPelicula == null)
			{
				return NotFound();
			}
			else
			{
				var itemRondaDto = _mapper.Map<RondaDto>(itemPelicula);
				return Ok(itemRondaDto);
			}

		}
		/// <summary>
		/// Obtener las rondas de una partida
		/// </summary>
		/// <param name="parId"> </param>
		/// <returns></returns>
		[HttpGet("GetRondasEnPartida/{parId:int}")]
		[ProducesResponseType(200, Type = typeof(RondaDto))]
		[ProducesResponseType(404)]
		[ProducesDefaultResponseType]
		public IActionResult GetRondasEnPartida(int parId)
		{
			var listaRonda = _rondasRepo.GetRondasEnPartidas(parId);
			if (listaRonda == null || listaRonda.Count == 0)
			{
				return NotFound();
			}
			var itemRonda = new List<RondaDto>();
			foreach (var item in listaRonda)
			{
				itemRonda.Add(_mapper.Map<RondaDto>(item));
			}
			return Ok(itemRonda);
		}

		/// <summary>
		/// Buscar los registros de una ronda en especifico
		/// </summary>
		/// <param name="idRonda"> </param>
		/// <returns></returns>
		[HttpGet("Buscar")]
		[ProducesResponseType(200, Type = typeof(RondaDto))]
		[ProducesResponseType(404)]
		[ProducesDefaultResponseType]
		public IActionResult Buscar(int idRonda)
		{
			try
			{
				var resultado = _rondasRepo.BuscarRonda(idRonda);
				if (resultado.Any())
				{
					return Ok(resultado);
				}
				return NotFound();
			}
			catch (Exception)
			{

				return StatusCode(StatusCodes.Status500InternalServerError, "Error recuperando datos de la aplicacion");
			}
		}


		/// <summary>
		/// Crear una nueva ronda
		/// </summary>
		/// <param name="RondaDto"></param>
		/// <returns></returns>
		[HttpPost]
		[ProducesResponseType(201, Type = typeof(RondaDto))]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult CrearRonda([FromForm] RondaDto RondaDto)
		{
			if (RondaDto == null)
			{
				return BadRequest(ModelState);
			}
			if (_rondasRepo.ExisteRonda(RondaDto.IdRonda))
			{
				ModelState.AddModelError("", "La Ronda ya existe");
				return StatusCode(404, ModelState);
			}

			var Ronda = _mapper.Map<Ronda>(RondaDto);

			if (!_rondasRepo.CrearRonda(Ronda))
			{
				ModelState.AddModelError("", $"Algo Salio mal guardando el registro{Ronda.IdRonda}");
				return StatusCode(500, ModelState);
			}
			return CreatedAtRoute("GetRonda", new { rondaId = Ronda.IdRonda }, Ronda);
		}



		/// <summary>
		/// Actualizar una ronda existente
		/// </summary>
		/// <param name="rondaId"></param>
		/// <param name="RondaDto"></param>
		/// <returns></returns>
		[HttpPatch("{rondaId:int}", Name = "ActualizarRonda")]
		[ProducesResponseType(204)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult ActualizarRonda(int rondaId, [FromBody] RondaDto RondaDto)
		{
			if (RondaDto == null || rondaId != RondaDto.IdRonda)
			{
				return BadRequest(ModelState);
			}
			var Ronda = _mapper.Map<Ronda>(RondaDto);
			if (!_rondasRepo.ActualizarRonda(Ronda))
			{
				ModelState.AddModelError("", $"Algo Salio mal actualizando el registro{Ronda.IdRonda}");
				return StatusCode(500, ModelState);
			}
			return NoContent();
		}

		/// <summary>
		/// Borrar una ronda existente
		/// </summary>
		/// <param name="rondaId"></param>
		/// <returns></returns>
		[HttpDelete("{rondaId:int}", Name = "BorrarRonda")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status409Conflict)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesDefaultResponseType]
		public IActionResult BorrarRonda(int rondaId)
		{
			if (!_rondasRepo.ExisteRonda(rondaId))
			{
				return NotFound();
			}
			var ronda = _rondasRepo.GetRonda(rondaId);
			if (!_rondasRepo.BorrarRonda(ronda))
			{
				ModelState.AddModelError("", $"Algo Salio mal borrando el registro{ronda.IdRonda}");
				return StatusCode(500, ModelState);
			}
			return NoContent();
		}
	}
}
