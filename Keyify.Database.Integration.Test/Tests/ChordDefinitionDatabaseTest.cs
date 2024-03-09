using Keyify.Database.Integration.Test.Helper;
using Keyify.Database.Integration.Test.ThrowawayDatabases;
using Microsoft.Data.SqlClient;

namespace Keyify.Database.Integration.Test.Tests
{
    public sealed class ChordDefinitionDatabaseTest : DatabaseIntegrationTest
    {
        public ChordDefinitionDatabaseTest(ThrowawayDatabaseWrapper throwawayDatabaseWrapper) : base(throwawayDatabaseWrapper)
        {
        }

        [Fact]
        public async Task InsertDuplicateChordDefinition_ThrowsException()
        {
            //Arrange
            await ThrowAwayDatabaseWrapper.ExecuteSqlQueryAsync(DatabaseTestHelper.CreateInsertChordDefinitionSqlScript(), DatabaseTestHelper.CreateInsertChordDefinitionSqlScriptParameters());

            //Act
            Func<Task> duplicateChordDefinitionRecordInsertAttempt = () => ThrowAwayDatabaseWrapper.ExecuteSqlQueryAsync(DatabaseTestHelper.CreateInsertChordDefinitionSqlScript(), DatabaseTestHelper.CreateInsertChordDefinitionSqlScriptParameters());

            //Assert
            await Assert.ThrowsAsync<SqlException>(duplicateChordDefinitionRecordInsertAttempt);
        }
    }
}
