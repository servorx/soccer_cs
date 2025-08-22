using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using soccer_cs.src.modules.torneo_equipo.domain.models;

namespace soccer_cs.src.shared.configurations;
public class TorneoEquipoConfig : IEntityTypeConfiguration<TorneoEquipo>
{
  public void Configure(EntityTypeBuilder<TorneoEquipo> builder)
  {
    // definicion de la tabla
    builder.ToTable("torneo_equipo");

    // definicion del id y el autoincrement
    builder.HasKey(te => new { te.IdTorneo, te.IdEquipo });

    // definir las columnas de la tabla, no tiene :(

    // definir las fk
    builder.HasOne(te => te.Equipo)
      .WithMany(e => e.TorneosEquipos)
      .HasForeignKey(te => te.IdEquipo)
      .OnDelete(DeleteBehavior.Restrict);

    builder.HasOne(te => te.Torneo)
      .WithMany(t => t.TorneosEquipos)
      .HasForeignKey(te => te.IdTorneo)
      .OnDelete(DeleteBehavior.Restrict);
  }
}
