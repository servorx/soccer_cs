using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using soccer_cs.src.modules.cuerpo_tecnico.domain.models;

namespace soccer_cs.src.shared.configurations;
public class CuerpoTecnicoConfig : IEntityTypeConfiguration<CuerpoTecnico>
{
  public void Configure(EntityTypeBuilder<CuerpoTecnico> builder)
  {
    builder.ToTable("cuerpo_tecnico");
    // tiene que heredar la clave principal de persona
    builder.HasKey(ct => ct.Id);
    builder.Property(ct => ct.Id).ValueGeneratedOnAdd();

    builder.Property(ct => ct.IdPersona).IsRequired();
    builder.Property(ct => ct.Rol).HasMaxLength(40).IsRequired().HasColumnType("varchar");
    builder.Property(ct => ct.AniosExperiencia).IsRequired();
    // configuracion de la clave foranea hacia equipo 
    builder.HasOne(ct => ct.Equipo)
        .WithMany(e => e.CuerpoTecnicos)
        .HasForeignKey(ct => ct.IdEquipo)
        .OnDelete(DeleteBehavior.Cascade);
    // relacio uno a uno con persona
    builder.HasOne(ct => ct.Persona)
    .WithOne(p => p.CuerpoTecnico)
    .HasForeignKey<CuerpoTecnico>(ct => ct.IdPersona)
    .OnDelete(DeleteBehavior.Cascade);
  }
}
