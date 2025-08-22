
using Microsoft.EntityFrameworkCore;
using soccer.src.modules.equipo.domain.models;
using soccer_cs.src.modules.cuerpo_medico.domain.models;
using soccer_cs.src.modules.cuerpo_tecnico.domain.models;
using soccer_cs.src.modules.domain.models;
using soccer_cs.src.modules.equipo_jugador.domain.models;
using soccer_cs.src.modules.estadistica_equipo.domain.models;
using soccer_cs.src.modules.estadistica_jugador.domain.models;
using soccer_cs.src.modules.jugador.domain.models;
using soccer_cs.src.modules.persona.domain.models;
using soccer_cs.src.modules.torneo.domain.models;
using soccer_cs.src.modules.torneo_equipo.domain.models;

namespace soccer_cs.src.shared.context;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
  // declaracion de todos los dbset para las entidades del proyecto
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