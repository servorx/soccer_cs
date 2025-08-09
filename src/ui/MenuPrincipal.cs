using System;
using System.Collections.Generic;
using System.Security;
using System.Threading;
using System.Threading.Tasks;
using soccer_cs.models;

namespace soccer_cs.ui;
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
  // se declara la variable que se va a utilizar para el menu principal
  private int opcionSeleccionada = 0;
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
  }
  // este metodo se encarga de ejecutar las opciones del menu principal, y se trabaja con boolean para determinar si se debe de continuar o no con el programa, es por eso que esta el Console.ReadKey(true), para que el programa espere a que el usuario precione una tecla antes de continua
  private async Task<bool> EjecutarOpcion(int opcion_seleccionada)
  {
    var context = DbContextFactory.Create();
    Console.Clear();
    switch (opcion_seleccionada)
    {
      case 0:
        Console.Clear();
        await new MenuTorneo(context).EjecutarMenu();  
        Console.ReadKey(true);
        break;
      case 1:
        Console.Clear();
        await new MenuEquipo(context).EjecutarMenu();  
        Console.ReadKey(true);
        break;
      case 2:
        Console.Clear();
        await new MenuJugador(context).EjecutarMenu();  
        Console.ReadKey(true);
        break;
      case 3:
        Console.Clear();
        await new MenuCuerpoMedico(context).EjecutarMenu();  
        Console.ReadKey(true);
        break;
      case 4:
        Console.Clear();
        await new MenuCuerpoTecnico(context).EjecutarMenu();  
        Console.ReadKey(true);
        break;
      case 5:
        Console.Clear();
        await new MenuTransferencias(context).EjecutarMenu();   
        Console.ReadKey(true);
        break;
      case 6:
        Console.Clear();
        await new MenuEstadisticaEquipo(context).EjecutarMenu();  
        Console.ReadKey(true);
        break;
      case 7:
        Console.Clear();
        await new MenuEstadisticaJugador(context).EjecutarMenu();  
        Console.ReadKey(true);
        break;
      case 8:
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
        Console.WriteLine("error al ingresar dato, intentelo de nuevo");
        Console.ReadLine();
        break;
    }
    return true;
  }  
}
