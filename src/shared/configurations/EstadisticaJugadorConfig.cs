using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Org.BouncyCastle.Asn1.Crmf;
using soccer_cs.src.modules.estadistica_jugador.domain.models;

namespace soccer_cs.src.shared.configurations;
public class EstadisticaJugadorConfig : IEntityTypeConfiguration<EstadisticaJugador>
{
  public void Configure(EntityTypeBuilder<EstadisticaJugador> builder)
  {
    builder.ToTable("estadistica_jugador");

    // clave autoincrement
    builder.HasKey(ej => ej.Id);
    builder.Property(ej => ej.Id).ValueGeneratedOnAdd();

    // definir las columnas de la tabla
    builder.Property(ej => ej.IdJugador).IsRequired();
    builder.Property(ej => ej.Goles).IsRequired();
    builder.Property(ej => ej.Asistencias).IsRequired();
    builder.Property(ej => ej.PartidosJugados).IsRequired();
    builder.Property(ej => ej.Estatura).IsRequired().HasColumnType("DECIMAL(4,2)");
    builder.Property(ej => ej.Peso).IsRequired().HasColumnType("DECIMAL(5,2)");
    builder.Property(ej => ej.TarjetasAmarillas).IsRequired();
    builder.Property(ej => ej.TarjetasRojas).IsRequired();
    builder.Property(ej => ej.FechaCreacion).IsRequired().HasColumnType("TIMESTAMP");

    // Interpretacion de esta parte, un elemento de estadistica jugador pertenece a un jugador
    builder.HasOne(ej => ej.Jugador)
    // un jugador puede tener varias estadisticas de acuerdo al tiempo o registro
        .WithMany(j => j.EstadisticaJugadors)
    // se establece con el id del jugador que es el fk como tal
        .HasForeignKey(ej => ej.JugadorId)
    // si se borra da un comportamiento de cascada.
        .OnDelete(DeleteBehavior.Cascade);
  }
}
