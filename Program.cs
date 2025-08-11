using System.Security;
using soccer_cs;
using soccer_cs.ui;

internal class Program
{
  // usar asincronia para que no se bloquee la UI al momento de ejecutar el programa
  private static async Task Main(string[] args)
  {
    // esto es para crear la baso de datos al momento de ejecutar el programa en caso de que no exista
    const string connectionStringNoDB = "Server=localhost;Uid=root;Pwd=s1e2r3v0or;";
    DbInstaller dbInstaller = new DbInstaller();
    dbInstaller.CrearBaseDeDatos(connectionStringNoDB, "soccer_cs");

    // esto es para mostar la pantalla de bienvenida al programa y ejecutar la funcion del menu principal
    var menuPrincipal = new MenuPrincipal();
    menuPrincipal.MostrarBienvenida();
    await menuPrincipal.EjecutarMenuMain();
  }
}