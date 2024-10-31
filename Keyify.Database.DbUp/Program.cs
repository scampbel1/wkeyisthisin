using DbUp;

internal class Program
{
    public static int Main(string[] args)
    {
        var scriptsDirectory = $"{Environment.CurrentDirectory}\\Scripts";
        var databaseConfiguration = Environment.GetEnvironmentVariable("databaseConnectionString");

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
