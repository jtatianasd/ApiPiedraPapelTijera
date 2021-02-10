using ApiPiedraPapelTijera.Data;
using ApiPiedraPapelTijera.Models;
using ApiPiedraPapelTijera.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPiedraPapelTijera.Repository
{
	public class PartidaRepository : IPartidaRepository
	{
		private readonly ApplicationDbContext _bd;

		public PartidaRepository(ApplicationDbContext bd)
		{
			_bd = bd;
		}
		public bool ActualizarPartida(Partida partida)
		{
			_bd.Partida.Update(partida);
			return Guardar();
		}

		public bool BorrarPartida(Partida partida)
		{
		
			_bd.Partida.Remove(partida);
			return Guardar();
		}

		public IEnumerable<Partida> BuscarPartida(int id)
		{
			IQueryable<Partida> query = _bd.Partida;
			if (id >0)
			{
				query = query.Where(e => e.Idpartida == id);
			}
			return query.ToList();
		}

		public bool CrearPartida(Partida partida)
		{
			_bd.Partida.Add(partida);
			return Guardar();
		}


		public bool ExistePartida(int id)
		{
			return _bd.Partida.Any(c => c.Idpartida == id);
		}

		public Partida GetPartida(int partidaId)
		{
			return _bd.Partida.FirstOrDefault(c => c.Idpartida == partidaId);

		}

		public ICollection<Partida> GetPartidas()
		{
			return _bd.Partida.OrderBy(c => c.Idpartida).ToList();
		}

		public bool Guardar()
		{
			return _bd.SaveChanges() >= 0 ? true : false;
		}
	}
}
