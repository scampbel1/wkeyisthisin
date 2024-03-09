using Dapper;
using Keyify.Database.Integration.Test.Helper;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using ThrowawayDb;

namespace Keyify.Database.Integration.Test.ThrowawayDatabases
{
    public sealed class ThrowawayDatabaseWrapper : IDisposable
    {
        private ThrowawayDatabase? _throwawayDbInstance;
        private readonly IReadOnlyList<string> _sqlScriptFileNames;

        public ThrowawayDatabase ThrowawayDatabase => _throwawayDbInstance!;

        public ThrowawayDatabaseWrapper()
        {
            _sqlScriptFileNames = Directory.GetFiles($"{Environment.CurrentDirectory}\\Scripts").ToList();

            Task.WaitAll(CreateThrowawayDbInstance());
        }

        private async Task CreateThrowawayDbInstance()
        {
            try
            {
                var connectionString = Environment.GetEnvironmentVariable("databaseConnectionString") ?? "Data Source=.;Integrated Security=True;";

                if (string.IsNullOrWhiteSpace(connectionString))
                {
                    throw new ArgumentNullException($"Problem with value of {nameof(connectionString)}: {connectionString}");
                }
                else
                {
                    Console.WriteLine($"From Console: {connectionString}");
                    Trace.WriteLine($"From Trace: {connectionString}");
                }

                _throwawayDbInstance = ThrowawayDatabase.Create(connectionString);

                await ExecuteSqlScripts();
            }
            catch (Exception exception)
            {
                Console.WriteLine($"From Console: {exception}");
                Trace.WriteLine($"From Trace: {exception}");

                _throwawayDbInstance?.Dispose();

                throw;
            }
        }

        public async Task ExecuteSqlQueryAsync(string sqlScriptContent)
        {
            using var sqlConnection = new SqlConnection(_throwawayDbInstance!.ConnectionString);

            sqlConnection.Open();

            await sqlConnection.ExecuteAsync(sqlScriptContent);

            sqlConnection.Close();
        }

        public async Task ExecuteSqlQueryAsync(string sqlScriptContent, params object[] parameters)
        {
            using var sqlConnection = new SqlConnection(_throwawayDbInstance!.ConnectionString);
            try
            {
                sqlConnection.Open();

                await sqlConnection.ExecuteAsync(sqlScriptContent, parameters);
            }
            catch(Exception exception)
            {
                throw;
            }
            finally
            {
                sqlConnection.Close();
            }

        }

        public async Task<T> QuerySingleAsync<T>(string sqlQuery)
        {
            using var sqlConnection = new SqlConnection(_throwawayDbInstance!.ConnectionString);

            sqlConnection.Open();

            var result = await sqlConnection.QuerySingleAsync<T>(sqlQuery);

            sqlConnection.Close();

            return result;
        }

        public void Dispose()
        {
            _throwawayDbInstance?.Dispose();
        }

        private async Task ExecuteSqlScripts()
        {
            foreach (var sqlScriptFileName in _sqlScriptFileNames)
            {
                var sqlScriptContent = DatabaseTestHelper.FormatSqlScriptForThrowawayDbInstance(File.ReadAllText(sqlScriptFileName));

                await ExecuteSqlQueryAsync(sqlScriptContent);
            }
        }
    }
}