using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soccer_csharp;

namespace soccer_cs.models;

public class Persona
{
  public int Id { get; set; }
  public string? Nombre { get; set; }
  public string? Apellido { get; set; }
  public int Edad { get; set; }
  public string? Nacionalidad { get; set; }
  public int DocumentoIdentidad { get; set; }
  public string? Genero { get; set; }
  public Persona(int id, string? nombre, string? apellido, int edad, string? nacionalidad, int documento_identidad, string? genero)
  {
    Id = id;
    Nombre = nombre;
    Apellido = apellido;
    Edad = edad;
    Nacionalidad = nacionalidad;
    DocumentoIdentidad = documento_identidad;
    Genero = genero;
  }
  public Persona() { }

  public override string ToString()
  {
    return $"{Nombre} {Apellido}, Edad: {Edad}, Nacionalidad: {Nacionalidad}, ID: {DocumentoIdentidad}, Género: {Genero}";
  }
}
