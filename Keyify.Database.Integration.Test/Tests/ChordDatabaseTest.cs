using Dapper;
using Keyify.Database.Integration.Test.Enums;
using Keyify.Database.Integration.Test.Helper;
using Keyify.Database.Integration.Test.ThrowawayDatabases;
using Microsoft.Data.SqlClient;
using System.Text.Json;
using Xunit;

namespace Keyify.Database.Integration.Tests.Test
{
    public class ChordDatabaseTest
    {
        [Fact]
        public async Task CreateChord_RecordCreatedInDatabase_ReturnsSingleRecord_ReturnsCorrectTabsIntArray()
        {
            using (var throwawayDbInstance = await ThrowawayDatabaseSetup.CreateThrowawayDbInstanceAsync())
            {
                using var sqlCconnection = new SqlConnection(throwawayDbInstance.ConnectionString);
                sqlCconnection.Open();

                //Arrange
                await sqlCconnection.ExecuteAsync(DatabaseTestHelper.CreateInsertTuningSqlScript(), DatabaseTestHelper.CreateInsertStandardTuningSqlScriptParameters());
                await sqlCconnection.ExecuteAsync(DatabaseTestHelper.CreateInsertChordSqlScript(), DatabaseTestHelper.CreateInsertEMajorChordSqlScriptParameters());

                //Act
                var sqlQuery = "SELECT [Tabs] FROM [Core].[Chord]";
                var chord = await sqlCconnection.QuerySingleAsync(sqlQuery);

                using var memoryStream = new MemoryStream(chord.Tabs);
                var tabResult = await JsonSerializer.DeserializeAsync<int[]>(memoryStream);

                await sqlCconnection.CloseAsync();

                //Assert
                Assert.Single(chord);
                Assert.Equal(GuitarChordTabConstant.StandardTuning_E_Major, tabResult);
            }
        }

        [Fact]
        public async Task CreateChord_AttemptInsertIntoDatabaseTwice_TriggersUniqueConstraint_ThrowsException()
        {
            using (var throwawayDbInstance = await ThrowawayDatabaseSetup.CreateThrowawayDbInstanceAsync())
            {
                using var sqlCconnection = new SqlConnection(throwawayDbInstance.ConnectionString);
                sqlCconnection.Open();

                //Arrange
                await sqlCconnection.ExecuteAsync(DatabaseTestHelper.CreateInsertTuningSqlScript(), DatabaseTestHelper.CreateInsertStandardTuningSqlScriptParameters());
                await sqlCconnection.ExecuteAsync(DatabaseTestHelper.CreateInsertChordSqlScript(), DatabaseTestHelper.CreateInsertEMajorChordSqlScriptParameters());

                //Act
                Func<Task> duplicateRecordInsertAttempt = () => sqlCconnection.ExecuteAsync(DatabaseTestHelper.CreateInsertChordSqlScript(), DatabaseTestHelper.CreateInsertEMajorChordSqlScriptParameters());

                //Assert
                await Assert.ThrowsAsync<SqlException>(duplicateRecordInsertAttempt);
            }
        }
    }
}
