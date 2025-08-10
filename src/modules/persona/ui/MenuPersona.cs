// using soccer_cs;
// using soccer_cs.infrastructure.utils;
// using System;

// namespace persona.ui;

// public class MenuPersona
// {
//   private readonly Validaciones validate_data = new Validaciones();
//   private readonly IPersonaService _personaService;
//   public MenuPersona(IPersonaService personaService)
//   {
//     _personaService = personaService;
//   }
//   public void MostrarMenu()
//   {
//     while (true)
//     {
//       Console.Clear();
//       Console.WriteLine("----- GESTIÓN DE PERSONAS -----");
//       Console.WriteLine("1. Registrar persona");
//       Console.WriteLine("2. Buscar persona");
//       Console.WriteLine("3. Listar personas");
//       Console.WriteLine("4. Editar persona");
//       Console.WriteLine("5. Eliminar persona");
//       Console.WriteLine("6. Regresar al menu principal");
//       Console.Write("Seleccione una opción: ");
//       string? opcion = validate_data.ValidarTexto(Console.ReadLine());

//       switch (opcion)
//       {
//         case "1":
//           RegistrarPersona();
//           break;
//         case "2":
//           BuscarPersona();
//           break;
//         case "3":
//           ListarPersonas();
//           break;
//         case "4":
//           EditarPersona();
//           break;
//         case "5":
//           EliminarPersona();
//           break;
//         case "6":
//           return;
//         default:
//           Console.Clear();
//           System.Console.WriteLine("error al ingresar dato, intentelo de nuevo");
//           Console.ReadLine();
//           break;
//       }

//       Console.WriteLine("\nPresione cualquier tecla para continuar...");
//       Console.ReadKey();
//     }
//   }

//   private void RegistrarPersona()
//   {
//     Console.Clear();
//     Console.WriteLine("---- Registrar Persona ----");

//     Console.Write("Nombre: ");
//     var nombre = Console.ReadLine();

//     Console.Write("Edad: ");
//     int.TryParse(Console.ReadLine(), out int edad);

//     Console.Write("Género: ");
//     var genero = Console.ReadLine();

//     var nuevaPersona = new Persona
//     {
//       Nombre = nombre,
//       Edad = edad,
//       Genero = genero
//     };

//     _personaService.RegistrarPersona(nuevaPersona);

//     Console.WriteLine("✅ Persona registrada con éxito.");
//   }
//   private void BuscarPersona()
//   {
//     Console.Clear();
//     Console.WriteLine("---- Buscar Persona ----");

//     Console.Write("Ingrese el ID de la persona: ");
//     int.TryParse(Console.ReadLine(), out int id);

//     var persona = _personaService.BuscarPersona(id);

//     if (persona != null)
//     {
//       Console.WriteLine($"Persona encontrada: {persona}");
//     }
//     else
//     {
//       Console.WriteLine("Persona no encontrada :(");
//     }
//   }
//   private void ListarPersonas()
//   {
//     Console.Clear();
//     Console.WriteLine("---- Lista de Personas ----");

//     var personas = _personaService.ListarPersonas();

//     foreach (var p in personas)
//     {
//       Console.WriteLine($"ID: {p.Id} | Nombre: {p.Nombre} | Edad: {p.Edad} | Género: {p.Genero}");
//     }
//   }
//   private void EditarPersona()
//   {
//     Console.Clear();
//     Console.WriteLine("---- Editar Persona ----");

//     Console.Write("Ingrese el ID de la persona a editar: ");
//     int.TryParse(Console.ReadLine(), out int id);

//     var persona = _personaService.BuscarPersona(id);
//     if (persona == null)
//     {
//       Console.WriteLine("Persona no encontrada.");
//       return;
//     }

//     Console.Write("Nuevo Nombre: ");
//     persona.Nombre = Console.ReadLine();

//     Console.Write("Nueva Edad: ");
//     int.TryParse(Console.ReadLine(), out int nuevaEdad);
//     persona.Edad = nuevaEdad;

//     Console.Write("Nuevo Género: ");
//     persona.Genero = Console.ReadLine();

//     _personaService.EditarPersona(persona);

//     Console.WriteLine("✅ Persona editada con éxito.");
//   }
//   private void EliminarPersona()
//   { 
//     Console.Clear();
//     Console.WriteLine("---- Eliminar Persona ----");

//     Console.Write("Ingrese el ID de la persona a eliminar: ");
//     int.TryParse(Console.ReadLine(), out int id);

//     _personaService.EliminarPersona(id);

//     Console.WriteLine("✅ Persona eliminada con éxito.");
//   }
// }
