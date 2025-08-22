using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soccer.src.modules.equipo.domain.models;
using soccer_cs.src.modules.cuerpo_medico.domain.models;
using soccer_cs.src.modules.torneo.domain.models;

namespace soccer_cs.src.modules.torneo.application.interfaces;

public interface ITorneoService
{
  Task AgregarTorneoAsync(Torneo torneo);
  Task ActualizarTorneoAsync(int id, Torneo torneo);
  Task EliminarTorneoAsync(int id);
  Task<IEnumerable<Torneo?>> MostrarTorneosAsync();
  Task<Torneo?> ObtenerTorneoPorIdAsync(int id);
  Task<Torneo?> ObtenerTorneoPorNombreAsync(string nombre);
  Task RegistrarEquipoATorneoAsync(int id_torneo, int id_equipo);
  Task EliminarEquipoATorneoAsync(int id_torneo, int id_equipo);

}
