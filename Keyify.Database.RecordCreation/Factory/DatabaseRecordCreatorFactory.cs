using Keyify.Database.RecordCreation.Enums;
using Keyify.Database.RecordCreation.Factory.Abstraction;
using Keyify.Database.RecordCreation.Factory.Creator;

namespace Keyify.Database.RecordCreation.Factory
{
    internal static class DatabaseRecordCreatorFactory
    {
        internal static DatabaseRecordCreator Create(Selection selection, string connectionString)
        {
            switch (selection)
            {
                case Selection.ChordDefinition:
                    return new ChordDefinitionCreator(connectionString);
                case Selection.ScaleDefinition:
                    return new ScaleDefinitionCreator(connectionString);
                default:
                    throw new ArgumentException($"Invalid selection {selection}");
            }
        }
    }
}
