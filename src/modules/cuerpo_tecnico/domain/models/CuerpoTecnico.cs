using System;
using soccer.modules.equipo.domain;

namespace soccer_cs;

public class CuerpoTecnico : Persona
{
  public string? Rol { get; set; }
  public int AniosExperiencia { get; set; }
  // relaciones foraneas
  public int EquipoId { get; set; }
  public Equipo? Equipo { get; set; }
  public CuerpoTecnico(
    string? nombre,
    string? apellido,
    int edad,
    string? nacionalidad,
    int documentoIdentidad,
    string? genero,
    string? rol,
    int aniosExperiencia
  ) : base(nombre, apellido, edad, nacionalidad, documentoIdentidad, genero)
  {
    Rol = rol;
    AniosExperiencia = aniosExperiencia;
  }

  public CuerpoTecnico() { }

  public override string ToString()
  {
    return $"{Nombre} {Apellido}, Rol: {Rol}, Experiencia: {AniosExperiencia} años";
  }
}
