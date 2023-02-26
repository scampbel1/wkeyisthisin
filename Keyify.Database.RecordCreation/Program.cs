using Keyify.Database.RecordCreation.Enums;
using Keyify.Database.RecordCreation.Factory;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var running = true;
        var connectionString = string.Empty;

        while (string.IsNullOrWhiteSpace(connectionString))
        {
            Console.WriteLine("Insert Connection String: ");
            connectionString = Console.ReadLine();
        }

        while (running)
        {
            Console.WriteLine("Please make a selection:");

            PrintSelections();

            var key = Console.ReadKey(true).KeyChar;

            if (key.ToString().ToUpper() == "Q")
            {
                running = false;
                break;
            }

            var selection = char.GetNumericValue(key);

            switch ((int)selection)
            {
                case (int)Selection.ChordDefinition:
                    var creator = DatabaseRecordCreatorFactory.Create(Selection.ChordDefinition, connectionString);
                    await creator.ExecuteAsync();
                    break;
                default:
                    Console.WriteLine($"Invalid selection '{selection}'");
                    break;
            }
        }
    }

    private static void PrintSelections()
    {
        foreach (var selection in Enum.GetValues(typeof(Selection)))

            Console.WriteLine($"{(int)selection}: {(Selection)selection}");
    }
}