using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using soccer.modules.equipo.domain;
using soccer_cs.models;

namespace soccer_cs;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
  {
  }
  // declaracion de todos los dbset para las entidades del proyecto
  public DbSet<CuerpoMedico> CuerpoMedicos => Set<CuerpoMedico>();
  public DbSet<CuerpoTecnico> CuerpoTecnicos => Set<CuerpoTecnico>();
  public DbSet<Equipo> Equipos => Set<Equipo>();
  public DbSet<EquipoCuerpoMedico> EquiposCuerpoMedico => Set<EquipoCuerpoMedico>();
  public DbSet<EquipoCuerpoTecnico> EquiposCuerpoTecnico => Set<EquipoCuerpoTecnico>();
  public DbSet<EquipoJugador> EquiposJugadores => Set<EquipoJugador>();
  public DbSet<EstadisticaEquipo> EstadisticasEquipos => Set<EstadisticaEquipo>();
  public DbSet<EstadisticaJugador> EstadisticasJugadores => Set<EstadisticaJugador>();
  public DbSet<Jugador> Jugadores => Set<Jugador>();
  public DbSet<Persona> Personas => Set<Persona>();
  public DbSet<Torneo> Torneos => Set<Torneo>();
  public DbSet<TorneoEquipo> TorneosEquipos => Set<TorneoEquipo>();
  public DbSet<Transferencia> Transferencias => Set<Transferencia>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
  }
}