using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace soccer_cs;
public class PersonaConfig : IEntityTypeConfiguration<Persona>
{
  public void Configure(EntityTypeBuilder<Persona> builder)
  {
    builder.ToTable("personas");

    builder.HasKey(p => p.Id);

    builder.Property(p => p.Nombre).HasMaxLength(80).IsRequired();
    builder.Property(p => p.Apellido).HasMaxLength(80).IsRequired();
    builder.Property(p => p.Edad).IsRequired();
    builder.Property(p => p.Nacionalidad).HasMaxLength(50).IsRequired();
    builder.Property(p => p.DocumentoIdentidad).IsRequired();
    builder.HasIndex(p => p.DocumentoIdentidad).IsUnique();
    builder.Property(p => p.Genero).HasMaxLength(50);
  }
}
