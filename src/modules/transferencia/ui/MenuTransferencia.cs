using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soccer.src.modules.equipo.domain.models;
using soccer_cs.src.modules.domain.models;
using soccer_cs.src.modules.equipo.application.services;
using soccer_cs.src.modules.infrastructure.repositories;
using soccer_cs.src.modules.jugador.application.services;
using soccer_cs.src.modules.jugador.domain.models;
using soccer_cs.src.modules.transferencia.application.services;
using soccer_cs.src.shared.context;
using soccer_cs.src.shared.utils;

namespace soccer_cs.src.modules.transferencia.ui;

public class MenuTransferencia
{
  private readonly Validaciones validate_data = new Validaciones();
  // esto con el fin de que se pueda acceder a la clase de servicio de cuerpo medico
  private readonly TransferenciaService _transferenciaService = null!;
  private readonly JugadorService _jugadorService = null!;
  private readonly EquipoService _equipoService = null!;
  // este codigo se hace con el fin de que cuando se ejecute el programa se pueda ve el menu de la aplicacion
  public MenuTransferencia(AppDbContext _context)
  {
    var repo = new TransferenciaRepository(_context);
    _transferenciaService = new TransferenciaService(repo);
  }
  // se declara la variable que se va a utilizar para el menu principal
  private int opcionSeleccionada = 0;
  // se declara un arreglo de strings que contiene las opciones del menu principal
  private readonly string[] opcionesMenuTransferencia =
  {
    "[CRUD] Crear transferencia",
    "[CRUD] Actualizar transferencia",
    "[CRUD] Eliminar transferencia",
    "[LISTAR] Historial de transferencias",
    "[BUSCAR] Historial por jugador",
    "[BUSCAR] Historial por equipo",
    "[BUSCAR] Historial por ID",
    "↩ Volver al menú principal"
  };
  // este es el metodo del menu principal en la consola con las flechas de arriba y abajo
  private void DibujarMenu(string titulo, string[] opciones, int opcionSeleccionada)
  {
    Console.Clear();

    // ===== CABECERA =====
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("╔══════════════════════════════════════════╗");
    Console.WriteLine($"║   {titulo.ToUpper().PadLeft((40 + titulo.Length) / 2).PadRight(36)}   ║");
    Console.WriteLine("╚══════════════════════════════════════════╝");
    Console.ResetColor();
    Console.WriteLine();

    // ===== OPCIONES =====
    for (int i = 0; i < opciones.Length; i++)
    {
      string opcion = opciones[i];

      if (i == opcionSeleccionada)
      {
        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.Yellow;
        Console.WriteLine($" ▶ {opcion} ");
        Console.ResetColor();
      }
      else
      {
        // Colores según categoría detectada en el prefijo
        if (opcion.StartsWith("[CRUD]"))
          Console.ForegroundColor = ConsoleColor.Green;
        else if (opcion.StartsWith("[BUSCAR]"))
          Console.ForegroundColor = ConsoleColor.Blue;
        else if (opcion.StartsWith("[LISTAR]"))
          Console.ForegroundColor = ConsoleColor.Magenta;
        else if (opcion.StartsWith("[RELACIÓN]"))
          Console.ForegroundColor = ConsoleColor.DarkCyan;
        else if (opcion.StartsWith("[TOP]"))
          Console.ForegroundColor = ConsoleColor.DarkYellow;
        else if (opcion.StartsWith("[TORNEO]"))
          Console.ForegroundColor = ConsoleColor.DarkGreen;
        else
          Console.ForegroundColor = ConsoleColor.Gray;

        Console.WriteLine($"   {opcion}");
        Console.ResetColor();
      }
    }

    // ===== PIE DE PÁGINA =====
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine("Usa ↑ ↓ para moverte, Enter para seleccionar, Esc para salir.");
    Console.ResetColor();
  }
  public async Task EjecutarMenu()
  {
    bool validate_menu = true;
    do
    {
      DibujarMenu("MENÚ TRANSFERENCIA", opcionesMenuTransferencia, opcionSeleccionada);
      // lee la tecla presionada por el usuario
      var tecla_input = Console.ReadKey(true);

      switch (tecla_input.Key)
      {
        // si es la flecha hacia arriba se decrementa la opcion seleccionada
        case ConsoleKey.UpArrow:
          opcionSeleccionada--;
          // si la opcion seleccionada es menor a 0, se asigna el ultimo elemento del arreglo de opcionesMenu
          if (opcionSeleccionada < 0) opcionSeleccionada = opcionesMenuTransferencia.Length - 1;
          break;
        // si es la flecha hacia abajo se aumenta la opcion seleccionada en el arreglo de opcionesMenu
        case ConsoleKey.DownArrow:
          opcionSeleccionada++;
          // si la opcion seleccionada es mayor o igual al largo del arreglo de opcionesMenu, se asigna 0
          if (opcionSeleccionada >= opcionesMenuTransferencia.Length) opcionSeleccionada = 0;
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
        await CrearTransferenciaAsync();
        break;
      case 1:
        Console.Clear();
        await ActualizarTransferenciaAsync();
        break;
      case 2:
        Console.Clear();
        await EliminarTransferenciaAsync();
        break;
      case 3:
        Console.Clear();
        await MostrarTodasLasTransferenciasAsync();
        break;
      case 4:
        Console.Clear();
        await BuscarTransferenciaPorJugadorAsync();
        break;
      case 5:
        Console.Clear();
        await BuscarTransferenciaPorEquipoAsync();
        break;
      case 6:
        Console.Clear();
        await ObtenerTransferenciaPorIdAsync();
        break;
      case 7:
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
  private async Task CrearTransferenciaAsync()
  {
    Console.Clear();
    Console.WriteLine("---- Registrar Transferencia ----");
    Console.ReadLine();
    // mostrar los jugadores disponibles para que el usuario elija
    await _jugadorService.MostrarJugadorsAsync();
    Console.Write("Jugador ID: ");
    int id_jugador = validate_data.ValidarEntero(Console.ReadLine());

    Console.WriteLine("Presione enter para continurar: ");
    Console.ReadLine();
    // mostrar los equipos disponibles para que el usuario elija
    await _equipoService.MostrarEquiposAsync();
    Console.Write("Equipo origen ID: ");
    int id_equipo_origen = validate_data.ValidarEntero(Console.ReadLine());

    Console.Write("Equipo destino ID: ");
    int id_equipo_destino = validate_data.ValidarEntero(Console.ReadLine());

    Console.Write("Tipo de transferencia: ");
    var tipo_transferencia = validate_data.ValidarTexto(Console.ReadLine());

    Console.Write("Valor de transferencia: ");
    float valor_transferencia = validate_data.ValidarEntero(Console.ReadLine());

    Console.Write("Fecha de transferencia: ");
    DateTime fecha_transferencia = validate_data.ValidarFecha(Console.ReadLine());

    // TODO: revisar que esto no sea necesario pero quiero darle utilidad al metodo MostrarResumen para reducir lineas de codigo aunque no se si funcione
    Transferencia transferencia = new Transferencia();
    transferencia.MostrarResumen();
    Console.WriteLine("\n¿Desea confirmar la creacion de la transferencia realizada? (S/N)");  
    var confirmacion = validate_data.ValidarBoleano(Console.ReadLine());

    if (confirmacion)
    {
      await _transferenciaService.RealizarTransferenciaAsync(id_jugador, id_equipo_origen, id_equipo_destino, tipo_transferencia, valor_transferencia, fecha_transferencia);
      Console.WriteLine("Transferencia creada.");
      Console.ReadLine();
    }
    else
    {
      Console.WriteLine("Transferencia cancelada.");
      Console.ReadLine();
    }
  }
  private async Task ActualizarTransferenciaAsync()
  {
    Console.Write("ID a actualizar: ");
    int id = validate_data.ValidarEntero(Console.ReadLine());

    var existente = await _transferenciaService.ObtenerTransferenciaPorIdAsync(id);
    if (existente == null)
    {
      Console.WriteLine("Transferencia no encontrado.");
      Console.ReadLine();
      return;
    }
    // en este caso no voy a hacer validate data de modo que si el usuario quiere mantener un dato, le de enter y lo deje como es
    Console.Write($"Nuevo tipo de transferencia (actual: {existente.TipoTransferencia}), presiona enter para mantener el mismo nombre: "); 
    var nuevoTipoTransferencia = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(nuevoTipoTransferencia))
      existente.TipoTransferencia = nuevoTipoTransferencia;

    Console.WriteLine($"Nuevo valor de transferencia (actual: {existente.ValorTransferencia:C}), presiona enter para mantener el mismo nombre: ");
    var nuevoValorTransferencia = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(nuevoValorTransferencia) && float.TryParse(nuevoValorTransferencia, out float nuevoValor))
      existente.ValorTransferencia = nuevoValor;

    Console.WriteLine($"Nuevo fecha de transferencia (actual: {existente.FechaTransferencia.ToShortDateString()}), presiona enter para mantener el mismo nombre: ");
    var nuevoFechaTransferencia = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(nuevoFechaTransferencia) && DateTime.TryParse(nuevoFechaTransferencia, out DateTime nuevoFecha))
      existente.FechaTransferencia = nuevoFecha;
    
    Console.WriteLine($"Nuevo equipo origen (actual: {existente.IdEquipoOrigen}), presiona enter para mantener el mismo nombre: ");
    var nuevoEquipoOrigen = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(nuevoEquipoOrigen) && int.TryParse(nuevoEquipoOrigen, out int nuevoEquipoOrigenId))
      existente.IdEquipoOrigen = nuevoEquipoOrigenId;

