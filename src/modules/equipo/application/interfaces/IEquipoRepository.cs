

using soccer.src.modules.equipo.domain.models;
using soccer_cs.src.modules.jugador.domain.models;

namespace soccer_cs.src.modules.equipo.application.interfaces;
public interface IEquipoRepository
{
  // curd basico
  void Add(Equipo entity);
  void Update(Equipo entity);
  void Remove(Equipo entity);
  Task<IEnumerable<Equipo?>> GetAllAsync();
  // consultas basicas con LINQ
  Task<Equipo?> GetByIdAsync(int id);
  Task<Equipo?> GetByNameAsync(string nombre);
  Task<IEnumerable<Jugador?>> GetJugadoresByEquipoIdAsync(int id_equipo);
  // guardar los cambios manualmente
  Task SaveAsync();
}
