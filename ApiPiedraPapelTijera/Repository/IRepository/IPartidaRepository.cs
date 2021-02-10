using ApiPiedraPapelTijera.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPiedraPapelTijera.Repository.IRepository
{
	public interface IPartidaRepository
	{
		ICollection<Partida> GetPartidas();
		Partida GetPartida(int partidaId);
		bool ExistePartida(int id);
		IEnumerable<Partida> BuscarPartida(int id);
		bool CrearPartida(Partida partida);
		bool ActualizarPartida(Partida partida);
		bool BorrarPartida(Partida partida);
		bool Guardar();
	}
}
