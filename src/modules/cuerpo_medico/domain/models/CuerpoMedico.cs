using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soccer.src.modules.equipo.domain.models;
using soccer_cs;
using soccer_cs.src.modules.persona.domain.models;

namespace soccer_cs.src.modules.cuerpo_medico.domain.models;

public class CuerpoMedico 
{
  public int Id { get; set; }
  public int IdPersona { get; set; }
  public string? Especialidad { get; set; }
  public int AniosExperiencia { get; set; }
  // relaciones de clases foraneas 
  public int? IdEquipo { get; set; }
  public Equipo? Equipo { get; set; }
  public Persona Persona { get; set; } = null!;
  public CuerpoMedico(int id, int id_persona, string? especialidad, int aniosExperiencia)
  {
    Id = id;
    IdPersona = id_persona;
    Especialidad = especialidad;
    AniosExperiencia = aniosExperiencia;
  }
  public CuerpoMedico() { } 
  public override string ToString()
  {
    return $"{Persona.Nombre} {Persona.Apellido} - {Especialidad} ({AniosExperiencia} años de experiencia)";
  }
}
