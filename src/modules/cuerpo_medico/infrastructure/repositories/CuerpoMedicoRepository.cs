using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using soccer_cs.src.modules.cuerpo_medico.application.interfaces;
using soccer_cs.src.modules.cuerpo_medico.domain.models;
using soccer_cs.src.shared.context;

namespace soccer_cs.src.modules.cuerpo_medico.infrastructure.repositories;

public class CuerpoMedicoRepository : ICuerpoMedicoRepository
{
  // trae las dependencias de las configuraciones de la aplicacion para que el repositorio pueda trabajar con la base de datos
  private readonly AppDbContext _context;
  public CuerpoMedicoRepository(AppDbContext context) =>_context = context;    
  // se agrega pero luego toca guardar los cambios manuamente con el metodo SaveChanges
  public void Add(CuerpoMedico cuerpoMedico) => _context.CuerpoMedicos.Add(cuerpoMedico);
  public void Update(CuerpoMedico entity) => _context.SaveChanges();
  public void Remove(CuerpoMedico entity) => _context.CuerpoMedicos.Remove(entity);
  public async Task<IEnumerable<CuerpoMedico?>> GetAllAsync() => await _context.CuerpoMedicos.ToListAsync();
  public async Task<CuerpoMedico?> GetByIdAsync(int id) => await _context.CuerpoMedicos.FirstOrDefaultAsync(cm => cm.Id == id);
  public async Task<CuerpoMedico?> GetByNameAsync(string nombre) => await _context.CuerpoMedicos.FirstOrDefaultAsync(cm => cm.Persona.Nombre == nombre);
  public async Task SaveAsync() => await _context.SaveChangesAsync();
}
