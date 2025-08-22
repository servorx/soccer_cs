using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using soccer_cs.src.modules.torneo.domain.models;

namespace soccer_cs.src.shared.configurations;
public class TorneoConfig : IEntityTypeConfiguration<Torneo>
{
  public void Configure(EntityTypeBuilder<Torneo> builder)
  {
    // definir nombre de la tabla
    builder.ToTable("torneos");

    // definir id y autoincrement
    builder.HasKey(eq => eq.Id);
    builder.Property(eq => eq.Id).ValueGeneratedOnAdd();

    // definicion de las columnas 
    builder.Property(eq => eq.Nombre).IsRequired();
    builder.Property(eq => eq.Tipo).IsRequired();
    builder.Property(eq => eq.Ubicacion).IsRequired();
    builder.Property(eq => eq.FechaInicio).IsRequired();
    builder.Property(eq => eq.FechaFinal).IsRequired();
    builder.Property(eq => eq.Premio).IsRequired();
  }
}
