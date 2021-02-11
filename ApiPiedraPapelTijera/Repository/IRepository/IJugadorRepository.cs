using ApiPiedraPapelTijera.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPiedraPapelTijera.Repository.IRepository
{
	public interface IJugadorRepository
	{
		ICollection<Jugador> GetJugadores();
		Jugador GetJugador(int JugadorId);
		bool ExisteJugador(int JugadorId);
		bool ExisteJugador(string nombre);
		bool CrearJugador(Jugador jugador);
		bool ActualizarJugador(Jugador jugador);
		bool BorrarJugador(Jugador jugador);
		bool Guardar();
	}
}
