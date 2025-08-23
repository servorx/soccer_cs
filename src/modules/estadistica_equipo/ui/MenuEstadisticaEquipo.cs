using System;
using soccer_cs.src.modules.equipo.application.services;
using soccer_cs.src.modules.estadistica_equipo.application.interfaces;
using soccer_cs.src.modules.estadistica_equipo.application.services;
using soccer_cs.src.modules.estadistica_equipo.domain.models;
using soccer_cs.src.modules.estadistica_equipo.infrastructure.repositories;
using soccer_cs.src.modules.jugador.application.services;
using soccer_cs.src.shared.context;
using soccer_cs.src.shared.utils;

namespace soccer_cs.src.modules.estadistica_equipo.ui;

public class MenuEstadisticaEquipo
{
  private readonly Validaciones validate_data = new Validaciones();
  // esto con el fin de que se pueda acceder a la clase de servicio de cuerpo medico
  // private readonly EstadisticaEquipoService _service = null!;
  private readonly EstadisticaEquipoService _estadisticaEquipoService;
  private readonly EquipoService _equipoService = null!; 
  // este codigo se hace con el fin de que cuando se ejecute el programa se pueda ve el menu de la aplicacion
  public MenuEstadisticaEquipo(AppDbContext _context)
  {
    var repo = new EstadisticaEquipoRepository(_context);
    _estadisticaEquipoService = new EstadisticaEquipoService(repo);
  }
  // se declara la variable que se va a utilizar para el menu principal
  private int opcionSeleccionada = 0;
  // se declara un arreglo de strings que contiene las opciones del menu principal
  private readonly string[] opcionesMenu =
  {
    "Crear estadistica equipo",
    "Actualizar estadistica equipo",
    "Eliminar estadistica equipo",
    "Mostrar todas las estadisticas de equipos",
    "Buscar estadistica equipo por id",
    "Regresar al menú principal"
  };
  // este es el metodo del menu principal en la consola con las flechas de arriba y abajo
  public void DibujarMenu()
  {
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("========== MENÚ ESTADÍSTICA EQUIPO ==========\n");
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
        await CrearEstadisticaEquipoAsync();
        break;
      case 1:
        Console.Clear();
        await ActualizarEstadisticaEquipoAsync();
        break;
      case 2:
        Console.Clear();
        await EliminarEstadisticaEquipoAsync();
        break;
      case 3:
        Console.Clear();
        await MostrarTodasLasEstadisticasEquiposAsync();
        break;
      case 4:
        Console.Clear();
        await BuscarEstadisticaEquipoPorIdAsync();
        break;
      case 5:
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
  private async Task CrearEstadisticaEquipoAsync()
  {
    Console.Clear();
    Console.WriteLine("---- Registrar Estadistica Equipo ----");
    // primero mostrar los jugadores existentes para escoger uno al que se le van a agregar las estadisticas
    await _equipoService.MostrarEquiposAsync();
    Console.Write("Escoja el id de un Equipo: ");
    int id_equipo = validate_data.ValidarEntero(Console.ReadLine());

    Console.WriteLine("Partidos jugados del equipo: ");
    int partidos_jugados = validate_data.ValidarEntero(Console.ReadLine());

    Console.WriteLine("Partidos ganados del equipo: ");
    int partidos_ganados = validate_data.ValidarEntero(Console.ReadLine());

    Console.WriteLine("Partidos empatados del equipo: ");
    int partidos_empatados = validate_data.ValidarEntero(Console.ReadLine());

    Console.WriteLine("Partidos perdidos del equipo: ");
    int partidos_perdidos = validate_data.ValidarEntero(Console.ReadLine());

    Console.WriteLine("Goles a favor del equipo: ");
    int goles_favor = validate_data.ValidarEntero(Console.ReadLine());

    Console.WriteLine("Goles en contra del equipo: ");
    int goles_contra = validate_data.ValidarEntero(Console.ReadLine());

    // crear la estadistica de equipo
    var estadistica = new EstadisticaEquipo
    {
      IdEquipo = id_equipo,
      PartidosJugados = partidos_jugados,
      PartidosGanados = partidos_ganados,
      PartidosEmpatados = partidos_empatados,
      PartidosPerdidos = partidos_perdidos,
      GolesAFavor = goles_favor,
      GolesEnContra = goles_contra,
    };
    // guardar la estadistica de jugador
    await _estadisticaEquipoService.AgregarEstadisticaEquipoAsync(estadistica);
    Console.WriteLine("Estadistica de jugador creada.");
    Console.ReadLine();
  }
  private async Task ActualizarEstadisticaEquipoAsync()
  {
    // ingresar id de la estadistica a actualizar
    Console.Clear();
    Console.WriteLine("---- Actualizar Estadistica de equipo ----");
    Console.WriteLine("Estadisticas diponibles:\n");
    await _estadisticaEquipoService.MostrarEstadisticaEquiposAsync();
    Console.Write("ingrese el ID de la estadistica a actualizar: ");
    int id_estadistica = validate_data.ValidarEntero(Console.ReadLine());

    var existente = await _estadisticaEquipoService.ObtenerEstadisticaEquipoPorIdAsync(id_estadistica);
    if (existente == null)
    {
      Console.WriteLine("Estadistica de jugador no encontrada.");
      Console.ReadLine();
      return;
    }
    // en este caso no voy a hacer validate data de modo que si el usuario quiere mantener un dato, le de enter y lo deje como es
    Console.Write($"Nueva cantidad de partidos jugados (actual: {existente.PartidosJugados}), presiona enter para mantener la misma cantidad de partidos jugados: "); 
    var nuevoPartidosJugadosStr = Console.ReadLine();
    if (!string.IsNullOrEmpty(nuevoPartidosJugadosStr))
    {
      if (int.TryParse(nuevoPartidosJugadosStr, out var nuevoPartidosJugados))
        existente.PartidosJugados = nuevoPartidosJugados;
      else
        Console.WriteLine("⚠️ Formato de dato entero inválido, se conserva la actual.");
      Console.WriteLine("presione enter para continuar");
      Console.ReadLine();
    }

    Console.Write($"Nueva cantidad de partidos ganados (actual: {existente.PartidosGanados}), presiona enter para mantener la misma cantidad de partidos ganados: "); 
    var nuevoPartidosGanadosStr = Console.ReadLine();
    if (!string.IsNullOrEmpty(nuevoPartidosGanadosStr))
    {
      if (int.TryParse(nuevoPartidosGanadosStr, out var nuevoPartidosGanados))
        existente.PartidosGanados = nuevoPartidosGanados;
      else
        Console.WriteLine("⚠️ Formato de dato entero inválido, se conserva la actual.");
      Console.WriteLine("presione enter para continuar");
      Console.ReadLine();
    }

    Console.Write($"Nueva cantidad de partidos empatados (actual: {existente.PartidosGanados}), presiona enter para mantener la misma cantidad de partidos ganados: "); 
    var nuevoPartidosEmpatadosStr = Console.ReadLine();
    if (!string.IsNullOrEmpty(nuevoPartidosEmpatadosStr))
    {
      if (int.TryParse(nuevoPartidosEmpatadosStr, out var nuevoPartidosEmpatados))
        existente.PartidosEmpatados = nuevoPartidosEmpatados;
      else
        Console.WriteLine("⚠️ Formato de dato entero inválido, se conserva la actual.");
      Console.WriteLine("presione enter para continuar");
      Console.ReadLine();
    }

    Console.Write($"Nueva cantidad de partidos perdidos (actual: {existente.PartidosPerdidos}), presiona enter para mantener la misma cantidad de partidos ganados: "); 
    var nuevoPartidosPerdidosStr = Console.ReadLine();
    if (!string.IsNullOrEmpty(nuevoPartidosPerdidosStr))
    {
      if (int.TryParse(nuevoPartidosPerdidosStr, out var nuevoPartidosPerdidos))
        existente.PartidosPerdidos = nuevoPartidosPerdidos;
      else
        Console.WriteLine("⚠️ Formato de dato entero inválido, se conserva la actual.");
      Console.WriteLine("presione enter para continuar");
      Console.ReadLine();
    }

    Console.Write($"Nueva cantidad de goles a favor (actual: {existente.GolesAFavor}), presiona enter para mantener la misma cantidad de goles a favor: "); 
    var nuevoGolesAFavorStr = Console.ReadLine();
    if (!string.IsNullOrEmpty(nuevoGolesAFavorStr))
    {
      if (int.TryParse(nuevoGolesAFavorStr, out var nuevoGolesAFavor))
        existente.GolesAFavor = nuevoGolesAFavor;
      else
        Console.WriteLine("⚠️ Formato de dato entero inválido, se conserva la actual.");
      Console.WriteLine("presione enter para continuar");
      Console.ReadLine();
    }

    Console.Write($"Nueva cantidad de goles en contra (actual: {existente.GolesEnContra}), presiona enter para mantener la misma cantidad de partidos ganados: "); 
    var nuevoGolesEnContraStr = Console.ReadLine();
    if (!string.IsNullOrEmpty(nuevoGolesEnContraStr))
    {
      if (int.TryParse(nuevoGolesEnContraStr, out var nuevoGolesEnContra))
        existente.GolesEnContra = nuevoGolesEnContra;
      else
        Console.WriteLine("⚠️ Formato de dato entero inválido, se conserva la actual.");
      Console.WriteLine("presione enter para continuar");
      Console.ReadLine();
    }
    // Mostrar resumen de los nuevos datos
    Console.WriteLine("\n--- Confirmar Actualización ---\n");
    Console.WriteLine($"ID: {existente.Id} | Partidos ganados {existente.PartidosGanados} | Partidos empatados {existente.PartidosEmpatados} | Partidos perdidos {existente.PartidosPerdidos} | Goles a favor {existente.GolesAFavor} | Goles en contra {existente.GolesEnContra} | Fecha de creacion: {existente.FechaCreacion}\n");
    Console.Write("¿Desea confirmar la actualización? (S/N): ");
    var confirmacion = validate_data.ValidarBoleano(Console.ReadLine());

    if (confirmacion)
    {
      await _estadisticaEquipoService.ActualizarEstadisticaEquipoAsync(id_estadistica, existente);
      Console.WriteLine("Estaditica de jugador actualizado.");
      Console.ReadLine();
    }
    else
    {
      Console.WriteLine("Actualización cancelada.");
      Console.ReadLine();
    }
  }
  private async Task EliminarEstadisticaEquipoAsync()
  {
    Console.Clear();
    Console.WriteLine("---- Eliminar Estadistica Equipo ----");
    Console.WriteLine("Estadisticas diponibles:\n");
    await _estadisticaEquipoService.MostrarEstadisticaEquiposAsync();
    Console.Write("ingrese el ID de la estadistica a eliminar: ");
    int id_estadistica = validate_data.ValidarEntero(Console.ReadLine());

    var existente = await _estadisticaEquipoService.ObtenerEstadisticaEquipoPorIdAsync(id_estadistica);
    if (existente == null)
    {
      Console.WriteLine("Estadistica de equipo no encontrada.");
      Console.WriteLine("Presione una tecla para continuar");
      Console.ReadLine();
      return;
    }

    await _estadisticaEquipoService.EliminarEstadisticaEquipoAsync(id_estadistica);
    Console.WriteLine("🗑️ Estadistica de jugador eliminada.");
  }
  private async Task MostrarTodasLasEstadisticasEquiposAsync()
  {
    var estadisticas_equipos = await _estadisticaEquipoService.MostrarEstadisticaEquiposAsync();
    if (!estadisticas_equipos.Any())
    {
      Console.WriteLine("No hay estadisticas de equipos registradas.");
      return;
    }
    Console.WriteLine("Estadisticas de equipos disponibles:");
    foreach (var ej in estadisticas_equipos)
    {
      if (ej is null) continue;
      Console.WriteLine($"ID: {ej.Id} | Partidos ganados {ej.PartidosGanados} | Partidos empatados {ej.PartidosEmpatados} | Partidos perdidos {ej.PartidosPerdidos} | Goles a favor {ej.GolesAFavor} | Goles en contra {ej.GolesEnContra} | Fecha de creacion: {ej.FechaCreacion}\n"); 
    }
  }
  private async Task BuscarEstadisticaEquipoPorIdAsync()
  {
    Console.Write("ID a obtener: ");
    int id = validate_data.ValidarEntero(Console.ReadLine());

    var ej = await _estadisticaEquipoService.ObtenerEstadisticaEquipoPorIdAsync(id);
    if (ej is null)
    {
      Console.WriteLine("Estadistica de Equipo no encontrado.");
      return;
    }

    Console.WriteLine($"ID: {ej.Id} | Partidos ganados {ej.PartidosGanados} | Partidos empatados {ej.PartidosEmpatados} | Partidos perdidos {ej.PartidosPerdidos} | Goles a favor {ej.GolesAFavor} | Goles en contra {ej.GolesEnContra} | Fecha de creacion: {ej.FechaCreacion}\n");
  }
}