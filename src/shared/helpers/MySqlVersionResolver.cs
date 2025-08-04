using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace soccer_cs;
public class MySqlVersionResolver
{
  // esta clase se encarga de detectar la versión de MySQL y devolvera para comprobar que es compatible con el proyecto
  public static Version DetectVersion(string connectionString)
  {
    using var comunicacion = new MySqlConnection(connectionString);
    comunicacion.Open();
    var raw = comunicacion.ServerVersion;
    var clean = raw.Split('-')[0];
    return Version.Parse(clean);
  }
}
