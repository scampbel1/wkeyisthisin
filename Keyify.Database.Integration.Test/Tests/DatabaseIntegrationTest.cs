using Keyify.Database.Integration.Test.ThrowawayDatabases;

namespace Keyify.Database.Integration.Test.Tests
{
    [Collection("Database Collection")]
    public class DatabaseIntegrationTest
    {
        protected readonly ThrowawayDatabaseWrapper ThrowAwayDatabaseWrapper;

        public DatabaseIntegrationTest(ThrowawayDatabaseWrapper throwawayDatabaseWrapper)
        {
            ThrowAwayDatabaseWrapper = throwawayDatabaseWrapper;
        }
    }
}
