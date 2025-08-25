using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using soccer_cs.src.modules.cuerpo_medico.domain.models;

namespace soccer_cs.src.shared.configurations;
public class CuerpoMedicoConfig : IEntityTypeConfiguration<CuerpoMedico>
{
  public void Configure(EntityTypeBuilder<CuerpoMedico> builder)
  {
    builder.ToTable("cuerpo_medico");
    // tiene que heredar la clave principal de persona
    builder.HasKey(cm => cm.Id);
    builder.Property(cm => cm.Id).ValueGeneratedOnAdd();

    builder.Property(cm => cm.IdPersona).IsRequired();
    builder.Property(cm => cm.Especialidad).HasMaxLength(100).IsRequired().HasColumnType("varchar");
    builder.Property(cm => cm.AniosExperiencia).IsRequired();
    // configuracion de la clave foranea hacia equipo, en este caso con relacion de uno a muchos
    builder.HasOne(cm => cm.Equipo)
        .WithMany(e => e.CuerpoMedicos)
        .HasForeignKey(cm => cm.IdEquipo)
        .OnDelete(DeleteBehavior.Cascade);
    // relacio uno a uno con persona
    builder.HasOne(cm => cm.Persona)
    .WithOne(p => p.CuerpoMedico)
    .HasForeignKey<CuerpoMedico>(cm => cm.IdPersona)
    .OnDelete(DeleteBehavior.Cascade);
  }
}
