

namespace soccer_cs.application.services;
public class PersonaService : IPersonaService
{
  private readonly IPersonaRepository _repo;

  public PersonaService(IPersonaRepository repo)
  {
    _repo = repo;
  }

  public void RegistrarPersona(Persona persona)
  {
    _repo.AgregarPersona(persona);
  }

  public Persona? BuscarPersona(int id)
  {
    return _repo.ObtenerPorId(id);
  }

  public List<Persona> ListarPersonas()
  {
    return _repo.ObtenerTodas();
  }

  public void EditarPersona(Persona persona)
  {
    _repo.ActualizarPersona(persona);
  }

  public void EliminarPersona(int id)
  {
    var persona = _repo.ObtenerPorId(id);
    if (persona != null)
      _repo.EliminarPersona(persona);
  }
}
