using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using soccer_cs.models;

namespace soccer_cs;
public class PersonaConfig : IEntityTypeConfiguration<Persona>
{
  public void Configure(EntityTypeBuilder<Persona> builder)
  {
    // definir tabla
    builder.ToTable("personas");

    // definir la llave principal
    builder.HasKey(p => p.Id);
    builder.Property(p => p.Id).ValueGeneratedOnAdd();

    // definir las columnas de la tabla 
    builder.Property(p => p.Nombre).HasMaxLength(80).IsRequired().HasColumnType("varchar");
    builder.Property(p => p.Apellido).HasMaxLength(80).IsRequired().HasColumnType("varchar");
    builder.Property(p => p.Edad).IsRequired().HasColumnType("int");
    builder.ToTable(p => p.HasCheckConstraint("CK_edad", "edad > 0"));
    builder.Property(p => p.Nacionalidad).HasMaxLength(50).IsRequired().HasColumnType("varchar");
    builder.Property(p => p.DocumentoIdentidad).IsRequired().HasColumnType("int");
    builder.HasIndex(p => p.DocumentoIdentidad).IsUnique();
    builder.Property(p => p.Genero).HasMaxLength(50).HasColumnType("varchar");

    // configuracion de llave foranea hacia cuerpo_medico
    builder.HasOne(p => p.CuerpoMedico)
        .WithOne(cm => cm.Persona)
        .HasForeignKey<CuerpoMedico>(cm => cm.PersonaId);
    // cuerpo tecnico
    builder.HasOne(p => p.CuerpoTecnico)
        .WithOne(ct => ct.Persona)
        .HasForeignKey<CuerpoTecnico>(ct => ct.PersonaId);
    // jugador
    builder.HasOne(p => p.Jugador)
        .WithOne(j => j.Persona)
        .HasForeignKey<Jugador>(j => j.PersonaId);
  }
}
