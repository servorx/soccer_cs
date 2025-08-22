using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using soccer.src.modules.equipo.domain.models;

namespace soccer_cs.src.shared.configurations;
public class EquipoConfig : IEntityTypeConfiguration<Equipo>
{
  public void Configure(EntityTypeBuilder<Equipo> builder)
  {
    builder.ToTable("equipos");
    // tiene que heredar la clave principal de persona
    builder.HasKey(e => e.Id);
    builder.Property(e => e.Id).ValueGeneratedOnAdd();

    // definicion de las columnas 
    builder.Property(e => e.Nombre).IsRequired().HasColumnType("varchar").HasMaxLength(100);
    builder.Property(e => e.Ciudad).IsRequired().HasColumnType("varchar").HasMaxLength(50);
    builder.Property(e => e.Pais).IsRequired().HasColumnType("varchar").HasMaxLength(40);
    builder.Property(e => e.Estadio).IsRequired().HasColumnType("varchar").HasMaxLength(180);
    builder.Property(e => e.TipoEquipo).IsRequired().HasColumnType("varchar").HasMaxLength(30);
    builder.Property(e => e.CantidadTitulos).IsRequired();
    // definicion de las relaciones con cuerpo medico
    builder.HasMany(e => e.CuerpoMedicos)
        .WithOne(cm => cm.Equipo)
        .HasForeignKey(cm => cm.IdEquipo)
        .OnDelete(DeleteBehavior.Cascade);
    // con cuerpo tecnico
    builder.HasMany(e => e.CuerpoTecnicos)
        .WithOne(ct => ct.Equipo)
        .HasForeignKey(ct => ct.IdEquipo)
        .OnDelete(DeleteBehavior.Cascade);
    // con equipo jugador
    builder.HasMany(e => e.EquipoJugadors)
        .WithOne(ej => ej.Equipo)
        .HasForeignKey(ej => ej.IdEquipo)
        .OnDelete(DeleteBehavior.Cascade);
    // con equipo_jugador porque la tabla debe de ser intermedia al haber una relacion de muchos a muchos, esta configuracion se encuentra en el archivo EquipoJugadorConfig.cs
        // con estadistica equipo
        builder.HasMany(e => e.EstadisticaEquipos)
        .WithOne(ee => ee.Equipo)
        .HasForeignKey(ee => ee.IdEquipo)
        .OnDelete(DeleteBehavior.Cascade);
    // con torneo equipo
    builder.HasMany(e => e.TorneosEquipos)
        .WithOne(te => te.Equipo)
        .HasForeignKey(ct => ct.IdEquipo)
        .OnDelete(DeleteBehavior.Cascade);
    // con transferencias (origen)
    builder.HasMany(e => e.TransferenciasOrigen)
        .WithOne(t => t.EquipoOrigen)
        .HasForeignKey(t => t.IdEquipoOrigen)
        .OnDelete(DeleteBehavior.Restrict);
    // con transferencias (destino)
    builder.HasMany(e => e.TransferenciasDestino)
        .WithOne(t => t.EquipoDestino)
        .HasForeignKey(t => t.IdEquipoDestino)
        .OnDelete(DeleteBehavior.Restrict);
  }
}
