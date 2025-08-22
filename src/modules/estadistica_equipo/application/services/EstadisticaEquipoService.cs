
using soccer_cs.src.modules.cuerpo_medico.application.interfaces;
using soccer_cs.src.modules.estadistica_equipo.application.interfaces;
using soccer_cs.src.modules.estadistica_equipo.domain.models;
using soccer_cs.src.modules.estadistica_equipo.infrastructure.repositories;
using soccer_cs.src.shared.context;
using soccer_cs.src.shared.utils;

namespace soccer_cs.src.modules.estadistica_equipo.application.services;

public class EstadisticaEquipoService : IEstadisticaEquipoService
{
  private readonly EstadisticaEquipoRepository _repo;
  public EstadisticaEquipoService(EstadisticaEquipoRepository repo)
  {
    _repo = repo;
  }
  public async Task AgregarEstadisticaEquipoAsync(EstadisticaEquipo estadisticaEquipo)
  {
    _repo.Add(estadisticaEquipo);
    await _repo.SaveAsync();
  }
  public async Task ActualizarEstadisticaEquipoAsync(int id, EstadisticaEquipo estadisticaEquipo)
  {
    var existingEstadisticaEquipo = await _repo.GetByIdAsync(id);
    if (existingEstadisticaEquipo != null)
    {
      existingEstadisticaEquipo.PartidosGanados = estadisticaEquipo.PartidosGanados;
      existingEstadisticaEquipo.PartidosEmpatados = estadisticaEquipo.PartidosEmpatados;
      existingEstadisticaEquipo.PartidosPerdidos = estadisticaEquipo.PartidosPerdidos;
      existingEstadisticaEquipo.GolesAFavor = estadisticaEquipo.GolesAFavor;
      existingEstadisticaEquipo.GolesEnContra = estadisticaEquipo.GolesEnContra;
      _repo.Update(existingEstadisticaEquipo);
      await _repo.SaveAsync();
    }
  }
  public async Task EliminarEstadisticaEquipoAsync(int id)
  {
    var estadisticaEquipo = await _repo.GetByIdAsync(id);
    if (estadisticaEquipo != null)
    {
      _repo.Remove(estadisticaEquipo);
      await _repo.SaveAsync();
    }
  }
  // estas son las partes de las consultas trabajandolas con LINQ
  public async Task<IEnumerable<EstadisticaEquipo?>> MostrarEstadisticaEquiposAsync() => await _repo.GetAllAsync();
  public async Task<EstadisticaEquipo?> ObtenerEstadisticaEquipoPorIdAsync(int id) => await _repo.GetByIdAsync(id); 
}
