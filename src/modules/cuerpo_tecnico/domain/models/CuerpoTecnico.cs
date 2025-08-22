using System;
using soccer.src.modules.equipo.domain.models;
using soccer_cs.src.modules.persona.domain.models;

namespace soccer_cs.src.modules.cuerpo_tecnico.domain.models;

public class CuerpoTecnico
{
  public int Id { get; set; }
  public int IdPersona { get; set; }
  public string? Rol { get; set; }
  public int AniosExperiencia { get; set; }
  // relaciones foraneas
  public int? IdEquipo { get; set; }
  public Equipo Equipo { get; set; } = null!;
  public Persona Persona { get; set; } = null!;
  public CuerpoTecnico(int id,string? rol, int aniosExperiencia)
  {
    Id = id;
    Rol = rol;
    AniosExperiencia = aniosExperiencia;
  }

  public CuerpoTecnico() { }

  public override string ToString()
  {
    return $"{Persona?.Nombre} {Persona?.Apellido}, Rol: {Rol}, Experiencia: {AniosExperiencia} años";
  }
}
