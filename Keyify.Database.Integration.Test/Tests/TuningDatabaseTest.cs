using Dapper;
using Keyify.Database.Integration.Test.Enums;
using Keyify.Database.Integration.Test.Helper;
using Keyify.Database.Integration.Test.ThrowawayDatabases;
using Microsoft.Data.SqlClient;
using System.Text.Json;

namespace Keyify.Database.Integration.Test.Tests
{
    public class TuningDatabaseTest
    {
        //TODO: Research best practices for ThrowawayDb
                // - Use of Snapshots
                // - Disposing of ThrowawayDb instances

        [Fact]
        public async Task CreateTuning_RecordCreatedInDatabase_ReturnsSingleRecord_ReturnsCorrectNotesIntArray()
        {
            using (var throwawayDbInstance = await ThrowawayDatabaseSetup.CreateThrowawayDbInstanceAsync())
            {
                using var sqlCconnection = new SqlConnection(throwawayDbInstance.ConnectionString);
                sqlCconnection.Open();

                //Arrange
                await sqlCconnection.ExecuteAsync(DatabaseTestHelper.CreateInsertTuningSqlScript(), DatabaseTestHelper.CreateInsertStandardTuningSqlScriptParameters());

                //Act
                var sqlQuery = "SELECT [Notes] FROM [Core].[Tuning]";
                var tuning = await sqlCconnection.QuerySingleAsync(sqlQuery);

                using var memoryStream = new MemoryStream(tuning.Notes);
                var notesResult = await JsonSerializer.DeserializeAsync<int[]>(memoryStream);

                await sqlCconnection.CloseAsync();

                //Assert
                Assert.Single(tuning);
                Assert.Equal(TestGuitarTuningConstant.StandardTuning, notesResult);
            }
        }

        [Fact]
        public async Task CreateTuning_AttemptToInsertDuplicateRecords_TriggersUniqueConstraint_ThrowsException()
        {
            using (var throwawayDbInstance = await ThrowawayDatabaseSetup.CreateThrowawayDbInstanceAsync())
            {
                using var sqlCconnection = new SqlConnection(throwawayDbInstance.ConnectionString);
                sqlCconnection.Open();

                //Arrange
                await sqlCconnection.ExecuteAsync(DatabaseTestHelper.CreateInsertTuningSqlScript(), DatabaseTestHelper.CreateInsertStandardTuningSqlScriptParameters());

                //Act
                Func<Task> duplicateRecordInsertAttempt = () => sqlCconnection.ExecuteAsync(DatabaseTestHelper.CreateInsertTuningSqlScript(), DatabaseTestHelper.CreateInsertStandardTuningSqlScriptParameters());

                //Assert
                await Assert.ThrowsAsync<SqlException>(duplicateRecordInsertAttempt);
            }
        }
    }
}
