using Microsoft.EntityFrameworkCore;
using soccer_cs.src.shared.helpers;

internal class Program
{
    private static void Main(string[] args)
    {
        var context = DbContextFactory.Create();
        Console.WriteLine("Hola mudno");
    }
}