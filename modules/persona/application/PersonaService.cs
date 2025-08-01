using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soccer_cs;
using soccer_cs.infrastructure.utils;
using soccer_cs.infrastructure.data;
using soccer_cs.application;


namespace soccer_cs.application;
public class PersonaService
{
  private readonly IPersonaRepository _personaRepository;
  private readonly Validaciones validate_input = new();
  // creacion del constructor de la clase PersonaService 
  public PersonaService(IPersonaRepository personaRepository)
  {
    _personaRepository = personaRepository;
  }
  public void CrearPersona()
  {
    Console.Clear();
    Console.WriteLine("=== CREAR NUEVA PERSONA ===");

    System.Console.Write("Ingrese el nombre de la persona: ");
    string nombre = validate_input.ValidarTexto(Console.ReadLine()).ToLower();

    System.Console.Write("Ingrese el apellido de la persona: ");
    string apellido = validate_input.ValidarTexto(Console.ReadLine()).ToLower();

    System.Console.Write("ingrese la edad de la persona: ");
    int edad = validate_input.ValidarEntero(Console.ReadLine());

    System.Console.Write("ingrese la nacionalidad de la persona: ");
    string nacionalidad = validate_input.ValidarTexto(Console.ReadLine());

    System.Console.Write("ingrese el numero del documento de la persona: ");
    int documento_identidad = validate_input.ValidarEntero(Console.ReadLine());

    System.Console.Write("ingrese el genero de la persona: ");
    string genero = validate_input.ValidarTexto(Console.ReadLine());

    System.Console.WriteLine("\nIngresaste los siguientes datos:");
    Persona nueva_persona = new Persona();
    nueva_persona.ToString();
    System.Console.WriteLine("deseas guardar los datos? (s/n): ");

    bool validate_data = validate_input.ValidarBoleano(Console.ReadLine());
    // agregar los datos a la lista de Personas
    if (validate_data)
    {
      _personaRepository.Crear(nueva_persona);
      Console.Clear();
      System.Console.WriteLine("Persona creada exitosamente :)");
      System.Console.WriteLine("presione una tecla para continuar...");
      Console.ReadLine();
    }
    else
    {
      Console.Clear();
      System.Console.WriteLine("no confirmó los cambios, presione una tecla para volver al menu");
      Console.ReadLine();
    }
  }
}
