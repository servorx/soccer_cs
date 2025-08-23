using System.Data;
using System.Runtime.CompilerServices;
using persona.src.persona.ui;
using soccer_cs.src.modules.equipo.application.services;
using soccer_cs.src.modules.torneo.application.services;
using soccer_cs.src.modules.torneo.domain.models;
using soccer_cs.src.modules.torneo.infrastructure.repositories;
using soccer_cs.src.shared.context;
using soccer_cs.src.shared.utils;

namespace soccer_cs.src.modules.torneo.ui;

public class MenuTorneo
{
  private readonly Validaciones validate_data = new Validaciones();
  // esto con el fin de que se pueda acceder a la clase de servicio de cuerpo medico
  private readonly TorneoService _torneoService = null!;
  private readonly EquipoService _equipoService = null!;
  // este codigo se hace con el fin de que cuando se ejecute el programa se pueda ve el menu de la aplicacion
  public MenuTorneo(AppDbContext _context)
  {
    var repo = new TorneoRepository(_context);
    _torneoService = new TorneoService(repo);
  }
  // se declara la variable que se va a utilizar para el menu principal
  private int opcionSeleccionada = 0;
  // se declara un arreglo de strings que contiene las opciones del menu principal
  private readonly string[] opcionesMenu =
  {
    "Crear torneo",
    "Actualizar torneo",
    "Eliminar torneo",
    "Mostrar todos los torneos",
    "Buscar torneo por id",
    "Buscar torneo por nombre",
    "Registrar equipo a torneo",
    "Eliminar equipo de torneo",
    "Regresar al menú principal"
  };
  // este es el metodo del menu principal en la consola con las flechas de arriba y abajo
  public void DibujarMenu()
  {
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("========== MENÚ TORNEO ==========\n");
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
        await CrearTorneoAsync();
        break;
      case 1:
        Console.Clear();
        await ActualizarTorneoAsync();
        break;
      case 2:
        Console.Clear();
        await EliminarTorneoAsync();
        break;
      case 3:
        Console.Clear();
        await MostrarTodosLosTorneosAsync();
        break;
      case 4:
        Console.Clear();
        await BuscarTorneoPorIdAsync();
        break;
      case 5:
        Console.Clear();
        await BuscarTorneoPorNombreAsync();
        break;
      case 6:
        Console.Clear();
        await RegistrarEquiposATorneoAsync();
        break;
      case 7:
        Console.Clear();
        await EliminarEquipoATorneoAsync();
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
  private async Task CrearTorneoAsync()
  {
    Console.Clear();
    Console.WriteLine("---- Registrar Torneo ----");
    // primero se piden los datos del torneo sin equipos 
    Console.Write("Nombre del torneo: ");
    var nombre_torneo = validate_data.ValidarTexto(Console.ReadLine());

    Console.Write("Tipo de torneo (liga o torneo): ");
    var tipo_torneo = validate_data.ValidarTexto(Console.ReadLine());

    Console.Write("ingrese la ubicacion del torneo: ");
    var ubicacion_torneo = validate_data.ValidarTexto(Console.ReadLine());

    Console.Write("Fecha de inicio: ");
    var fecha_inicio = validate_data.ValidarFecha(Console.ReadLine());

    Console.Write("Fecha de finalizacion: ");
    var fecha_final = validate_data.ValidarFecha(Console.ReadLine());

    Console.Write("Premio del torneo: ");
    var premio_torneo = validate_data.ValidarFloat(Console.ReadLine());

    // verifica si el usuario quiere confirmar los cambios
    Console.Clear();
    Console.WriteLine("Datos ingresados: \n");
    Console.WriteLine($"Nombre: {nombre_torneo}");
    Console.WriteLine($"Tipo: {tipo_torneo}");
    Console.WriteLine($"Ubicacion: {ubicacion_torneo}");
    Console.WriteLine($"Fecha de inicio: {fecha_inicio}");
    Console.WriteLine($"Fecha de finalizacion: {fecha_final}");
    Console.WriteLine($"Premio: {premio_torneo}");
    Console.Write("¿Desea registrar el torneo con los datos introducidos? (S/N): ");
    var opcion = validate_data.ValidarBoleano(Console.ReadLine());
    if (opcion == false)
    { 
      Console.WriteLine("Registro cancelado.");
      Console.ReadLine();
      return;
    }

    // se crea el nuevo torneo
    var torneo = new Torneo
    {
      Nombre = nombre_torneo,
      Tipo = tipo_torneo,
      Ubicacion = ubicacion_torneo,
      FechaInicio = fecha_inicio,
      FechaFinal = fecha_final,
      Premio = premio_torneo
    };
    await _torneoService.AgregarTorneoAsync(torneo);
    Console.WriteLine("Torneo creado exitosamente.");
    Console.WriteLine("Presiona enter para continuar...");
    Console.ReadLine();
  }
  private async Task ActualizarTorneoAsync()
  {
    Console.Clear();
    Console.WriteLine("---- Actualizar Torneo ----");
    Console.WriteLine("Torneos Disponibles:\n");
    await _torneoService.MostrarTorneosAsync();
    Console.Write("ingrese el ID del torneo a actualizar: ");
    int id = validate_data.ValidarEntero(Console.ReadLine());

    var existente = await _torneoService.ObtenerTorneoPorIdAsync(id);
    if (existente == null)
    {
      Console.WriteLine("Cuerpo medico no encontrado.");
      Console.ReadLine();
      return;
    }
    // en este caso no voy a hacer validate data de modo que si el usuario quiere mantener un dato, le de enter y lo deje como es
    Console.Write($"Nuevo nombre del torneo (actual: {existente.Nombre}), presiona enter para mantener el mismo nombre: ");
    var nuevoNombreStr = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(nuevoNombreStr))
      existente.Nombre = nuevoNombreStr;

    Console.Write($"Nuevo tipo de torneo (actual: {existente.Tipo}), presiona enter para mantener el tipo de torneo: ");
    var nuevoTipoStr = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(nuevoTipoStr))
      existente.Tipo = nuevoTipoStr;

