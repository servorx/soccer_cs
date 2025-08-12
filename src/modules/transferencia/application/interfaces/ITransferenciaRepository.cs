using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soccer_cs.models;

namespace soccer_cs;
public interface ITransferenciaRepository
{
  void Add(Transferencia entity);
  void Update(Transferencia entity);
  void Remove(Transferencia entity);
  Task<IEnumerable<Transferencia?>> GetAllAsync();
  Task<IEnumerable<Transferencia?>> ObtenerTransferenciasPorJugador(int id_jugador);
  Task<IEnumerable<Transferencia?>> ObtenerTransferenciasPorEquipo(int id_equipo);
  Task<Transferencia?> GetByIdAsync(int id);
  Task SaveAsync();
}
