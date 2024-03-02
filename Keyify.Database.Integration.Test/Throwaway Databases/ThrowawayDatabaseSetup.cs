using Keyify.Database.Integration.Test.Helper;
using Microsoft.Data.SqlClient;
using ThrowawayDb;

namespace Keyify.Database.Integration.Test.ThrowawayDatabases
{
    internal static class ThrowawayDatabaseSetup
    {
        internal static async Task<ThrowawayDatabase> CreateThrowawayDbInstanceAsync()
        {
            var sqlScriptFileNames = Directory.GetFiles($"{Environment.CurrentDirectory}\\Scripts").ToList();

            var databaseConfiguration = Environment.GetEnvironmentVariable("databaseConnectionString");
            var throwawayDbInstance = ThrowawayDatabase.Create(databaseConfiguration);

            await ExecuteSqlScriptsAgainstThrowawayDbInstanceAsync(sqlScriptFileNames, throwawayDbInstance);

            return throwawayDbInstance;
        }

        private static async Task ExecuteSqlScriptsAgainstThrowawayDbInstanceAsync(List<string> sqlScriptFileNames, ThrowawayDatabase throwawayDbInstance)
        {
            foreach (var sqlScriptFileName in sqlScriptFileNames)
            {
                var sqlScriptContent = DatabaseTestHelper.FormatSqlScriptForThrowawayDbInstance(await File.ReadAllTextAsync(sqlScriptFileName));

                await ExecuteSqlQueryAsync(sqlScriptContent, throwawayDbInstance);
            }
        }

        private static async Task ExecuteSqlQueryAsync(string sqlScriptContent, ThrowawayDatabase throwawayDbInstance)
        {
            using var sqlCconnection = new SqlConnection(throwawayDbInstance.ConnectionString);
            sqlCconnection.Open();

            using var sqlCommand = new SqlCommand(sqlScriptContent, sqlCconnection);

            await sqlCommand.ExecuteNonQueryAsync();
        }
    }
}