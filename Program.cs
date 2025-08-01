using MySql.Data;
using soccer_cs;
using soccer_cs.infrastructure.data;
using soccer_cs.ui; 
internal class Program
{
  private static void Main(string[] args)
  {
    // Configurar la cadena de conexión a la base de datos
    const string connectionString = "Server=localhost;Database=soccer_cs;Uid=root;Pwd=s1e2r3v0or;";
    IDbFactory dbFactory = new MySqlDbFactory(connectionString);

    // crear base de datos si no existe
    // crear la constante sin especificar la base de datos
    const string connectionStringNoDB = "Server=localhost;Uid=root;Pwd=s1e2r3v0or;";
    DbInstaller dbInstaller = new DbInstaller();
    dbInstaller.CrearBaseDeDatos(connectionStringNoDB, "soccer_cs");

    // Instanciar el menú principal para ejecutar el programa
    MenuPrincipal menuPrincipal = new MenuPrincipal();
    menuPrincipal.MostrarBienvenida();
    menuPrincipal.EjecutarMenuMain();
  }
}