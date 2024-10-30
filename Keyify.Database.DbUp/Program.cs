using System.Diagnostics;
using DbUp;

internal class Program
{
    public static int Main(string[] args)
    {

        var scriptsDirectory = $"{Environment.CurrentDirectory}\\Scripts";
        var databaseConfiguration = "Server=tcp:campbe11devops.database.windows.net,1433;Initial Catalog=deployment;Persist Security Info=False;User ID=deploymentadmin;Password=Zt@3lUDwZewDvV;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        Trace.WriteLine($"Hey look! {databaseConfiguration}");

        var upgrader =
            DeployChanges.To
                .SqlDatabase(databaseConfiguration)
                .WithScriptsFromFileSystem(scriptsDirectory)
                .LogToConsole()
                .Build();

        EnsureDatabase.For.SqlDatabase(databaseConfiguration);

        var result = upgrader.PerformUpgrade();

        if (!result.Successful)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(result.Error);
            Console.ResetColor();

#if DEBUG
            Console.ReadLine();
#endif

            return -1;
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Success!");
        Console.ResetColor();
        return 0;
    }
}
