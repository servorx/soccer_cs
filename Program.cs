using Microsoft.EntityFrameworkCore;
using soccer_cs.src.shared.helpers;
using soccer_cs.src.ui;

internal class Program
{
    private static void Main(string[] args)
    {
        var context = DbContextFactory.Create();
        Console.WriteLine("Hola mudno");

        MenuPrincipal menu = new();
        menu.MostrarBienvenida();
        _ = menu.EjecutarMenuMain();
    }
}