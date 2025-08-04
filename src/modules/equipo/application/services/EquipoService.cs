using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Org.BouncyCastle.Asn1;
using soccer_cs.infrastructure.utils;
using System.Runtime.CompilerServices;
using soccer_cs.services;
using soccer.modules.equipo.domain;
using soccer_cs.models;


namespace soccer_cs;

public class EquipoService
{
  private readonly Validaciones validate_input = new();
  private readonly IdUtil idUtil = new();
  public void CrearEquipo()
  {
    Console.Clear();
    Console.WriteLine("=== CREAR NUEVO EQUIPO ===");

    int id_nuevo = idUtil.GenerarID();

    System.Console.WriteLine("ingrese el nombre del equipo: ");
    string nombre = validate_input.ValidarTexto(Console.ReadLine()).ToLower();

    System.Console.WriteLine("ingrese la ciudad de donde viene el equipo: ");
    string? ciudad = validate_input.ValidarTexto(Console.ReadLine()).ToLower();

    System.Console.WriteLine("ingrese el pais de donde viene el equipo: ");
    string? pais = validate_input.ValidarTexto(Console.ReadLine()).ToLower();

    System.Console.WriteLine("ingrese el nombre del estadio del equipo ");
    string? estadio = validate_input.ValidarTexto(Console.ReadLine());

    System.Console.WriteLine("ingrese que tipo de equipo es (seleccion o club):");
    string tipo_equipo = validate_input.ValidarTexto(Console.ReadLine());

    System.Console.WriteLine("ingrese la cantidad de titulos que tiene el equipo: ");
    int? cantidad_titulos = validate_input.ValidarEntero(Console.ReadLine());

    // crear los objetos de las listas que trabaja para pedir los datos de las listas 
    // TODO: hacer condicionales para preguntarle al usuario si desea ingresar esos servicios y hacerlos opcionales, osea, que admitan servicios nulos
    System.Console.WriteLine("Desea agregarle jugadores a su equipo? (s/n): ");
    bool input_jugador = validate_input.ValidarBoleano(Console.ReadLine());
    if (input_jugador)
    {
      JugadorService jugadorService = new JugadorService();
      jugadorService.CrearJugador();
    }
    
    System.Console.WriteLine("Desea agregarle cuerpo tecnico y cuerpo medico a su equipo? (s/n): ");
    bool input_cuerpo = validate_input.ValidarBoleano(Console.ReadLine());
    if (input_cuerpo)
    {
      EquipoService equipoService = new EquipoService();
      equipoService.CrearCuerpoTecnico();
      equipoService.CrearCuerpoMedico();
    }
    
    // mostrar los datos ingresados y validar su confirmacion 
    System.Console.WriteLine($"\ningresaste los datos:");
    Equipo equipo = new Equipo();
    equipo.ToString();
    System.Console.Write("deseas confirmar los cambios? (s/n): ");
    bool validate_data = validate_input.ValidarBoleano(Console.ReadLine());

    // agregar los datos a la lista Torneo
    if (validate_data)
    {
      // crear un nuevo equipo con los datos ingresados
      Equipo nuevo_equipo = new Equipo(id_nuevo,
      nombre,
      ciudad,
      pais,
      estadio,
      tipo_equipo,
      cantidad_titulos,
      new List<Jugador?>() { AppData.Jugadores.Last() },
      new List<CuerpoTecnico?>() { AppData.CuerpoTecnicos.Last() },
      new List<CuerpoMedico?>() { AppData.CuerpoMedicos.Last() },
      new List<Torneo?>() { AppData.Torneos.Last() },
      new List<EstadisticaEquipo?>() { AppData.EstadisticaEquipos.Last() });
      // agrega la lista de datos nuevo_equipo a Equipos
      AppData.Equipos.Add(nuevo_equipo);
      Console.Clear();
      System.Console.WriteLine("Equipo creado exitosamente :)");
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
  public void CrearCuerpoTecnico()
  {
    Console.Clear();
    Console.WriteLine("=== CREAR CUERPO TÉCNICO ===");

    // crear de nuevo una persona para trabajar y recortar codigo
    PersonaService personaService = new PersonaService();
    personaService.CrearPersona();

    System.Console.WriteLine("ingrese el rol del tecnico: ");
    string rol = validate_input.ValidarTexto(Console.ReadLine()).ToLower();

    System.Console.WriteLine("ingrese los anios de experiencia del tecnico: ");
    int aniosExperiencia = validate_input.ValidarEntero(Console.ReadLine());

    // mostrar los datos ingresados y validar su confirmacion
    System.Console.WriteLine($"\ningresaste los datos:");
    CuerpoTecnico cuerpoTecnico = new CuerpoTecnico();
    cuerpoTecnico.ToString();
    System.Console.Write("deseas confirmar los cambios? (s/n): ");
    bool validate_data = validate_input.ValidarBoleano(Console.ReadLine());

    var last_persona = AppData.Personas.Last();
    // agregar los datos a la lista Torneo
    if (validate_data)
    {
      // crear un nuevo equipo con los datos ingresados
      CuerpoTecnico nuevo_cuerpo_tecnico = new CuerpoTecnico(
      last_persona.Id,
      last_persona.Nombre,
      last_persona.Apellido,
      last_persona.Edad,
      last_persona.Nacionalidad,
      last_persona.DocumentoIdentidad,
      last_persona.Genero,
      rol,
      aniosExperiencia);
      // agrega la lista de datos nuevo_equipo a Equipos
      AppData.CuerpoTecnicos.Add(nuevo_cuerpo_tecnico);
      Console.Clear();
      System.Console.WriteLine("Cuerpo tecnico creado exitosamente :)");
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
  public void CrearCuerpoMedico()
  {
    Console.Clear();
    Console.WriteLine("=== CREAR CUERPO MÉDICO ===");

    // crear de nuevo una persona para trabajar y recortar codigo
    PersonaService personaService = new PersonaService();
    personaService.CrearPersona();

    System.Console.WriteLine("ingrese la especialidad del medico: ");
    string especialidad = validate_input.ValidarTexto(Console.ReadLine()).ToLower();

    System.Console.WriteLine("ingrese la certificacion del medico: ");
    int anios_experiencia = validate_input.ValidarEntero(Console.ReadLine());

    // mostrar los datos ingresados y validar su confirmacion
    System.Console.WriteLine($"\ningresaste los datos:");
    CuerpoMedico cuerpoMedico = new CuerpoMedico();
    cuerpoMedico.ToString();
    System.Console.Write("deseas confirmar los cambios? (s/n): ");
    bool validate_data = validate_input.ValidarBoleano(Console.ReadLine());

    var last_persona = AppData.Personas.Last();
    // agregar los datos a la lista Torneo
    if (validate_data)
    {
      // crear un nuevo equipo con los datos ingresados
      CuerpoMedico nuevo_cuerpo_medico = new CuerpoMedico(last_persona.Id,
      last_persona.Nombre,
      last_persona.Apellido,
      last_persona.Edad,
      last_persona.Nacionalidad,
      last_persona.DocumentoIdentidad,
      last_persona.Genero,
      especialidad,
      anios_experiencia);
      // agrega la lista de datos nuevo_equipo a Equipos
      AppData.CuerpoMedicos.Add(nuevo_cuerpo_medico);
      Console.Clear();
      System.Console.WriteLine("Cuerpo medico creado exitosamente :)");
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
  public void InscribirTorneo()
  {
    Console.Clear();
    
    System.Console.Write("ingrese el ID o el nombre del equipo que desea inscribir: ");
    string? busqueda = validate_input.ValidarTexto(Console.ReadLine()).ToLower();

    var equipo_busqueda = AppData.Equipos.FirstOrDefault(t =>
    t.Nombre!.Contains(busqueda) || t.Id.ToString() == busqueda
    );

    if (equipo_busqueda != null)
    {
      System.Console.Write($"\nEquipo encontrado:\nID: {equipo_busqueda.Id}\nNombre: {equipo_busqueda.Nombre}\nUbicacion: {equipo_busqueda.Pais}\nEstadio: {equipo_busqueda.Estadio} días\nTotal de titulos: {equipo_busqueda.CantidadTitulos}\nJugadores del equipo: {equipo_busqueda.Jugadores.Count}\n");
      Console.ReadLine();
    }
    else
    {
      System.Console.Write("Equipo no encontrado...");
      Console.ReadLine();
    }

    System.Console.WriteLine("desea inscribir su equipo a un torneo? (s/n): ");
    bool input_torneo = validate_input.ValidarBoleano(Console.ReadLine());
    if (input_torneo)
    {
      TorneoService torneoService = new TorneoService();
      torneoService.CrearTorneo();
      EstadisticaService estadisticaEquipo = new EstadisticaService();
      estadisticaEquipo.CrearEstadisticasEquipo();
    }
  }

  public void GestionarJugadoresPorEquipo()
  {
    // Implementación del método para gestionar jugadores por equipo
  }

  public void NotificacionTransferencia()
  {
    // Implementación del método para notificar transferencias
  }

  public void SalirDelTorneo()
  {
    // Implementación del método para salir de un torneo
  }
}
