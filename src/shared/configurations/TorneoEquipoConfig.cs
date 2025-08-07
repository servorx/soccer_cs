using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace soccer_cs;
public class TorneoEquipoConfig : IEntityTypeConfiguration<TorneoEquipo>
{
  public void Configure(EntityTypeBuilder<TorneoEquipo> builder)
  {
    // definicion de la tabla
    builder.ToTable("torneo_equipo");

    // definicion del id y el autoincrement
    builder.HasKey(te => new { te.TorneoId, te.EquipoId });

    // definir las columnas de la tabla, no tiene :(
    // foreign keys
    builder.HasOne(te => te.Torneo)
        .WithMany(t => t.TorneosEquipos)
        .HasForeignKey(te => te.TorneoId)
        .OnDelete(DeleteBehavior.Cascade);
    builder.HasOne(te => te.Equipo)
        .WithMany(eq => eq.TorneosEquipos)
        .HasForeignKey(te => te.EquipoId)
        .OnDelete(DeleteBehavior.Cascade);
  }
}
