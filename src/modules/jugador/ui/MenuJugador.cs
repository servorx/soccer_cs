using Microsoft.EntityFrameworkCore;
using persona.src.persona.ui;
using soccer_cs.src.modules.cuerpo_medico.application.interfaces;
using soccer_cs.src.modules.cuerpo_medico.application.services;
using soccer_cs.src.modules.jugador.application.interfaces;
using soccer_cs.src.modules.jugador.application.services;
using soccer_cs.src.modules.jugador.domain.models;
using soccer_cs.src.modules.jugador.infrastructure.repositories;
using soccer_cs.src.modules.persona.application.services;
using soccer_cs.src.shared.context;
using soccer_cs.src.shared.helpers;
using soccer_cs.src.shared.utils;

namespace soccer_cs.src.modules.jugador.ui;
public class MenuJugador
{
    private readonly Validaciones validate_data = new Validaciones();
  // esto con el fin de que se pueda acceder a la clase de servicio de jugador
  // private readonly JugadorService _service = null!;
  // private readonly IJugadorService _JugadorService;
  private readonly PersonaService personaService = null!;
  private readonly JugadorService _jugadorService;
  // esto se implemente con el fin de poder llamar a la clase de menu de persona para algunas funciones como el crear persona al ingresar un cuerpo medico
  private readonly MenuPersona _menuPersona;
  // este codigo se hace con el fin de que cuando se ejecute el programa se pueda ve el menu de la aplicacion
  public MenuJugador(AppDbContext _context)
  {
    var repo = new JugadorRepository(_context);
    _jugadorService = new JugadorService(repo); 
  }
  // se declara la variable que se va a utilizar para el menu principal
  private int opcionSeleccionada = 0;
  // se declara un arreglo de strings que contiene las opciones del menu principal
  private readonly string[] opcionesMenu =
  {
    "Crear jugador",
    "Actualizar jugador",
    "Eliminar jugador",
    "Mostrar todos los cuerpos medicos",
    "Buscar jugador por id",
    "Buscar jugador por nombre",
    "Registrar jugador a equipo",
    "Eliminar jugador de un equipo",
    "Regresar al menú principal"
  };
  // este es el metodo del menu principal en la consola con las flechas de arriba y abajo
  public void DibujarMenu()
  {
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("========== MENÚ JUGADORES ==========\n");
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
  public async Task EjecutarMenu()
  {
    bool validate_menu = true;
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
          validate_menu = await EjecutarOpcion(opcionSeleccionada);
          break;
      }
    } while (validate_menu);
  }
  private async Task<bool> EjecutarOpcion(int opcion_seleccionada)
  {
    Console.Clear();
    switch (opcion_seleccionada)
    {
      case 0:
        Console.Clear();
        await AgregarJugadorAsync();
        break;
      case 1:
        Console.Clear();
        await ActualizarJugadorAsync();
        break;
      case 2:
        Console.Clear();
        await EliminarJugadorAsync();
        break;
      case 3:
        Console.Clear();
        await MostrarJugadorsAsync();
        break;
      case 4:
        Console.Clear();
        await ObtenerJugadorPorIdAsync();
        break;
      case 5:
        Console.Clear();
        await ObtenerJugadorPorNombreAsync();
        break;
      case 6:
        Console.Clear();
        await RegistrarJugadoraEquipoAsync();
        break;
      case 7:
        Console.Clear();
        await EliminarJugadorDeEquipoAsync();
        break;
      case 8:
        return false;
      default:
        Console.Clear();
        Console.WriteLine("error al ingresar dato, intentelo de nuevo");
        Console.ReadLine();
        return false;
    }
    return true;
  }
  private async Task AgregarJugadorAsync()
  {
    Console.Clear(); 
    Console.WriteLine("---- Registrar jugador ----");
    // Crear la persona primero y obtener su Id
    var persona = await _menuPersona.AgregarPersonaAsync();
    
    Console.Write("Posicion: ");
    var posicion = validate_data.ValidarTexto(Console.ReadLine());

    Console.Write("Numero de dorsal: ");
    var numero_dorsal = validate_data.ValidarEntero(Console.ReadLine());

    Console.WriteLine("Pie habil (izquierdo/derecho): ");
    var pie_habil = validate_data.ValidarTexto(Console.ReadLine());

    Console.WriteLine("Valor del jugador en el mercado: ");
    var valor_jugador = validate_data.ValidarEntero(Console.ReadLine());
    // hacer que el id persona sea el ultimo id creado en la base de datos ya que al crear el jugador se crea una persona primero
    var id_persona = await DbContextFactory.Create().Personas.MaxAsync(p => p.Id);

    // verifica si el usuario quiere confirmar los cambios
    Console.Clear();
    Console.WriteLine("Datos ingresados: \n");
    Console.WriteLine($"Nombre: {posicion} | Numero de dorsal: {numero_dorsal} | Pie habil: {pie_habil} | Valor del jugador: {valor_jugador}");
    Console.Write("¿Desea registrar el jugador con los datos introducidos? (S/N): ");
    var opcion = validate_data.ValidarBoleano(Console.ReadLine());
    if (opcion == false) return;

    // se crea el nuevo torneo
    var jugador = new Jugador
    {
      Persona = persona,
      Posicion = posicion,
      NumeroDorsal = numero_dorsal,
      PieHabil = pie_habil,
      ValorMercado = valor_jugador 
    };
    await _jugadorService.AgregarJugadorAsync(jugador);
    Console.WriteLine("Jugador creado exitosamente.");
    Console.WriteLine("Presiona enter para continuar...");  
    Console.ReadLine();
  }
  private async Task ActualizarJugadorAsync()
  {
    // mostrar todos los jugadores disponibles
    await MostrarJugadorsAsync();
    Console.Write("ID del jugador a actualizar: ");
    int id = validate_data.ValidarEntero(Console.ReadLine());

    var existente = await _jugadorService.ObtenerJugadorPorIdAsync(id);
    if (existente == null)
    {
      Console.WriteLine("Jugador no encontrado.");
      Console.ReadLine();
      return;
    }
    // en este caso no voy a hacer validate data de modo que si el usuario quiere mantener un dato, le de enter y lo deje como es
    var nuevaPersona = await _menuPersona.ActualizarPersonaAsync();
    if (nuevaPersona == null)
    {
      Console.WriteLine("Persona no encontrada.");
      Console.ReadLine();
      return;
    }

    Console.Write($"Nueva posicion (actual: {existente.Posicion}), presiona enter para mantener la misma posicion: ");
    var nuevoPosicionStr = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(nuevoPosicionStr))
      existente.Posicion = nuevoPosicionStr;

    Console.Write($"Nuevo numero de dorsal (actual: {existente.NumeroDorsal}), presiona enter para mantener el tipo de dorsal: "); 
    var nuevoNumeroDorsalStr = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(nuevoNumeroDorsalStr) && int.TryParse(nuevoNumeroDorsalStr, out int nuevoNumeroDorsal))
    {
      existente.NumeroDorsal = nuevoNumeroDorsal;
    }
    else if (!string.IsNullOrEmpty(nuevoNumeroDorsalStr))
    {
      Console.WriteLine("⚠️ Error al ingresar el tipo de dato, se conserva el actual.");
      Console.WriteLine("Presiona una tecla para continuar...");
      Console.ReadLine();
    }

    Console.Write($"Nueva pie habil (actual: {existente.PieHabil}), presiona enter para mantener el mismo pie habil: ");
    var nuevoPieHabilStr= Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(nuevoPieHabilStr))
      existente.PieHabil = nuevoPieHabilStr;

    Console.Write($"Nuevo valor del jugador (actual: {existente.ValorMercado}), presiona enter para mantener el mismo valor: ");
    var nuevoValorStr = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(nuevoValorStr) && float.TryParse(nuevoValorStr, out float nuevoValor))
      existente.ValorMercado = nuevoValor;

    // Mostrar resumen de los nuevos datos
    Console.WriteLine("\n--- Confirmar Actualización ---\n");
    Console.WriteLine($"Nombre: {existente.Persona.Nombre}");
    Console.WriteLine($"Apellido: {existente.Persona.Apellido}");
    Console.WriteLine($"Edad: {existente.Persona.Edad}");
    Console.WriteLine($"Nacionalidad: {existente.Persona.Nacionalidad}");
    Console.WriteLine($"Documento: {existente.Persona.DocumentoIdentidad}");
    Console.WriteLine($"Género: {existente.Persona.Genero}");
    Console.WriteLine($"Posicion: {existente.Posicion}");
    Console.WriteLine($"Numero de dorsal: {existente.NumeroDorsal}");
    Console.WriteLine($"Pie habil: {existente.PieHabil}");
    Console.WriteLine($"Valor del jugador: {existente.ValorMercado}");
    Console.Write("¿Confirmar actualización? (S/N): ");

    var confirmacion = validate_data.ValidarBoleano(Console.ReadLine());

    if (confirmacion)
    {
      await _jugadorService.ActualizarJugadorAsync(id, existente);
      Console.WriteLine("Jugador actualizado.");
      Console.ReadLine();
    }
    else
    {
      Console.WriteLine("Actualización cancelada.");
      Console.ReadLine();
    }
  }
  private async Task EliminarJugadorAsync()
  {
    Console.Clear();
    await MostrarJugadorsAsync();
    Console.Write("ID del jugadora eliminar: ");
    int id = validate_data.ValidarEntero(Console.ReadLine());

    var existente = await _jugadorService.ObtenerJugadorPorIdAsync(id);
    if (existente == null)
    {
      Console.WriteLine("Jugador no encontrado.");
      Console.ReadLine();
      return;
    }

    await _jugadorService.EliminarJugadorAsync(id);
    Console.WriteLine("🗑️ Jugador eliminado.");
  }
  private async Task MostrarJugadorsAsync()
  {
    var jugador = await _jugadorService.MostrarJugadorsAsync();
    if (!jugador.Any())
    {
      Console.WriteLine("No hay jugadores registrados.");
      return;
    }

    Console.WriteLine("Jugadores disponibles:");
    foreach (var j in jugador)
    {
      if (j is null) continue;
      Console.WriteLine($"ID: {j.Id} | Nombre: {j.Persona.Nombre} | Posicion: {j.Posicion} | Numero de dorsal: {j.NumeroDorsal} | Pie habil: {j.PieHabil} | Valor del jugador: {j.ValorMercado}");
    }
  }
  private async Task ObtenerJugadorPorIdAsync()
  {
    // mostrar todos los jugadores disponibles
    await MostrarJugadorsAsync();
    Console.Write("ID del jugador a obtener: ");
    int id = validate_data.ValidarEntero(Console.ReadLine());

    var j = await _jugadorService.ObtenerJugadorPorIdAsync(id);
    if (j is null)
    {
      Console.WriteLine("Jugador no encontrado.");
      return;
    }

    Console.WriteLine($"ID: {j.Id} | Nombre: {j.Persona.Nombre} | Posicion: {j.Posicion} | Numero de dorsal: {j.NumeroDorsal} | Pie habil: {j.PieHabil} | Valor del jugador: {j.ValorMercado}");
  }
  private async Task ObtenerJugadorPorNombreAsync()
  {
    // mostrar todos los jugadores disponibles
    await MostrarJugadorsAsync();
    Console.Write("Escriba el nombre del jugador (o parte del nombre): ");
    var nombre = Console.ReadLine()?.Trim();

    if (string.IsNullOrWhiteSpace(nombre))
    {
      Console.WriteLine("Nombre inválido.");
      return;
    }
    var j = await _jugadorService.ObtenerJugadorPorNombreAsync(nombre);
    if (j is null)
    {
      Console.WriteLine("Cuerpo médico no encontrado.");
      return;
    }
    Console.WriteLine($"ID: {j.Id} | Nombre: {j.Persona.Nombre} | Posicion: {j.Posicion} | Numero de dorsal: {j.NumeroDorsal} | Pie habil: {j.PieHabil} | Valor del jugador: {j.ValorMercado}");
  }
  public async Task RegistrarJugadoraEquipoAsync()
  {
    Console.Write("ID jugador: ");
    int id_jugador = validate_data.ValidarEntero(Console.ReadLine());

    Console.Write("ID equipo: ");
    int id_equipo = validate_data.ValidarEntero(Console.ReadLine());

    await _jugadorService.RegistrarJugadorAEquipoAsync(id_jugador, id_equipo);
    Console.WriteLine("Cuerpo medico registrado.");
  }
  public async Task EliminarJugadorDeEquipoAsync()
  {
    Console.Write("ID jugador: ");
    int id_cuerpo_medico = validate_data.ValidarEntero(Console.ReadLine());

    Console.Write("ID equipo: ");
    int id_equipo = validate_data.ValidarEntero(Console.ReadLine());

    await _jugadorService.EliminarJugadorAEquipoAsync(id_cuerpo_medico, id_equipo);
    Console.WriteLine("Cuerpo medico eliminado.");
  }
}
