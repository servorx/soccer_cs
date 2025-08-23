using soccer_cs.src.modules.cuerpo_medico.application.interfaces;
using soccer_cs.src.modules.cuerpo_medico.domain.models;
using soccer_cs.src.modules.equipo.application.interfaces;
using soccer_cs.src.modules.equipo_jugador.domain.models;
using soccer_cs.src.modules.jugador.application.interfaces;
using soccer_cs.src.modules.jugador.domain.models;
using soccer_cs.src.shared.utils;

namespace soccer_cs.src.modules.jugador.application.services;

public class JugadorService : IJugadorService
{
  // ? revisar si todo esto esta bien
  // en esta parte de define la interfaz del repositorio que se va a utilizar a lo largo de la clase
  private readonly Validaciones validate_data = new Validaciones();
  private readonly IJugadorRepository _jugadorRepository;
  private readonly IEquipoRepository _equipoRepository;
  // estas son las funcionalidades basicas del crud con las cuales va a interactura el usuario y que se van a implementar en el menu de su respectiva entidad
  public JugadorService(IJugadorRepository jugadorRepository) => _jugadorRepository = jugadorRepository;
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
  public async Task<Jugador?> RegistrarJugadorAEquipoAsync(int id_jugador, int id_equipo)
  {
    Console.Write("ingrese la fecha final del contrato del jugador: ");
    var fecha_fin = validate_data.ValidarFecha(Console.ReadLine());

    var jugador = await _jugadorRepository.GetByIdAsync(id_jugador);
    if (jugador == null) return null;

    var equipo = await _equipoRepository.GetByIdAsync(id_equipo);
    if (equipo == null) return null;

    // Crear el objeto de relación intermedia
    var equipoJugador = new EquipoJugador
    {
        IdJugador = id_jugador,
        IdEquipo = id_equipo,
        FechaInicio = DateTime.Now, // aquí puedes poner lógica propia
        FechaFin = fecha_fin,            // si quieres permitir nulo en
        Jugador = jugador,
        Equipo = equipo
    };

    // Agregarlo a la colección
    jugador.EquipoJugadors.Add(equipoJugador);

    _jugadorRepository.Update(jugador);
    await _jugadorRepository.SaveAsync();

    return jugador;
  }

  public async Task<Jugador?> EliminarJugadorAEquipoAsync(int id_jugador, int id_equipo)
  {
    var jugador = await _jugadorRepository.GetByIdAsync(id_jugador);
    if (jugador == null) return null;
    var equipo = await _equipoRepository.GetByIdAsync(id_equipo);
    if (equipo == null) return null;
    jugador.EquipoJugadors = null;
    _jugadorRepository.Update(jugador);
    await _jugadorRepository.SaveAsync();
    return jugador;
  }
}
