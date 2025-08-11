

namespace soccer_cs.application.services;

public class PersonaService : IPersonaService
{
  // ? revisar si todo esto esta bien
  // en esta parte de define la interfaz del repositorio que se va a utilizar a lo largo de la clase
  private readonly IPersonaRepository _personaRepository;
  // estas son las funcionalidades basicas del crud con las cuales va a interactura el usuario y que se van a implementar en el menu de su respectiva entidad
  public PersonaService(IPersonaRepository personaRepository) => _personaRepository = personaRepository;
  public async Task AgregarPersonaAsync(Persona persona)
  {
    _personaRepository.Add(persona);
    await _personaRepository.SaveAsync();
  }
}
