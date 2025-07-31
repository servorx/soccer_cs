using soccer_csharp.data;
using soccer_csharp.models;
using soccer_csharp.utils;

namespace soccer_cs.services;

public class EstadisticaEquipoService
{
  private readonly Validaciones validate_input = new();
  private readonly IdUtil id_util = new();

  public void CrearEstadisticasEquipo()
  {
    Console.Clear();
    Console.WriteLine("=== CREAR NUEVAS ESTADISTICAS DE EQUIPO ===");

    int id_nuevo = id_util.GenerarID();

    Console.Write("Ingrese el ID del equipo: ");
    int? equipo_id = validate_input.ValidarEntero(Console.ReadLine());

    Console.Write("Ingrese la cantidad de partidos ganados: ");
    int partidos_ganados = validate_input.ValidarEntero(Console.ReadLine());

    Console.Write("Ingrese la cantidad de partidos empatados: ");
    int partidos_empatados = validate_input.ValidarEntero(Console.ReadLine());

    Console.Write("Ingrese la cantidad de partidos perdidos: ");
    int partidos_perdidos = validate_input.ValidarEntero(Console.ReadLine());

    Console.Write("Ingrese la cantidad de goles a favor: ");
    int goles_a_favor = validate_input.ValidarEntero(Console.ReadLine());

    Console.Write("Ingrese la cantidad de goles en contra: ");
    int goles_en_contra = validate_input.ValidarEntero(Console.ReadLine());

    Console.WriteLine("\nIngresaste los siguientes datos:");
    var nueva_estadistica = new EstadisticaEquipo(id_nuevo, equipo_id, partidos_ganados, partidos_empatados, partidos_perdidos, goles_a_favor, goles_en_contra);
    nueva_estadistica.MostrarResumen();

    Console.Write("¿Deseas confirmar los cambios? (s/n): ");
    bool validate_data = validate_input.ValidarBoleano(Console.ReadLine());

    if (validate_data)
    {
      AppData.EstadisticaEquipos.Add(nueva_estadistica);
      Console.Clear();
      Console.WriteLine("Estadística de equipo creada exitosamente :)");
    }
    else
    {
      Console.Clear();
      Console.WriteLine("No se confirmaron los cambios.");
    }

    Console.WriteLine("Presione una tecla para continuar...");
    Console.ReadLine();
  }

  public void EquiposConMasGolesEnContraPorTorneo()
  {
    // Lógica futura aquí
  }
}
