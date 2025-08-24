using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace soccer_cs.src.shared.utils;

public class Validaciones
{
  public string ValidarTexto(string? text)
  {
    do
    {
      if (string.IsNullOrWhiteSpace(text))
      {
        Console.WriteLine("Error al ingresar un texto vacío. Presione una tecla para continuar...");
        Console.Write("Ingrese de nuevo el valor solicitado: "); 
        text = Console.ReadLine();
      }
      else
      {
        break; // si es válido, sale del ciclo
      }
    } while (true);
    return text.Trim();
  }
  public int ValidarEntero(string? num)
  {
    int resultado = 0;
    do
    {
      if (!int.TryParse(num, out resultado))
      {
        Console.WriteLine("Error al tratar de ingresar un valor entero. Presione una tecla para continuar...");
        // pausa hasta que el usuario presione una tecla
        Console.ReadKey(); 
        Console.Write("Ingrese de nuevo el valor solicitado: "); 
        num = Console.ReadLine();
      }
      else
      {
        break; // si es válido, salimos
      }
    } while (true);

    return resultado;
  }
  public decimal ValidarDecimal(string? valor_decimal)
  {
    decimal resultado = 0;
    do
    {
      if (!decimal.TryParse(valor_decimal, out resultado))
      {
        Console.WriteLine("Error al tratar de ingresar un valor decimal. Presione una tecla para continuar...");
        // pausa hasta que el usuario presione una tecla
        Console.ReadKey(); 
        Console.Write("Ingrese de nuevo el valor solicitado: "); 
        valor_decimal = Console.ReadLine();
      }
      else
      {
        break; // si es válido, salimos
      }
    } while (true);

    return resultado;
  }
  public bool ValidarBoleano(string? boleano)
  {
    while (true)
    {
      if (string.IsNullOrWhiteSpace(boleano))
      {
        Console.WriteLine("error al tratar de ingresar una respuesta válida (s/n): ");
        boleano = Console.ReadLine();
        continue;
      }
      // validar que la entrar evite espacios y sea en minuscula
      boleano = boleano.Trim().ToLower();

      if (boleano == "si" || boleano == "s")
        return true;

      if (boleano == "no" || boleano == "n")
        return false;

      Console.WriteLine("error al tratar de validar un valor boleano");
      boleano = Console.ReadLine();
    }
  }
  public DateTime ValidarFecha(string? fecha)
  {
    // esta validacion se hace con el fin de que el usuario ingrese una fecha en formato validado, y pueda tener varias opcione sde ingreso de datos usando el System.Globalization  
    DateTime resultado;
    // lista de formatos aceptados
    string[] formatos = { "dd/MM/yyyy", "d/M/yyyy", "yyyy-MM-dd", "dd-MM-yyyy" };

    while (!DateTime.TryParseExact(fecha, formatos, 
                                  System.Globalization.CultureInfo.InvariantCulture,
                                  System.Globalization.DateTimeStyles.None,
                                  out resultado))
    {
      Console.WriteLine("⚠️ Error: ingrese una fecha válida en formato (ej: 19/08/2025 o 19-08-2025).");
      fecha = Console.ReadLine();
    }

    return resultado;
  }
}
