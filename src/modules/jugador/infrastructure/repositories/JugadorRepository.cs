using Microsoft.EntityFrameworkCore;
using soccer_cs.src.modules.cuerpo_medico.domain.models;
using soccer_cs.src.modules.jugador.application.interfaces;
using soccer_cs.src.modules.jugador.domain.models;
using soccer_cs.src.shared.context;

namespace soccer_cs.src.modules.jugador.infrastructure.repositories;
public class JugadorRepository : IJugadorRepository
{
  // trae las dependencias de las configuraciones de la aplicacion para que el repositorio pueda trabajar con la base de datos
  private readonly AppDbContext _context;
  public JugadorRepository(AppDbContext context) =>_context = context;    
  // se agrega pero luego toca guardar los cambios manuamente con el metodo SaveChanges
  public void Add(Jugador jugador) => _context.Jugadores.Add(jugador);
  public void Update(Jugador entity) => _context.SaveChanges();
  public void Remove(Jugador entity) => _context.Jugadores.Remove(entity);
  public async Task<IEnumerable<Jugador?>> GetAllAsync() => await _context.Jugadores.ToListAsync();
  public async Task<Jugador?> GetByIdAsync(int id) => await _context.Jugadores.FirstOrDefaultAsync(j => j.Id == id);
  public async Task<Jugador?> GetByNameAsync(string nombre) => await _context.Jugadores.FirstOrDefaultAsync(j => j.Persona.Nombre == nombre);
  public async Task SaveAsync() => await _context.SaveChangesAsync();
}
