using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using soccer_cs.src.modules.estadistica_jugador.application.interfaces;
using soccer_cs.src.modules.estadistica_jugador.domain.models;
using soccer_cs.src.shared.context;

namespace soccer_cs.src.modules.estadistica_jugador.infrastructure.repositories;
public class EstadisticaJugadorRepository : IEstadisticaJugadorRepository   
{
  // trae las dependencias de las configuraciones de la aplicacion para que el repositorio pueda trabajar con la base de datos
  private readonly AppDbContext _context;
  public EstadisticaJugadorRepository(AppDbContext context) =>_context = context;
  // se agrega pero luego toca guardar los cambios manuamente con el metodo SaveChanges
  // parte de las crud basico
  public void Add(EstadisticaJugador estadisticaJugador) => _context.EstadisticasJugadores.Add(estadisticaJugador);
  public void Update(EstadisticaJugador estadisticaJugador) => _context.SaveChanges();
  public void Remove(EstadisticaJugador estadisticaJugador) => _context.EstadisticasJugadores.Remove(estadisticaJugador);
  // parte de las consultas sencillas
  public async Task<IEnumerable<EstadisticaJugador?>> GetAllAsync() => await _context.EstadisticasJugadores.ToListAsync();
  public async Task<EstadisticaJugador?> GetByIdAsync(int id) => await _context.EstadisticasJugadores.FirstOrDefaultAsync(cm => cm.Id == id);
  public async Task<EstadisticaJugador?> GetByJugadorNombreAsync(string nombre) =>
      await _context.EstadisticasJugadores.Include(e => e.Jugador)
          .FirstOrDefaultAsync(e => e.Jugador!.Persona.Nombre == nombre);
  public async Task<IEnumerable<EstadisticaJugador?>> GetTopGoleadoresAsync() =>
        await _context.EstadisticasJugadores.OrderByDescending(e => e.Goles).ToListAsync();

    public async Task<IEnumerable<EstadisticaJugador?>> GetTopPartidosAsync() =>
        await _context.EstadisticasJugadores.OrderByDescending(e => e.PartidosJugados).ToListAsync();

    public async Task<IEnumerable<EstadisticaJugador?>> GetMasAltosAsync() =>
        await _context.EstadisticasJugadores.OrderByDescending(e => e.Estatura).ToListAsync();

    public async Task<IEnumerable<EstadisticaJugador?>> GetMenosPesadosAsync() =>
        await _context.EstadisticasJugadores.OrderBy(e => e.Peso).ToListAsync();

    public async Task<IEnumerable<EstadisticaJugador?>> GetMasTarjetasAmarillasAsync() =>
        await _context.EstadisticasJugadores.OrderByDescending(e => e.TarjetasAmarillas).ToListAsync();

    public async Task<IEnumerable<EstadisticaJugador?>> GetMenosTarjetasRojasAsync() =>
        await _context.EstadisticasJugadores.OrderBy(e => e.TarjetasRojas).ToListAsync();

    public async Task<IEnumerable<EstadisticaJugador?>> GetEdadMayorPromedioEquipoAsync(int equipoId) =>
        await _context.EstadisticasJugadores.Where(e => e.Jugador.EquipoJugadors.FirstOrDefault(ej => ej.IdEquipo == equipoId).IdEquipo == equipoId) 
            .OrderByDescending(e => e.Jugador.Persona.Edad).ToListAsync();

  public async Task SaveAsync() => await _context.SaveChangesAsync();
}
