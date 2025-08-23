using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using soccer_cs.src.modules.cuerpo_tecnico.application.services;
using soccer_cs.src.modules.cuerpo_tecnico.domain.models;
using soccer_cs.src.modules.cuerpo_tecnico.infrastructure.repositories;
using soccer_cs.src.modules.persona.application.services;
using soccer_cs.src.modules.persona.domain.models;
using soccer_cs.src.shared.context;
using soccer_cs.src.shared.helpers;
using soccer_cs.src.shared.utils;

namespace soccer_cs.src.modules.cuerpo_tecnico.ui;
public class MenuCuerpoTecnico
{
  private readonly Validaciones validate_data = new Validaciones();
  // esto con el fin de que se pueda acceder a la clase de servicio de cuerpo tecnico
  readonly CuerpoTecnicoService _cuerpoTecnicoservice = null!;
  readonly PersonaService _personaService = null!;
  // este codigo se hace con el fin de que cuando se ejecute el programa se pueda ve el menu de la aplicacion
  public MenuCuerpoTecnico(AppDbContext _context)
  {
    var repo = new CuerpoTecnicoRepository(_context);
    _cuerpoTecnicoservice = new CuerpoTecnicoService(repo);
  }
  // se declara la variable que se va a utilizar para el menu principal
  private int opcionSeleccionada = 0;
  // se declara un arreglo de strings que contiene las opciones del menu principal
  private readonly string[] opcionesMenu =
  {
    "Crear cuerpo tecnico",
    "Actualizar cuerpo tecnico",
    "Eliminar cuerpo tecnico",
    "Mostrar todos los cuerpos medicos",
    "Buscar cuerpo tecnico por id",
    "Buscar cuerpo tecnico por nombre",
    "Registrar cuerpo tecnico a equipo",
    "Eliminar cuerpo tecnico de un equipo",
    "Regresar al menú principal"
  };
  // este es el metodo del menu principal en la consola con las flechas de arriba y abajo
  public void DibujarMenu()
  {
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("========== MENÚ CUERPO TECNICO ==========\n");
    Console.ResetColor();
    // este ciclo se encarga de dibujar las opciones del menu principal de acuerdo a la opcion seleccioada, recorriendo el arreglo de opcionesMenu definidco previamente
    for (int i = 0; i < opcionesMenu.Length; i++)
    {
      if (i == opcionSeleccionada)
      {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"▶ {opcionesMenu[i]}");
        Console.ResetColor();
      }
      else
      {
        Console.WriteLine($"  {opcionesMenu[i]}");
      }
    }
    Console.WriteLine("\nUsa las flechas ↑ ↓ para moverte y Enter para seleccionar.");
  }
  public async Task EjecutarMenu()
  {
    bool validate_menu = true;
    do
    {
      DibujarMenu();
      // lee la tecla presionada por el usuario
      var tecla_input = Console.ReadKey(true);

      switch (tecla_input.Key)
      {
        // si es la flecha hacia arriba se decrementa la opcion seleccionada
        case ConsoleKey.UpArrow:
          opcionSeleccionada--;
          // si la opcion seleccionada es menor a 0, se asigna el ultimo elemento del arreglo de opcionesMenu
          if (opcionSeleccionada < 0) opcionSeleccionada = opcionesMenu.Length - 1;
          break;
        // si es la flecha hacia abajo se aumenta la opcion seleccionada en el arreglo de opcionesMenu
        case ConsoleKey.DownArrow:
          opcionSeleccionada++;
          // si la opcion seleccionada es mayor o igual al largo del arreglo de opcionesMenu, se asigna 0
          if (opcionSeleccionada >= opcionesMenu.Length) opcionSeleccionada = 0;
          break;
        // si se preisona Enter se ejecuta el metodo de EjecutarOpcion con la opcion seleccionada
        case ConsoleKey.Enter:
          validate_menu = await EjecutarOpcion(opcionSeleccionada);
          break;
      }
    } while (validate_menu);
  }
  private async Task<bool> EjecutarOpcion(int opcion_seleccionada)
  {
    Console.Clear();
    switch (opcion_seleccionada)
    {
      case 0:
        Console.Clear();
        await CrearCuerpoTecnicoAsync();
        break;
      case 1:
        Console.Clear();
        await ActualizarCuerpoTecnicoAsync();
        break;
      case 2:
        Console.Clear();
        await EliminarCuerpoTecnicoAsync();
        break;
      case 3:
        Console.Clear();
        await MostrarCuerposTecnicosAsync();
        break;
      case 4:
        Console.Clear();
        await MostrarCuerpoTecnicoPorIdAsync();
        break;
      case 5:
        Console.Clear();
        await MostrarCuerpoTecnicoPorNombreAsync();
        break;
      case 6:
        Console.Clear();
        await RegistrarCuerpoTecnicoAEquipoAsync();
        break;
      case 7:
        Console.Clear();
        await EliminarCuerpoTecnicoDeEquipoAsync();
        break;
      case 8:
        Console.WriteLine("Presione cualquier tecla para regresar al menú...");
        return false;
      default:
        Console.Clear();
        Console.WriteLine("error al ingresar dato, intentelo de nuevo");
        Console.ReadLine();
        return false;
    }
    return true;
  }
  private async Task CrearCuerpoTecnicoAsync()
  {
    // TODO: antes de crear el cuerpo tecnico se debe de crear primeo la persona y se le asigna el id de la ultima persona creada
    Persona persona = new Persona();
    // TODO: sale error porque el metodo no esta definido en el servicio de personas 
    await _personaService.AgregarPersonaAsync(persona);
    Console.Write("Rol: ");
    var rol = validate_data.ValidarTexto(Console.ReadLine());

    Console.Write("Anios de experiencia: ");
    var aniosExperiencia = validate_data.ValidarEntero(Console.ReadLine());

    // hacer que el id persona sea el ultimo id creado en la base de datos ya que al crear el cuerpo tecnico se crea una persona primero
    // TODO: revisar si esto esta bien ya que puede ser nullo 
    var id_persona = await DbContextFactory.Create().Personas.MaxAsync(p => p.Id);

    System.Console.WriteLine($"¿Desea registrar el cuerpo tecnico {rol} con {aniosExperiencia} anios de experiencia?");

    System.Console.WriteLine("Si presiona 'S' se creara, si presiona 'N' se cancelara: ");
    var opcion = validate_data.ValidarBoleano(Console.ReadLine());
    if (opcion == false) return;

    // agregar el nuevo cuerpo tecnico
    var cuerpo_tecnico = new CuerpoTecnico
    {
      IdPersona = persona.Id,
      Rol = rol.Trim(), 
      AniosExperiencia = aniosExperiencia,
      Persona = persona
    };
    await _cuerpoTecnicoservice.AgregarCuerpoTecnicoAsync(cuerpo_tecnico); 
    Console.WriteLine("Cuerpo tecnico creado.");
  }
  private async Task ActualizarCuerpoTecnicoAsync()
  {
    Console.Write("ID a actualizar: ");
    int id = validate_data.ValidarEntero(Console.ReadLine());

    var existente = await _cuerpoTecnicoservice.ObtenerCuerpoTecnicoPorIdAsync(id);
    if (existente == null)
    {
      Console.WriteLine("Cuerpo tecnico no encontrado.");
      Console.ReadLine();
      return;
    }
    // en este caso no voy a hacer validate data de modo que si el usuario quiere mantener un dato, le de enter y lo deje como es
    Console.Write($"Nuevo nombre (actual: {existente.Persona.Nombre}), presiona enter para mantener el mismo nombre: ");
    var nuevoNombre = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(nuevoNombre))
      existente.Persona.Nombre = nuevoNombre;

    Console.Write($"Nuevo apellido (actual: {existente.Persona.Apellido}), presiona enter para mantener el mismo apellido: ");
    var nuevoApellido = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(nuevoApellido))
      existente.Persona.Apellido = nuevoApellido;

    Console.Write($"Nueva edad (actual: {existente.Persona.Edad}), presiona enter para mantener la misma edad: ");
    var nuevaEdadStr = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(nuevaEdadStr) && int.TryParse(nuevaEdadStr, out int nuevaEdad))
      existente.Persona.Edad = nuevaEdad;

    Console.Write($"Nueva nacionalidad (actual: {existente.Persona.Nacionalidad}), presiona enter para mantener la misma nacionalidad: ");
    var nuevaNacionalidad = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(nuevaNacionalidad))
      existente.Persona.Nacionalidad = nuevaNacionalidad;

    Console.Write($"Nuevo documento identidad (actual: {existente.Persona.DocumentoIdentidad}), presiona enter para mantener el mismo documento: ");
    var nuevoDocStr = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(nuevoDocStr) && int.TryParse(nuevoDocStr, out int nuevoDoc))
      existente.Persona.DocumentoIdentidad = nuevoDoc;

    Console.Write($"Nuevo género (actual: {existente.Persona.Genero}), presiona enter para mantener el mismo genero: ");
    var nuevoGenero = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(nuevoGenero))
      existente.Persona.Genero = nuevoGenero;

    Console.Write($"Nueva rol (actual: {existente.Rol}), presiona enter para mantener el mismo rol: ");
    var nuevaRol = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(nuevaRol))
      existente.Rol = nuevaRol;

    Console.Write($"Años experiencia (actual: {existente.AniosExperiencia}), presiona enter para mantener la misma cantidad de años de experiencia: ");
    var nuevoAniosExpStr = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(nuevoAniosExpStr) && int.TryParse(nuevoAniosExpStr, out int nuevoAniosExp))
      existente.AniosExperiencia = nuevoAniosExp;

    // Mostrar resumen de los nuevos datos
    Console.WriteLine("\n--- Confirmar Actualización ---");
    Console.WriteLine($"Nombre: {existente.Persona.Nombre}");
    Console.WriteLine($"Apellido: {existente.Persona.Apellido}");
    Console.WriteLine($"Edad: {existente.Persona.Edad}");
    Console.WriteLine($"Nacionalidad: {existente.Persona.Nacionalidad}");
    Console.WriteLine($"Documento: {existente.Persona.DocumentoIdentidad}");
    Console.WriteLine($"Género: {existente.Persona.Genero}");
    Console.WriteLine($"Rol: {existente.Rol}");
    Console.WriteLine($"Años Experiencia: {existente.AniosExperiencia}");
    Console.Write("¿Confirmar actualización? (S/N): ");

    var confirmacion = validate_data.ValidarBoleano(Console.ReadLine());

    if (confirmacion)
    {
      await _cuerpoTecnicoservice.ActualizarCuerpoTecnicoAsync(id, existente);
      Console.WriteLine("Cuerpo Técnico actualizado.");
      Console.ReadLine();
    }
    else
    {
      Console.WriteLine("Actualización cancelada.");
      Console.ReadLine();
    }
  }
  private async Task EliminarCuerpoTecnicoAsync()
  {
    Console.Write("ID a actualizar: ");
    int id = validate_data.ValidarEntero(Console.ReadLine());

    var existente = await _cuerpoTecnicoservice.ObtenerCuerpoTecnicoPorIdAsync(id);
    if (existente == null)
    {
      Console.WriteLine("Cuerpo tecnico no encontrado.");
      Console.ReadLine();
      return;
    }

    await _cuerpoTecnicoservice.EliminarCuerpoTecnicoAsync(id);
    Console.WriteLine("🗑️ Cuerpo tecnico eliminado.");
  }
  private async Task MostrarCuerposTecnicosAsync()
  {
    // TODO: tengo que revisar si esto esta bien por el nombre del servicio ya que son los mismos en el servicio, o no entiendo
    var cuerpo_tecnico = await _cuerpoTecnicoservice.MostrarCuerpoTecnicosAsync();
    if (!cuerpo_tecnico.Any())
    {
      Console.WriteLine("No hay países registrados.");
      return;
    }

    Console.WriteLine("Cuerpo Tecnicos:");
    foreach (var ct in cuerpo_tecnico)
    {
      if (ct is null) continue;
      Console.WriteLine($"ID: {ct.Id} | Nombre: {ct.Persona.Nombre} | Rol: {ct.Rol} | Años de experiencia: {ct.AniosExperiencia}");
    }
  }
  private async Task MostrarCuerpoTecnicoPorIdAsync()
  {
    Console.Write("ID a obtener: ");
    int id = validate_data.ValidarEntero(Console.ReadLine());

    var existente = await _cuerpoTecnicoservice.ObtenerCuerpoTecnicoPorIdAsync(id);
    if (existente == null)
    {
      Console.WriteLine("Cuerpo tecnico no encontrado.");
      Console.ReadLine();
      return;
    }

    var ct = await _cuerpoTecnicoservice.ObtenerCuerpoTecnicoPorIdAsync(id);
    if (ct is null)
    {
      Console.WriteLine("Cuerpo médico no encontrado.");
      return;
    }

    Console.WriteLine($"Cuerpo Médico: ID={ct.Id} | Nombre={ct.Persona?.Nombre} {ct.Persona?.Apellido} | Rol={ct.Rol} | Años de experiencia={ct.AniosExperiencia} | Nacionalidad={ct.Persona.Nacionalidad} | Documento={ct.Persona.DocumentoIdentidad}");
  }
  private async Task MostrarCuerpoTecnicoPorNombreAsync()
  {
    Console.Write("Nombre (o parte del nombre): ");
    var nombre = Console.ReadLine()?.Trim();

    if (string.IsNullOrWhiteSpace(nombre))
    {
      Console.WriteLine("Nombre inválido.");
      return;
    }
    var ct = await _cuerpoTecnicoservice.ObtenerCuerpoTecnicoPorNombreAsync(nombre);
    if (ct is null)
    {
      Console.WriteLine("Cuerpo médico no encontrado.");
      return;
    }
    Console.WriteLine($"Cuerpo Médico: ID={ct.Id} | Nombre={ct.Persona?.Nombre} {ct.Persona?.Apellido} | Rol={ct.Rol} | Años de experiencia={ct.AniosExperiencia} | Nacionalidad={ct.Persona?.Nacionalidad} | Documento={ct.Persona?.DocumentoIdentidad}");
    Console.ReadKey();
  }
  public async Task RegistrarCuerpoTecnicoAEquipoAsync()
  {
    Console.Write("ID cuerpo tecnico: ");
    int id_cuerpo_tecnico = validate_data.ValidarEntero(Console.ReadLine());

    Console.Write("ID equipo: ");
    int id_equipo = validate_data.ValidarEntero(Console.ReadLine());

    await _cuerpoTecnicoservice.RegistrarCuerpoTecnicoEquipoAsync(id_cuerpo_tecnico, id_equipo);
    Console.WriteLine("Cuerpo tecnico registrado.");
  }
  public async Task EliminarCuerpoTecnicoDeEquipoAsync()
  {
    Console.Write("ID cuerpo tecnico: ");
    int id_cuerpo_tecnico = validate_data.ValidarEntero(Console.ReadLine());

    Console.Write("ID equipo: ");
    int id_equipo = validate_data.ValidarEntero(Console.ReadLine());

    await _cuerpoTecnicoservice.EliminarCuerpoTecnicoEquipoAsync(id_cuerpo_tecnico, id_equipo);
    Console.WriteLine("Cuerpo tecnico eliminado.");
  }
}
