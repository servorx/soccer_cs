using System;

namespace soccer_cs;

public class MenuEstadisticaEquipo
{
  private readonly EstadisticaService estadisticaService = new EstadisticaService();

  public void MostrarMenu()
  {
    Console.Clear();
    Console.WriteLine("==== MENÚ ESTADÍSTICAS - EQUIPOS ====\n");
    Console.WriteLine("1. Equipos con más goles en contra por torneo");
    Console.WriteLine("2. Regresar al menú principal\n");
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
          estadisticaService.EquiposConMasGolesEnContraPorTorneo();
          break;
        case "2":
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
