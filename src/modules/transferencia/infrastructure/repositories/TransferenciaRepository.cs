using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using soccer_cs.src.modules.domain.models;
using soccer_cs.src.modules.transferencia.application.interfaces;
using soccer_cs.src.shared.context;

namespace soccer_cs.src.modules.infrastructure.repositories;

public class TransferenciaRepository : ITransferenciaRepository
{
  // trae las dependencias de las configuraciones de la aplicacion para que el repositorio pueda trabajar con la base de datos
  private readonly AppDbContext _context;
  public TransferenciaRepository(AppDbContext context) =>_context = context;    
  // se agrega pero luego toca guardar los cambios manuamente con el metodo SaveChanges
  public void Add(Transferencia transferencia) => _context.Transferencias.Add(transferencia);
  public void Update(Transferencia entity) => _context.SaveChanges();
  public void Remove(Transferencia entity) => _context.Transferencias.Remove(entity);
  public async Task<IEnumerable<Transferencia?>> GetAllAsync() => await _context.Transferencias.ToListAsync();
  public async Task<Transferencia?> GetByIdAsync(int id) => await _context.Transferencias.FirstOrDefaultAsync(cm 
  => cm.Id == id);
  // el .cast se utiiliza para poder trabajar con los datos de la base de datos y que se pueda hacer de forma nula 
  public async Task<List<Transferencia?>> ObtenerTransferenciasPorJugador(int idJugador) 
      => (await _context.Transferencias
                        .Where(t => t.IdJugador == idJugador)
                        .ToListAsync())
        .Cast<Transferencia?>()
        .ToList();

  public async Task<List<Transferencia?>> ObtenerTransferenciasPorEquipo(int idEquipo) 
      => (await _context.Transferencias
                        .Where(t => t.IdEquipoOrigen == idEquipo || t.IdEquipoDestino == idEquipo)
                        .ToListAsync())
        .Cast<Transferencia?>()
        .ToList();
  public async Task SaveAsync() => await _context.SaveChangesAsync();
}
