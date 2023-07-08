using Keyify.Database.Integration.Test.Helper;
using Microsoft.Data.SqlClient;
using ThrowawayDb;

namespace Keyify.Database.Integration.Test.ThrowawayDatabases
{
    internal static class ThrowawayDatabaseSetup
    {
        //TODO: Make this configurable - suspect this will fail in cloud environments
        private const string _localDatabase = ".";
        //TODO: Make this configurable - also suspect this will fail in cloud environments (perhaps not after looking at build output... but still)
        private static string _databaseCreationSqlScriptsDirectory => $"{Environment.CurrentDirectory}\\Scripts";

        internal static async Task<ThrowawayDatabase> CreateThrowawayDbInstanceAsync()
        {
            var throwawayDbInstance = ThrowawayDatabase.FromLocalInstance(_localDatabase);
            var sqlScriptFileNames = GetSqlScriptFileNames();

            await ExecuteSqlScriptsAgainstThrowawayDbInstanceAsync(sqlScriptFileNames, throwawayDbInstance);

            return throwawayDbInstance;
        }

        private static List<string> GetSqlScriptFileNames()
        {
            var sqlScriptFilesNames = new List<string>();

            foreach (var sqlScriptFileName in Directory.GetFiles(_databaseCreationSqlScriptsDirectory))
            {
                sqlScriptFilesNames.Add(sqlScriptFileName);
            }

            return sqlScriptFilesNames;
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