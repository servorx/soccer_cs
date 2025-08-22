using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soccer_cs.src.modules.estadistica_jugador.domain.models;

namespace soccer_cs.src.modules.estadistica_jugador.application.interfaces;

public interface IEstadisticaJugadorRepository
{
  // crud basico
  void Add(EstadisticaJugador estadisticaJugador);
  void Update(EstadisticaJugador estadisticaJugador);
  void Remove(EstadisticaJugador estadisticaJugador);
  // consultas sencillas
  Task<IEnumerable<EstadisticaJugador?>> GetAllAsync();
  Task<EstadisticaJugador?> GetByIdAsync(int id);
  Task<EstadisticaJugador?> GetByJugadorNombreAsync(string nombre);
  // consultas especiales
  Task<IEnumerable<EstadisticaJugador?>> GetTopGoleadoresAsync();
  Task<IEnumerable<EstadisticaJugador?>> GetTopPartidosAsync();
  Task<IEnumerable<EstadisticaJugador?>> GetMasAltosAsync();
  Task<IEnumerable<EstadisticaJugador?>> GetMenosPesadosAsync();
  Task<IEnumerable<EstadisticaJugador?>> GetMasTarjetasAmarillasAsync();
  Task<IEnumerable<EstadisticaJugador?>> GetMenosTarjetasRojasAsync();
  Task<IEnumerable<EstadisticaJugador?>> GetEdadMayorPromedioEquipoAsync(int equipoId);
  // guardar cambis 
  Task SaveAsync();
}
