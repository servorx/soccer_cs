using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using soccer_cs.src.modules.jugador.domain.models;

namespace soccer_cs.src.shared.configurations;
public class JugadorConfig : IEntityTypeConfiguration<Jugador>
{
  public void Configure(EntityTypeBuilder<Jugador> builder)
  {
    // definir nombre de la tabla
    builder.ToTable("jugadores");

    // definir llave primaria
    builder.HasKey(j => j.Id);

    // definir columnas 
    builder.Property(j => j.Posicion).HasMaxLength(40).IsRequired();
    builder.Property(j => j.NumeroDorsal).IsRequired();
    builder.Property(j => j.PieHabil).HasMaxLength(15).IsRequired();
    builder.Property(j => j.ValorMercado).IsRequired();
    builder.Property(j => j.NumeroDorsal).IsRequired();

    // Relación uno a uno con Persona
    builder.HasOne(j => j.Persona)
        .WithOne(p => p.Jugador)
        .HasForeignKey<Jugador>(j => j.IdPersona);

    // Relación muchos a muchos (jugador - equipo) a través de EquipoJugador
    builder.HasMany(j => j.EquipoJugadors)
        .WithOne(ej => ej.Jugador)
        .HasForeignKey(ej => ej.IdJugador);
}
}
