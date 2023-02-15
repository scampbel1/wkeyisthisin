using Dapper;
using Keyify.Database.Integration.Test.Helper;
using Keyify.Database.Integration.Test.ThrowawayDatabases;
using Microsoft.Data.SqlClient;

namespace Keyify.Database.Integration.Test.Tests
{
    public class ChordDefinitionDatabaseTest
    {
        [Fact]
        public async Task InsertDuplicateChordDefinition_ThrowsException()
        {
            using (var throwawayDbInstance = await ThrowawayDatabaseSetup.CreateThrowawayDbInstanceAsync())
            {
                using var sqlCconnection = new SqlConnection(throwawayDbInstance.ConnectionString);
                sqlCconnection.Open();

                //Arrange
                await sqlCconnection.ExecuteAsync(DatabaseTestHelper.CreateInsertChordDefinitionSqlScript(), DatabaseTestHelper.CreateInsertChordDefinitionSqlScriptParameters());

                //Act
                Func<Task> duplicateChordDefinitionRecordInsertAttempt = () => sqlCconnection.ExecuteAsync(DatabaseTestHelper.CreateInsertChordDefinitionSqlScript(), DatabaseTestHelper.CreateInsertChordDefinitionSqlScriptParameters());

                //Assert
                await Assert.ThrowsAsync<SqlException>(duplicateChordDefinitionRecordInsertAttempt);
            }
        }
    }
}
