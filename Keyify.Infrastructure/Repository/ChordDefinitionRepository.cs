using Dapper;
using Keyify.Web.Infrastructure.Models.ChordDefinition;
using Keyify.Web.Infrastructure.Repository.Interfaces;
using System.Data.SqlClient;
using System.Text;
using System.Text.Json;

namespace Keyify.Infrastructure.Repository
{
    public class ChordDefinitionRepository : IChordDefinitionRepository
    {
        private readonly string _connectionString;

        public ChordDefinitionRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Task<List<ChordDefinitionEntity>> GetAllChordDefinitions()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DoesChordDefinitionExist(string name)
        {
            using var sqlConnection = new SqlConnection(_connectionString);

            await sqlConnection.OpenAsync();

            var query = "SELECT COUNT(1) FROM [Core].[ChordDefinition] WHERE [Name] = @name";
            var isFound = await sqlConnection.ExecuteScalarAsync<bool>(query, new { name });

            await sqlConnection.CloseAsync();

            return isFound;
        }

        public async Task InsertChordDefinition(ChordDefinitionRequest chordDefinitionRequest)
        {
            //TODO: Validate request
            if (await DoesChordDefinitionExist(chordDefinitionRequest.Name))
            {
                return;
            }
            using var memoryStream = new MemoryStream();

            JsonSerializer.Serialize(memoryStream, chordDefinitionRequest.Intervals);

            using var sqlCconnection = new SqlConnection(_connectionString);

            await sqlCconnection.OpenAsync();

            //TODO: Convert to Builder Pattern
            var sb = new StringBuilder();

            sb.AppendLine("INSERT INTO [Core].[ChordDefinition] (");
            sb.AppendLine("[Name],");
            sb.AppendLine("[Intervals]");
            sb.AppendLine(")");
            sb.AppendLine("VALUES");
            sb.AppendLine("(");
            sb.AppendLine("@Name,");
            sb.AppendLine("@Intervals");
            sb.AppendLine(")");

            var chord = await sqlCconnection.ExecuteAsync(sb.ToString(), new { Name = chordDefinitionRequest.Name, Intervals = memoryStream.ToArray() });

            await sqlCconnection.CloseAsync();
        }

        public Task<List<ChordDefinitionEntity>> SyncChordDefinitions(IEnumerable<int> existingChordDefinitionIds)
        {
            throw new NotImplementedException();
        }
    }
}
