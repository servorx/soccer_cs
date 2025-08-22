using Microsoft.EntityFrameworkCore;
using persona.src.persona.ui;
using soccer_cs.src.modules.cuerpo_medico.application.interfaces;
using soccer_cs.src.modules.cuerpo_medico.application.services;
using soccer_cs.src.modules.jugador.application.interfaces;
using soccer_cs.src.modules.jugador.application.services;
using soccer_cs.src.modules.jugador.domain.models;
using soccer_cs.src.modules.jugador.infrastructure.repositories;
using soccer_cs.src.shared.context;
using soccer_cs.src.shared.helpers;
using soccer_cs.src.shared.utils;

namespace soccer_cs.src.modules.jugador.ui;
public class MenuJugador
{
    private readonly Validaciones validate_data = new Validaciones();
  // esto con el fin de que se pueda acceder a la clase de servicio de jugador
  // private readonly JugadorService _service = null!;
  private readonly IJugadorService _JugadorService;
  private readonly JugadorService _service;
  // esto se implemente con el fin de poder llamar a la clase de menu de persona para algunas funciones como el crear persona al ingresar un cuerpo medico
  private readonly MenuPersona _menuPersona;
  // este codigo se hace con el fin de que cuando se ejecute el programa se pueda ve el menu de la aplicacion
  public MenuJugador(AppDbContext _context)
  {
    var repo = new JugadorRepository(_context);
    _service = new JugadorService(repo); 
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
    await _service.AgregarJugadorAsync(jugador);
    Console.WriteLine("Jugador creado exitosamente.");
    Console.WriteLine("Presiona enter para continuar...");  
    Console.ReadLine();
  }
  private async Task ActualizarJugadorAsync()
  {
    Console.Write("ID del jugador a actualizar: ");
    int id = validate_data.ValidarEntero(Console.ReadLine());

    var existente = await _service.ObtenerJugadorPorIdAsync(id);
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
    Console.Write($"Nuevo numero de dorsal (actual: {existente.NumeroDorsal}), presiona enter para mantener el tipo de dorsal: "); 
    var nuevoNumeroDorsalStr = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(nuevoNumeroDorsalStr))
    {
      existente.NumeroDorsal = nuevoTipoStr;
    }
    else if (!string.IsNullOrEmpty(nuevoTipoStr))
    {
        Console.WriteLine("⚠️ El tipo de torneo no puede ser vacío, se conserva el actual.");
        Console.ReadLine();
    }

