// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using soccer_cs.infrastructure.utils;

// namespace soccer_cs;
// public class MenuCuerpoTecnico
// {
//   private readonly Validaciones validate_data = new Validaciones();
//   // esto con el fin de que se pueda acceder a la clase de servicio de cuerpo tecnico
//   readonly CuerpoTecnicoService _service = null!;
//   // este codigo se hace con el fin de que cuando se ejecute el programa se pueda ve el menu de la aplicacion
//   public MenuCuerpoTecnico(AppDbContext _context)
//   {
//     var repo = new CuerpoTecnicoRepository(_context);
//     _service = new CuerpoTecnicoService(repo);
//   }
//   // se declara la variable que se va a utilizar para el menu principal
//   private int opcionSeleccionada = 0;
//   // se declara un arreglo de strings que contiene las opciones del menu principal
//   private readonly string[] opcionesMenu =
//   {
//     "Crear cuerpo tecnico",
//     "Actualizar cuerpo tecnico",
//     "Eliminar cuerpo tecnico",
//     "Mostrar todos los cuerpos medicos",
//     "Buscar cuerpo tecnico por id",
//     "Buscar cuerpo tecnico por nombre",
//     "Registrar cuerpo tecnico a equipo",
//     "Eliminar cuerpo tecnico de un equipo",
//     "Regresar al menú principal"
//   };
//   // este es el metodo del menu principal en la consola con las flechas de arriba y abajo
//   public void DibujarMenu()
//   {
//     Console.Clear();
//     Console.ForegroundColor = ConsoleColor.Cyan;
//     Console.WriteLine("========== MENÚ CUERPO TECNICO ==========\n");
//     Console.ResetColor();
//     // este ciclo se encarga de dibujar las opciones del menu principal de acuerdo a la opcion seleccioada, recorriendo el arreglo de opcionesMenu definidco previamente
//     for (int i = 0; i < opcionesMenu.Length; i++)
//     {
//       if (i == opcionSeleccionada)
//       {
//         Console.ForegroundColor = ConsoleColor.Yellow;
//         Console.WriteLine($"▶ {opcionesMenu[i]}");
//         Console.ResetColor();
//       }
//       else
//       {
//         Console.WriteLine($"  {opcionesMenu[i]}");
//       }
//     }
//     Console.WriteLine("\nUsa las flechas ↑ ↓ para moverte y Enter para seleccionar.");
//   }
//   public async Task EjecutarMenu()
//   {
//     bool validate_menu = true;
//     do
//     {
//       DibujarMenu();
//       // lee la tecla presionada por el usuario
//       var tecla_input = Console.ReadKey(true);

