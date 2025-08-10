using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using soccer.modules.equipo.domain;
using soccer_cs.models;

namespace soccer_cs;

public class EquipoRepository : IEquipoRepository
{
  private readonly AppDbContext _context;
  public EquipoRepository(AppDbContext context) => _context = context;

  public void Add(Equipo entity) => _context.Equipos.Add(entity);

  public void Update(Equipo entity) => _context.Entry(entity).State = EntityState.Modified;

  public void Remove(Equipo entity) => _context.Equipos.Remove(entity);

  public async Task<IEnumerable<Equipo>> GetAllAsync() => await _context.Equipos.ToListAsync();

  public async Task<Equipo?> GetByIdAsync(int id)
  { 
    return await _context.Equipos
            .Include(e => e.CuerpoMedicos)
            .Include(e => e.CuerpoTecnicos)
            .FirstOrDefaultAsync(e => e.Id == id);
  }
  public async Task<Equipo?> GetByNameAsync(string nombre) => await _context.Equipos.FirstOrDefaultAsync(e => e.Nombre == nombre);
  public async Task<IEnumerable<Jugador>> GetJugadoresByEquipoIdAsync(int id_equipo)
  {
    return await _context.Equipos
        .Where(e => e.Id == id_equipo)
        .SelectMany(e => e.EquipoJugadors.Select(ej => ej.Jugador))
        .ToListAsync();
  }

  public async Task SaveAsync() => await _context.SaveChangesAsync();
}