    Console.Write($"Nueva fecha de inicio de torneo (actual: {existente.FechaInicio}), presiona enter para mantener la misma fecha de inicio: ");
    var nuevoFechaInicioStr = Console.ReadLine();
    if (!string.IsNullOrEmpty(nuevoFechaInicioStr))
    {
      if (DateTime.TryParse(nuevoFechaInicioStr, out var nuevoFechaInicio))
        existente.FechaInicio = nuevoFechaInicio;
      else
        Console.WriteLine("⚠️ Formato de fecha inválido, se conserva la actual.");
      Console.ReadLine();
    }

    Console.Write($"Nueva fecha de finalizacion de torneo (actual: {existente.FechaFinal}), presiona enter para mantener la misma fecha de finalizacion: ");
    var nuevoFechaFinalStr = Console.ReadLine();
    if (!string.IsNullOrEmpty(nuevoFechaFinalStr))
    {
      if (DateTime.TryParse(nuevoFechaFinalStr, out var nuevoFechaFinal))
        existente.FechaInicio = nuevoFechaFinal;
      else
        Console.WriteLine("⚠️ Formato de fecha inválido, se conserva la actual.");
      Console.ReadLine();
    }

    Console.Write($"Nuevo premio del torneo (actual: {existente.Premio}), presiona enter para mantener el mismo premio: ");
    var nuevoPremioStr = Console.ReadLine();
    if (!string.IsNullOrEmpty(nuevoPremioStr))
    {
      if (float.TryParse(nuevoPremioStr, out var nuevoPremio))
        existente.Premio = nuevoPremio;
      else
        Console.WriteLine("⚠️ Formato de dato flotante inválido, se conserva la actual.");
      Console.WriteLine("presione enter para continuar");
      Console.ReadLine();
    }

    // Mostrar resumen de los nuevos datos
    Console.WriteLine("\n--- Confirmar Actualización del Torneo ---");
    Console.WriteLine($"Nombre: {existente.Nombre}");
    Console.WriteLine($"Tipo: {existente.Tipo}");
    Console.WriteLine($"Ubicación: {existente.Ubicacion}");
    Console.WriteLine($"Fecha de Inicio: {existente.FechaInicio}");
    Console.WriteLine($"Fecha de Finalización: {existente.FechaFinal}");
    Console.WriteLine($"Premio: {existente.Premio}");
    Console.Write("¿Desea confirmar la actualización del torneo? (S/N): ");
    var confirmacion = validate_data.ValidarBoleano(Console.ReadLine());

