using DbUp;
using DbUp.Engine;
using System.Diagnostics;

internal class Program
{
    public static int Main(string[] args)
    {
        var (connectionString, scriptsDirectoryArg) = SetArgumentValues(args);

        var upgrader =
            DeployChanges.To
                .SqlDatabase(connectionString)
                .WithScriptsFromFileSystem(scriptsDirectoryArg)
                .LogToConsole()
                .Build();

        EnsureDatabase.For.SqlDatabase(connectionString);

        return ProcessUpgradeResult(upgrader.PerformUpgrade());
    }

    private static (string, string) SetArgumentValues(string[] args)
    {
        string connectionString;
        string scriptsDirectoryArg;

        try
        {
            connectionString = args[0];
        }
        catch
        {
            connectionString = "Server=localhost;Database=notestokey;Trusted_Connection=True;TrustServerCertificate=True;";
        }

        Console.WriteLine($"Console: {connectionString}");
        Trace.WriteLine($"Trace: {connectionString}");

        try
        {
            scriptsDirectoryArg = args[1];
        }
        catch
        {
            scriptsDirectoryArg = string.Empty;
        }

        Console.WriteLine($"Console: {scriptsDirectoryArg}");
        Trace.WriteLine($"Trace: {scriptsDirectoryArg}");

        scriptsDirectoryArg = $"{Environment.CurrentDirectory}{scriptsDirectoryArg}\\Scripts";

        Console.WriteLine($"Console: {scriptsDirectoryArg}");
        Trace.WriteLine($"Trace: {scriptsDirectoryArg}");

        return (connectionString, scriptsDirectoryArg);
    }

    private static int ProcessUpgradeResult(DatabaseUpgradeResult result)
    {
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

