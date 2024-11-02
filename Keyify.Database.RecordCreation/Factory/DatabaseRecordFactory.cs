using Keyify.Database.RecordCreation.Enums;
using Keyify.Database.RecordCreation.Factory.Abstraction;
using Keyify.Database.RecordCreation.Factory.Creator;

namespace Keyify.Database.RecordCreation.Factory
{
    internal static class DatabaseRecordFactory
    {
        internal static DatabaseRecordCreator Create(RecordType selection, string connectionString)
        {
            switch (selection)
            {
                case RecordType.ChordDefinition:
                    return new ChordDefinitionCreator(connectionString);
                case RecordType.ScaleDefinition:
                    return new ScaleDefinitionCreator(connectionString);
                default:
                    throw new ArgumentException($"Invalid selection {selection}");
            }
        }
    }
}
