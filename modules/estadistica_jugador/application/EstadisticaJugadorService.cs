using soccer_csharp.data;
using soccer_csharp.models;
using soccer_csharp.utils;

namespace soccer_cs;

public class EstadisticaJugadorService
{
    private readonly Validaciones validate_input = new();
    private readonly IdUtil id_util = new();

    public void CrearEstadisticasJugador()
    {
        Console.Clear();
        Console.WriteLine("=== CREAR NUEVAS ESTADISTICAS DE JUGADOR ===");

        int id_nuevo = id_util.GenerarID();

        Console.Write("Ingrese el nombre del jugador: ");
        string nombre = validate_input.ValidarTexto(Console.ReadLine()).ToLower();

        Console.Write("Ingrese los goles del jugador: ");
        int goles = validate_input.ValidarEntero(Console.ReadLine());

        Console.Write("Ingrese las asistencias del jugador: ");
        int asistencias = validate_input.ValidarEntero(Console.ReadLine());

        Console.Write("Ingrese la cantidad de partidos jugados por el jugador: ");
        int partidos_jugados = validate_input.ValidarEntero(Console.ReadLine());

        Console.Write("Ingrese la estatura del jugador (en metros): ");
        float estatura = validate_input.ValidarDecimal(Console.ReadLine());

        Console.Write("Ingrese el peso del jugador (en kilogramos): ");
        float peso = validate_input.ValidarDecimal(Console.ReadLine());

        Console.Write("Ingrese la cantidad de tarjetas amarillas del jugador: ");
        int tarjetas_amarillas = validate_input.ValidarEntero(Console.ReadLine());

        Console.Write("Ingrese la cantidad de tarjetas rojas del jugador: ");
        int tarjetas_rojas = validate_input.ValidarEntero(Console.ReadLine());

        Console.WriteLine("\nIngresaste los siguientes datos:");
        var nueva_estadistica = new EstadisticaJugador(id_nuevo, goles, asistencias, partidos_jugados, estatura, peso, tarjetas_amarillas, tarjetas_rojas);
        nueva_estadistica.MostrarResumen();

        Console.Write("¿Deseas confirmar los cambios? (s/n): ");
        bool validate_data = validate_input.ValidarBoleano(Console.ReadLine());

        if (validate_data)
        {
            AppData.EstadisticaJugadors.Add(nueva_estadistica);
            Console.Clear();
            Console.WriteLine("Estadística de jugador creada exitosamente :)");
        }
        else
        {
            Console.Clear();
            Console.WriteLine("No se confirmaron los cambios.");
        }

        Console.WriteLine("Presione una tecla para continuar...");
        Console.ReadLine();
    }

    public void JugadoresConMasAsistenciasPorTorneo()
    {
        // Lógica futura aquí
    }

    public void JugadoresMasCarosPorEquipo()
    {
        // Lógica futura aquí
    }

    public void JugadoresConEdadMayorAlPromedioDeEdadDelEquipo()
    {
        // Lógica futura aquí
    }
}
