using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using soccer_cs.infrastructure.utils;
using soccer_cs.services;

namespace soccer_cs;
public class MenuTransferencias
{
  private Validaciones validate_data = new Validaciones();
  private readonly TransferenciaService transferenciaService = new TransferenciaService();
  public void MostrarMenuTransferencias()
  {
    Console.Clear();
    Console.WriteLine("========== MENÚ TRANSFERENCIAS ==========\n");
    Console.WriteLine("1.6.1. Comprar jugador");
    Console.WriteLine("1.6.2. Prestar jugador");
    Console.WriteLine("1.6.3. Vender jugador");
    Console.WriteLine("1.6.4. Regresar al main menu\n");
    Console.Write("Selecciona una opción (1-4): ");
  }
  public void Mostrar()
  {
    bool validation_program = true;
    do
    {
      MostrarMenuTransferencias();
      string? opcion = validate_data.ValidarTexto(Console.ReadLine());
      switch (opcion)
      {
        case "1":
          TransferenciaService.ComprarJugador();
          break;
        case "2":
        // TODO: revisar si hace falta el metodo de prestar jugador o simplemente dar la opcion de comprar y vender jugador
          TransferenciaService.PrestarJugador();
          break;
        case "3":
          TransferenciaService.VenderJugador();
          break;
        case "4":
          return;
        default:
          Console.Clear();
          System.Console.WriteLine("error al ingresar dato, intentelo de nuevo");
          Console.ReadLine();
          break;
      }
    } while (validation_program);
  }
}
