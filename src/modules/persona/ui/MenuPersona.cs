using soccer_cs;
using soccer_cs.infrastructure.utils;
using System;

namespace persona.ui;

public class MenuPersona
{
  private readonly Validaciones validate_data = new Validaciones();
  private readonly IPersonaService _personaService;
  public MenuPersona(IPersonaService personaService) => _personaService = personaService;
  public async Task<Persona> AgregarPersonaAsync()
  {
    Console.Clear();
    Console.WriteLine("---- Registrar Persona ----");

    Console.Write("Nombre: ");
    string nombre = validate_data.ValidarTexto(Console.ReadLine());

    Console.Write("Apellido: ");
    string apellido = validate_data.ValidarTexto(Console.ReadLine());

    Console.Write("Edad: ");
    int edad = validate_data.ValidarEntero(Console.ReadLine());

    Console.Write("Nacionalidad: ");
    string nacionalidad = validate_data.ValidarTexto(Console.ReadLine());

    Console.Write("Documento: ");
    int documento_identidad = validate_data.ValidarEntero(Console.ReadLine());

    Console.Write("Género: ");
    var genero = Console.ReadLine();

    var nuevaPersona = new Persona
    {
      Nombre = nombre,
      Apellido = apellido,
      Edad = edad,
      Nacionalidad = nacionalidad,
      DocumentoIdentidad = documento_identidad,
      Genero = genero
    };

    // se realizar de forma asincrona para evitar el bloqueo del programa al momento de registrar la persona
    await _personaService.AgregarPersonaAsync(nuevaPersona);

    Console.WriteLine("✅ Persona registrada con éxito.");
    Console.ReadLine();
    // esto se hacer para poder volver a llamar a la función de agregar persona en otros menus del programa
    return nuevaPersona;
  }
}
