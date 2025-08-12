using soccer_cs.infrastructure.utils;
using soccer_cs.models;

namespace soccer_cs;

public class EstadisticaJugadorService : IEstadisticaJugadorService
{
  // ? revisar si todo esto esta bien
  // en esta parte de define la interfaz del repositorio que se va a utilizar a lo largo de la clase
  private readonly IEstadisticaJugadorRepository _repo;
  public EstadisticaJugadorService(IEstadisticaJugadorRepository repo) => _repo = repo;
  public async Task CrearEstadisticaAsync(EstadisticaJugador estadistica)
  {
    _repo.Add(estadistica);
    await _repo.SaveAsync();
  }
  public async Task ActualizarEstadisticaAsync(int id, EstadisticaJugador estadistica)
  {
    var existente = await _repo.GetByIdAsync(id);
    if (existente != null)
    {
      existente.Goles = estadistica.Goles;
      existente.PartidosJugados = estadistica.PartidosJugados;
      existente.TarjetasAmarillas = estadistica.TarjetasAmarillas;
      existente.TarjetasRojas = estadistica.TarjetasRojas;
      existente.Estatura = estadistica.Estatura;
      existente.Peso = estadistica.Peso;
      existente.Edad = estadistica.Edad;
      _repo.Update(existente);
      await _repo.SaveAsync();
    }
  }

  public async Task EliminarEstadisticaAsync(int id)
  {
      var existente = await _repo.GetByIdAsync(id);
      if (existente != null)
      {
          _repo.Remove(existente);
          await _repo.SaveAsync();
      }
  }

  public async Task<IEnumerable<EstadisticaJugador>> VerTodasAsync() => await _repo.GetAllAsync();
  public async Task<EstadisticaJugador?> VerPorIdAsync(int id) => await _repo.GetByIdAsync(id);
  public async Task<EstadisticaJugador?> VerPorNombreAsync(string nombre) => await _repo.GetByJugadorNombreAsync(nombre);

  public async Task<IEnumerable<EstadisticaJugador>> JugadoresConMasGolesAsync() => await _repo.GetTopGoleadoresAsync();
  public async Task<IEnumerable<EstadisticaJugador>> JugadoresConMasPartidosAsync() => await _repo.GetTopPartidosAsync();
  public async Task<IEnumerable<EstadisticaJugador>> JugadoresMasAltosAsync() => await _repo.GetMasAltosAsync();
  public async Task<IEnumerable<EstadisticaJugador>> JugadoresMenosPesadosAsync() => await _repo.GetMenosPesadosAsync();
  public async Task<IEnumerable<EstadisticaJugador>> JugadoresConMasTarjetasAmarillasAsync() => await _repo.GetMasTarjetasAmarillasAsync();
  public async Task<IEnumerable<EstadisticaJugador>> JugadoresConMenosTarjetasRojasAsync() => await _repo.GetMenosTarjetasRojasAsync();
  public async Task<IEnumerable<EstadisticaJugador>> JugadoresEdadMayorPromedioEquipoAsync(int equipoId) => await _repo.GetEdadMayorPromedioEquipoAsync(equipoId);
  }
}
