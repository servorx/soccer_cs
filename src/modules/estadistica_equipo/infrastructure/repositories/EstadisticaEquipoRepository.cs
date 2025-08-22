using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using soccer_cs.src.modules.estadistica_equipo.application.interfaces;
using soccer_cs.src.modules.estadistica_equipo.domain.models;
using soccer_cs.src.shared.context;

namespace soccer_cs.src.modules.estadistica_equipo.infrastructure.repositories;

public class EstadisticaEquipoRepository : IEstadisticaEquipoRepository
{
  private readonly AppDbContext _context;
  public EstadisticaEquipoRepository(AppDbContext context) =>_context = context;    
  // se agrega pero luego toca guardar los cambios manuamente con el metodo SaveChanges
  public void Add(EstadisticaEquipo estadisticaEquipo) => _context.EstadisticasEquipos.Add(estadisticaEquipo);
  public void Update(EstadisticaEquipo entity) => _context.SaveChanges();
  public void Remove(EstadisticaEquipo entity) => _context.EstadisticasEquipos.Remove(entity);
  public async Task<IEnumerable<EstadisticaEquipo?>> GetAllAsync() => await _context.EstadisticasEquipos.ToListAsync();
  public async Task<EstadisticaEquipo?> GetByIdAsync(int id) => await _context.EstadisticasEquipos.FirstOrDefaultAsync(et => et.Id == id);
  public async Task SaveAsync() => await _context.SaveChangesAsync();
}
