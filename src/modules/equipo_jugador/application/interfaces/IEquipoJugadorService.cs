using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soccer_cs.src.modules.equipo_jugador.domain.models;

namespace soccer_cs.src.modules.equipo_jugador.application.interfaces;
public interface IEquipoJugadorService
{
  Task AgregarEquipoJugadorAsync(EquipoJugador jugador);
  Task ActualizarEquipoJugadorAsync(int id, EquipoJugador jugador);
  Task EliminarEquipoJugadorAsync(int id);
  Task<IEnumerable<EquipoJugador?>> MostrarEquipoJugadorsAsync();
  // Task<EquipoJugador?> ObtenerJugadorPorIdAsync(int id);
  // Task<EquipoJugador?> ObtenerEquipoJugadorPorNombreAsync(string nombre);
}
