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
    // definir relaciones de las tablas
    builder.HasOne( => ct.Equipo)
        .WithMany(e => e.CuerpoTecnicos)
        .HasForeignKey(ct => ct.EquipoId)
        .OnDelete(DeleteBehavior.Cascade);
    builder.HasOne( => ct.Equipo)
        .WithMany(e => e.CuerpoTecnicos)
        .HasForeignKey(ct => ct.EquipoId)
        .OnDelete(DeleteBehavior.Cascade);
    builder.HasOne( => ct.Equipo)
        .WithMany(e => e.CuerpoTecnicos)
        .HasForeignKey(ct => ct.EquipoId)
        .OnDelete(DeleteBehavior.Cascade);
  }
}
