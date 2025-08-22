using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using soccer_cs.src.modules.cuerpo_tecnico.application.interfaces;
using soccer_cs.src.modules.cuerpo_tecnico.domain.models;
using soccer_cs.src.shared.context;

namespace soccer_cs.src.modules.cuerpo_tecnico.infrastructure.repositories;
public class CuerpoTecnicoRepository : ICuerpoTecnicoRepository
{
  // trae las dependencias de las configuraciones de la aplicacion para que el repositorio pueda trabajar con la base de datos
  private readonly AppDbContext _context;
  public CuerpoTecnicoRepository(AppDbContext context) =>_context = context;    
  // se agrega pero luego toca guardar los cambios manuamente con el metodo SaveChanges
  public void Add(CuerpoTecnico cuerpoTecnico) => _context.CuerpoTecnicos.Add(cuerpoTecnico);
  public void Update(CuerpoTecnico entity) => _context.SaveChanges();
  public void Remove(CuerpoTecnico entity) => _context.CuerpoTecnicos.Remove(entity);
  public async Task<IEnumerable<CuerpoTecnico?>> GetAllAsync() => await _context.CuerpoTecnicos.ToListAsync();
  public async Task<CuerpoTecnico?> GetByIdAsync(int id) => await _context.CuerpoTecnicos.FirstOrDefaultAsync(ct => ct.Id == id);
  public async Task<CuerpoTecnico?> GetByNameAsync(string nombre) => await _context.CuerpoTecnicos.FirstOrDefaultAsync(ct => ct.Persona.Nombre == nombre);
  public async Task SaveAsync() => await _context.SaveChangesAsync();
}
