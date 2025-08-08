using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using soccer_cs.models;

namespace soccer_cs;
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
    //TODO: tengo que revisar si colocar el id de persoan a pesar de trabajar con herencia, lo mismo revisarla con el id del equipo a pesar de tener la tabla intermedia equipo_jugador
    builder.HasOne(j => j.Jugador)
        .WithMany(ej => ej.EstadisticaJugadors)
        .HasForeignKey(j => j.JugadorId)
        .OnDelete(DeleteBehavior.Cascade);
  }
}