    Console.Write($"Nuevo apellido (actual: {existente.Apellido}), presiona enter para mantener el mismo nombre: : ");
    var nuevoApellido = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(nuevoApellido))
      existente.Apellido = nuevoApellido;

    Console.Write($"Nueva edad (actual: {existente.Edad}), presiona enter para mantener el mismo nombre: : ");
    var nuevaEdadStr = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(nuevaEdadStr) && int.TryParse(nuevaEdadStr, out int nuevaEdad))
      existente.Edad = nuevaEdad;

    Console.Write($"Nueva nacionalidad (actual: {existente.Nacionalidad}), presiona enter para mantener el mismo nombre: : ");
    var nuevaNacionalidad = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(nuevaNacionalidad))
      existente.Nacionalidad = nuevaNacionalidad;

    Console.Write($"Nuevo documento identidad (actual: {existente.DocumentoIdentidad}), presiona enter para mantener el mismo nombre: : ");
    var nuevoDocStr = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(nuevoDocStr) && int.TryParse(nuevoDocStr, out int nuevoDoc))
      existente.DocumentoIdentidad = nuevoDoc;

    Console.Write($"Nuevo género (actual: {existente.Genero}), presiona enter para mantener el mismo nombre: : ");
    var nuevoGenero = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(nuevoGenero))
      existente.Genero = nuevoGenero;

    Console.Write($"Nueva especialidad (actual: {existente.Especialidad}), presiona enter para mantener el mismo nombre: : ");
    var nuevaEspecialidad = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(nuevaEspecialidad))
      existente.Especialidad = nuevaEspecialidad;

    Console.Write($"Años experiencia (actual: {existente.AniosExperiencia}), presiona enter para mantener el mismo nombre: : ");
    var nuevoAniosExpStr = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(nuevoAniosExpStr) && int.TryParse(nuevoAniosExpStr, out int nuevoAniosExp))
      existente.AniosExperiencia = nuevoAniosExp;

    // Mostrar resumen de los nuevos datos
    Console.WriteLine("\n--- Confirmar Actualización ---");
    Console.WriteLine($"Nombre: {existente.Nombre}");
    Console.WriteLine($"Apellido: {existente.Apellido}");
    Console.WriteLine($"Edad: {existente.Edad}");
    Console.WriteLine($"Nacionalidad: {existente.Nacionalidad}");
    Console.WriteLine($"Documento: {existente.DocumentoIdentidad}");
    Console.WriteLine($"Género: {existente.Genero}");
    Console.WriteLine($"Especialidad: {existente.Especialidad}");
    Console.WriteLine($"Años Experiencia: {existente.AniosExperiencia}");
    Console.Write("¿Confirmar actualización? (S/N): ");

    var confirmacion = validate_data.ValidarBoleano(Console.ReadLine());

    if (confirmacion)
    {
      await _service.ActualizarJugadorAsync(id, existente);
      Console.WriteLine("País actualizado.");
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
    Console.Write("ID a actualizar: ");
    int id = validate_data.ValidarEntero(Console.ReadLine());

    var existente = await _service.ObtenerJugadorPorIdAsync(id);
    if (existente == null)
    {
      Console.WriteLine("Cuerpo medico no encontrado.");
      Console.ReadLine();
      return;
    }

    await _service.EliminarJugadorAsync(id);
    Console.WriteLine("🗑️ Cuerpo medico eliminado.");
  }
  private async Task MostrarJugadorsAsync()
  {
    var cuerpo_medico = await _service.MostrarJugadorsAsync();
    if (!cuerpo_medico.Any())
    {
      Console.WriteLine("No hay países registrados.");
      return;
    }

    Console.WriteLine("Cuerpo Medicos:");
    foreach (var cm in cuerpo_medico)
    {
      if (cm is null) continue;
      Console.WriteLine($"ID: {cm.Id} | Nombre: {cm.Nombre} | Especialidad: {cm.Especialidad} | Años de experiencia: {cm.AniosExperiencia}");
    }
  }
  private async Task ObtenerJugadorPorIdAsync()
  {
    Console.Write("ID a obtener: ");
    int id = validate_data.ValidarEntero(Console.ReadLine());

    var existente = await _service.ObtenerJugadorPorIdAsync(id);
    if (existente == null)
    {
      Console.WriteLine("Cuerpo medico no encontrado.");
      Console.ReadLine();
      return;
    }

    var cm = await _service.ObtenerJugadorPorIdAsync(id);
    if (cm is null)
    {
      Console.WriteLine("Cuerpo médico no encontrado.");
      return;
    }

    Console.WriteLine($"Cuerpo Médico: ID={cm.Id} | Nombre={cm.Nombre} {cm.Apellido} | Especialidad={cm.Especialidad} | Años de experiencia={cm.AniosExperiencia} | Nacionalidad={cm.Nacionalidad} | Documento={cm.DocumentoIdentidad}");
  }
  private async Task ObtenerJugadorPorNombreAsync()
  {
    Console.Write("Nombre (o parte del nombre): ");
    var nombre = Console.ReadLine()?.Trim();

    if (string.IsNullOrWhiteSpace(nombre))
    {
      Console.WriteLine("Nombre inválido.");
      return;
    }
    var cm = await _service.ObtenerJugadorPorNombreAsync(nombre);
    if (cm is null)
    {
      Console.WriteLine("Cuerpo médico no encontrado.");
      return;
    }
    Console.WriteLine($"Cuerpo Médico: ID={cm.Id} | Nombre={cm.Nombre} {cm.Apellido} | Especialidad={cm.Especialidad} | Años de experiencia={cm.AniosExperiencia} | Nacionalidad={cm.Nacionalidad} | Documento={cm.DocumentoIdentidad}");
    Console.ReadKey();
  }
  public async Task RegistrarJugadoraEquipoAsync()
  {
    Console.Write("ID jugador: ");
    int id_cuerpo_medico = validate_data.ValidarEntero(Console.ReadLine());

    Console.Write("ID equipo: ");
    int id_equipo = validate_data.ValidarEntero(Console.ReadLine());

    await _service.RegistrarJugadorEquipoAsync(id_cuerpo_medico, id_equipo);
    Console.WriteLine("Cuerpo medico registrado.");
  }
  public async Task EliminarJugadorDeEquipoAsync()
  {
    Console.Write("ID jugador: ");
    int id_cuerpo_medico = validate_data.ValidarEntero(Console.ReadLine());

    Console.Write("ID equipo: ");
    int id_equipo = validate_data.ValidarEntero(Console.ReadLine());

    await _service.EliminarJugadorEquipoAsync(id_cuerpo_medico, id_equipo);
    Console.WriteLine("Cuerpo medico eliminado.");
  }
}
