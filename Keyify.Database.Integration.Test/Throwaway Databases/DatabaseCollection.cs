using Keyify.Database.Integration.Test.ThrowawayDatabases;

namespace Keyify.Database.Integration.Test.Throwaway_Databases
{
    [CollectionDefinition("Database Collection")]
    public class DatabaseCollection : ICollectionFixture<ThrowawayDatabaseWrapper>
    {

    }
}
