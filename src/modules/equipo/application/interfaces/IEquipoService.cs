using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soccer.modules.equipo.domain;
using soccer_cs.models;

namespace soccer_cs;
public interface IEquipoService
{
  Task AgregarEquipoAsync(Equipo cuerpoTecnico);
  Task ActualizarEquipoAsync(int id, Equipo cuerpoTecnico);
  Task EliminarEquipoAsync(int id);

  // en el Enumerable obtiene las colecciona completas
  Task<IEnumerable<Equipo>> MostrarEquiposAsync();
  Task<Equipo?> ObtenerEquipoPorIdAsync(int id); 
  Task <IEnumerable<Equipo>> ObtenerEquipoPorNombreAsync(string nombre);

  Task<IEnumerable<Jugador>> ObtenerJugadoresPorEquipoAsync(int id_equipo);

  Task InsciribirEquipoAsync(int id_equipo, int id_torneo);
  Task DesencribirEquipoAsync(int id_equipo, int id_torneo);
}
