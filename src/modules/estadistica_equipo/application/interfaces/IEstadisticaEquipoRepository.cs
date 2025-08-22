using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soccer_cs.src.modules.estadistica_equipo.domain.models;

namespace soccer_cs.src.modules.estadistica_equipo.application.interfaces;
public interface IEstadisticaEquipoRepository
{
  void Add(EstadisticaEquipo entity);
  void Update(EstadisticaEquipo entity);
  void Remove(EstadisticaEquipo entity);
  Task<IEnumerable<EstadisticaEquipo?>> GetAllAsync();
  Task<EstadisticaEquipo?> GetByIdAsync(int id);
  Task SaveAsync();
}
