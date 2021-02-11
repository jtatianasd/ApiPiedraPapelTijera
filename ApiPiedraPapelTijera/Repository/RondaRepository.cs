using ApiPiedraPapelTijera.Data;
using ApiPiedraPapelTijera.Models;
using ApiPiedraPapelTijera.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPiedraPapelTijera.Repository
{
	public class RondaRepository : IRondaRepository
	{
		private readonly ApplicationDbContext _bd;
		public RondaRepository(ApplicationDbContext bd)
		{
			_bd = bd;
		}
		public bool ActualizarRonda(Ronda ronda)
		{
			_bd.Ronda.Update(ronda);
			return Guardar();
		}

		public bool BorrarRonda(Ronda ronda)
		{
			_bd.Ronda.Remove(ronda);
			return Guardar();
		}

		public IEnumerable<Ronda> BuscarRonda(int rondaId)
		{
			IQueryable<Ronda> query = _bd.Ronda;
			if (rondaId > 0)
			{
				query = query.Where(e => e.IdRonda == rondaId);
			}
			return query.ToList();
		}

		public bool CrearRonda(Ronda ronda)
		{
			_bd.Ronda.Add(ronda);
			return Guardar();
		}

		public bool ExisteRonda(int id)
		{
			return _bd.Ronda.Any(c => c.IdRonda == id);
		}

		public Ronda GetRonda(int rondaId)
		{
			return _bd.Ronda.FirstOrDefault(c => c.IdRonda == rondaId);
		}

		public ICollection<Ronda> GetRondas()
		{
			return _bd.Ronda.OrderBy(c => c.Idpartida).ToList();
		}

		public ICollection<Ronda> GetRondasEnPartidas(int ParId)
		{
			return _bd.Ronda.Include(pa => pa.Partida).Where(pa => pa.Idpartida == ParId).ToList();

		}

		public bool Guardar()
		{
			return _bd.SaveChanges() >= 0 ? true : false;
		}
	}
}
