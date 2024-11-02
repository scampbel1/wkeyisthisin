using Keyify.Database.RecordCreation.Enums;
using Keyify.Database.RecordCreation.Factory;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var connectionString = SetConnectionString(args);

        foreach (var recordType in Enum.GetValues(typeof(RecordType)))
        {
            switch (recordType)
            {
                case RecordType.ChordDefinition:
                    var chordDefintionCreator = DatabaseRecordFactory.Create(RecordType.ChordDefinition, connectionString);
                    await chordDefintionCreator.ExecuteAsync();
                    break;
                case RecordType.ScaleDefinition:
                    var scaleDefinitionCreator = DatabaseRecordFactory.Create(RecordType.ScaleDefinition, connectionString);
                    await scaleDefinitionCreator.ExecuteAsync();
                    break;
                default:
                    Console.WriteLine($"Invalid selection '{recordType}'");
                    throw new NotImplementedException();
            }
        }
    }

    private static string SetConnectionString(string[] args)
    {
        string connectionString;

        try
        {
            connectionString = args[0];
        }
        catch
        {
            connectionString = "Server=localhost;Database=notestokey;Trusted_Connection=True;TrustServerCertificate=True;";
        }

        return connectionString;
    }
}