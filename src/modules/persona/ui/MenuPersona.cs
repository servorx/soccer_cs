using soccer_cs;
using soccer_cs.src.modules.persona.application.interfaces;
using soccer_cs.src.modules.persona.domain.models;
using soccer_cs.src.shared.utils;

namespace persona.src.persona.ui;

public class MenuPersona
{
  private readonly Validaciones validate_data = new Validaciones();
  private readonly IPersonaService _personaService;
  public MenuPersona(IPersonaService personaService) => _personaService = personaService;
  public async Task<Persona?> CrearPersonaAsync()
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

    // verifica si el usuario quiere confirmar los cambios
    Console.WriteLine("Datos ingresados: \n");
    Console.WriteLine($"Nombre: {nombre} | Apellido: {apellido} | Edad: {edad} | Nacionalidad: {nacionalidad} | Documento: {documento_identidad} | Genero: {genero}");
    Console.Write("¿Desea registrar la persona con los datos introducidos? (S/N): ");
    var opcion = validate_data.ValidarBoleano(Console.ReadLine());
    if (opcion == false) return null;
    // se crea la nueva persona 
    var persona = new Persona
    {
      Nombre = nombre,
      Apellido = apellido,
      Edad = edad,
      Nacionalidad = nacionalidad,
      DocumentoIdentidad = documento_identidad,
      Genero = genero
    };
    try
    {

      Console.WriteLine("Persona creada exitosamente.");
      Console.WriteLine($"Id generado: {persona.Id}");
      Console.WriteLine("Presiona Enter para continuar...");
      Console.ReadLine();
      return persona;
    }
    catch (Exception ex)
    {
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine("❌ Error al crear la persona: " + ex.Message);

      if (ex.InnerException != null)
      {
        Console.WriteLine("🔎 InnerException: " + ex.InnerException.Message);
      }

      Console.ResetColor();
      Console.ReadLine();
      return null;
    }
  }
  public async Task<Persona?> ActualizarPersonaAsync()
  {
    Console.Clear();
    Console.WriteLine("---- Actualizar Persona ----");

    Console.WriteLine("Id de la persona a actualizar: ");
    int id_actualizar = validate_data.ValidarEntero(Console.ReadLine());
    var existente = await _personaService.ObtenerPersonaPorIdAsync(id_actualizar);
    if (existente == null)
    {
      Console.WriteLine("Persona no encontrada.");
      Console.ReadLine();
      return null;
    }

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

    // verifica si el usuario quiere confirmar los cambios
    Console.WriteLine("Datos ingresados: \n");
    Console.WriteLine($"Nombre: {nombre} | Apellido: {apellido} | Edad: {edad} | Nacionalidad: {nacionalidad} | Documento: {documento_identidad} | Genero: {genero}");
    Console.Write("¿Desea registrar la persona con los datos introducidos? (S/N): ");
    var opcion = validate_data.ValidarBoleano(Console.ReadLine());
    if (opcion == false) return null;

    // se crea el nuevo torneo
    var persona = new Persona
    {
      Nombre = nombre,
      Apellido = apellido,
      Edad = edad,
      Nacionalidad = nacionalidad,
      DocumentoIdentidad = documento_identidad,
      Genero = genero
    };
    await _personaService.ActualizarPersonaAsync(id_actualizar, persona);
    Console.WriteLine("Persona actualizada exitosamente.");
    Console.WriteLine("Presiona enter para continuar...");
    Console.ReadLine();
    return persona;
  }
  public async Task<Persona?> EliminarPersonaAsync()
  {
    Console.Clear();
    Console.WriteLine("---- Eliminar Persona ----");

    Console.WriteLine("Id de la persona a eliminar: ");
    int id_eliminar = validate_data.ValidarEntero(Console.ReadLine());
    var existente = await _personaService.ObtenerPersonaPorIdAsync(id_eliminar);
    if (existente == null)
    {
      Console.WriteLine("Persona no encontrada.");
      Console.ReadLine();
      return null;
    }

    await _personaService.EliminarPersonaAsync(id_eliminar);
    Console.WriteLine("🗑️ Persona eliminada exitosamente.");
    Console.WriteLine("Presiona enter para continuar...");
    Console.ReadLine();
    return existente;
  }
}
