using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using persona.src.persona.ui;
using soccer_cs.src.modules.cuerpo_medico.application.interfaces;
using soccer_cs.src.modules.cuerpo_medico.application.services;
using soccer_cs.src.modules.cuerpo_medico.domain.models;
using soccer_cs.src.modules.cuerpo_medico.infrastructure.repositories;
using soccer_cs.src.shared.context;
using soccer_cs.src.shared.helpers;
using soccer_cs.src.shared.utils;

namespace soccer_cs.src.modules.cuerpo_medico.ui;

public class MenuCuerpoMedico
{
  private readonly Validaciones validate_data = new Validaciones();
  // esto con el fin de que se pueda acceder a la clase de servicio de cuerpo medico
  // private readonly CuerpoMedicoService _service = null!;
  private readonly CuerpoMedicoService _cuerpoMedicoService = null!;
  // esto se implemente con el fin de poder llamar a la clase de menu de persona para algunas funciones como el crear persona al ingresar un cuerpo medico
  private readonly MenuPersona _menuPersona = null!;
  // este codigo se hace con el fin de que cuando se ejecute el programa se pueda ve el menu de la aplicacion
  public MenuCuerpoMedico(AppDbContext _context)
  {
    var repo = new CuerpoMedicoRepository(_context);
    _cuerpoMedicoService = new CuerpoMedicoService(repo);
  }
    // se declara la variable que se va a utilizar para el menu principal
    private int opcionSeleccionada = 0;
    private AppDbContext context4;

    // se declara un arreglo de strings que contiene las opciones del menu principal
    private readonly string[] opcionesMenu =
  {
    "Crear cuerpo medico",
    "Actualizar cuerpo medico",
    "Eliminar cuerpo medico",
    "Mostrar todos los cuerpos medicos",
    "Buscar cuerpo medico por id",
    "Buscar cuerpo medico por nombre",
    "Registrar cuerpo medico a equipo",
    "Eliminar cuerpo medico de un equipo",
    "Regresar al menú principal"
  };
  // este es el metodo del menu principal en la consola con las flechas de arriba y abajo
  public void DibujarMenu()
  {
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("========== MENÚ CUERPO MEDICO ==========\n");
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
        await CrearCuerpoMedicoAsync();
        break;
      case 1:
        Console.Clear();
        await ActualizarCuerpoMedicoAsync();
        break;
      case 2:
        Console.Clear();
        await EliminarCuerpoMedicoAsync();
        break;
      case 3:
        Console.Clear();
        await MostrarTodosLosCuerposMedicosAsync();
        break;
      case 4:
        Console.Clear();
        await BuscarCuerpoMedicoPorIdAsync();
        break;
      case 5:
        Console.Clear();
        await BuscarCuerpoMedicoPorNombreAsync();
        break;
      case 6:
        Console.Clear();
        await RegistrarCuerpoMedicoAEquipoAsync();
        break;
      case 7:
        Console.Clear();
        await EliminarCuerpoMedicoDeEquipoAsync();
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
  private async Task CrearCuerpoMedicoAsync()
  {
    Console.Clear();
    Console.WriteLine("---- Registrar Cuerpo Medico ----");
    // Crear la persona primero y obtener su Id
    var persona = await _menuPersona.AgregarPersonaAsync();

    Console.Write("Especialidad: ");
    var especialidad = validate_data.ValidarTexto(Console.ReadLine());

    Console.Write("Anios de experiencia: ");
    var aniosExperiencia = validate_data.ValidarEntero(Console.ReadLine());

    // hacer que el id persona sea el ultimo id creado en la base de datos ya que al crear el cuerpo medico se crea una persona primero
    var id_persona = await DbContextFactory.Create().Personas.MaxAsync(p => p.Id);

    System.Console.WriteLine($"¿Desea registrar el cuerpo medico {especialidad} con {aniosExperiencia} anios de experiencia?");

    System.Console.WriteLine("Si presiona 'S' se creara, si presiona 'N' se cancelara: ");
    var opcion = validate_data.ValidarBoleano(Console.ReadLine());
    if (opcion == false) return;

    // agregar el nuevo cuerpo medico
    var cuerpo_medico = new CuerpoMedico
    {
      IdPersona = persona.Id,
      Especialidad = especialidad.Trim(),
      AniosExperiencia = aniosExperiencia
    };
    await _cuerpoMedicoService.AgregarCuerpoMedicoAsync(cuerpo_medico);
    Console.WriteLine("Cuerpo Medico creado.");
    Console.ReadLine();
  }
  private async Task ActualizarCuerpoMedicoAsync()
  {
    Console.Write("ID del cuerpo medico a actualizar: ");
    int id = validate_data.ValidarEntero(Console.ReadLine());

    var existente = await _cuerpoMedicoService.ObtenerCuerpoMedicoPorIdAsync(id);
    if (existente == null)
    {
      Console.WriteLine("Cuerpo medico no encontrado.");
      Console.ReadLine();
      return;
    }
    // en este caso no voy a hacer validate data de modo que si el usuario quiere mantener un dato, le de enter y lo deje como es
    Console.Write($"Nuevo nombre (actual: {existente.Persona.Nombre}), presiona enter para mantener el mismo nombre: ");
    var nuevoNombre = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(nuevoNombre))
      existente.Persona.Nombre = nuevoNombre;

    Console.Write($"Nuevo apellido (actual: {existente.Persona.Apellido}), presiona enter para mantener el mismo nombre: : ");
    var nuevoApellido = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(nuevoApellido))
      existente.Persona.Apellido = nuevoApellido;