//       switch (tecla_input.Key)
//       {
//         // si es la flecha hacia arriba se decrementa la opcion seleccionada
//         case ConsoleKey.UpArrow:
//           opcionSeleccionada--;
//           // si la opcion seleccionada es menor a 0, se asigna el ultimo elemento del arreglo de opcionesMenu
//           if (opcionSeleccionada < 0) opcionSeleccionada = opcionesMenu.Length - 1;
//           break;
//         // si es la flecha hacia abajo se aumenta la opcion seleccionada en el arreglo de opcionesMenu
//         case ConsoleKey.DownArrow:
//           opcionSeleccionada++;
//           // si la opcion seleccionada es mayor o igual al largo del arreglo de opcionesMenu, se asigna 0
//           if (opcionSeleccionada >= opcionesMenu.Length) opcionSeleccionada = 0;
//           break;
//         // si se preisona Enter se ejecuta el metodo de EjecutarOpcion con la opcion seleccionada
//         case ConsoleKey.Enter:
//           validate_menu = await EjecutarOpcion(opcionSeleccionada);
//           break;
//       }
//     } while (validate_menu);
//   }
//   private async Task<bool> EjecutarOpcion(int opcion_seleccionada)
//   {
//     Console.Clear();
//     switch (opcion_seleccionada)
//     {
//       case 0:
//         Console.Clear();
//         await AgregarCuerpoTecnicoAsync();
//         break;
//       case 1:
//         Console.Clear();
//         await ActualizarCuerpoTecnicoAsync();
//         break;
//       case 2:
//         Console.Clear();
//         await EliminarCuerpoTecnicoAsync();
//         break;
//       case 3:
//         Console.Clear();
//         await MostrarCuerpoTecnicosAsync();
//         break;
//       case 4:
//         Console.Clear();
//         await ObtenerCuerpoTecnicoPorIdAsync();
//         break;
//       case 5:
//         Console.Clear();
//         await ObtenerCuerpoTecnicoPorNombreAsync();
//         break;
//       case 6:
//         Console.Clear();
//         await RegistrarCuerpoTecnicoaEquipoAsync();
//         break;
//       case 7:
//         Console.Clear();
//         await EliminarCuerpoTecnicoDeEquipoAsync();
//         break;
//       case 8:
//         return false;
//       default:
//         Console.Clear();
//         Console.WriteLine("error al ingresar dato, intentelo de nuevo");
//         Console.ReadLine();
//         return false;
//     }
//     return true;
//   }
//   private async Task AgregarCuerpoTecnicoAsync()
//   {
//     // TODO: antes de crear el cuerpo tecnico se debe de crear primeo la persona y se le asigna el id de la ultima persona creada
//     Persona persona = new Persona();
//     // TODO: sale error porque el metodo no esta definido en el servicio de personas 
//     await _service.AgregarPersonaAsync(persona);
//     Console.Write("Rol: ");
//     var rol = validate_data.ValidarTexto(Console.ReadLine());

//     Console.Write("Anios de experiencia: ");
//     var aniosExperiencia = validate_data.ValidarEntero(Console.ReadLine());

//     // hacer que el id persona sea el ultimo id creado en la base de datos ya que al crear el cuerpo tecnico se crea una persona primero
//     // TODO: revisar si esto esta bien
//     var id_persona = await DbContextFactory.Create().Personas.MaxAsync(p => p.Id);

//     System.Console.WriteLine($"¿Desea registrar el cuerpo tecnico {rol} con {aniosExperiencia} anios de experiencia?");

//     System.Console.WriteLine("Si presiona 'S' se creara, si presiona 'N' se cancelara: ");
//     var opcion = validate_data.ValidarBoleano(Console.ReadLine());
//     if (opcion == false) return;

//     // agregar el nuevo cuerpo tecnico
//     var cuerpo_tecnico = new CuerpoTecnico
//     {
//       Rol = rol.Trim(), 
//       AniosExperiencia = aniosExperiencia,
//       PersonaId = id_persona
//     };
//     await _service.AgregarCuerpoTecnicoAsync(cuerpo_tecnico); 
//     Console.WriteLine("Cuerpo tecnico creado.");
//   }
//   private async Task ActualizarCuerpoTecnicoAsync()
//   {
//     Console.Write("ID a actualizar: ");
//     int id = validate_data.ValidarEntero(Console.ReadLine());

//     var existente = await _service.ObtenerCuerpoTecnicoPorIdAsync(id);
//     if (existente == null)
//     {
//       Console.WriteLine("Cuerpo tecnico no encontrado.");
//       Console.ReadLine();
//       return;
//     }
//     // en este caso no voy a hacer validate data de modo que si el usuario quiere mantener un dato, le de enter y lo deje como es
//     Console.Write($"Nuevo nombre (actual: {existente.Nombre}), presiona enter para mantener el mismo nombre: ");
//     var nuevoNombre = Console.ReadLine();
//     if (!string.IsNullOrWhiteSpace(nuevoNombre))
//       existente.Nombre = nuevoNombre;

//     Console.Write($"Nuevo apellido (actual: {existente.Apellido}), presiona enter para mantener el mismo nombre: : ");
//     var nuevoApellido = Console.ReadLine();
//     if (!string.IsNullOrWhiteSpace(nuevoApellido))
//       existente.Apellido = nuevoApellido;

