using System;
using soccer_cs.src.modules.estadistica_equipo.application.interfaces;
using soccer_cs.src.modules.estadistica_equipo.application.services;
using soccer_cs.src.modules.estadistica_equipo.infrastructure.repositories;
using soccer_cs.src.shared.context;
using soccer_cs.src.shared.utils;

namespace soccer_cs.src.modules.estadistica_equipo.ui;

public class MenuEstadisticaEquipo
{
  private readonly Validaciones validate_data = new Validaciones();
  // esto con el fin de que se pueda acceder a la clase de servicio de cuerpo medico
  // private readonly EstadisticaEquipoService _service = null!;
  private readonly IEstadisticaEquipoService _EstadisticaEquipoService;
  private readonly EstadisticaEquipoService _service;
  // este codigo se hace con el fin de que cuando se ejecute el programa se pueda ve el menu de la aplicacion
  public MenuEstadisticaEquipo(AppDbContext _context)
  {
    var repo = new EstadisticaEquipoRepository(_context);
    _ = new EstadisticaEquipoService(repo);
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
        await AgregarEstadisticaEquipoAsync();
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
        await MostrarEstadisticaEquiposAsync();
        break;
      case 4:
        Console.Clear();
        await ObtenerEstadisticaEquipoPorIdAsync();
        break;
      case 5:
        return false;
      default:
        Console.Clear();
        Console.WriteLine("error al ingresar dato, intentelo de nuevo");
        Console.ReadLine();
        return false;
    }
    return true;
  }
  private async Task AgregarEstadisticaEquipoAsync()
  {
    Console.Clear();
    Console.WriteLine("---- Registrar Estadistica Equipo ----");
    // primero mostrar los jugadores existentes para escoger uno al que se le van a agregar las estadisticas
    var estadisticas_jugadores = await _EstadisticaEquipoService.MostrarEstadisticaEquiposAsync();
    if (!estadisticas_jugadores.Any())
    {
      Console.WriteLine("No hay estadisticas_jugadores registrados.");
      return;
    }
    Console.WriteLine("Jugadores disponibles:");
    foreach (var ej in estadisticas_jugadores)
    {
      if (ej is null) continue;
      Console.WriteLine($"ID: {ej.Id} | Nombre: {ej.Equipo?.Nombre} {ej.Equipo?.Ciudad} | Pais: {ej.Equipo?.Pais}");
    }
    Console.Write("Escoja un jugador: ");
    int id_jugador = validate_data.ValidarEntero(Console.ReadLine());

    Console.WriteLine("Goles del jugador: ");
    int goles = validate_data.ValidarEntero(Console.ReadLine());

    Console.WriteLine("Asistenia del jugador: ");
    int asistencias = validate_data.ValidarEntero(Console.ReadLine());

    Console.WriteLine("Partidos jugados del jugador: ");
    int partidos_jugados = validate_data.ValidarEntero(Console.ReadLine());

    Console.WriteLine("Estatura del jugador: ");
    decimal estatura = validate_data.ValidarDecimal(Console.ReadLine());

    Console.WriteLine("Peso del jugador: ");
    decimal peso = validate_data.ValidarDecimal(Console.ReadLine());

    Console.WriteLine("Tarjetas amarillas del jugador: ");
    int tarjetas_amarillas = validate_data.ValidarEntero(Console.ReadLine());

    Console.WriteLine("Tarjetas rojas del jugador: ");
    int tarjetas_rojas = validate_data.ValidarEntero(Console.ReadLine());

    // crear la estadistica de jugador
    var estadistica = new EstadisticaJugador
    {
      Goles = goles,
      Asistencias = asistencias,
      PartidosJugados = partidos_jugados,
      Estatura = estatura,
      Peso = peso,
      TarjetasAmarillas = tarjetas_amarillas,
      TarjetasRojas = tarjetas_rojas,
      IdJugador = id_jugador,
    };
    // guardar la estadistica de jugador
    await _service.AgregarEstadisticaJugadorAsync(estadistica);
    Console.WriteLine("Estadistica de jugador creada.");
    Console.ReadLine();
  }
  private async Task ActualizarEstadisticaJugadorAsync()
  {
    // ingresar id de la estadistica a actualizar
    Console.Write("ID de la estadistica a actualizar: ");
    int id = validate_data.ValidarEntero(Console.ReadLine());

    var existente = await _service.VerPorIdAsync(id);
    if (existente == null)
    {
      Console.WriteLine("Estadistica de jugador no encontrada.");
      Console.ReadLine();
      return;
    }
    // en este caso no voy a hacer validate data de modo que si el usuario quiere mantener un dato, le de enter y lo deje como es
    Console.Write($"Nueva cantidad de goles (actual: {existente.Goles}), presiona enter para mantener la misma cantidad de goles: ");
    var nuevoGolesStr = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(nuevoGolesStr) && int.TryParse(nuevoGolesStr, out int nuevoGoles))
      existente.Goles = nuevoGoles;

    Console.Write($"Nueva cantidad de asistencias (actual: {existente.Asistencias}), presiona enter para mantener la misma cantidad de asistencias: ");
    var nuevoAsistenciasStr = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(nuevoAsistenciasStr) && int.TryParse(nuevoAsistenciasStr, out int nuevoAsistencias))
      existente.Asistencias = nuevoAsistencias;

    Console.Write($"Nueva cantidad de partidos jugados (actual: {existente.PartidosJugados}), presiona enter para mantener la misma cantidad de partidos jugados: ");
    var nuevaParidosJugadosStr = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(nuevaParidosJugadosStr) && int.TryParse(nuevaParidosJugadosStr, out int nuevoPartidosJugados))
      existente.PartidosJugados = nuevoPartidosJugados;

    Console.Write($"Nueva estatura (actual: {existente.Estatura}), presiona enter para mantener la misma estatura: ");
    var neuvaEstaturaStr = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(neuvaEstaturaStr) && decimal.TryParse(neuvaEstaturaStr, out decimal nuevaEstatura))
      existente.Estatura = nuevaEstatura;

    Console.Write($"Nuevo peso (actual: {existente.Peso}), presiona enter para mantener el mismo peso: ");
    var nuevoPesoStr = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(nuevoPesoStr) && decimal.TryParse(nuevoPesoStr, out decimal nuevoPeso))
      existente.Peso = nuevoPeso;

    Console.Write($"Nuevo tarjetas amarillas (actual: {existente.TarjetasAmarillas}), presiona enter para mantener el mismo nombre: ");
    var nuevoTarjetasAmarillasStr = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(nuevoTarjetasAmarillasStr) && int.TryParse(nuevoTarjetasAmarillasStr, out int nuevoTarjetasAmarillas))
      existente.TarjetasAmarillas = nuevoTarjetasAmarillas;

    Console.Write($"Nuevo tarjetas rojas (actual: {existente.TarjetasRojas}), presiona enter para mantener el mismo nombre: ");
    var nuevoTarjetasRojasStr = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(nuevoTarjetasRojasStr) && int.TryParse(nuevoTarjetasRojasStr, out int nuevoTarjetasRojas))
      existente.TarjetasRojas = nuevoTarjetasRojas;

    // Mostrar resumen de los nuevos datos
    Console.WriteLine("\n--- Confirmar Actualización ---\n");
    Console.WriteLine($"Nombre: {existente.Jugador?.Persona.Nombre}");
    Console.WriteLine($"Apellido: {existente.Jugador?.Persona.Apellido}");
    Console.WriteLine($"Edad: {existente.Jugador?.Persona.Edad}");
    Console.WriteLine($"Nacionalidad: {existente.Jugador?.Persona.Nacionalidad}");
    Console.WriteLine($"Documento: {existente.Jugador?.Persona.DocumentoIdentidad}");
    Console.WriteLine($"Género: {existente.Jugador?.Persona.Genero}");
    Console.WriteLine($"Goles: {existente.Goles}");
    Console.WriteLine($"Asistencias: {existente.Asistencias}");
    Console.WriteLine($"Partidos Jugados: {existente.PartidosJugados}");
    Console.WriteLine($"Estatura: {existente.Estatura}");
    Console.WriteLine($"Peso: {existente.Peso}");
    Console.WriteLine($"Tarjetas Amarillas: {existente.TarjetasAmarillas}");
    Console.WriteLine($"Tarjetas Rojas: {existente.TarjetasRojas}");
    Console.Write("¿Desea confirmar la actualización? (S/N): ");
    var confirmacion = validate_data.ValidarBoleano(Console.ReadLine());

    if (confirmacion)
    {
      await _service.ActualizarEstadisticaJugadorAsync(id, existente);
      Console.WriteLine("Estaditica de jugador actualizado.");
      Console.ReadLine();
    }
    else
    {
      Console.WriteLine("Actualización cancelada.");
      Console.ReadLine();
    }
  }
  private async Task EliminarEstadisticaJugadorAsync()
  {
    Console.Write("ID a actualizar: ");
    int id = validate_data.ValidarEntero(Console.ReadLine());

    var existente = await _service.VerPorIdAsync(id);
    if (existente == null)
    {
      Console.WriteLine("Cuerpo medico no encontrado.");
      Console.ReadLine();
      return;
    }

    await _service.EliminarEstadisticaJugadorAsync(id);
    Console.WriteLine("🗑️ Estadistica de jugador eliminada.");
  }
  private async Task MostrarEstadisticaJugadorsAsync()
  {
    var estadisticaJugadors = await _service.VerTodasAsync();
    if (!estadisticaJugadors.Any())
    {
      Console.WriteLine("No hay estadisticas registradas.");
      return;
    }

    Console.WriteLine("Estadisticas de jugadores:");
    foreach (var ej in estadisticaJugadors)
    {
      if (ej is null) continue;
      Console.WriteLine($"ID: {ej.Id} | Nombre: {ej.Jugador?.Persona.Nombre} {ej.Jugador?.Persona.Apellido} | Edad: {ej.Jugador?.Persona.Edad} | Nacionalidad: {ej.Jugador?.Persona.Nacionalidad} | Goles {ej.Goles} | Asistencias {ej.Asistencias} | Partidos Jugados {ej.PartidosJugados} | Estatura {ej.Estatura} | Peso {ej.Peso} | Tarjetas Amarillas {ej.TarjetasAmarillas} | Tarjetas Rojas {ej.TarjetasRojas}\n");
    }
  }
  private async Task ObtenerEstadisticaJugadorPorIdAsync()
  {
    Console.Write("ID a obtener: ");
    int id = validate_data.ValidarEntero(Console.ReadLine());

    var ej = await _service.VerPorIdAsync(id);
    if (ej is null)
    {
      Console.WriteLine("Estadistica de jugador no encontrado.");
      return;
    }

    Console.WriteLine($"ID: {ej.Id} | Nombre: {ej.Jugador?.Persona.Nombre} {ej.Jugador?.Persona.Apellido} | Edad: {ej.Jugador?.Persona.Edad} | Nacionalidad: {ej.Jugador?.Persona.Nacionalidad} | Goles {ej.Goles} | Asistencias {ej.Asistencias} | Partidos Jugados {ej.PartidosJugados} | Estatura {ej.Estatura} | Peso {ej.Peso} | Tarjetas Amarillas {ej.TarjetasAmarillas} | Tarjetas Rojas {ej.TarjetasRojas}\n");
  }
}