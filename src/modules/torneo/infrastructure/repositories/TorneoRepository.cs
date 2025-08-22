using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using soccer_cs.src.modules.cuerpo_medico.domain.models;
using soccer_cs.src.modules.torneo.application.interfaces;
using soccer_cs.src.modules.torneo.domain.models;
using soccer_cs.src.shared.context;

namespace soccer_cs.src.modules.torneo.infrastructure.repositories;
public class TorneoRepository : ITorneoRepository
{
  // trae las dependencias de las configuraciones de la aplicacion para que el repositorio pueda trabajar con la base de datos
  private readonly AppDbContext _context;
  public TorneoRepository(AppDbContext context) =>_context = context;    
  // se agrega pero luego toca guardar los cambios manuamente con el metodo SaveChanges
  public void Add(Torneo torneo) => _context.Torneos.Add(torneo);
  public void Update(Torneo entity) => _context.SaveChanges();
  public void Remove(Torneo entity) => _context.Torneos.Remove(entity);
  public async Task<IEnumerable<Torneo?>> GetAllAsync() => await _context.Torneos.ToListAsync();
  public async Task<Torneo?> GetByIdAsync(int id) => await _context.Torneos.FirstOrDefaultAsync(t => t.Id == id);
  public async Task<Torneo?> GetByNameAsync(string nombre) => await _context.Torneos.FirstOrDefaultAsync(t => t.Nombre == nombre);
  public async Task SaveAsync() => await _context.SaveChangesAsync();
}
