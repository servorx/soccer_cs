using persona.src.persona.ui;
using soccer_cs.src.modules.cuerpo_medico.ui;
using soccer_cs.src.modules.cuerpo_tecnico.ui;
using soccer_cs.src.modules.equipo.ui;
using soccer_cs.src.modules.estadistica_equipo.ui;
using soccer_cs.src.modules.estadistica_jugador.ui;
using soccer_cs.src.modules.jugador.ui;
using soccer_cs.src.modules.torneo.ui;
using soccer_cs.src.modules.transferencia.ui;
using soccer_cs.src.shared.helpers;

namespace soccer_cs.src.ui;

public class MenuPrincipal
{
  // esto es un contructor que se encarga de inicializr un mensaje de bienvenida al ejecutar el programa
  public void MostrarBienvenida()
  {
    Console.Clear();
    EscribirConPausa("======================================", 50);
    EscribirConPausa("⚽ BIENVENIDO AL SISTEMA DE FÚTBOL ⚽", 50);
    EscribirConPausa("======================================\n", 50);

    Thread.Sleep(300);
    EscribirConPausa("Este sistema permite gestionar:", 50);
    EscribirConPausa("- Torneos", 50);
    EscribirConPausa("- Equipos", 50);
    EscribirConPausa("- Jugadores", 50);
    EscribirConPausa("- Transferencias", 50);
    EscribirConPausa("- Estadísticas", 50);
    Console.WriteLine();

    Thread.Sleep(300);
    EscribirConPausa("De forma totalmente interactiva ⚙️ 🧠\n", 50);
    EscribirConPausa("Desarrollado por Ángel Pinzón 🧠💻\n", 50);

    Console.ForegroundColor = ConsoleColor.Yellow;
    EscribirConPausa("Presiona una tecla para continuar...", 50);
    Console.ResetColor();
    // esta linea de codigo es para que el programa espere a que el usuario presiones una tecla antes de continuar, deteniendo le ejecucion del programa
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
    "Registro de torneos",
    "Registro de equipos",
    "Registro de jugadores",
    "Registros de cuerpo médico",
    "Registros de cuerpo técnico",
    "Transferencias (compra de jugadores)",
    "Estadísticas de equipo",
    "Estadísticas de jugadores",
    "Salir del programa"
  };
  // se declara la variable que se va a utilizar para el menu principal
  private int opcionSeleccionada = 0;
  // este es el metodo del menu principal en la consola con las flechas de arriba y abajo
  private void DibujarMenu()
  {
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("========== MENÚ PRINCIPAL ==========\n");
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
    switch (opcion_seleccionada)
    {
      case 0:
        var context1 = DbContextFactory.Create();
        await new MenuTorneo(context1).EjecutarMenu();
        Console.ReadKey(true);
        return true;
      case 1:
        var context2 = DbContextFactory.Create();
        await new MenuEquipo(context2).EjecutarMenu();
        Console.ReadKey(true);
        return true;
      case 2:
        var context3 = DbContextFactory.Create();
        await new MenuJugador(context3).EjecutarMenu();
        Console.ReadKey(true);
        return true;
      case 3:
        var context4 = DbContextFactory.Create();
        await new MenuCuerpoMedico(context4).EjecutarMenu();
        Console.ReadKey(true);
        return true;
      case 4:
        var context5 = DbContextFactory.Create();
        await new MenuCuerpoTecnico(context5).EjecutarMenu();
        Console.ReadKey(true);
        return true;
      case 5:
        var context6 = DbContextFactory.Create();
        await new MenuTransferencia(context6).EjecutarMenu();
        Console.ReadKey(true);
        return true;
      case 6:
        var context7 = DbContextFactory.Create();
        await new MenuEstadisticaEquipo(context7).EjecutarMenu();
        Console.ReadKey(true);
        return true;
      case 7:
        var context8 = DbContextFactory.Create();
        await new MenuEstadisticaJugador(context8).EjecutarMenu();
        Console.ReadKey(true);
        return true;
      case 8:
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("==========================================");
        Console.WriteLine("     🙌 ¡GRACIAS POR USAR EL SISTEMA! 🙌");
        Console.WriteLine("==========================================\n");
        Console.ResetColor();

        Console.WriteLine("Esperamos que tu experiencia haya sido excelente. ⚽💻");
        Console.WriteLine("\n¡Johlver coloqueme buena nota porfa 🙏!");
        Console.WriteLine("\nPresiona cualquier tecla para salir...");
        Console.ReadKey();
        return false; // salir del ciclo
      default:
        Console.Clear();
        Console.WriteLine("error al ingresar dato, intentelo de nuevo");
        Console.ReadKey(true);
        return true;
    }
  }
}

// using soccer_cs.src.modules.cuerpo_medico.ui;
// using soccer_cs.src.modules.cuerpo_tecnico.ui;
// using soccer_cs.src.modules.transferencia.ui;
// using soccer_cs.src.shared.helpers;

// namespace soccer_cs.src.ui;

// public class MenuPrincipal
// {
//     private readonly string[] opcionesMenu =
//     {
//         "🏆 Registro de torneos",
//         "👥 Registro de equipos",
//         "⚽ Registro de jugadores",
//         "🩺 Registros de cuerpo médico",
//         "🎩 Registros de cuerpo técnico",
//         "💸 Transferencias (compra de jugadores)",
//         "📊 Estadísticas de equipo",
//         "📈 Estadísticas de jugadores",
//         "🚪 Salir del programa"
//     };

