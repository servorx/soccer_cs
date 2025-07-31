using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soccer_cs;

namespace soccer_cs;

public class CuerpoMedico : Persona
{
  public string? Especialidad { get; set; }
  public int AniosExperiencia { get; set; }
  public CuerpoMedico(int id, string? nombre, string? apellido, int edad, string? nacionalidad, int documentoIdentidad, string? genero, string? especialidad, int aniosExperiencia)
    : base(id, nombre, apellido, edad, nacionalidad, documentoIdentidad, genero)
  {
    Especialidad = especialidad;
    AniosExperiencia = aniosExperiencia;
  }
  public CuerpoMedico() { }
  public override string ToString()
  {
    return $"{Nombre} {Apellido} - {Especialidad} ({AniosExperiencia} años de experiencia)";
  }
}
