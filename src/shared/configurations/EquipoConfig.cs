using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using soccer.modules.equipo.domain;

namespace soccer_cs;
public class EquipoConfig : IEntityTypeConfiguration<Equipo>
{
  public void Configure(EntityTypeBuilder<Equipo> builder)
  {
    builder.ToTable("equipos");
    // tiene que heredar la clave principal de persona
    builder.HasKey(ct => ct.Id);


  }
}
