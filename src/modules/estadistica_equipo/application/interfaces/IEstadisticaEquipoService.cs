using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soccer_cs.src.modules.estadistica_equipo.domain.models;

namespace soccer_cs.src.modules.estadistica_equipo.application.interfaces;

public interface IEstadisticaEquipoService
{
  Task AgregarEstadisticaEquipoAsync(EstadisticaEquipo estadisticaEquipo);
  Task ActualizarEstadisticaEquipoAsync(int id, EstadisticaEquipo estadisticaEquipo);
  Task EliminarEstadisticaEquipoAsync(int id);
  Task<IEnumerable<EstadisticaEquipo?>> MostrarEstadisticaEquiposAsync();
  Task<EstadisticaEquipo?> ObtenerEstadisticaEquipoPorIdAsync(int id);
}
