using Keyify.Database.Integration.Test.Helper;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using ThrowawayDb;

namespace Keyify.Database.Integration.Test.ThrowawayDatabases
{
    internal static class ThrowawayDatabaseSetup
    {
        internal static async Task<ThrowawayDatabase> CreateThrowawayDbInstanceAsync()
        {
            try
            {
                ThrowawayDatabase throwawayDbInstance;
                var sqlScriptFileNames = Directory.GetFiles($"{Environment.CurrentDirectory}\\Scripts").ToList();

#if DEBUG
                throwawayDbInstance = ThrowawayDatabase.FromLocalInstance(".");
#else
                var databaseConfiguration = Environment.GetEnvironmentVariable("databaseConnectionString");

                if (string.IsNullOrWhiteSpace(databaseConfiguration))
                {
                    throw new ArgumentNullException($"Problem with value of {nameof(databaseConfiguration)}: {databaseConfiguration}");
                }
                else
                {
                    Console.WriteLine($"From Console: {databaseConfiguration}");
                    Trace.WriteLine($"From Trace: {databaseConfiguration}");
                }

                throwawayDbInstance = ThrowawayDatabase.Create(databaseConfiguration);
#endif

                await ExecuteSqlScriptsAgainstThrowawayDbInstanceAsync(sqlScriptFileNames, throwawayDbInstance);

                return throwawayDbInstance;
            }
            catch (Exception exception)
            {
                Console.WriteLine($"From Console: {exception}");
                Trace.WriteLine($"From Trace: {exception}");

                throw;
            }
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