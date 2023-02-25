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
            Console.WriteLine($"{(int)Selection.ChordDefinition}: Chord Template Creation");

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
                    break;
            }
        }
    }
}