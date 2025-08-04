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
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    // aca pueden haber configuraciones adicionales de entidades pero no se donde colocarlas 
    base.OnModelCreating(modelBuilder);
  }
  public DbSet<CuerpoMedico> CuerpoMedicos { get; set; }
  public DbSet<CuerpoTecnico> CuerpoTecnicos { get; set; }
  public DbSet<Equipo> Equipos { get; set; }
  public DbSet<EquipoCuerpoMedico> EquipoCuerpoMedicos { get; set; }
  public DbSet<EquipoCuerpoTecnico> EquipoCuerpoTecnicos { get; set; }
  public DbSet<EquipoJugador> EquipoJugadores { get; set; }
  public DbSet<EstadisticaEquipo> EstadisticaEquipos { get; set; }
  public DbSet<EstadisticaJugador> EstadisticaJugadores { get; set; }
  public DbSet<Jugador> Jugadores { get; set; }
  public DbSet<Persona> Personas { get; set; }
  public DbSet<Torneo> Torneos { get; set; }
  public DbSet<TorneoEquipo> TorneoEquipos { get; set; }
  public DbSet<Transferencia> Transferencias { get; set; }
}

