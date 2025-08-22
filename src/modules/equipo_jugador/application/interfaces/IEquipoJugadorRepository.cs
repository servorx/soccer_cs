using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soccer_cs.src.modules.equipo_jugador.domain.models;

namespace soccer_cs.src.modules.equipo_jugador.application.interfaces;
public interface IEquipoJugadorRepository
{
  void Add(EquipoJugador entity);
  void Update(EquipoJugador entity);
  void Remove(EquipoJugador entity);
  Task<IEnumerable<EquipoJugador?>> GetAllAsync();
  Task<EquipoJugador?> GetByIdAsync(int id);
  // Task<EquipoJugador?> GetByEquipoNameAsync(string nombre_equipo);
  // Task<EquipoJugador?> GetByJugadorNameAsync(string nombre_jugador); 
  Task SaveAsync();
}
