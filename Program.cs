using MySql.Data;
using soccer_cs.infrastructure.data;
using soccer_cs.ui; 
internal class Program
{
  private static void Main(string[] args)
  {
    // Configurar la cadena de conexión a la base de datos
    const string connectionString = "Server=localhost;Database=soccer_cs;Uid=root;Pwd=s1e2r3v0or;";
    IDbFactory dbFactory = new MySqlDbFactory(connectionString);
    // Instanciar el menú principal
    MenuPrincipal menuPrincipal = new MenuPrincipal();
    menuPrincipal.MostrarBienvenida();
    menuPrincipal.EjecutarMenuMain();
  }
}