    Console.Write($"Nueva edad (actual: {existente.Persona.Edad}), presiona enter para mantener el mismo nombre: : ");
    var nuevaEdadStr = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(nuevaEdadStr) && int.TryParse(nuevaEdadStr, out int nuevaEdad))
      existente.Persona.Edad = nuevaEdad;

    Console.Write($"Nueva nacionalidad (actual: {existente.Persona.Nacionalidad}), presiona enter para mantener el mismo nombre: : ");
    var nuevaNacionalidad = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(nuevaNacionalidad))
      existente.Persona.Nacionalidad = nuevaNacionalidad;

    Console.Write($"Nuevo documento identidad (actual: {existente.Persona.DocumentoIdentidad}), presiona enter para mantener el mismo nombre: : ");
    var nuevoDocStr = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(nuevoDocStr) && int.TryParse(nuevoDocStr, out int nuevoDoc))
      existente.Persona.DocumentoIdentidad = nuevoDoc;

    Console.Write($"Nuevo género (actual: {existente.Persona.Genero}), presiona enter para mantener el mismo nombre: : ");
    var nuevoGenero = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(nuevoGenero))
      existente.Persona.Genero = nuevoGenero;

    Console.Write($"Nueva especialidad (actual: {existente.Especialidad}), presiona enter para mantener el mismo nombre: : ");
    var nuevaEspecialidad = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(nuevaEspecialidad))
      existente.Especialidad = nuevaEspecialidad;

    Console.Write($"Años experiencia (actual: {existente.AniosExperiencia}), presiona enter para mantener el mismo nombre: : ");
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
    Console.WriteLine($"Especialidad: {existente.Especialidad}");
    Console.WriteLine($"Años Experiencia: {existente.AniosExperiencia}");
    Console.Write("¿Confirmar actualización? (S/N): ");

    var confirmacion = validate_data.ValidarBoleano(Console.ReadLine());

    if (confirmacion)
    {
      await _cuerpoMedicoService.ActualizarCuerpoMedicoAsync(id, existente);
      Console.WriteLine("Cuerpo medico actualizado.");
      Console.ReadLine();
    }
    else
    {
      Console.WriteLine("Actualización cancelada.");
      Console.ReadLine();
    }
  }
  private async Task EliminarCuerpoMedicoAsync()
  {
    Console.Write("ID a actualizar: ");
    int id = validate_data.ValidarEntero(Console.ReadLine());

    var existente = await _cuerpoMedicoService.ObtenerCuerpoMedicoPorIdAsync(id);
    if (existente == null)
    {
      Console.WriteLine("Cuerpo medico no encontrado.");
      Console.ReadLine();
      return;
    }

    await _cuerpoMedicoService.EliminarCuerpoMedicoAsync(id);
    Console.WriteLine("🗑️ Cuerpo medico eliminado.");
  }
  private async Task MostrarTodosLosCuerposMedicosAsync()
  {
    var cuerpo_medico = await _cuerpoMedicoService.MostrarCuerpoMedicosAsync();
    if (!cuerpo_medico.Any())
    {
      Console.WriteLine("No hay países registrados.");
      return;
    }

    Console.WriteLine("Cuerpo Medicos:");
    foreach (var cm in cuerpo_medico)
    {
      if (cm is null) continue;
      Console.WriteLine($"ID: {cm.IdPersona} | Nombre: {cm.Persona.Nombre} | Especialidad: {cm.Especialidad} | Años de experiencia: {cm.AniosExperiencia}");
    }
  }
  private async Task BuscarCuerpoMedicoPorIdAsync()
  {
    Console.Write("ID a obtener: ");
    int id = validate_data.ValidarEntero(Console.ReadLine());

    var existente = await _cuerpoMedicoService.ObtenerCuerpoMedicoPorIdAsync(id);
    if (existente == null)
    {
      Console.WriteLine("Cuerpo medico no encontrado.");
      Console.ReadLine();
      return;
    }

    var cm = await _cuerpoMedicoService.ObtenerCuerpoMedicoPorIdAsync(id);
    if (cm is null)
    {
      Console.WriteLine("Cuerpo médico no encontrado.");
      return;
    }

    Console.WriteLine($"Cuerpo Médico: ID={cm.Id} | Nombre={cm.Persona.Nombre} {cm.Persona.Apellido} | Especialidad={cm.Especialidad} | Años de experiencia={cm.AniosExperiencia} | Nacionalidad={cm.Persona.Nacionalidad} | Documento={cm.Persona.DocumentoIdentidad}");
  }
  private async Task BuscarCuerpoMedicoPorNombreAsync()
  {
    Console.Write("Nombre (o parte del nombre): ");
    var nombre = Console.ReadLine()?.Trim();

    if (string.IsNullOrWhiteSpace(nombre))
    {
      Console.WriteLine("Nombre inválido.");
      return;
    }
    var cm = await _cuerpoMedicoService.ObtenerCuerpoMedicoPorNombreAsync(nombre);
    if (cm is null)
    {
      Console.WriteLine("Cuerpo médico no encontrado.");
      return;
    }
    Console.WriteLine($"Cuerpo Médico: ID={cm.Id} | Nombre={cm.Persona.Nombre} {cm.Persona.Apellido} | Especialidad={cm.Especialidad} | Años de experiencia={cm.AniosExperiencia} | Nacionalidad={cm.Persona.Nacionalidad} | Documento={cm.Persona.DocumentoIdentidad}");
    Console.ReadKey();
  }
  private async Task RegistrarCuerpoMedicoAEquipoAsync()
  {
    Console.Write("ID cuerpo medico: ");
    int id_cuerpo_medico = validate_data.ValidarEntero(Console.ReadLine());

    Console.Write("ID equipo: ");
    int id_equipo = validate_data.ValidarEntero(Console.ReadLine());

    await _cuerpoMedicoService.RegistrarCuerpoMedicoEquipoAsync(id_cuerpo_medico, id_equipo);
    Console.WriteLine("Cuerpo medico registrado.");
  }
  private async Task EliminarCuerpoMedicoDeEquipoAsync()
  {
    Console.Write("ID cuerpo medico: ");
    int id_cuerpo_medico = validate_data.ValidarEntero(Console.ReadLine());

    Console.Write("ID equipo: ");
    int id_equipo = validate_data.ValidarEntero(Console.ReadLine());

    await _cuerpoMedicoService.EliminarCuerpoMedicoEquipoAsync(id_cuerpo_medico, id_equipo);
    Console.WriteLine("Cuerpo medico eliminado.");
  }
}
