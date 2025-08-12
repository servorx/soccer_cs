using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soccer_cs.models;

namespace soccer_cs;

public interface IEstadisticaJugadorRepository
{
  // crud basico
  void Add(EstadisticaJugador entity);
  void Update(EstadisticaJugador entity);
  void Remove(EstadisticaJugador entity);
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