    if (confirmacion)
    {
      await _torneoService.ActualizarTorneoAsync(id, existente);
      Console.WriteLine("Torneo actualizado exitosamente.");
      Console.ReadLine();
    }
    else
    {
      Console.WriteLine("Actualización cancelada.");
      Console.ReadLine();
    }
  }
  private async Task EliminarTorneoAsync()
  {
    // mostrar los torneos registrados
    await MostrarTodosLosTorneosAsync();
    Console.Write("ID de torneo a actualizar: ");
    int id = validate_data.ValidarEntero(Console.ReadLine());

    var existente = await _torneoService.ObtenerTorneoPorIdAsync(id);
    if (existente == null)
    {
      Console.WriteLine("Torneo no encontrado.");
      Console.ReadLine();
      return;
    }

    await _torneoService.EliminarTorneoAsync(id);
    Console.WriteLine("🗑️ Torneo eliminado.");
  }
  private async Task MostrarTodosLosTorneosAsync()
  {
    var torneos = await _torneoService.MostrarTorneosAsync();
    if (!torneos.Any())
    {
      Console.WriteLine("No hay torneos registrados.");
      return;
    }

    Console.WriteLine("Torneos registrados:");
    foreach (var t in torneos)
    {
      // si el torneo actual es null, continua con el siguiente
      if (t is null) continue;
      Console.WriteLine($"ID: {t.Id} | Nombre: {t.Nombre} | Tipo: {t.Tipo} | Ubicacion: {t.Ubicacion} | Fecha de inicio: {t.FechaInicio} | Fecha de finalizacion: {t.FechaFinal} | Premio: {t.Premio}");
    }
  }
  private async Task BuscarTorneoPorIdAsync()
  {
    Console.Write("escribe el ID del torneo a obtener: ");
    int id = validate_data.ValidarEntero(Console.ReadLine());

    var t = await _torneoService.ObtenerTorneoPorIdAsync(id);
    if (t == null)
    {
      Console.WriteLine("Torneo no encontrado.");
      Console.ReadLine();
      return;
    }

    Console.WriteLine($"Torneo: ID={t.Id} | Nombre={t.Nombre} | Tipo={t.Tipo} | Ubicacion={t.Ubicacion} | Fecha de inicio={t.FechaInicio} | Fecha de finalizacion={t.FechaFinal} | Premio={t.Premio}");
  }
  private async Task BuscarTorneoPorNombreAsync()
  {
    Console.Write("Nombre (o parte del nombre) del torneo a obtener: ");
    var nombre = validate_data.ValidarTexto(Console.ReadLine())?.Trim();

    // todo: arreglar de alguna forma esta advertencia
    var t = await _torneoService.ObtenerTorneoPorNombreAsync(nombre);
    if (t is null)
    {
      Console.WriteLine("Torneo no encontrado.");
      return;
    }
    Console.WriteLine($"Torneo: ID={t.Id} | Nombre={t.Nombre} | Tipo={t.Tipo} | Ubicacion={t.Ubicacion} | Fecha de inicio={t.FechaInicio} | Fecha de finalizacion={t.FechaFinal} | Premio={t.Premio}");
  }
  private async Task RegistrarEquiposATorneoAsync()
  {
    Console.Clear();
    Console.Write("Escribe el ID del torneo a registrar: ");
    int id = validate_data.ValidarEntero(Console.ReadLine());

    var existente = await _torneoService.ObtenerTorneoPorIdAsync(id);
    if (existente == null)
    {
      Console.WriteLine("Torneo no encontrado.");
      Console.ReadLine();
      return;
    }

    Console.Write("Escribe el ID del equipo a registrar: ");
    int id_equipo = validate_data.ValidarEntero(Console.ReadLine());

    var equipo = await _equipoService.ObtenerEquipoPorIdAsync(id_equipo);
    if (equipo == null)
    {
      Console.WriteLine("Equipo no encontrado.");
      Console.ReadLine();
      return;
    }

    await _torneoService.RegistrarEquipoATorneoAsync(id, id_equipo);
    Console.WriteLine("Equipo registrado exitosamente.");
    Console.WriteLine("Presiona enter para continuar...");
    Console.ReadLine();
  }
  private async Task EliminarEquipoATorneoAsync()
  { 
    Console.Clear();
    Console.Write("Escribe el ID del torneo a eliminar: ");
    int id = validate_data.ValidarEntero(Console.ReadLine());

    var existente = await _torneoService.ObtenerTorneoPorIdAsync(id);
    if (existente == null)
    {
      Console.WriteLine("Torneo no encontrado.");
      Console.ReadLine();
      return;
    }

    Console.Write("Escribe el ID del equipo a eliminar: ");
    int id_equipo = validate_data.ValidarEntero(Console.ReadLine());

    var equipo = await _equipoService.ObtenerEquipoPorIdAsync(id_equipo);
    if (equipo == null)
    {
      Console.WriteLine("Equipo no encontrado.");
      Console.ReadLine();
      return;
    }

    await _torneoService.EliminarEquipoATorneoAsync(id, id_equipo);
    Console.WriteLine("Equipo eliminado exitosamente.");
    Console.WriteLine("Presiona enter para continuar...");
    Console.ReadLine();
  }
}
