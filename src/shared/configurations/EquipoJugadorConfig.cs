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
    builder.ToTable("equipo_jugador");

    builder.HasKey(ej => new { ej.EquipoId, ej.JugadorId });

    builder.Property(ej => ej.FechaIngreso)
            .IsRequired();

    builder.HasOne(ej => ej.Equipo)
            .WithMany(e => e.EquipoJugador)
            .HasForeignKey(ej => ej.EquipoId)
            .OnDelete(DeleteBehavior.Cascade);

    builder.HasOne(ej => ej.Jugador)
            .WithMany(j => j.EquipoJugador)
            .HasForeignKey(ej => ej.JugadorId)
            .OnDelete(DeleteBehavior.Cascade);
  }
}