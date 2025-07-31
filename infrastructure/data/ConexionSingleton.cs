using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

// la clase forma parte de la infraestructura de datos con el fin de proveer una unica conexión a la base de datos
namespace soccer_cs.infrastructure.data;

// sus funciones son: implementar el patrón Singleton para asegurar que solo haya una conexión a la base de datos en toda la aplicación
// gestionar la conexion a la base de datos MySQL
public class ConexionSingleton
{
  // se crea la instancia de la clase de forma privada y estática con nullable para poder verificar si la instancia es nula
  // si es nula, se crea una nueva instancia de la clase
  // si no es nula, se retorna la instancia existente
  private static ConexionSingleton? _instancia;
  // se define la cadena de conexión para guardarla en la clase
  private readonly string _connectionString;
  // se define la conexión y la guarda en una variable privada
  private MySqlConnection? _conexion;
  // la conexionSingleton es privada para que no se pueda instanciar desde fuera 
  private ConexionSingleton(string connectionString)
  {
    _connectionString = connectionString;
  }
  // esto lo que hace es que si la instancia es nula, crea una nueva instancia de la clase
  public static ConexionSingleton Instancia(string connectionString)
  {
    _instancia ??= new ConexionSingleton(connectionString);
    return _instancia;
  }
  public MySqlConnection ObtenerConexion()
  {
    _conexion ??= new MySqlConnection(_connectionString);

    if (_conexion.State != System.Data.ConnectionState.Open)
      _conexion.Open();

    return _conexion;
  }
}
