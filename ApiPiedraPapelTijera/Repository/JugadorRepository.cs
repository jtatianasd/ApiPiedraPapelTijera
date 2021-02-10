using ApiPiedraPapelTijera.Data;
using ApiPiedraPapelTijera.Models;
using ApiPiedraPapelTijera.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPiedraPapelTijera.Repository
{
	public class JugadorRepository : IJugadorRepository
	{
		private readonly ApplicationDbContext _bd;
		public JugadorRepository(ApplicationDbContext bd)
		{
			_bd = bd;
		}
		public bool ActualizarJugador(Jugador jugador)
		{
			_bd.Jugador.Update(jugador);
			return Guardar();
		}

		public bool BorrarJugador(Jugador jugador)
		{

			_bd.Jugador.Remove(jugador);
			return Guardar();
		}

		public bool CrearJugador(Jugador jugador)
		{
			_bd.Jugador.Add(jugador);
			return Guardar();
		}

		public bool ExisteJugador(string nombre)
		{
			bool valor = _bd.Jugador.Any(c => c.Nombre.ToLower().Trim() == nombre.ToLower().Trim());
			return valor;
		}


		public Jugador GetJugador(string JugadorId)
		{
			return _bd.Jugador.FirstOrDefault(c => c.Id == JugadorId);
		}

		public ICollection<Jugador> GetJugadores()
		{
			return _bd.Jugador.OrderBy(c => c.Nombre).ToList();
		}

		public bool Guardar()
		{
			return _bd.SaveChanges() >= 0 ? true : false;
		}
	}
}
