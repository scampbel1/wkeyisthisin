using Keyify.Database.Integration.Test.Helper;
using Microsoft.Data.SqlClient;
using ThrowawayDb;

namespace Keyify.Database.Integration.Test.ThrowawayDatabases
{
    internal static class ThrowawayDatabaseSetup
    {
        internal static async Task<ThrowawayDatabase> CreateThrowawayDbInstanceAsync()
        {
            var databaseCreationSqlScriptsDirectory = $"{Environment.CurrentDirectory}\\Scripts";

            var throwawayDbInstance = ThrowawayDatabase.FromLocalInstance(".");
            var sqlCconnection = new SqlConnection(throwawayDbInstance.ConnectionString);

            sqlCconnection.Open();

            foreach (var sqlScriptFileDirectory in Directory.GetFiles(databaseCreationSqlScriptsDirectory))
            {
                var sqlScriptContent = DatabaseTestHelper.FormatSqlScriptForThrowawayDbInstance(File.ReadAllText(sqlScriptFileDirectory));

                using var sqlCommand = new SqlCommand(sqlScriptContent, sqlCconnection);

                await sqlCommand.ExecuteNonQueryAsync();
            }

            return throwawayDbInstance;
        }
    }
}
