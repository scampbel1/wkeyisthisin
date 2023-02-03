using Keyify.Database.Integration.Test.ThrowawayDatabases;
using Xunit;
using Microsoft.Data.SqlClient;
using Keyify.Database.Integration.Test.Helper;
using Dapper;

namespace Keyify.Database.Integration.Tests.Test
{
    public class ChordDatabaseTest
    {
        [Fact]
        public async Task Can_Select_Chord_Entry_From_Database()
        {
            using (var throwawayDbInstance = await ThrowawayDatabaseSetup.CreateThrowawayDbInstanceAsync())
            {
                using var sqlCconnection = new SqlConnection(throwawayDbInstance.ConnectionString);
                sqlCconnection.Open();

                await sqlCconnection.ExecuteAsync(DatabaseTestHelper.CreateInsertTuningSqlScript(), DatabaseTestHelper.CreateInsertStandardTuningSqlScriptParameters());

                await sqlCconnection.ExecuteAsync(DatabaseTestHelper.CreateInsertChordSqlScript(), DatabaseTestHelper.CreateInsertEMajorChordSqlScriptParameters());
            }
        }
    }
}
