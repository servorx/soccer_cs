using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soccer_cs.infrastructure.utils;

namespace soccer_cs.ui;
public class MenuPrincipal
{
  private readonly Validaciones validate_data = new Validaciones();
  public void MostrarBienvenida()
  {
    Console.Clear();

    EscribirConPausa("======================================", 100);
    EscribirConPausa("⚽ BIENVENIDO AL SISTEMA DE FÚTBOL ⚽", 100);
    EscribirConPausa("======================================\n", 100);

    Thread.Sleep(400);

    EscribirConPausa("Este sistema permite gestionar:", 100);
    EscribirConPausa("- Torneos", 100);
    EscribirConPausa("- Equipos", 100);
    EscribirConPausa("- Jugadores", 100);
    EscribirConPausa("- Transferencias", 100);
    EscribirConPausa("- Estadísticas", 100);
    Console.WriteLine();

    Thread.Sleep(500);
    EscribirConPausa("De forma totalmente interactiva ⚙️ 🧠\n", 100);

    Thread.Sleep(500);
    EscribirConPausa("Desarrollado por Ángel Pinzón 🧠💻\n", 100);

    Thread.Sleep(700);
    Console.ForegroundColor = ConsoleColor.Yellow;
    EscribirConPausa("Presiona una tecla para continuar...", 100);
    Console.ResetColor();
    Console.ReadKey();
  }
  // Método auxiliar para escribir línea por línea con pausa.
  public void EscribirConPausa(string texto, int milisegundos)
  {
    Console.WriteLine(texto);
    Thread.Sleep(milisegundos);
  }
  public void MostrarMenuPrincipal()
  {
    Console.Clear();
    Console.WriteLine("========== MENÚ PRINCIPAL ==========\n");
    Console.WriteLine("1. Registro torneos");
    Console.WriteLine("2. Registro de equipos");
    Console.WriteLine("3. Registros jugadores");
    Console.WriteLine("4. Registros de cuerpo medico");
    Console.WriteLine("5. Registros de cuerpo tecnico");
    Console.WriteLine("5. Transferencias (compra de jugadores)");
    Console.WriteLine("5. Estadisticas de equipo");
    Console.WriteLine("6. Estadisitcas de jugadores");
    Console.WriteLine("7. Salir del programa\n");
    Console.Write("Selecciona una opción (1-7): ");
  }
  public void EjecutarMenuMain()
  {
    bool validation_program = true;
    do
    {
      MostrarMenuPrincipal();
      string? opcion = validate_data.ValidarTexto(Console.ReadLine());

      switch (opcion)
      {
        case "1":
          MenuTorneo menuTorneos = new MenuTorneo();
          menuTorneos.Mostrar();
          break;
        case "2":
          MenuEquipo menuEquipos = new MenuEquipo();
          menuEquipos.Mostrar();
          break;
        case "3":
          MenuJugador menuJugadores = new MenuJugador();
          menuJugadores.Mostrar();
          break;
        case "4":
          MenuEstadisticaJugador menuEstadisticaJugador = new MenuEstadisticaJugador();
          menuEstadisticaJugador.Mostrar();
          break;
        case "5":
          MenuEstadisticaEquipo menuEstadisticaEquipo = new MenuEstadisticaEquipo();
          menuEstadisticaEquipo.Mostrar();
          break;
        case "6":
          DbInstaller dbInstaller = new DbInstaller();
          dbInstaller.BorrarBaseDeDatos("Server=localhost;Uid=root;Pwd=s1e2r3v0or;", "soccer_cs");
          break;
        case "7":
          validation_program = false;
          Console.Clear();
          Console.ForegroundColor = ConsoleColor.Cyan;
          Console.WriteLine("==========================================");
          Console.WriteLine("     🙌 ¡GRACIAS POR USAR EL SISTEMA! 🙌");
          Console.WriteLine("==========================================\n");
          Console.ResetColor();

          Console.WriteLine("Esperamos que tu experiencia haya sido excelente. ⚽💻");
          Console.WriteLine("\n¡Johlver coloqueme buena nota porfa 🙏!");
          Console.WriteLine("\nPresiona cualquier tecla para salir...");
          Console.ReadKey();
          break;
        default:
          Console.Clear();
          System.Console.WriteLine("error al ingresar dato, intentelo de nuevo");
          Console.ReadLine();
          break;
      }
    } while (validation_program);
  }
}
