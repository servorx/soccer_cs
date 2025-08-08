using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace soccer_cs;
public class EquipoJugadorConfig : IEntityTypeConfiguration<EquipoJugador>
{
  public void Configure(EntityTypeBuilder<EquipoJugador> builder)
  {
    // definicion de la tabla
    builder.ToTable("equipo_jugador");

    // definicion de la llave primaria, en este caso es compuesta
    builder.HasKey(ej => new { ej.EquipoId, ej.JugadorId });

    // defincion de las columnas de la tabla
    builder.Property(ej => ej.FechaInicio).IsRequired().HasColumnType("DATE");
    builder.Property(ej => ej.FechaFin).IsRequired().HasColumnType("DATE");

    // definicion de las llaves FK
    // Equipos
    builder.HasOne(ej => ej.Equipo)
            .WithMany(e => e.EquipoJugadors)
            .HasForeignKey(ej => ej.EquipoId)
            .OnDelete(DeleteBehavior.Cascade);
    // Jugadores
    builder.HasOne(ej => ej.Jugador)
            .WithMany(j => j.EquipoJugadors)
            .HasForeignKey(ej => ej.JugadorId)
            .OnDelete(DeleteBehavior.Cascade);
  }
}