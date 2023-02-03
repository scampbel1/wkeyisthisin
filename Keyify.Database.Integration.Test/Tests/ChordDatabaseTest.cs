using Dapper;
using Keyify.Database.Integration.Test.Helper;
using Keyify.Database.Integration.Test.ThrowawayDatabases;
using Microsoft.Data.SqlClient;
using Xunit;

namespace Keyify.Database.Integration.Tests.Test
{
    public class ChordDatabaseTest
    {
        [Fact]
        public async Task CreateChord_RecordCreatedInDatabase_ReturnsSingleRecord()
        {
            using (var throwawayDbInstance = await ThrowawayDatabaseSetup.CreateThrowawayDbInstanceAsync())
            {
                using var sqlCconnection = new SqlConnection(throwawayDbInstance.ConnectionString);
                sqlCconnection.Open();

                await sqlCconnection.ExecuteAsync(DatabaseTestHelper.CreateInsertTuningSqlScript(), DatabaseTestHelper.CreateInsertStandardTuningSqlScriptParameters());

                await sqlCconnection.ExecuteAsync(DatabaseTestHelper.CreateInsertChordSqlScript(), DatabaseTestHelper.CreateInsertEMajorChordSqlScriptParameters());

                var reader = await sqlCconnection.ExecuteReaderAsync("SELECT COUNT(*) FROM [Core].[Chord]");

                while (reader.Read())
                {
                    var count = reader.GetInt32(0);

                    Assert.Equal(1, count);
                    Assert.NotEqual(2, count);
                }
            }
        }
    }
}
