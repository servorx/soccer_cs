using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace soccer_cs;
public class CuerpoTecnicoConfig : IEntityTypeConfiguration<CuerpoTecnico
{
  public void Configure(EntityTypeBuilder<CuerpoTecnico> builder)
  {
    builder.ToTable("cuerpo_tecnico");
    // tiene que heredar la clave principal de persona
    builder.HasKey(ct => ct.Id);

    builder.Property(cm => cm.Especialidad).HasMaxLength(100).IsRequired();
    builder.Property(cm => cm.AniosExperiencia).IsRequired();
    // configuracion de la clave foranea hacia equipo 
    builder.HasOne(cm => cm.Equipo)
        .WithMany(e => e.CuerpoMedicos)
        .HasForeignKey(cm => cm.EquipoId)
        .OnDelete(DeleteBehavior.Cascade); // O .Restrict / .SetNull
  }
}
