using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soccer_cs;

namespace soccer_cs;

public class Persona
{
  public int Id { get; set; }
  public string? Nombre { get; set; }
  public string? Apellido { get; set; }
  public int Edad { get; set; }
  public string? Nacionalidad { get; set; }
  public int DocumentoIdentidad { get; set; }
  public string? Genero { get; set; }
}
