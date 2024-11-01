using DbUp;
using System.Net.Sockets;
using System.Net;

internal class Program
{
    public static int Main(string[] args)
    {
        var scriptsDirectory = $"{Environment.CurrentDirectory}\\Keyify.Database.DbUp.Scripts\\Scripts";

        var databaseConfiguration = args[0];

        Console.WriteLine($"Environment: {Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}");

        Console.WriteLine("Here, have some IP addresses:");

        var host = Dns.GetHostEntry(Dns.GetHostName());
        
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                Console.WriteLine(ip.ToString());
            }
        }

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