//     private int opcionSeleccionada = 0;

//     public void MostrarBienvenida()
//     {
//         Console.Clear();
//         DibujarBanner("⚽ BIENVENIDO AL SISTEMA DE FÚTBOL ⚽");

//         EscribirConPausa("\nEste sistema permite gestionar:", 40);
//         EscribirConPausa("- Torneos", 40);
//         EscribirConPausa("- Equipos", 40);
//         EscribirConPausa("- Jugadores", 40);
//         EscribirConPausa("- Transferencias", 40);
//         EscribirConPausa("- Estadísticas\n", 40);

//         Thread.Sleep(300);
//         EscribirConPausa("De forma totalmente interactiva ⚙️ 🧠\n", 40);

//         Console.ForegroundColor = ConsoleColor.Yellow;
//         EscribirConPausa("👨‍💻 Desarrollado por Ángel Pinzón\n", 40);
//         Console.ResetColor();

//         Console.ForegroundColor = ConsoleColor.Green;
//         EscribirConPausa("\nPresiona cualquier tecla para comenzar el partido...", 40);
//         Console.ResetColor();
//         Console.ReadKey(true);
//     }

//     private void DibujarBanner(string titulo)
//     {
//         Console.ForegroundColor = ConsoleColor.Cyan;
//         Console.WriteLine("==========================================");
//         Console.ForegroundColor = ConsoleColor.Green;
//         Console.WriteLine($"         {titulo}         ");
//         Console.ForegroundColor = ConsoleColor.Cyan;
//         Console.WriteLine("==========================================");
//         Console.ResetColor();
//     }

//     private void EscribirConPausa(string texto, int milisegundos)
//     {
//         foreach (char c in texto)
//         {
//             Console.Write(c);
//             Thread.Sleep(15); // efecto máquina de escribir
//         }
//         Console.WriteLine();
//         Thread.Sleep(milisegundos);
//     }

//     private void DibujarMenu()
//     {
//         Console.Clear();
//         DibujarBanner("🏟️ MENÚ PRINCIPAL 🏟️");
//         Console.WriteLine();

//         for (int i = 0; i < opcionesMenu.Length; i++)
//         {
//             if (i == opcionSeleccionada)
//             {
//                 Console.ForegroundColor = ConsoleColor.Yellow;
//                 Console.WriteLine($"▶ {opcionesMenu[i]}");
//                 Console.ResetColor();
//             }
//             else
//             {
//                 Console.WriteLine($"  {opcionesMenu[i]}");
//             }
//         }

//         Console.ForegroundColor = ConsoleColor.DarkGray;
//         Console.WriteLine("\nUsa las flechas ↑ ↓ para moverte y Enter para seleccionar.");
//         Console.ResetColor();
//     }

//     public async Task EjecutarMenuMain()
//     {
//         bool continuar = true;
//         do
//         {
//             DibujarMenu();
//             var tecla_input = Console.ReadKey(true);

//             switch (tecla_input.Key)
//             {
//                 case ConsoleKey.UpArrow:
//                     opcionSeleccionada = (opcionSeleccionada - 1 + opcionesMenu.Length) % opcionesMenu.Length;
//                     break;
//                 case ConsoleKey.DownArrow:
//                     opcionSeleccionada = (opcionSeleccionada + 1) % opcionesMenu.Length;
//                     break;
//                 case ConsoleKey.Enter:
//                     continuar = await EjecutarOpcion(opcionSeleccionada);
//                     break;
//             }
//         } while (continuar);
//     }

//     private async Task<bool> EjecutarOpcion(int opcion_seleccionada)
//     {
//         Console.Clear();
//         var context = DbContextFactory.Create();

//         switch (opcion_seleccionada)
//         {
//             case 0:
//                 await new MenuTorneo(context).EjecutarMenu();
//                 break;
//             case 1:
//                 await new MenuEquipo(context).EjecutarMenu();
//                 break;
//             case 2:
//                 await new MenuJugador(context).EjecutarMenu();
//                 break;
//             case 3:
//                 await new MenuCuerpoMedico(context).EjecutarMenu();
//                 break;
//             case 4:
//                 await new MenuCuerpoTecnico(context).EjecutarMenu();
//                 break;
//             case 5:
//                 await new MenuTransferencia(context).EjecutarMenu();
//                 break;
//             case 6:
//                 await new MenuEstadisticaEquipo(context).EjecutarMenu();
//                 break;
//             case 7:
//                 await new MenuEstadisticaJugador(context).EjecutarMenu();
//                 break;
//             case 8:
//                 DibujarBanner("🙌 ¡GRACIAS POR JUGAR! 🙌");
//                 Console.WriteLine("Esperamos que tu experiencia haya sido excelente. ⚽💻");
//                 Console.WriteLine("\n¡Johlver, coloqueme buena nota porfa 🙏!");
//                 Console.ForegroundColor = ConsoleColor.Red;
//                 Console.WriteLine("\nPresiona cualquier tecla para salir...");
//                 Console.ResetColor();
//                 Console.ReadKey();
//                 return false;
//         }

//         Console.ForegroundColor = ConsoleColor.DarkGray;
//         Console.WriteLine("\nPresiona cualquier tecla para regresar al menú...");
//         Console.ResetColor();
//         Console.ReadKey(true);
//         return true;
//     }
// }

