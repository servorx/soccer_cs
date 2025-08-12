using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using soccer_cs.models;

namespace soccer_cs;

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
  // En el repositorio
  public async Task<IEnumerable<Transferencia?>> ObtenerTransferenciasPorEquipo(int idEquipo) 
      => await _context.Transferencias
                        .Where(t => t.EquipoOrigenId == idEquipo || t.EquipoDestinoId == idEquipo)
                        .ToListAsync();
  public async Task<IEnumerable<Transferencia?>> ObtenerTransferenciasPorJugador(int id_jugador) =>
      await _context.Transferencias
                          .Where(t => t.JugadorId == id_jugador)
                          .ToListAsync();

  public async Task SaveAsync() => await _context.SaveChangesAsync();
}
