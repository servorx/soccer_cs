using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soccer_cs.src.modules.jugador.domain.models;

namespace soccer_cs.src.modules.jugador.application.interfaces;
public interface IJugadorRepository
{
  void Add(Jugador entity);
  void Update(Jugador entity);
  void Remove(Jugador entity);
  Task<IEnumerable<Jugador?>> GetAllAsync();
  Task<Jugador?> GetByIdAsync(int id);
  Task<Jugador?> GetByNameAsync(string nombre);
  Task SaveAsync();
}
