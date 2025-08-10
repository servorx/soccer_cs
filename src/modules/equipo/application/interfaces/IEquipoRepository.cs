using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soccer.modules.equipo.domain;
using soccer_cs.models;

namespace soccer_cs;
public interface IEquipoRepository
{
  void Add(Equipo entity);
  void Update(Equipo entity);
  void Remove(Equipo entity);

  Task<IEnumerable<Equipo>> GetAllAsync();
  Task<Equipo?> GetByIdAsync(int id);
  Task<Equipo?> GetByNameAsync(string nombre);

  Task<IEnumerable<Jugador>> GetJugadoresByEquipoIdAsync(int id);
  Task SaveAsync();
}
