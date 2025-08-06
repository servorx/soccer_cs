using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using soccer.modules.equipo.domain;
using soccer_cs.configurations;
using soccer_cs.models;

namespace soccer_cs;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
  {
  }
  // declaracion de todos los dbset para las entidades del proyecto
  // // revisar detalladamente si es con Set o con { get; set; }
  // en realidad es mas preferible trabajarlo con { get; set; }
  public DbSet<CuerpoMedico> CuerpoMedicos { get; set; }
  public DbSet<CuerpoTecnico> CuerpoTecnicos {get; set;}
  public DbSet<Equipo> Equipos {get; set;}
  public DbSet<EquipoJugador> EquiposJugadores {get; set;}
  public DbSet<EstadisticaEquipo> EstadisticasEquipos {get; set;}
  public DbSet<EstadisticaJugador> EstadisticasJugadores {get; set;}
  public DbSet<Jugador> Jugadores {get; set;}
  public DbSet<Persona> Personas {get; set;}
  public DbSet<Torneo> Torneos {get; set;}  
  public DbSet<TorneoEquipo> TorneosEquipos {get; set;}
  public DbSet<Transferencia> Transferencias {get; set;}

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    // con la parte de de las configuracions automaticas no es necesario que se declare cada una de las entidades
    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
  }
}