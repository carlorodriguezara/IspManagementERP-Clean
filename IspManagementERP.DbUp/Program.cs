using System;
using System.IO;
using DbUp;

class Program
{
    static int Main(string[] args)
    {
        // Lee la cadena de conexión desde la variable de entorno (el workflow pasa el secret a esta variable)
        // Cambiado para leer la variable ConnectionStrings__DefaultConnection (coincide con lo que estás definiendo)
        var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");

        if (string.IsNullOrWhiteSpace(connectionString))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("❌ ERROR: No se encontró la variable de entorno 'ConnectionStrings__DefaultConnection'.");
            Console.WriteLine("Asegúrate de pasarla como secret en el workflow o definirla en la sesión.");
            Console.ResetColor();
            return -1;
        }

        Console.WriteLine("✅ Usando cadena de conexión desde variable de entorno.");

        // Los scripts deben estar en la carpeta "Scripts" dentro del output (se configurará en el csproj)
        var scriptsPath = Path.Combine(AppContext.BaseDirectory, "Scripts");
        Console.WriteLine($"Buscando scripts en: {scriptsPath}");

        var upgrader =
            DeployChanges.To
                .SqlDatabase(connectionString)
                .WithScriptsFromFileSystem(scriptsPath)
                .LogToConsole()
                .WithTransaction()               // Ejecutar en transacción por script (seguro)
                .Build();

        var result = upgrader.PerformUpgrade();

        if (!result.Successful)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("❌ Error aplicando migraciones:");
            Console.WriteLine(result.Error);
            Console.ResetColor();
            return -1;
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("🎉 Migraciones aplicadas correctamente.");
        Console.ResetColor();
        return 0;
    }
}