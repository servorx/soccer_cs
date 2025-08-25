using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using soccer_cs.src.modules.cuerpo_medico.domain.models;
using soccer_cs.src.modules.cuerpo_tecnico.domain.models;
using soccer_cs.src.modules.jugador.domain.models;
using soccer_cs.src.modules.persona.domain.models;

namespace soccer_cs.src.shared.configurations;
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
    builder.Property(p => p.Nombre).HasMaxLength(80).IsRequired();
    builder.Property(p => p.Apellido).HasMaxLength(80).IsRequired();
    builder.Property(p => p.Edad).IsRequired().HasColumnType("int");
    builder.ToTable(p => p.HasCheckConstraint("CK_edad", "edad > 0"));
    builder.Property(p => p.Nacionalidad).HasMaxLength(50).IsRequired();
    builder.Property(p => p.DocumentoIdentidad).IsRequired().HasColumnType("int");
    builder.HasIndex(p => p.DocumentoIdentidad).IsUnique();
    builder.Property(p => p.Genero).IsRequired().HasMaxLength(50);

    // TODO: revisar la parte de las relaciona a pesar de que herede de persona ya que es una relacion de uno a uno 
    // ? no se colocan relaciones ya que las clases heredan directamente de persona
    // configuracion de llave foranea hacia cuerpo_medico
    builder.HasOne(p => p.CuerpoMedico)
        .WithOne(cm => cm.Persona)
        .HasForeignKey<CuerpoMedico>(cm => cm.IdPersona)
        .OnDelete(DeleteBehavior.Cascade); 
    // cuerpo tecnico
    builder.HasOne(p => p.CuerpoTecnico)
        .WithOne(ct => ct.Persona)
        .HasForeignKey<CuerpoTecnico>(ct => ct.IdPersona)
        .OnDelete(DeleteBehavior.Cascade); 
    // en jugador no hay persona porque directamente se hereda la clase
    builder.HasOne(p => p.Jugador)
        .WithOne(j => j.Persona)
        .HasForeignKey<Jugador>(j => j.IdPersona)
        .OnDelete(DeleteBehavior.Cascade);
  }
}
