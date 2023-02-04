using Keyify.Database.Integration.Test.Helper;
using Microsoft.Data.SqlClient;
using ThrowawayDb;

namespace Keyify.Database.Integration.Test.ThrowawayDatabases
{
    internal static class ThrowawayDatabaseSetup
    {
        private const string _localDatabase = "(LocalDb)\\MSSQLLocalDB";
        private static string _databaseCreationSqlScriptsDirectory => $"{Environment.CurrentDirectory}\\Scripts";

        internal static async Task<ThrowawayDatabase> CreateThrowawayDbInstanceAsync()
        {
            var throwawayDbInstance = ThrowawayDatabase.FromLocalInstance(_localDatabase);
            var sqlCconnection = new SqlConnection(throwawayDbInstance.ConnectionString);

            sqlCconnection.Open();

            foreach (var sqlScriptFileDirectory in Directory.GetFiles(_databaseCreationSqlScriptsDirectory))
            {
                var sqlScriptContent = DatabaseTestHelper.FormatSqlScriptForThrowawayDbInstance(File.ReadAllText(sqlScriptFileDirectory));

                using var sqlCommand = new SqlCommand(sqlScriptContent, sqlCconnection);

                await sqlCommand.ExecuteNonQueryAsync();
            }

            return throwawayDbInstance;
        }
    }
}