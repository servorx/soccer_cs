using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soccer_cs.src.modules.estadistica_jugador.domain.models;

namespace soccer_cs.src.modules.estadistica_jugador.application.interfaces;

public interface IEstadisticaJugadorService
{
  // crud basico
  Task AgregarEstadisticaJugadorAsync(EstadisticaJugador estadisticaJugador);
  Task ActualizarEstadisticaJugadorAsync(int id, EstadisticaJugador estadisticaJugador);
  Task EliminarEstadisticaJugadorAsync(int id);
  // consultas sencilllas
  Task<IEnumerable<EstadisticaJugador?>> VerTodasAsync();
  Task<EstadisticaJugador?> VerPorIdAsync(int id);
  Task<EstadisticaJugador?> VerPorNombreAsync(string nombre);
  // consultas especiales
  Task<IEnumerable<EstadisticaJugador?>> JugadoresConMasGolesAsync();
  Task<IEnumerable<EstadisticaJugador?>> JugadoresConMasPartidosAsync();
  Task<IEnumerable<EstadisticaJugador?>> JugadoresMasAltosAsync();
  Task<IEnumerable<EstadisticaJugador?>> JugadoresMenosPesadosAsync();
  Task<IEnumerable<EstadisticaJugador?>> JugadoresConMasTarjetasAmarillasAsync();
  Task<IEnumerable<EstadisticaJugador?>> JugadoresConMenosTarjetasRojasAsync();
  Task<IEnumerable<EstadisticaJugador?>> JugadoresEdadMayorPromedioEquipoAsync(int equipoId);
}
