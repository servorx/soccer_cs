using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace soccer_cs;
public class CuerpoTecnicoConfig : IEntityTypeConfiguration<CuerpoTecnico>
{
  public void Configure(EntityTypeBuilder<CuerpoTecnico> builder)
  {
    builder.ToTable("cuerpo_tecnico");
    // tiene que heredar la clave principal de persona
    builder.HasKey(ct => ct.Id);

    builder.Property(ct => ct.Rol).HasMaxLength(40).IsRequired().HasColumnType("varchar");
    builder.Property(ct => ct.AniosExperiencia).IsRequired();
    // configuracion de la clave foranea hacia equipo 
    builder.HasOne(ct => ct.Equipo)
        .WithMany(e => e.CuerpoTecnicos)
        .HasForeignKey(ct => ct.EquipoId)
        .OnDelete(DeleteBehavior.Cascade);
  }
}
