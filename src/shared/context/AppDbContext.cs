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
  // TODO: revisar detalladamente si es con Set o con { get; set; }
  public DbSet<CuerpoMedico> CuerpoMedicos => Set<CuerpoMedico>();
  public DbSet<CuerpoTecnico> CuerpoTecnicos => Set<CuerpoTecnico>();
  public DbSet<Equipo> Equipos => Set<Equipo>();
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
    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    // configuracion TPT para tener una tabla por tipo de clave 
    modelBuilder.Entity<Jugador>().ToTable("jugadores");
    modelBuilder.Entity<CuerpoMedico>().ToTable("cuerpo_medico");
    modelBuilder.Entity<CuerpoTecnico>().ToTable("cuerpo_tecnico");
    modelBuilder.Entity<Persona>().ToTable("personas"); 
    modelBuilder.Entity<Transferencia>().ToTable("transferencias"); 
  }
}