    Console.WriteLine($"Nuevo equipo destino (actual: {existente.IdEquipoDestino}), presiona enter para mantener el mismo nombre: ");
    var nuevoEquipoDestino = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(nuevoEquipoDestino) && int.TryParse(nuevoEquipoDestino, out int nuevoEquipoDestinoId))
      existente.IdEquipoDestino = nuevoEquipoDestinoId;

    // Mostrar resumen de los nuevos datos
    Console.WriteLine("\n--- Confirmar Actualización ---");
    Console.WriteLine($"Tipo de transferencia: {existente.TipoTransferencia}");
    Console.WriteLine($"Valor de transferencia: {existente.ValorTransferencia:C}");
    Console.WriteLine($"Fecha de transferencia: {existente.FechaTransferencia.ToShortDateString()}");
    Console.WriteLine($"Equipo origen: {existente.IdEquipoOrigen}");
    Console.WriteLine($"Equipo destino: {existente.IdEquipoDestino}");
    Console.Write("¿Confirmar actualización? (S/N): ");

    var confirmacion = validate_data.ValidarBoleano(Console.ReadLine());

    if (confirmacion)
    {
      await _transferenciaService.ActualizarTransferenciaAsync(id, existente);
      Console.WriteLine("Transferencia Actualizada."); 
      Console.ReadLine();
    }
    else
    {
      Console.WriteLine("Actualización cancelada.");
      Console.ReadLine();
    }
  }
  private async Task EliminarTransferenciaAsync()
  {
    Console.Write("ID a actualizar: ");
    int id = validate_data.ValidarEntero(Console.ReadLine());

    var existente = await _transferenciaService.ObtenerTransferenciaPorIdAsync(id);
    if (existente == null)
    {
      Console.WriteLine("Transferencia no encontrado.");
      Console.ReadLine();
      return;
    }

    await _transferenciaService.EliminarTransferenciaAsync(id);
    Console.WriteLine("🗑️ Transferencia eliminado.");
  }
  private async Task MostrarTodasLasTransferenciasAsync()
  {
    var transferencias = await _transferenciaService.VerTodoTransferenciaAsync();
    if (!transferencias.Any())
    {
      Console.WriteLine("No hay transferencias registradas."); 
      return;
    }

    Console.WriteLine("Transferencias:");
    foreach (var t in transferencias)
    {
      if (t is null) continue;
      Console.WriteLine($"ID: {t.Id} | Tipo de transferencia: {t.TipoTransferencia} | Valor de transferencia: {t.ValorTransferencia:C} | Fecha de transferencia: {t.FechaTransferencia.ToShortDateString()} | Equipo origen: {t.IdEquipoOrigen} | Equipo destino: {t.IdEquipoDestino}");
    }
  }
  private async Task BuscarTransferenciaPorJugadorAsync()
  { 
    Console.Write("ID jugador: ");
    int id_jugador = validate_data.ValidarEntero(Console.ReadLine());

    var Historial = await _transferenciaService.VerHistorialTransferenciaPorJugadorAsync(id_jugador);
    if (!Historial.Any())
    {
      Console.WriteLine("No hay transferencias registradas.");
      return;
    }

    Console.WriteLine("Transferencias:");
    foreach (var t in Historial)
    {
      if (t is null) continue;
      Console.WriteLine($"ID: {t.Id} | Tipo de transferencia: {t.TipoTransferencia} | Valor de transferencia: {t.ValorTransferencia:C} | Fecha de transferencia: {t.FechaTransferencia.ToShortDateString()} | Equipo origen: {t.IdEquipoOrigen} | Equipo destino: {t.IdEquipoDestino}");
    }
  }
  private async Task BuscarTransferenciaPorEquipoAsync()
  {
    Console.Write("ID equipo: ");
    int id_equipo = validate_data.ValidarEntero(Console.ReadLine());

    var Historial = await _transferenciaService.VerHistorialTransferenciaPorEquipoAsync(id_equipo);
    if (!Historial.Any())
    {
      Console.WriteLine("No hay transferencias registradas.");
      return;
    }

    Console.WriteLine("Transferencias:");
    foreach (var t in Historial)
    {
      if (t is null) continue;
      Console.WriteLine($"ID: {t.Id} | Tipo de transferencia: {t.TipoTransferencia} | Valor de transferencia: {t.ValorTransferencia:C} | Fecha de transferencia: {t.FechaTransferencia.ToShortDateString()} | Equipo origen: {t.IdEquipoOrigen} | Equipo destino: {t.IdEquipoDestino}");
    }
  }
  private async Task ObtenerTransferenciaPorIdAsync()
  {
    Console.Write("ID a obtener: ");
    int id = validate_data.ValidarEntero(Console.ReadLine());

    var existente = await _transferenciaService.ObtenerTransferenciaPorIdAsync(id);
    if (existente == null)
    {
      Console.WriteLine("Transferencia no encontrada.");
      Console.ReadLine();
      return;
    }

    var t = await _transferenciaService.ObtenerTransferenciaPorIdAsync(id);
    if (t is null)
    {
      Console.WriteLine("Transferencia no encontrado.");
      return;
    }
    Console.WriteLine($"Transferencia:");
    Console.WriteLine($"ID: {t.Id} | Tipo de transferencia: {t.TipoTransferencia} | Valor de transferencia: {t.ValorTransferencia:C} | Fecha de transferencia: {t.FechaTransferencia.ToShortDateString()} | Equipo origen: {t.IdEquipoOrigen} | Equipo destino: {t.IdEquipoDestino}");
    Console.ReadLine();
  }
}
