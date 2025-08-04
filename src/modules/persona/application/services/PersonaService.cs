using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soccer_cs;
using soccer_cs.infrastructure.utils;
using soccer_cs.infrastructure.data;
using soccer_cs.application;


namespace soccer_cs.application;
// el propositor de este archivo es usar el repositorio para implementar la lógica de negocio de tu aplicación.
public class PersonaService : IPersonaService
{
  private readonly Validaciones validate_input = new();
  private readonly IPersonaRepository _personaRepository;

  public PersonaService(IPersonaRepository personaRepository)
  {
    _personaRepository = personaRepository;
  }

  public void CrearPersona(Persona persona)
  {
    // Aquí podrías hacer validaciones o lógica adicional si necesitas
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
    nueva_persona = new Persona(nombre, apellido, edad, nacionalidad, documento_identidad, genero);
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
    _personaRepository.InsertarPersona(persona);
  }
  public List<Persona> ObtenerPersonas()
  {
    return _personaRepository.ObtenerTodas();
  }
  public void EditarPersona(Persona persona)
  {
    // Aquí podrías hacer validaciones o lógica adicional si necesitas
    Console.Clear();
    System.Console.WriteLine("=== EDITAR PERSONA ===");
    System.Console.Write("Ingrese el ID de la persona a editar: ");
    int id = validate_input.ValidarEntero(Console.ReadLine());

    var personaExistente = _personaRepository.ObtenerPorId(id);
    if (personaExistente == null)
    {
      Console.WriteLine("Persona no encontrada.");
      return;
    }

    System.Console.Write("Nuevo nombre (dejar en blanco para no cambiar): ");
    string nuevoNombre = Console.ReadLine();
    if (!string.IsNullOrEmpty(nuevoNombre))
      personaExistente.Nombre = nuevoNombre;

    System.Console.Write("Nuevo apellido (dejar en blanco para no cambiar): ");
    string nuevoApellido = Console.ReadLine();
    if (!string.IsNullOrEmpty(nuevoApellido))
      personaExistente.Apellido = nuevoApellido;

    System.Console.Write("Nueva edad (dejar en blanco para no cambiar): ");
    string nuevaEdadStr = Console.ReadLine();
    if (int.TryParse(nuevaEdadStr, out int nuevaEdad))
      personaExistente.Edad = nuevaEdad;

    System.Console.Write("Nueva nacionalidad (dejar en blanco para no cambiar): ");
    string nuevaNacionalidad = Console.ReadLine();
    if (!string.IsNullOrEmpty(nuevaNacionalidad))
      personaExistente.Nacionalidad = nuevaNacionalidad;

    System.Console.Write("Nuevo documento de identidad (dejar en blanco para no cambiar): ");
    string nuevoDocumentoStr = Console.ReadLine();
    if (int.TryParse(nuevoDocumentoStr, out int nuevoDocumento))
      personaExistente.DocumentoIdentidad = nuevoDocumento;

    System.Console.Write("Nuevo género (dejar en blanco para no cambiar): ");
    string nuevoGenero = Console.ReadLine();
    if (!string.IsNullOrEmpty(nuevoGenero))
      personaExistente.Genero = nuevoGenero;

    _personaRepository.Actualizar(personaExistente);
  }
  public void EliminarPersona(int id)
  {
    // Aquí podrías hacer validaciones o lógica adicional si necesitas
    Console.Clear();
    System.Console.WriteLine("=== ELIMINAR PERSONA ===");
    System.Console.Write("Ingrese el ID de la persona a eliminar: ");
    id = validate_input.ValidarEntero(Console.ReadLine());
    var personaExistente = _personaRepository.ObtenerPorId(id);
    if (personaExistente == null)
    {
      Console.WriteLine("Persona no encontrada.");
      return;
    }
  }
}



// public class PersonaService
// {  private readonly IPersonaRepository _personaRepository;
//   private readonly Validaciones validate_input = new();

//   public PersonaService()
//   {
//   }

//   // creacion del constructor de la clase PersonaService 
//   public PersonaService(IPersonaRepository personaRepository)
//   {
//     _personaRepository = personaRepository;
//   }
//   public void CrearPersona()
//   {
//     Console.Clear();
//     Console.WriteLine("=== CREAR NUEVA PERSONA ===");

//     System.Console.Write("Ingrese el nombre de la persona: ");
//     string nombre = validate_input.ValidarTexto(Console.ReadLine()).ToLower();

//     System.Console.Write("Ingrese el apellido de la persona: ");
//     string apellido = validate_input.ValidarTexto(Console.ReadLine()).ToLower();

//     System.Console.Write("ingrese la edad de la persona: ");
//     int edad = validate_input.ValidarEntero(Console.ReadLine());

//     System.Console.Write("ingrese la nacionalidad de la persona: ");
//     string nacionalidad = validate_input.ValidarTexto(Console.ReadLine());

//     System.Console.Write("ingrese el numero del documento de la persona: ");
//     int documento_identidad = validate_input.ValidarEntero(Console.ReadLine());

//     System.Console.Write("ingrese el genero de la persona: ");
//     string genero = validate_input.ValidarTexto(Console.ReadLine());

//     System.Console.WriteLine("\nIngresaste los siguientes datos:");
//     Persona nueva_persona = new Persona();
//     nueva_persona.ToString();
//     System.Console.WriteLine("deseas guardar los datos? (s/n): ");

//     bool validate_data = validate_input.ValidarBoleano(Console.ReadLine());
//     nueva_persona = new Persona(nombre, apellido, edad, nacionalidad, documento_identidad, genero);
//     // agregar los datos a la lista de Personas
//     if (validate_data)
//     {
//       _personaRepository.Crear(nueva_persona);
//       Console.Clear();
//       System.Console.WriteLine("Persona creada exitosamente :)");
//       System.Console.WriteLine("presione una tecla para continuar...");
//       Console.ReadLine();
//     }
//     else
//     {
//       Console.Clear();
//       System.Console.WriteLine("no confirmó los cambios, presione una tecla para volver al menu");
//       Console.ReadLine();
//     }
//   }
// }
