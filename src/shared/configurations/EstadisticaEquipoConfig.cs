using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mysqlx.Crud;

namespace soccer_cs;
public class EstadisticaEquipoConfig : IEntityTypeConfiguration<EstadisticaEquipo>
{
  public void Configure(EntityTypeBuilder<EstadisticaEquipo> builder)
  {
    // definicion de la tabla
    builder.ToTable("estadistica_equipo");

    // definicion del id y el autoincrement
    builder.HasKey(eq => eq.Id);
    builder.Property(eq => eq.Id).ValueGeneratedOnAdd();

    // definir las columnas de la tabla
    builder.Property(eq => eq.PartidosGanados).IsRequired();
    builder.Property(eq => eq.PartidosEmpatados).IsRequired();
    builder.Property(eq => eq.PartidosPerdidos).IsRequired();
    builder.Property(eq => eq.GolesAFavor).IsRequired();
    builder.Property(eq => eq.GolesEnContra).IsRequired();
    builder.Property(eq => eq.FechaCreacion).IsRequired().HasColumnType("DATE");

    // foreign keys
    builder.HasOne(eq => eq.Equipo)
        .WithMany(eq => eq.EstadisticaEquipos)
        .HasForeignKey(eq => eq.EquipoId)
        .OnDelete(DeleteBehavior.Cascade);
  }
}
