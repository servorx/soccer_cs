// programa realizado por Angel David con el objetivo de tener un control completo con persistencia de datos del futbol completo 
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