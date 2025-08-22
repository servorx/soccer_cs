using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soccer.src.modules.equipo.domain.models;
using soccer_cs.src.modules.jugador.domain.models;

namespace soccer_cs.src.modules.equipo.application.interfaces;
public interface IEquipoService
{
  Task AgregarEquipoAsync(Equipo equipo);
  Task ActualizarEquipoAsync(int id, Equipo equipo);
  Task EliminarEquipoAsync(int id);
  // en el Enumerable obtiene las colecciona completas
  Task<IEnumerable<Equipo?>> MostrarEquiposAsync();
  Task<Equipo?> ObtenerEquipoPorIdAsync(int id); 
  Task<Equipo?> ObtenerEquipoPorNombreAsync(string nombre);
  Task<IEnumerable<Jugador?>> ObtenerJugadoresPorEquipoAsync(int id_equipo);
}
