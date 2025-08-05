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

    builder.HasKey(p => p.Id);

    builder.Property(p => p.Rol).HasMaxLength(40);
    builder.Property(p => p.AniosExperiencia);
  }
}
