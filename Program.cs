using soccer_cs.ui; 
internal class Program
{
  private static void Main(string[] args)
  {
    // Instanciar el menú principal
    MenuPrincipal menuPrincipal = new MenuPrincipal();
    // Mostrar la bienvenida
    menuPrincipal.MostrarBienvenida();
    
    // Ejecutar el menú principal
    menuPrincipal.EjecutarMenuMain();
  }
}