using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using soccer_cs.src.modules.equipo_jugador.domain.models;

namespace soccer_cs.src.shared.configurations;
public class EquipoJugadorConfig : IEntityTypeConfiguration<EquipoJugador>
{
  public void Configure(EntityTypeBuilder<EquipoJugador> builder)
  {
    // definicion de la tabla
    builder.ToTable("equipo_jugador");

    // definicion de la llave primaria, en este caso es compuesta
    builder.HasKey(ej => new { ej.IdEquipo, ej.IdJugador }); 

    // defincion de las columnas de la tabla
    builder.Property(ej => ej.FechaInicio).IsRequired().HasColumnType("DATE");
    builder.Property(ej => ej.FechaFin).IsRequired().HasColumnType("DATE");

    // definicion de las llaves FK
    // Equipos
    builder.HasOne(ej => ej.Equipo)
            .WithMany(e => e.EquipoJugadors)
            .HasForeignKey(ej => ej.IdEquipo)
            .OnDelete(DeleteBehavior.Cascade);
    // Jugadores
    builder.HasOne(ej => ej.Jugador)
            .WithMany(j => j.EquipoJugadors)
            .HasForeignKey(ej => ej.IdJugador)
            .OnDelete(DeleteBehavior.Cascade);
  }
}