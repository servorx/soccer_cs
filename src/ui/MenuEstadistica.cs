using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace soccer_cs;
public class MenuEstadistica
{
  private readonly EstadisticaService estadisticaService = new EstadisticaService();
  public void MostrarMenuEstadisticas()
  {
    Console.Clear();
    Console.WriteLine("========== MENÚ ESTADISTICAS ==========\n");
    Console.WriteLine("3.1. Jugadores con mas asistencias por torneo ");
    Console.WriteLine("3.2. Equipos con mas goles en contra por torneo");
    Console.WriteLine("3.3. Jugadores mas caros por equipo");
    Console.WriteLine("3.4. Jugadores con edad mayor al promedio de edad del equipo");
    Console.WriteLine("3.5. Regresar al main menu\n");
    Console.Write("Selecciona una opción: ");
  }
  public void Mostrar()
  {
    bool validation_program = true;
    do
    {
      MostrarMenuEstadisticas();
      string? opcion = Console.ReadLine();
      switch (opcion)
      {
        case "1":
          estadisticaService.JugadoresConMasAsistenciasPorTorneo();
          break;
        case "2":
          estadisticaService.EquiposConMasGolesEnContraPorTorneo();
          break;
        case "3":
          estadisticaService.JugadoresMasCarosPorEquipo();
          break;
        case "4":
          estadisticaService.JugadoresConEdadMayorAlPromedioDeEdadDelEquipo();
          break;
        case "5":
          return;
        default:
          Console.Clear();
          System.Console.WriteLine("error al ingresar dato, intentelo de nuevo");
          Console.ReadLine();
          break;
      }
    } while (validation_program);
  }
}
