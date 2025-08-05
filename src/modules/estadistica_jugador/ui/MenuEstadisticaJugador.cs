using System;

namespace soccer_cs;

public class MenuEstadisticaJugador
{
  private readonly EstadisticaService estadisticaService = new EstadisticaService();

  public void MostrarMenu()
  {
    Console.Clear();
    Console.WriteLine("==== MENÚ ESTADÍSTICAS - JUGADORES ====\n");
    Console.WriteLine("1. Jugadores con más asistencias por torneo");
    Console.WriteLine("2. Jugadores más caros por equipo");
    Console.WriteLine("3. Jugadores con edad mayor al promedio de edad del equipo");
    Console.WriteLine("4. Regresar al menú principal\n");
    Console.Write("Selecciona una opción: ");
  }

  public void Mostrar()
  {
    bool continuar = true;
    while (continuar)
    {
      MostrarMenu();
      string? opcion = Console.ReadLine();
      switch (opcion)
      {
        case "1":
          estadisticaService.JugadoresConMasAsistenciasPorTorneo();
          break;
        case "2":
          estadisticaService.JugadoresMasCarosPorEquipo();
          break;
        case "3":
          estadisticaService.JugadoresConEdadMayorAlPromedioDeEdadDelEquipo();
          break;
        case "4":
          continuar = false;
          break;
        default:
          Console.Clear();
          Console.WriteLine("Opción inválida, por favor intenta de nuevo.");
          Console.ReadLine();
          break;
      }
    }
  }
}
