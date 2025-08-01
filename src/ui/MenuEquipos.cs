using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soccer_cs.modules.equipo.domain;


namespace soccer_cs;

public class MenuEquipos
{
  // se crean las instancias de los servicios necesarios de forma privada por conveniencia en esta parte del codigo para que no se pueda acceder a ellos desde fuera de esta clase.
  private readonly EquipoService equipoService = new EquipoService();
  private readonly TransferenciaService transferenciaService = new TransferenciaService();
  public void MostrarMenuEquipos()
  {
    Console.Clear();
    Console.WriteLine("========== MENÚ EQUIPOS ==========\n");
    Console.WriteLine("1.1. Registrar equipo");
    Console.WriteLine("1.2. Registrar cuerpo tecnico");
    Console.WriteLine("1.3. Registrar cuerpo medico");
    Console.WriteLine("1.4. Inscricpion torneo");
    Console.WriteLine("1.5. Gestionar jugadores por equipo");
    Console.WriteLine("1.6. Transferencias");
    Console.WriteLine("1.7. Desencribir equipo del torneo");
    Console.WriteLine("1.8. Regresar al main menu\n");
    Console.Write("Selecciona una opción: ");
  }
  public void Mostrar()
  {
    bool validation_program = true;
    do
    {
      MostrarMenuEquipos();
      string? opcion = Console.ReadLine();
      switch (opcion)
      {
        case "1":
          equipoService.CrearEquipo();
          break;
        case "2":
          equipoService.CrearCuerpoTecnico();
          break;
        case "3":
          equipoService.CrearCuerpoMedico();
          break;
        case "4":
          equipoService.InscribirTorneo();
          break;
        case "5":
          equipoService.GestionarJugadoresPorEquipo();
          break;
        case "6":
          MostrarSubmenuTransferencias();
          break;
        case "7":
          equipoService.SalirDelTorneo();
          break;
        case "8":
          return;
        default:
          Console.Clear();
          System.Console.WriteLine("error al ingresar dato, intentelo de nuevo");
          Console.ReadLine();
          break;
      }
    } while (validation_program);
  }
  private void MostrarSubmenuTransferencias()
  {
    bool validation_program = true;
    while (validation_program)
    {
      Console.Clear();
      Console.WriteLine("===== SUBMENÚ TRANSFERENCIAS =====\n");
      Console.WriteLine("1.6.1 Comprar jugador");
      Console.WriteLine("1.6.2 Prestar jugador");
      Console.WriteLine("1.6.3 Vender jugador");
      Console.WriteLine("1.6.4 Regresar\n");
      Console.Write("Selecciona una opción: ");

      string? opcion = Console.ReadLine();
      switch (opcion)
      {
        case "1":
          transferenciaService.ComprarJugador();
          break;
        case "2":
          transferenciaService.PrestarJugador();
          break;
        case "3":
          transferenciaService.VenderJugador();
          break;
        case "4":
          return;
        default:
          Console.WriteLine("Opción invalida, presiona enter para continuar");
          Console.ReadLine();
          break;
      }
    }
  }
}
