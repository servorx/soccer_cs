

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using soccer_cs.src.shared.context;

namespace soccer_cs.src.shared.helpers;
public class DbContextFactory
{
    public static AppDbContext Create()
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true)
            .AddEnvironmentVariables()
            .Build();
        string? connectionString = Environment.GetEnvironmentVariable("MYSQL_CONNECTION")
                ?? config.GetConnectionString("MysqlDatabase");

        if (string.IsNullOrWhiteSpace(connectionString))
            throw new InvalidOperationException("No se encontró una cadena de conexión válida.");
        // Detectar versión MySQL 
        var detectedVersion = MySqlVersionResolver.DetectVersion(connectionString);
        var minVersion = new Version(8, 0, 0);
        if (detectedVersion < minVersion)
            throw new NotSupportedException($"Versión de MySQL no soportada: {detectedVersion}. Requiere {minVersion} o superior.");
        // Console.WriteLine($"🔍 MySQL detectado: {detectedVersion}");
        // Console.WriteLine("presione una tecla para continuar...");
        // Console.ReadLine();
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseMySql(connectionString, new MySqlServerVersion(detectedVersion))
            .Options;
        return new AppDbContext(options); 
    }
}