//     Console.Write($"Nueva edad (actual: {existente.Edad}), presiona enter para mantener el mismo nombre: : ");
//     var nuevaEdadStr = Console.ReadLine();
//     if (!string.IsNullOrWhiteSpace(nuevaEdadStr) && int.TryParse(nuevaEdadStr, out int nuevaEdad))
//       existente.Edad = nuevaEdad;

//     Console.Write($"Nueva nacionalidad (actual: {existente.Nacionalidad}), presiona enter para mantener el mismo nombre: : ");
//     var nuevaNacionalidad = Console.ReadLine();
//     if (!string.IsNullOrWhiteSpace(nuevaNacionalidad))
//       existente.Nacionalidad = nuevaNacionalidad;

//     Console.Write($"Nuevo documento identidad (actual: {existente.DocumentoIdentidad}), presiona enter para mantener el mismo nombre: : ");
//     var nuevoDocStr = Console.ReadLine();
//     if (!string.IsNullOrWhiteSpace(nuevoDocStr) && int.TryParse(nuevoDocStr, out int nuevoDoc))
//       existente.DocumentoIdentidad = nuevoDoc;

//     Console.Write($"Nuevo género (actual: {existente.Genero}), presiona enter para mantener el mismo nombre: : ");
//     var nuevoGenero = Console.ReadLine();
//     if (!string.IsNullOrWhiteSpace(nuevoGenero))
//       existente.Genero = nuevoGenero;

//     Console.Write($"Nueva rol (actual: {existente.Rol}), presiona enter para mantener el mismo nombre: : ");
//     var nuevaRol = Console.ReadLine();
//     if (!string.IsNullOrWhiteSpace(nuevaRol))
//       existente.Rol = nuevaRol;

//     Console.Write($"Años experiencia (actual: {existente.AniosExperiencia}), presiona enter para mantener el mismo nombre: : ");
//     var nuevoAniosExpStr = Console.ReadLine();
//     if (!string.IsNullOrWhiteSpace(nuevoAniosExpStr) && int.TryParse(nuevoAniosExpStr, out int nuevoAniosExp))
//       existente.AniosExperiencia = nuevoAniosExp;

//     // Mostrar resumen de los nuevos datos
//     Console.WriteLine("\n--- Confirmar Actualización ---");
//     Console.WriteLine($"Nombre: {existente.Nombre}");
//     Console.WriteLine($"Apellido: {existente.Apellido}");
//     Console.WriteLine($"Edad: {existente.Edad}");
//     Console.WriteLine($"Nacionalidad: {existente.Nacionalidad}");
//     Console.WriteLine($"Documento: {existente.DocumentoIdentidad}");
//     Console.WriteLine($"Género: {existente.Genero}");
//     Console.WriteLine($"Rol: {existente.Rol}");
//     Console.WriteLine($"Años Experiencia: {existente.AniosExperiencia}");
//     Console.Write("¿Confirmar actualización? (S/N): ");

//     var confirmacion = validate_data.ValidarBoleano(Console.ReadLine());

//     if (confirmacion)
//     {
//       await _service.ActualizarCuerpoTecnicoAsync(id, existente);
//       Console.WriteLine("País actualizado.");
//       Console.ReadLine();
//     }
//     else
//     {
//       Console.WriteLine("Actualización cancelada.");
//       Console.ReadLine();
//     }
//   }
//   private async Task EliminarCuerpoTecnicoAsync()
//   {
//     Console.Write("ID a actualizar: ");
//     int id = validate_data.ValidarEntero(Console.ReadLine());

//     var existente = await _service.ObtenerCuerpoTecnicoPorIdAsync(id);
//     if (existente == null)
//     {
//       Console.WriteLine("Cuerpo tecnico no encontrado.");
//       Console.ReadLine();
//       return;
//     }

