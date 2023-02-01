using Microsoft.Data.SqlClient;
using ThrowawayDb;
using Xunit;

namespace Keyify.Database.Integration.Test
{
    public class ChordDatabaseTest
    {
        //https://khalidabuhakmeh.com/dotnet-database-integration-tests
        //https://github.com/Zaid-Ajaj/ThrowawayDb

        [Fact]
        public void Can_Select_Chord_Entry_From_Database()
        {
            using (var database = ThrowawayDatabase.FromLocalInstance("."))
            {
                Console.WriteLine($"Created database {database.Name}");

                //var solutiondir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

                // - Apply database migrations here if necessary
                // - Seed the database with data
                // - Execute your code against this database
                using var connection = new SqlConnection(database.ConnectionString);
                connection.Open();
                using var cmd = new SqlCommand("SELECT 1", connection);
                var result = Convert.ToInt32(cmd.ExecuteScalar());
                Console.WriteLine(result);
            }
        }
    }
}
