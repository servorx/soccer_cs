
using Microsoft.EntityFrameworkCore;
using soccer_cs.src.modules.persona.application.interfaces;
using soccer_cs.src.modules.persona.domain.models;
using soccer_cs.src.shared.context;

namespace soccer_cs.src.modules.persona.infrastructure.repositories;
public class PersonaRepository : IPersonaRepository
{
  // trae las dependencias de las configuraciones de la aplicacion para que el repositorio pueda trabajar con la base de datos
  private readonly AppDbContext _context;
  public PersonaRepository(AppDbContext context) =>_context = context;    
  // se agrega pero luego toca guardar los cambios manuamente con el metodo SaveChanges
  public void Add(Persona persona) => _context.Personas.Add(persona);
  public void Update(Persona entity) => _context.Personas.Update(entity);
  public void Remove(Persona entity) => _context.Personas.Remove(entity);
  public async Task<Persona?> GetByIdAsync(int id) => await _context.Personas.FirstOrDefaultAsync(p => p.Id == id);
  public async Task<IEnumerable<Persona>> GetAllAsync() => await _context.Personas.ToListAsync();
  public async Task SaveAsync() => await _context.SaveChangesAsync();
}
