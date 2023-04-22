using Dapper;
using Keyify.Infrastructure.Models.ChordDefinition;
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

        private byte[] ConvertIntervalsArrayToByteArray(Interval[] intervals)
        {
            using var memoryStream = new MemoryStream();

            JsonSerializer.Serialize(memoryStream, intervals);

            var bytes = memoryStream.ToArray();

            return bytes;
        }

        public async Task<ChordDefinitionFoundResult> DoesChordDefinitionExist(string name, Interval[] intervals)
        {
            using var sqlConnection = new SqlConnection(_connectionString);

            await sqlConnection.OpenAsync();

            var intervalsByteArray = ConvertIntervalsArrayToByteArray(intervals);

            var query = string.Empty;
            var hasIntervals = intervalsByteArray != null && intervalsByteArray.Any();

            if (!string.IsNullOrWhiteSpace(name))
            {
                if (hasIntervals)
                {
                    query = "SELECT COUNT(1) FROM [Core].[ChordDefinition] WHERE [Name] = @name OR [Intervals] = @intervals";

                    if (await sqlConnection.ExecuteScalarAsync<bool>(query, new { name, intervals }))
                    {
                        return new ChordDefinitionFoundResult(true, $"Chord Definition already exists. Searched on Name: '{name}' and Intervals '{string.Join(',', intervals)}'", intervals, intervalsByteArray!);
                    }
                }
                else
                {
                    query = "SELECT COUNT(1) FROM [Core].[ChordDefinition] WHERE [Name] = @name";

                    if (await sqlConnection.ExecuteScalarAsync<bool>(query, new { name }))
                    {
                        return new ChordDefinitionFoundResult(true, $"Chord Definition already exists. Searched on Name: '{name}'");
                    }

                }
            }
            else if (hasIntervals)
            {
                query = "SELECT COUNT(1) FROM [Core].[ChordDefinition] WHERE [Intervals] = @intervals";

                if (await sqlConnection.ExecuteScalarAsync<bool>(query, new { intervals }))
                {
                    return new ChordDefinitionFoundResult(true, $"Chord Definition already exists. Searched on Intervals '{string.Join(',', intervals)}'", intervals, intervalsByteArray!);
                }
            }

            await sqlConnection.CloseAsync();

            return new ChordDefinitionFoundResult(false, string.Empty);
        }

        public async Task<Tuple<bool, string>> InsertChordDefinition(ChordDefinitionInsertRequest chordDefinitionRequest)
        {
            var (name, intervals) = (chordDefinitionRequest.Name, chordDefinitionRequest.Intervals!);

            var chordFoundResult = await DoesChordDefinitionExist(name!, intervals.Select(i => (Interval)i).ToArray());

            if (chordFoundResult.Found)
            {
                return Tuple.Create(false, chordFoundResult.Message!);
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

            var chord = await sqlCconnection.ExecuteAsync(sb.ToString(), new { chordDefinitionRequest.Name, Intervals = chordFoundResult.Bytes });

            await sqlCconnection.CloseAsync();

            return Tuple.Create(true, string.Empty);
        }

        private Task DoesChordDefinitionExist(string v, string[] strings)
        {
            throw new NotImplementedException();
        }

        public Task<List<ChordDefinitionEntity>> SyncChordDefinitions(IEnumerable<int> existingChordDefinitionIds)
        {
            throw new NotImplementedException();
        }
    }

    //TODO: Rename to something more useful and move elsewhere
    public class ChordDefinitionFoundResult
    {
        public bool Found { get; set; }
        public string? Message { get; set; }
        public Interval[]? Intervals { get; set; }
        public byte[]? Bytes { get; set; }

        public ChordDefinitionFoundResult(bool found, string message)
        {
            Found = found;
            Message = message;
        }

        public ChordDefinitionFoundResult(bool found, string message, Interval[] intervals, byte[] bytes) : this(found, message)
        {
            Intervals = intervals;
            Bytes = bytes;
        }
    }
}
