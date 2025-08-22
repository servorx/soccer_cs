using soccer_cs.src.modules.cuerpo_medico.application.interfaces;
using soccer_cs.src.modules.cuerpo_medico.domain.models;
using soccer_cs.src.modules.jugador.application.interfaces;
using soccer_cs.src.modules.jugador.domain.models;

namespace soccer_cs.src.modules.jugador.application.services;

public class JugadorService : IJugadorService
{
  // ? revisar si todo esto esta bien
  // en esta parte de define la interfaz del repositorio que se va a utilizar a lo largo de la clase
  private readonly IJugadorRepository _jugadorRepository;
  // estas son las funcionalidades basicas del crud con las cuales va a interactura el usuario y que se van a implementar en el menu de su respectiva entidad
  public JugadorService(IJugadorRepository jugadorRepository) =>_jugadorRepository = jugadorRepository;
  public async Task AgregarJugadorAsync(Jugador jugador)
  {
    _jugadorRepository.Add(jugador);
    await _jugadorRepository.SaveAsync();
  }
  public async Task ActualizarJugadorAsync(int id, Jugador jugador)
  {
    var existingJugador = await _jugadorRepository.GetByIdAsync(id);
    if (existingJugador != null)
    {
      existingJugador.Persona.Nombre = jugador.Persona.Nombre;
      existingJugador.Id = jugador.Id;
      _jugadorRepository.Update(existingJugador);
      await _jugadorRepository.SaveAsync();
    }
  }
  public async Task EliminarJugadorAsync(int id)
  {
    var jugador = await _jugadorRepository.GetByIdAsync(id);
    if (jugador != null)
    {
      _jugadorRepository.Remove(jugador);
      await _jugadorRepository.SaveAsync();
    }
  }
  // estas son las partes de las consultas trabajandolas con LINQ
  public async Task<IEnumerable<Jugador?>> MostrarJugadorsAsync() => await _jugadorRepository.GetAllAsync();
  public async Task<Jugador?> ObtenerJugadorPorIdAsync(int id) => await _jugadorRepository.GetByIdAsync(id);
  public async Task<Jugador?> ObtenerJugadorPorNombreAsync(string nombre) => await _jugadorRepository.GetByNameAsync(nombre); 
}
