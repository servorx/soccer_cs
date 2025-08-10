using System.Security;
using soccer_cs;
using soccer_cs.ui;

internal class Program
{
  private static void Main(string[] args)
  {
    // // Configurar la cadena de conexión a la base de datos
    // const string connectionString = "Server=localhost;Database=soccer_cs;Uid=root;Pwd=s1e2r3v0or;";
    // IDbFactory dbFactory = new MySqlDbFactory(connectionString);

    // // crear base de datos si no existe
    // // crear la constante sin especificar la base de datos
    // const string connectionStringNoDB = "Server=localhost;Uid=root;Pwd=s1e2r3v0or;";
    // DbInstaller dbInstaller = new DbInstaller();
    // dbInstaller.CrearBaseDeDatos(connectionStringNoDB, "soccer_cs");

    MenuPrincipal menuPrincipal = new MenuPrincipal();
    menuPrincipal.MostrarBienvenida();
        _ = menuPrincipal.EjecutarMenuMain();


    // esto es para mostrar la conexion a la base de datos y la version de MySQL
    // var context = DbContextFactory.Create();
  }
}