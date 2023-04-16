using Dapper;
using Keyify.Infrastructure.Repository.Interfaces;
using Keyify.MusicTheory.Enums;
using Keyify.Services.Formatter.Interfaces;
using Keyify.Web.Infrastructure.Models.ChordDefinition;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using System.Text;
using System.Text.Json;

namespace Keyify.Infrastructure.Repository
{
    public class ChordDefinitionRepository : IChordDefinitionRepository
    {
        private readonly ILogger _logger;
        private readonly string _connectionString;
        private readonly ISerializationFormatter _serializationFormatter;

        public ChordDefinitionRepository(ILogger<ChordDefinitionRepository> logger, string connectionString, ISerializationFormatter serializationFormatter)
        {
            _logger = logger;
            _connectionString = connectionString;
            _serializationFormatter = serializationFormatter;
        }

        public async Task<List<ChordDefinitionEntity>> GetAllChordDefinitions()
        {
            _logger.LogInformation($"Database Server: '{_connectionString.Split(';')[0]}'");

            var chordDefinitions = new List<ChordDefinitionEntity>();

            try
            {
                using var sqlConnection = new SqlConnection(_connectionString);

                await sqlConnection.OpenAsync();

                var query = "SELECT [Id], [Name], [Intervals] FROM [Core].[ChordDefinition] WHERE [Deleted] = 0";
                var result = await sqlConnection.ExecuteReaderAsync(query);

                while (result.Read())
                {
                    chordDefinitions.Add(new ChordDefinitionEntity()
                    {
                        Id = result.GetInt32(0),
                        Name = result.GetString(1),
                        Intervals = await _serializationFormatter.ConvertToIntervalArray((byte[])result[2])
                    });
                }

                _logger.LogInformation($"Found: {chordDefinitions.Count} Chord Definition Entries");

                await sqlConnection.CloseAsync();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Could not retrieve Chord Definitions");
            }

            return chordDefinitions;
        }

        public async Task<bool> DoesChordDefinitionExist(string name, byte[] intervals)
        {
            using var sqlConnection = new SqlConnection(_connectionString);

            await sqlConnection.OpenAsync();

            var isFound = false;
            var query = string.Empty;
            var hasIntervals = intervals != null && intervals.Any();

            if (!string.IsNullOrWhiteSpace(name))
            {
                if (hasIntervals)
                {
                    query = "SELECT COUNT(1) FROM [Core].[ChordDefinition] WHERE [Name] = @name OR [Intervals] = @intervals";
                    isFound = await sqlConnection.ExecuteScalarAsync<bool>(query, new { name, intervals });
                }
                else
                {
                    query = "SELECT COUNT(1) FROM [Core].[ChordDefinition] WHERE [Name] = @name";
                    isFound = await sqlConnection.ExecuteScalarAsync<bool>(query, new { name });
                }
            }
            else if (hasIntervals)
            {
                query = "SELECT COUNT(1) FROM [Core].[ChordDefinition] WHERE [Intervals] = @intervals";
                isFound = await sqlConnection.ExecuteScalarAsync<bool>(query, new { intervals });
            }

            await sqlConnection.CloseAsync();

            return isFound;
        }

        public async Task<bool> InsertChordDefinition(ChordDefinitionRequest chordDefinitionRequest)
        {
            var (name, intervals) = (chordDefinitionRequest.Name, chordDefinitionRequest.Intervals);

            using var memoryStream = new MemoryStream();

            JsonSerializer.Serialize(memoryStream, intervals);

            if (await DoesChordDefinitionExist(name!, memoryStream.ToArray()))
            {
                return false;
            }

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

            var chord = await sqlCconnection.ExecuteAsync(sb.ToString(), new { chordDefinitionRequest.Name, Intervals = memoryStream.ToArray() });

            await sqlCconnection.CloseAsync();

            return true;
        }

        public Task<List<ChordDefinitionEntity>> SyncChordDefinitions(IEnumerable<int> existingChordDefinitionIds)
        {
            throw new NotImplementedException();
        }
    }
}
