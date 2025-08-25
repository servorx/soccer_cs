using soccer_cs.src.modules.persona.domain.models;

namespace soccer_cs.src.modules.persona.application.interfaces;
// este archivo como tal es la puerta de salida del dominio persona hacia el exterior, es decir, es la interfaz que se usa para interactuar con el dominio persona
// se usa para declarar metodos que se van a usar en PersonaRepository.cs y PersonaService.cs
public interface IPersonaRepository
{
  void Add(Persona persona);
  void Update(Persona entity);
  void Remove(Persona entity);
  Task<Persona?> GetByIdAsync(int id);
  Task<IEnumerable<Persona>> GetAllAsync();
  Task SaveAsync();
}
