

namespace soccer_cs.application.services;
public class PersonaService : IPersonaService
{
  private readonly IPersonaRepository _repo;

  public PersonaService(IPersonaRepository repo)
  {
    _repo = repo;
  }

  public void CrearPersona(Persona persona) => _repo.CrearPersona(persona);
  public Persona? BuscarPorId(int id) => _repo.ObtenerPorId(id);
  public IEnumerable<Persona> ListarPersonas() => _repo.ObtenerTodas();
  public void ActualizarPersona(Persona persona) => _repo.ActualizarPersona(persona);
  public void EliminarPersona(int id) => _repo.EliminarPersona(id);
}
