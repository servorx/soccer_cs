using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using soccer_cs.src.modules.equipo_jugador.application.interfaces;
using soccer_cs.src.modules.equipo_jugador.domain.models;
using soccer_cs.src.modules.jugador.application.interfaces;
using soccer_cs.src.shared.context;

namespace soccer_cs.src.modules.equipo_jugador.infrastructure.repositories;

public class EquipoJugadorRepository : IEquipoJugadorRepository
{
  private readonly AppDbContext _context;
  public EquipoJugadorRepository(AppDbContext context) =>_context = context;
  public void Add(EquipoJugador equipoJugador) => _context.EquiposJugadores.Add(equipoJugador);
  public void Update(EquipoJugador entity) => _context.SaveChanges();
  public void Remove(EquipoJugador entity) => _context.EquiposJugadores.Remove(entity);
  public async Task<IEnumerable<EquipoJugador?>> GetAllAsync() => await _context.EquiposJugadores.ToListAsync();
  // no se necesitan porque ya existen en otros modulos 
  public async Task<EquipoJugador?> GetByIdAsync(int id) => await _context.EquiposJugadores.FirstOrDefaultAsync(e => e.IdEquipo == id || e.IdJugador == id);
  // public async Task<EquipoJugador?> GetByEquipoIdAsync(int id) => await _context.EquiposJugadores.FirstOrDefaultAsync(e => e.IdEquipo == id);
  // public async Task<EquipoJugador?> GetByEquipoNameAsync(string nombre) => await _context.EquiposJugadores.FirstOrDefaultAsync(e => e.Equipo.Nombre == nombre);
  // public async Task<EquipoJugador?> GetByJugadorNameAsync(string nombre) => await _context.EquiposJugadores.FirstOrDefaultAsync(e => e.Jugador.Persona.Nombre == nombre);
  public async Task SaveAsync() => await _context.SaveChangesAsync();
  
}