//     await _service.EliminarCuerpoTecnicoAsync(id);
//     Console.WriteLine("🗑️ Cuerpo tecnico eliminado.");
//   }
//   private async Task MostrarCuerpoTecnicosAsync()
//   {
//     // TODO: tengo que revisar si esto esta bien por el nombre del servicio ya que son los mismos en el servicio, o no entiendo
//     var cuerpo_tecnico = await _service.MostrarCuerpoTecnicosAsync();
//     if (!cuerpo_tecnico.Any())
//     {
//       Console.WriteLine("No hay países registrados.");
//       return;
//     }

//     Console.WriteLine("Cuerpo Tecnicos:");
//     foreach (var cm in cuerpo_tecnico)
//     {
//       if (cm is null) continue;
//       Console.WriteLine($"ID: {cm.Id} | Nombre: {cm.Nombre} | Rol: {cm.Rol} | Años de experiencia: {cm.AniosExperiencia}");
//     }
//   }
//   private async Task ObtenerCuerpoTecnicoPorIdAsync()
//   {
//     Console.Write("ID a obtener: ");
//     int id = validate_data.ValidarEntero(Console.ReadLine());

//     var existente = await _service.ObtenerCuerpoTecnicoPorIdAsync(id);
//     if (existente == null)
//     {
//       Console.WriteLine("Cuerpo tecnico no encontrado.");
//       Console.ReadLine();
//       return;
//     }

//     var cm = await _service.ObtenerCuerpoTecnicoPorIdAsync(id);
//     if (cm is null)
//     {
//       Console.WriteLine("Cuerpo médico no encontrado.");
//       return;
//     }

//     Console.WriteLine($"Cuerpo Médico: ID={cm.Id} | Nombre={cm.Nombre} {cm.Apellido} | Rol={cm.Rol} | Años de experiencia={cm.AniosExperiencia} | Nacionalidad={cm.Nacionalidad} | Documento={cm.DocumentoIdentidad}");
//   }
//   private async Task ObtenerCuerpoTecnicoPorNombreAsync()
//   {
//     Console.Write("Nombre (o parte del nombre): ");
//     var nombre = Console.ReadLine()?.Trim();

//     if (string.IsNullOrWhiteSpace(nombre))
//     {
//       Console.WriteLine("Nombre inválido.");
//       return;
//     }
//     var cm = await _service.ObtenerCuerpoTecnicoPorNombreAsync(nombre);
//     if (cm is null)
//     {
//       Console.WriteLine("Cuerpo médico no encontrado.");
//       return;
//     }
//     Console.WriteLine($"Cuerpo Médico: ID={cm.Id} | Nombre={cm.Nombre} {cm.Apellido} | Rol={cm.Rol} | Años de experiencia={cm.AniosExperiencia} | Nacionalidad={cm.Nacionalidad} | Documento={cm.DocumentoIdentidad}");
//     Console.ReadKey();
//   }
//   public async Task RegistrarCuerpoTecnicoaEquipoAsync()
//   {
//     Console.Write("ID cuerpo tecnico: ");
//     int id_cuerpo_tecnico = validate_data.ValidarEntero(Console.ReadLine());

//     Console.Write("ID equipo: ");
//     int id_equipo = validate_data.ValidarEntero(Console.ReadLine());

//     await _service.RegistrarCuerpoTecnicoEquipoAsync(id_cuerpo_tecnico, id_equipo);
//     Console.WriteLine("Cuerpo tecnico registrado.");
//   }
//   public async Task EliminarCuerpoTecnicoDeEquipoAsync()
//   {
//     Console.Write("ID cuerpo tecnico: ");
//     int id_cuerpo_tecnico = validate_data.ValidarEntero(Console.ReadLine());

//     Console.Write("ID equipo: ");
//     int id_equipo = validate_data.ValidarEntero(Console.ReadLine());

//     await _service.EliminarCuerpoTecnicoEquipoAsync(id_cuerpo_tecnico, id_equipo);
//     Console.WriteLine("Cuerpo tecnico eliminado.");
//   }
// }
