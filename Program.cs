using System.Security;
using soccer_cs;
using soccer_cs.ui;

internal class Program
{
  private static async Task Main(string[] args)
  {
    // crear base de datos si no existe
    // crear la constante sin especificar la base de datos
    const string connectionStringNoDB = "Server=localhost;Uid=root;Pwd=s1e2r3v0or;";
    DbInstaller dbInstaller = new DbInstaller();
    dbInstaller.CrearBaseDeDatos(connectionStringNoDB, "soccer_cs");

    MenuPrincipal menuPrincipal = new MenuPrincipal();
    menuPrincipal.MostrarBienvenida();
    await menuPrincipal.EjecutarMenuMain();
  }
}