using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Globalization;
using soccer_cs.infrastructure.utils;
using soccer_cs.application;
using soccer_cs.application.services;
using soccer_cs.models;

namespace soccer_cs.services;

public class JugadorService
{
  private readonly Validaciones validate_input = new();
  public void CrearJugador()
  {
    Console.Clear();
    // primero crea la persona asociada al jugador
    PersonaService personaService = new PersonaService();
    personaService.CrearPersona();

    Console.WriteLine("=== CREAR NUEVO JUGADOR ===");

    System.Console.Write("ingrese la posicion del jugador: ");
    string posicion = validate_input.ValidarTexto(Console.ReadLine()).ToLower();

    System.Console.Write("ingrese el numero de camiseta del jugador: ");
    int numero_dorsal = validate_input.ValidarEntero(Console.ReadLine());

    System.Console.Write("ingrese el pie habil del jugador (derecho/izquierdo): ");
    string pie_habil = validate_input.ValidarTexto(Console.ReadLine()).ToLower();

    System.Console.Write($"ingrese el valor de mercado del jugador en {NumberFormatInfo.CurrentInfo.CurrencySymbol}: ");
    float valor_mercado = validate_input.ValidarDecimal(Console.ReadLine());

    System.Console.Write("ingrese el equipo actual del jugador (dejar en blanco si no pertenece a ningun equipo): ");
    string equipo_actual = validate_input.ValidarTexto(Console.ReadLine()).ToLower();

    if (string.IsNullOrWhiteSpace(equipo_actual))
    { 
      // TODO 
    }

    
    // TODO revisar muy bien como registrar equipos en el torneo y como crear las estadisticas del jugador
    // crear estadisticas del jugador
    EstadisticaService estadisticaService = new EstadisticaService();
    estadisticaService.CrearEstadisticasJugador();

    // mostrar los datos ingresados y validar su confirmacion 
    System.Console.WriteLine($"\ningresaste los datos:");
    Jugador jugador = new Jugador();
    jugador.ToString();
    System.Console.Write("deseas confirmar los cambios? (s/n): ");
    bool validate_data = validate_input.ValidarBoleano(Console.ReadLine());

    // agregar los datos a la lista Torneo
    if (validate_data)
    {
      // agregar los datos de persona y estadisticas al jugador
      // se usa AppData.Personas.Last() y el nombre de la variable asociada para obtener la ultima persona creada
      // // var last_person = AppData.Personas.Last();

      Jugador nuevo_jugador = new Jugador(id_nuevo, 
      last_person.Nombre, 
      last_person.Apellido,
      last_person.Edad,
      last_person.Nacionalidad,
      last_person.DocumentoIdentidad,
      last_person.Genero,
      posicion,
      numero_dorsal,
      pie_habil,
      valor_mercado,
      equipo_actual,
      // crear una nueva lista para poder instancia la ultima estadistica de jugador
      new List<EstadisticaJugador?> { AppData.EstadisticaJugadors.Last() });
      // agrega la lista de datos nuevo_jugadora a Torneos
      AppData.Jugadores.Add(nuevo_jugador);
      Console.Clear();
      System.Console.WriteLine("Jugador creado exitosamente :)");
      System.Console.WriteLine("presione una tecla para continuar...");
      Console.ReadLine();
    }
    else
    {
      Console.Clear();
      System.Console.WriteLine("no confirmó los cambios, presione una tecla para volver al menu");
      Console.ReadLine();
    }
  }

  public void BuscarJugador()
  {
    
  }

  public void EditarJugador()
  {
    
  }

  public void EliminarJugador()
  {
    
  }
}
