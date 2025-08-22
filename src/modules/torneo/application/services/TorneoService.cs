using soccer_cs.src.modules.torneo.application.interfaces;
using soccer_cs.src.modules.torneo.domain.models;
using soccer_cs.src.modules.torneo_equipo.domain.models;
using soccer_cs.src.modules.equipo.application.interfaces;

namespace soccer_cs.src.modules.torneo.application.services;

public class TorneoService : ITorneoService
{
  // ? revisar si todo esto esta bien
  // en esta parte de define la interfaz del repositorio que se va a utilizar a lo largo de la clase
  private readonly ITorneoRepository _torneoRepository;
  private readonly IEquipoRepository _equipoRepository;
  // estas son las funcionalidades basicas del crud con las cuales va a interactura el usuario y que se van a implementar en el menu de su respectiva entidad

  public TorneoService(ITorneoRepository torneoRepository) => _torneoRepository = torneoRepository;
  public async Task AgregarTorneoAsync(Torneo torneo)
  {
    // agrega y guarda los cambios al mismo tiempo
    _torneoRepository.Add(torneo);
    await _torneoRepository.SaveAsync();
  }
  public async Task ActualizarTorneoAsync(int id, Torneo torneo)
  {
    var existingTorneo = await _torneoRepository.GetByIdAsync(id);
    if (existingTorneo != null)
    {
      existingTorneo.Nombre = torneo.Nombre;
      existingTorneo.Id = torneo.Id;
      _torneoRepository.Update(existingTorneo);
      await _torneoRepository.SaveAsync();
    }
  }
  public async Task EliminarTorneoAsync(int id)
  {
    var torneo = await _torneoRepository.GetByIdAsync(id);
    if (torneo != null)
    {
      _torneoRepository.Remove(torneo);
      await _torneoRepository.SaveAsync();
    }
  }
  // estas son las partes de las consultas trabajandolas con LINQ
  public async Task<IEnumerable<Torneo?>> MostrarTorneosAsync() => await _torneoRepository.GetAllAsync();
  public async Task<Torneo?> ObtenerTorneoPorIdAsync(int id) => await _torneoRepository.GetByIdAsync(id);
  public async Task<Torneo?> ObtenerTorneoPorNombreAsync(string nombre) => await _torneoRepository.GetByNameAsync(nombre);
  public async Task RegistrarEquipoATorneoAsync(int id_torneo, int id_equipo)
  {
    var torneo = await _torneoRepository.GetByIdAsync(id_torneo);
    var equipo = await _equipoRepository.GetByIdAsync(id_equipo);
    if (torneo is null)
    {
      throw new InvalidOperationException($"No se encontró Torneo con ID {id_torneo}");
    }
    if (equipo is null)
    {
      throw new InvalidOperationException($"No se encontró Equipo con ID {id_equipo}");
    }
    torneo.TorneosEquipos.Add(new TorneoEquipo(id_torneo, id_equipo));
    _torneoRepository.Update(torneo);
  }
  public async Task EliminarEquipoATorneoAsync(int id_torneo, int id_equipo)
  {
    var torneo = await _torneoRepository.GetByIdAsync(id_torneo);
    var equipo = await _equipoRepository.GetByIdAsync(id_equipo);
    if (torneo is null)
    {
      throw new InvalidOperationException($"No se encontró Torneo con ID {id_torneo}");
    }
    if (equipo is null)
    {
      throw new InvalidOperationException($"No se encontró Equipo con ID {id_equipo}");
    }
    torneo.TorneosEquipos.Remove(new TorneoEquipo(id_torneo, id_equipo));
    _torneoRepository.Update(torneo);
  }
}

