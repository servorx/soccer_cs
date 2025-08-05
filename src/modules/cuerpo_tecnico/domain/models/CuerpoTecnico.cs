using System;

namespace soccer_cs;

public class CuerpoTecnico : Persona
{
  public string? Rol { get; set; }
  public int AniosExperiencia { get; set; }
  public int PersonaId { get; set; }
  public Persona? Persona { get; set; }
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
