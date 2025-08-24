using persona.src.persona.ui;
using soccer_cs.src.modules.cuerpo_medico.ui;
using soccer_cs.src.modules.cuerpo_tecnico.ui;
using soccer_cs.src.modules.equipo.ui;
using soccer_cs.src.modules.estadistica_equipo.ui;
using soccer_cs.src.modules.estadistica_jugador.ui;
using soccer_cs.src.modules.jugador.application.services;
using soccer_cs.src.modules.jugador.infrastructure.repositories;
using soccer_cs.src.modules.jugador.ui;
using soccer_cs.src.modules.persona.application.services;
using soccer_cs.src.modules.persona.infrastructure.repositories;
using soccer_cs.src.modules.torneo.ui;
using soccer_cs.src.modules.transferencia.ui;
using soccer_cs.src.shared.helpers;

namespace soccer_cs.src.ui;

public class MenuPrincipal
{
  // esto es un contructor que se encarga de inicializr un mensaje de bienvenida al ejecutar el programa
  public void MostrarBienvenida()
  {
    string titulo = "⚽ BIENVENIDO AL SISTEMA DE FÚTBOL ⚽";
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("╔══════════════════════════════════════════════════════╗");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"║{titulo.PadLeft((54 + titulo.Length) / 2).PadRight(52)}║");
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("╚══════════════════════════════════════════════════════╝");
    Console.ResetColor();
    Console.WriteLine();

    EscribirConPausa("\nEste sistema permite gestionar:", 40);
    EscribirConPausa("- Torneos", 40);
    EscribirConPausa("- Equipos", 40);
    EscribirConPausa("- Jugadores", 40);
    EscribirConPausa("- Transferencias", 40);
    EscribirConPausa("- Estadísticas\n", 40);

    Thread.Sleep(300);
    EscribirConPausa("De forma totalmente interactiva ⚙️ 🧠\n", 40);

    Console.ForegroundColor = ConsoleColor.Yellow;
    EscribirConPausa("👨‍💻 Desarrollado por Ángel Pinzón\n", 40);
    Console.ResetColor();

    Console.ForegroundColor = ConsoleColor.Green;
    EscribirConPausa("\nPresiona cualquier tecla para comenzar el programa...", 40);
    Console.ResetColor();
    Console.ReadKey(true);
  }
  // este es el metodo que se encarga de escribir el texto con pausa 
  private void EscribirConPausa(string texto, int milisegundos)
  {
    Console.WriteLine(texto);
    Thread.Sleep(milisegundos);
  }
  // se declara un arreglo de strings que contiene las opciones del menu principal
  private readonly string[] opcionesMenu =
  {
    "🏆 Registro de torneos",
    "👥 Registro de equipos",
    "⚽ Registro de jugadores",
    "🩺 Registros de cuerpo médico",
    "🎩 Registros de cuerpo técnico",
    "💸 Transferencias (compra de jugadores)",
    "📊 Estadísticas de equipo",
    "📈 Estadísticas de jugadores",
    "🚪 Salir del programa"
  };
  // se declara la variable que se va a utilizar para el menu principal
  private int opcionSeleccionada = 0;
  // este es el metodo del menu principal en la consola con las flechas de arriba y abajo
  private void DibujarMenu()
  {
    string titulo = "🏟️  Menu Principal 🏟️";
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("╔══════════════════════════════════════════════════════╗");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"║{titulo.PadLeft((54 + titulo.Length) / 2).PadRight(58)}║");
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("╚══════════════════════════════════════════════════════╝");
    Console.ResetColor();
    Console.WriteLine();

    for (int i = 0; i < opcionesMenu.Length; i++)
    {
      string opcion = opcionesMenu[i];

      if (i == opcionSeleccionada)
      {
        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.Yellow;
        Console.WriteLine($" ▶ {opcion.PadRight(40)} ");
        Console.ResetColor();
      }
      else
      {
        // Colorear según tipo de módulo
        if (opcion.Contains("torneo")) Console.ForegroundColor = ConsoleColor.DarkGreen;
        else if (opcion.Contains("equipo")) Console.ForegroundColor = ConsoleColor.Blue;
        else if (opcion.Contains("jugador")) Console.ForegroundColor = ConsoleColor.Cyan;
        else if (opcion.Contains("cuerpo")) Console.ForegroundColor = ConsoleColor.Magenta;
        else if (opcion.Contains("Transferencias")) Console.ForegroundColor = ConsoleColor.DarkYellow;
        else if (opcion.Contains("Estadísticas")) Console.ForegroundColor = ConsoleColor.DarkCyan;
        else Console.ForegroundColor = ConsoleColor.Gray;

        Console.WriteLine($"   {opcion}");
        Console.ResetColor();
      }
    }

    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine("\n[↑] [↓] Moverse   [Enter] Seleccionar");
    Console.ResetColor();
  }
  // este es el metodo que se encarga de ejecutar el menu principal, donde se va a manejar la logica del menu y de los inputs
  public async Task EjecutarMenuMain()
  {
    bool validate_program = true;
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
          validate_program = await EjecutarOpcion(opcionSeleccionada);
          break;
      }
    } while (validate_program);
    // Console.WriteLine("\nPresiona cualquier tecla para cerrar...");
    // Console.ReadKey();
  }
  // este metodo se encarga de ejecutar las opciones del menu principal, y se trabaja con boolean para determinar si se debe de continuar o no con el programa, es por eso que esta el Console.ReadKey(true), para que el programa espere a que el usuario precione una tecla antes de continua
  private async Task<bool> EjecutarOpcion(int opcion_seleccionada)
  {
    Console.Clear();
    var context = DbContextFactory.Create();

    switch (opcion_seleccionada)
    {
      case 0:
        await new MenuTorneo(context).EjecutarMenu();
        return true;
      case 1:
        await new MenuEquipo(context).EjecutarMenu();
        return true;
      case 2:
        await new MenuJugador(context).EjecutarMenu();
        return true;
      case 3:
        await new MenuCuerpoMedico(context).EjecutarMenu();
        return true;
      case 4:
        await new MenuCuerpoTecnico(context).EjecutarMenu();
        return true;
      case 5:
        await new MenuTransferencia(context).EjecutarMenu();
        return true;
      case 6:
        await new MenuEstadisticaEquipo(context).EjecutarMenu();
        return true;
      case 7:
        await new MenuEstadisticaJugador(context).EjecutarMenu();
        return true;
      case 8:
        string titulo = "🙌 ¡GRACIAS POR USAR EL SISTEMA! 🙌";
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("╔══════════════════════════════════════════════════════╗");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"║{titulo.PadLeft((54 + titulo.Length) / 2).PadRight(54)}║");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("╚══════════════════════════════════════════════════════╝");
        Console.ResetColor();
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Esperamos que tu experiencia haya sido excelente. ⚽💻");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n👨‍💻 Desarrollado por Ángel Pinzón");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("\nPresiona cualquier tecla para salir...");
        Console.ResetColor();
        Console.ReadKey();
        return false;
      default:
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("❌ Opción inválida. Inténtalo de nuevo.");
        Console.ResetColor();
        Console.ReadKey(true);
        return true;
    }
  }
}
