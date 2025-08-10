// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using soccer_cs.infrastructure.utils;
// using soccer_cs.services;

// namespace soccer_cs;
// public class MenuTorneo
// {
//    // instanciar el objeto que se usa a lo largo de los cases como propiedad de la clase MenuTorneos porque el metodo no es static y poruqe no quiero crear un nuevo metodo por cada case
//   private readonly TorneoService torneoService = new TorneoService();
//   private readonly Validaciones validate_data = new Validaciones();
//   public void MostrarMenuTorneos()
//   {
//     Console.Clear();
//     Console.WriteLine("========== MENÚ TORNEOS ==========\n");
//     Console.WriteLine("0.1. Crear torneo");
//     Console.WriteLine("0.2. Buscar torneo");
//     Console.WriteLine("0.3. Eliminar torneo");
//     Console.WriteLine("0.4. Actualizar torneo");
//     Console.WriteLine("0.5. Regresar al main menu\n");
//     Console.Write("Selecciona una opción: ");
//   }
//   public void Mostrar()
//   {
//     bool validation_program = true;
//     do
//     {
//       MostrarMenuTorneos();
//       string? opcion = validate_data.ValidarTexto(Console.ReadLine());
//       switch (opcion)
//       {
//         case "1":
//           torneoService.CrearTorneo();
//           break;
//         case "2":
//           torneoService.BuscarTorneo();
//           break;
//         case "3":
//           torneoService.EliminarTorneo();
//           break;
//         case "4":
//           torneoService.ActualizarTorneo();
//           break;
//         case "5":
//           return;
//         default:
//           Console.Clear();
//           System.Console.WriteLine("error al ingresar dato, intentelo de nuevo");
//           Console.ReadLine();
//           break;
//       }
//     } while (validation_program);
//   }
// }
