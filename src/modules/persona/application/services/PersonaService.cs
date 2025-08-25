

using soccer_cs.src.modules.persona.application.interfaces;
using soccer_cs.src.modules.persona.domain.models;

namespace soccer_cs.src.modules.persona.application.services;

public class PersonaService : IPersonaService
{
  // ? revisar si todo esto esta bien
  // en esta parte de define la interfaz del repositorio que se va a utilizar a lo largo de la clase
  private readonly IPersonaRepository _personaRepository;
  // estas son las funcionalidades basicas del crud con las cuales va a interactura el usuario y que se van a implementar en el menu de su respectiva entidad
  public PersonaService(IPersonaRepository personaRepository) => _personaRepository = personaRepository;
  public async Task<Persona> AgregarPersonaAsync(Persona persona)
  {
    try
    {
      _personaRepository.Add(persona);
      await _personaRepository.SaveAsync();
      Console.WriteLine("✅ Persona creada con éxito");
      return persona; // aquí EF ya habrá asignado el Id
    }
    catch (Exception ex)
    {
      Console.WriteLine($"❌ Error al crear la persona: {ex.Message}");
      if (ex.InnerException != null)
        Console.WriteLine($"🔎 InnerException: {ex.InnerException.Message}");
      throw; // importante: vuelve a lanzar para que lo capture tu menú
    }
  }
  public async Task ActualizarPersonaAsync(int id, Persona persona)
  {
    var existingPersona = await _personaRepository.GetByIdAsync(id);
    if (existingPersona != null)
    {
      existingPersona.Nombre = persona.Nombre;
      existingPersona.Apellido = persona.Apellido;
      existingPersona.Edad = persona.Edad;
      existingPersona.Nacionalidad = persona.Nacionalidad;
      existingPersona.DocumentoIdentidad = persona.DocumentoIdentidad;
      existingPersona.Genero = persona.Genero;
      _personaRepository.Update(existingPersona);
      await _personaRepository.SaveAsync();
    }
  }
  public async Task EliminarPersonaAsync(int id)
  {
    var persona = await _personaRepository.GetByIdAsync(id);
    if (persona != null)
    {
      _personaRepository.Remove(persona);
      await _personaRepository.SaveAsync();
    }
  }
  public async Task<Persona?> ObtenerPersonaPorIdAsync(int id) => await _personaRepository.GetByIdAsync(id);
  public async Task<IEnumerable<Persona>> GetAllPersonasAsync() => await _personaRepository.GetAllAsync();
}
