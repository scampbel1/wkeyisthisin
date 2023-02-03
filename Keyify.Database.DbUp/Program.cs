using DbUp;

internal class Program
{
    public static int Main(string[] args)
    {
        var connectionString =
            args.FirstOrDefault()
            ?? "Server=.; Database=Keyify; Trusted_connection=true; TrustServerCertificate=True";

        var scriptsDirectory = $"{Environment.CurrentDirectory}\\Scripts";

        var upgrader =
            DeployChanges.To
                .SqlDatabase(connectionString)
                .WithScriptsFromFileSystem(scriptsDirectory)
                .LogToConsole()
                .Build();

        EnsureDatabase.For.SqlDatabase(connectionString);

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
