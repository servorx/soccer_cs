
using soccer_cs.src.modules.jugador.domain.models;
using soccer_cs.src.modules.cuerpo_medico.domain.models;
using soccer_cs.src.modules.cuerpo_tecnico.domain.models;

namespace soccer_cs.src.modules.persona.domain.models;

public class Persona
{
  public int Id { get; set; }
  public string? Nombre { get; set; }
  public string? Apellido { get; set; }
  public int Edad { get; set; }
  public string? Nacionalidad { get; set; }
  public int DocumentoIdentidad { get; set; }
  public string? Genero { get; set; }
  // TODO: revisar la parte de las relaciones a pesar de que herede de persona ya que es una relacion de uno a uno
  // Persona se relaciona con CuerpoMedico, CuerpoTecnico y jugadores
  public CuerpoMedico? CuerpoMedico { get; set; }
  public CuerpoTecnico? CuerpoTecnico { get; set; }
  public Jugador? Jugador { get; set; }
  // define el constructor de la clase Persona para poder declararla como subclase de CuerpoMedico y otras clases
  public Persona(string? nombre, string? apellido, int edad, string? nacionalidad, int documento_identidad, string? genero)
  {
    // Id = id;
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
