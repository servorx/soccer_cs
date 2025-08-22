using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using soccer.src.modules.equipo.domain.models;
using soccer_cs.src.modules.cuerpo_medico.application.services;
using soccer_cs.src.modules.cuerpo_tecnico.application.services;
using soccer_cs.src.modules.cuerpo_tecnico.domain.models;
using soccer_cs.src.modules.equipo.application.services;
using soccer_cs.src.modules.equipo.infrastructure.repositories;
using soccer_cs.src.modules.equipo_jugador.domain.models;
using soccer_cs.src.modules.jugador.domain.models;
using soccer_cs.src.modules.persona.domain.models;
using soccer_cs.src.modules.torneo.application.services;
using soccer_cs.src.shared.context;
using soccer_cs.src.shared.helpers;
using soccer_cs.src.shared.utils;

namespace soccer_cs.src.modules.equipo.ui;

public class MenuEquipo
{
  private readonly Validaciones validate_data = new Validaciones();
  // esto con el fin de que se pueda acceder a la clase de servicio de equipo, cuerpo medico y torneos
  readonly EquipoService _equipoService = null!;
  readonly CuerpoMedicoService _cuerpoMedicoService = null!;
  readonly CuerpoTecnicoService _cuerpoTecnicoService = null!;
  readonly TorneoService _torneoService = null!;
  // este codigo se hace con el fin de que cuando se ejecute el programa se pueda ve el menu de la aplicacion
  public MenuEquipo(AppDbContext _context)
  {
    var repo = new EquipoRepository(_context);
    _equipoService = new EquipoService(repo);
  }
  // se declara la variable que se va a utilizar para el menu principal
  private int opcionSeleccionada = 0;
  // se declara un arreglo de strings que contiene las opciones del menu principal
  private readonly string[] opcionesMenu =
  {
    "Crear equipo",
    "Actualizar equipo",
    "Eliminar equipo",
    "Mostrar todos los equipos",
    "Buscar equipo por id",
    "Buscar equipo por nombre",
    "Buscar jugadores por equipo",
    "Registrar cuerpo tecnico a equipo",
    "Registrar cuerpo medico a equipo",
    "Registrar jugadores a equipo",
    "Inscribir equipo a torneo",
    "Desvincular equipo de torneo",
    "Regresar al menú principal"
  };
  // este es el metodo del menu principal en la consola con las flechas de arriba y abajo
  public void DibujarMenu()
  {
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("========== MENÚ EQUIPO ==========\n");
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
        await CrearEquipoAsync();
        break;
      case 1:
        Console.Clear();
        await ActualizarEquipoAsync();
        break;
      case 2:
        Console.Clear();
        await EliminarEquipoAsync();
        break;
      case 3:
        Console.Clear();
        await MostrarEquiposAsync();
        break;
      case 4:
        Console.Clear();
        await BuscarEquipoPorIdAsync();
        break;
      case 5:
        Console.Clear();
        await BuscarEquipoPorNombreAsync();
        break;
      case 6:
        Console.Clear();
        await BuscarJugadoresPorEquipoAsync();
        break;
      case 7:
        Console.Clear();
        await RegistrarCuerpoMedicoEnEquipoAsync();
        break;
      case 8:
        Console.Clear();
        await RegistrarCuerpoTecnicoEnEquipoAsync();
        break;
      case 9:
        Console.Clear();
        await InscribirEquipoaTorneoAsync();
        break;
      case 10:
        Console.Clear();
        await DesinscribirEquipoATorneoAsync();
        break;
      case 11:
        return false;
      default:
        Console.Clear();
        Console.WriteLine("error al ingresar dato, intentelo de nuevo");
        Console.ReadLine();
        return false;
    }
    return true;
  }
  private async Task CrearEquipoAsync()
  {
    Console.Clear();
    Console.WriteLine("---- Registrar equipo ----");
    Console.Write("Nombre del equipo: ");
    var nombre = validate_data.ValidarTexto(Console.ReadLine());

    Console.Write("Ciudad del equipo: ");
    var ciudad = validate_data.ValidarTexto(Console.ReadLine());

    Console.Write("Pais del equipo: ");
    var pais = validate_data.ValidarTexto(Console.ReadLine());

    Console.Write("nombre del estadio del equipo: ");
    var estadio = validate_data.ValidarTexto(Console.ReadLine());

    Console.Write("Tipo de equipo (seleccion, club): "); 
    var tipo_equipo = validate_data.ValidarTexto(Console.ReadLine());

    Console.Write("Cantidad de títulos: ");
    var cantidad_titulos = validate_data.ValidarEntero(Console.ReadLine());
  

    Console.WriteLine($"¿Desea registrar el equipo con los siguientes datos introducidos?: ");
    Console.WriteLine($"Nombre: {nombre}");
    Console.WriteLine($"Ciudad: {ciudad}");
    Console.WriteLine($"Pais: {pais}");
    Console.WriteLine($"Estadio: {estadio}");
    Console.WriteLine($"Tipo de equipo: {tipo_equipo}");
    Console.WriteLine($"Cantidad de títulos: {cantidad_titulos}");

    Console.WriteLine("Si presiona 'S' se creara, si presiona 'N' se cancelara: ");
    var opcion = validate_data.ValidarBoleano(Console.ReadLine());
    if (opcion == false) return;
    var equipo = new Equipo
    {
      Nombre = nombre,
      Ciudad = ciudad,
      Pais = pais,
      Estadio = estadio,
      TipoEquipo = tipo_equipo,
      CantidadTitulos = cantidad_titulos
    };
    // agregar el nuevo equipo
    await _equipoService.AgregarEquipoAsync(equipo);
    Console.WriteLine("Equipo creado.");
  }
  private async Task ActualizarEquipoAsync()
  {
    // primero muestra todos los equipos disponibles 
    Console.Write("ID a actualizar: ");
    int id = validate_data.ValidarEntero(Console.ReadLine());

    var existente = await _equipoService.ObtenerEquipoPorIdAsync(id);
    if (existente == null)
    {
      Console.WriteLine("Equipo no encontrado.");
      Console.ReadLine();
      return;
    }
    // en este caso no voy a hacer validate data de modo que si el usuario quiere mantener un dato, le de enter y lo deje como es
    Console.Write($"Nuevo nombre del equipo (actual: {existente.Nombre}), presiona enter para mantener el mismo nombre: ");
    var nuevoNombreStr = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(nuevoNombreStr))
      existente.Nombre = nuevoNombreStr;

    Console.Write($"Nueva ciudad de origen del equipo (actual: {existente.Ciudad}), presiona enter para mantener la misma ciudad: "); 
    var nuevoCiudadStr = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(nuevoCiudadStr))
      existente.Ciudad = nuevoCiudadStr;

    Console.Write($"Nuevo pais de origen del equipo (actual: {existente.Pais}), presiona enter para mantener el mismo pais: ");
    var nuevoPaisStr = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(nuevoPaisStr))
      existente.Pais = nuevoPaisStr;
    //   Console.Write($"Nuevo pais de origen del equipo (actual: {existente.Pais}), presiona enter para mantener el mismo pais: : ");
    // var nuevoPaisStr = Console.ReadLine();
    // if (!string.IsNullOrWhiteSpace(nuevaEdadStr) && int.TryParse(nuevaEdadStr, out int nuevaEdad))
    //   existente.Pais = nuevaEdad;

    Console.Write($"Nuevo estadio del equipo (actual: {existente.Estadio}), presiona enter para mantener el mismo estadio: "); 
    var nuevoEstadioStr = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(nuevoEstadioStr))
      existente.Estadio = nuevoEstadioStr;

    Console.Write($"Nuevo tipo de equipo (actual: {existente.TipoEquipo}), presiona enter para mantener el mismo tipo de equipo: ");
    var nuevoTipoEquipoStr = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(nuevoTipoEquipoStr))
      existente.TipoEquipo = nuevoTipoEquipoStr;

    Console.Write($"Nueva cantidad de titulos (actual: {existente.CantidadTitulos}), presiona enter para mantener la misma cantidad de titulos: ");
    var nuevoCantidadTitulosStr = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(nuevoCantidadTitulosStr) && int.TryParse(nuevoCantidadTitulosStr, out int nuevoCantidadTitulos))
      existente.CantidadTitulos = nuevoCantidadTitulos;

    // Mostrar resumen de los nuevos datos
    Console.WriteLine("\n--- Confirmar Actualización ---");
    Console.WriteLine($"Nombre: {existente.Nombre}");
    Console.WriteLine($"Ciudad: {existente.Ciudad}");
    Console.WriteLine($"País: {existente.Pais}");
    Console.WriteLine($"Estadio: {existente.Estadio}");
    Console.WriteLine($"Tipo de equipo: {existente.TipoEquipo}");
    Console.WriteLine($"Cantidad de titulos: {existente.CantidadTitulos}");
    Console.Write("¿Confirmar actualización? (S/N): ");

    var confirmacion = validate_data.ValidarBoleano(Console.ReadLine());

    if (confirmacion)
    {
      await _equipoService.ActualizarEquipoAsync(id, existente);
      Console.WriteLine("País actualizado.");
      Console.ReadLine();
    }
    else
    {
      Console.WriteLine("Actualización cancelada.");
      Console.ReadLine();
    }
  }
  private async Task EliminarEquipoAsync()
  {
    Console.Write("ID a actualizar: ");
    int id = validate_data.ValidarEntero(Console.ReadLine());

    var existente = await _equipoService.ObtenerEquipoPorIdAsync(id);
    if (existente == null)
    {
      Console.WriteLine("Equipo no encontrado.");
      Console.ReadLine();
      return;
    }

    await _equipoService.EliminarEquipoAsync(id);
    Console.WriteLine("🗑️ Equipo eliminado.");
  }
  private async Task MostrarEquiposAsync()
  {
    var equipo = await _equipoService.MostrarEquiposAsync();
    if (!equipo.Any())
    {
      Console.WriteLine("No hay Equipos registrados.");
      return;
    }

    Console.WriteLine("Equipos:");
    foreach (var e in equipo)
    {
      if (e is null) continue;
      Console.WriteLine($"ID: {e.Id} | Nombre: {e.Nombre} | Ciudad: {e.Ciudad} | País: {e.Pais} | Estadio: {e.Estadio} | Tipo de equipo: {e.TipoEquipo} | Cantidad de titulos: {e.CantidadTitulos}");
    }
  }
  private async Task BuscarEquipoPorIdAsync()
  {
    // mostrar todos los equpos disponibles
    await MostrarEquiposAsync();
    Console.Write("ID a obtener: ");
    int id = validate_data.ValidarEntero(Console.ReadLine());

    var e = await _equipoService.ObtenerEquipoPorIdAsync(id);
    if (e is null)
    {
      Console.WriteLine("Equipo no encontrado.");
      return;
    }

    Console.WriteLine($"Equipo: ID{e.Id} | Nombre={e.Nombre}| Ciudad={e.Ciudad} | País={e.Pais} | Estadio={e.Estadio} | Tipo de equipo={e.TipoEquipo} | Cantidad de titulos={e.CantidadTitulos}");
  }
  private async Task BuscarEquipoPorNombreAsync()
  {
    // mostrar todos los equpos disponibles
    await MostrarEquiposAsync();
    Console.Write("Nombre (o parte del nombre) del equipo: ");
    var nombre = Console.ReadLine()?.Trim();

    if (string.IsNullOrWhiteSpace(nombre))
    {
      Console.WriteLine("Nombre inválido.");
      return;
    }
    var e = await _equipoService.ObtenerEquipoPorNombreAsync(nombre);
    if (e is null)
    {
      Console.WriteLine("Equipo no encontrado.");
      return;
    }
    Console.WriteLine($"Equipo: ID{e.Id} | Nombre={e.Nombre}| Ciudad={e.Ciudad} | País={e.Pais} | Estadio={e.Estadio} | Tipo de equipo={e.TipoEquipo} | Cantidad de titulos={e.CantidadTitulos}");
    Console.ReadKey();
  }
  private async Task BuscarJugadoresPorEquipoAsync()
  {
    // muestra los equipos disponibles
    await MostrarEquiposAsync();
    Console.Write("ID del equipo: ");
    int id_equipo = validate_data.ValidarEntero(Console.ReadLine());

    var equipoJugadores = await _equipoService.ObtenerJugadoresPorEquipoAsync(id_equipo);
    if (equipoJugadores == null || !equipoJugadores.Any())
    {
      Console.WriteLine("Jugadores no encontrados.");
      return;
    }

    Console.WriteLine("Jugadores:");
    foreach (var ej in equipoJugadores)
    {
      if (ej?.EquipoJugadors == null) continue;

      foreach (var jugadorEquipo in ej.EquipoJugadors)
      {
        var jugador = jugadorEquipo.Jugador;
        var persona = jugador?.Persona;

        Console.WriteLine(
          $"JugadorID: {jugador?.Id} | Nombre: {persona?.Nombre} {persona?.Apellido} | Edad: {persona?.Edad} | Nacionalidad: {persona?.Nacionalidad}"
        );
      }
    }

    Console.WriteLine("Presione una tecla para continuar...");
    Console.ReadLine();
  }
  private async Task RegistrarCuerpoMedicoEnEquipoAsync()
  {
    // mostrar todos los equipos disponibles
    await MostrarEquiposAsync();
    Console.Write("ID del equipo: ");
    int id_equipo = validate_data.ValidarEntero(Console.ReadLine());

    // mostrar todos los cuerpos medicos disponibles
    await _cuerpoMedicoService.MostrarCuerpoMedicosAsync();
    Console.Write("ID del cuerpo medico: ");
    int id_cuerpo_medico = validate_data.ValidarEntero(Console.ReadLine());

    await _cuerpoMedicoService.RegistrarCuerpoMedicoEquipoAsync(id_equipo, id_cuerpo_medico);
    Console.WriteLine("Cuerpo medico registrado.");
    Console.WriteLine("Presione una tecla para continuar...");
    Console.ReadLine();
  }
  private async Task RegistrarCuerpoTecnicoEnEquipoAsync()
  {
    // mostrar todos los equipos disponibles
    await MostrarEquiposAsync();
    Console.Write("ID del equipo: ");
    int id_equipo = validate_data.ValidarEntero(Console.ReadLine());

    // mostrar todos los cuerpos tecnicos disponibles
    await _cuerpoTecnicoService.MostrarCuerpoTecnicosAsync();
    Console.Write("ID del cuerpo tecnico: ");
    int id_cuerpo_tecnico = validate_data.ValidarEntero(Console.ReadLine());

    await _cuerpoTecnicoService.RegistrarCuerpoTecnicoEquipoAsync(id_equipo, id_cuerpo_tecnico);
    Console.WriteLine("Cuerpo tecnico registrado.");
    Console.WriteLine("Presione una tecla para continuar...");
    Console.ReadLine();
  }
  private async Task InscribirEquipoaTorneoAsync()
  {
    // mostrar todos los equipos disponibles
    await MostrarEquiposAsync();
    Console.Write("ID equipo: ");
    int id_equipo = validate_data.ValidarEntero(Console.ReadLine());

    // mostrar todos los torneos disponibles
    await _torneoService.MostrarTorneosAsync();
    Console.Write("ID torneo: ");
    int id_torneo = validate_data.ValidarEntero(Console.ReadLine());

    await _torneoService.RegistrarEquipoATorneoAsync(id_equipo, id_torneo);
    Console.WriteLine("Equipo inscrito.");
  }
  private async Task DesinscribirEquipoATorneoAsync()
  {
    // mostrar todos los equipos disponibles
    await MostrarEquiposAsync(); 
    Console.Write("ID equipo: ");
    int id_equipo = validate_data.ValidarEntero(Console.ReadLine());

    // mostrar todos los torneos disponibles
    await _torneoService.MostrarTorneosAsync();
    Console.Write("ID torneo: ");
    int id_torneo = validate_data.ValidarEntero(Console.ReadLine());

    await _torneoService.EliminarEquipoATorneoAsync(id_equipo, id_torneo);
    Console.WriteLine("Equipo desinscrito.");
  }
}
