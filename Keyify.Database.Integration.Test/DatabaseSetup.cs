using Microsoft.Data.SqlClient;
using ThrowawayDb;

namespace Keyify.Database.Integration.Test
{
    internal static class DatabaseSetup
    {
        internal static async Task<ThrowawayDatabase> Create()
        {
            var scriptsDirectory = $"{Environment.CurrentDirectory}\\Scripts";
            var database = ThrowawayDatabase.FromLocalInstance(".");

            var connection = new SqlConnection(database.ConnectionString);
            connection.Open();

            foreach (var file in Directory.GetFiles(scriptsDirectory))
            {
                var sqlScriptContent = DatabaseTestHelper.FormatSqlScriptForThrowawayDbInstance(File.ReadAllText(file));

                var sqlCommand = new SqlCommand(sqlScriptContent, connection);

                await sqlCommand.ExecuteNonQueryAsync();
            }

            return database;
        }
    }
}
