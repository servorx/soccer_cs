using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace soccer_cs;

public class CuerpoMedicoRepository : ICuerpoMedicoRepository
{
  private readonly AppDbContext _context;
  public CuerpoMedicoRepository(AppDbContext context)
    {
      _context = context;
    }       
  public void Add(CuerpoMedico cuerpoMedico)
  {
      _context.CuerpoMedicos.Add(cuerpoMedico);
  }

  public async Task<IEnumerable<CuerpoMedico?>> GetAllAsync() => await _context.CuerpoMedicos.ToListAsync();

  public async Task<CuerpoMedico?> GetByIdAsync(int id)
  {
      return await _context.CuerpoMedicos.FirstOrDefaultAsync(cm => cm.Id == id);
  }

  public void Remove(CuerpoMedico entity) => _context.CuerpoMedicos.Remove(entity);

  public async Task SaveAsync() => await _context.SaveChangesAsync();

  public void Update(CuerpoMedico entity) => _context.SaveChanges();
}
