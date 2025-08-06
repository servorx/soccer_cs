using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using soccer_cs.models;

namespace soccer_cs.configurations;

public class TransferenciaConfig : IEntityTypeConfiguration<Transferencia>
{
  public void Configure(EntityTypeBuilder<Transferencia> builder)
  {
    // creacion de la tabla
    builder.ToTable("transferencia");

    // creacion de la llave primaria
    builder.HasKey(t => t.Id);
    builder.Property(t => t.Id).ValueGeneratedOnAdd();


    // creacion de la columnas
    builder.Property(t => t.TipoTransferencia).IsRequired().HasMaxLength(120);
    builder.Property(t => t.ValorTransferencia).HasColumnType("decimal(12,2)");
    builder.Property(t => t.FechaTransferencia).IsRequired();

    // Relación con Jugador
    builder.HasOne(t => t.Jugador)
        .WithMany(j => j.Transferencias)
        .HasForeignKey(t => t.JugadorId)
        .OnDelete(DeleteBehavior.Restrict);

    // EquipoOrigen
    builder.HasOne(t => t.EquipoOrigen)
        .WithMany(e => e.TransferenciasOrigen)
        .HasForeignKey(t => t.EquipoOrigenId)
        .OnDelete(DeleteBehavior.Restrict);

    // Relación con Equipo Destino
    builder.HasOne(t => t.EquipoDestino)
        .WithMany(e => e.TransferenciasDestino)
        .HasForeignKey(t => t.EquipoDestinoId)
        .OnDelete(DeleteBehavior.Restrict);
  }
}
