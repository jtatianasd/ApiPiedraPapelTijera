using ApiPiedraPapelTijera.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPiedraPapelTijera.Repository.IRepository
{
	public interface IRondaRepository
	{
		ICollection<Ronda> GetRondas();
		ICollection<Ronda> GetRondasEnPartidas(int ParId);
		Ronda GetRonda(int rondaId);
		IEnumerable<Ronda> BuscarRonda(int rondaId);
		bool ExisteRonda(int id);
		bool CrearRonda(Ronda ronda);
		bool ActualizarRonda(Ronda ronda);
		bool BorrarRonda(Ronda ronda);
		bool Guardar();
	}
}
