using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soccer_cs.src.modules.domain.models;

namespace soccer_cs.src.modules.transferencia.application.interfaces;
public interface ITransferenciaRepository
{
  void Add(Transferencia entity);
  void Update(Transferencia entity);
  void Remove(Transferencia entity);
  Task<IEnumerable<Transferencia?>> GetAllAsync();
  Task<Transferencia?> GetByIdAsync(int id);
  Task<List<Transferencia?>> ObtenerTransferenciasPorJugador(int id_jugador);
  Task<List<Transferencia?>> ObtenerTransferenciasPorEquipo(int id_equipo);
  Task SaveAsync();
}
