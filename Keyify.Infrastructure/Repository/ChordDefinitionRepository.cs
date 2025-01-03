﻿using Dapper;
using Keyify.Infrastructure.Models.ChordDefinition;
using Keyify.Infrastructure.Repository.Interfaces;
using Keyify.MusicTheory.Enums;
using Keyify.Services.Formatter.Interfaces;
using Keyify.Web.Infrastructure.Models.ChordDefinition;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System.Text;
using System.Text.Json;

namespace Keyify.Infrastructure.Repository
{
    public class ChordDefinitionRepository(ILogger<ChordDefinitionRepository> logger, string connectionString, ISerializationFormatter serializationFormatter) : IChordDefinitionRepository
    {
        private readonly ILogger _logger = logger;
        private readonly string _connectionString = connectionString;
        private readonly ISerializationFormatter _serializationFormatter = serializationFormatter;

        public async Task<List<ChordDefinitionEntity>> GetAllChordDefinitions()
        {
            var chordDefinitions = new List<ChordDefinitionEntity>();

            try
            {
                using var sqlConnection = new SqlConnection(_connectionString);

                await sqlConnection.OpenAsync();

                var query = "SELECT [Id], [Name], [Intervals], [Popularity] FROM [Core].[ChordDefinition] WHERE [Deleted] = 0";
                var result = await sqlConnection.ExecuteReaderAsync(query);

                while (result.Read())
                {
                    chordDefinitions.Add(new ChordDefinitionEntity()
                    {
                        Id = result.GetInt32(0),
                        Name = result.GetString(1),
                        Intervals = await _serializationFormatter.ConvertToIntervalArray((byte[])result[2]),
                        Popularity = result.GetInt32(3),
                    });
                }

                if (chordDefinitions.Count != 0)
                {
                    _logger.LogInformation("Found Chord Definition Entries");
                }

                await sqlConnection.CloseAsync();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Could not retrieve Chord Definitions");
            }

            return chordDefinitions;
        }

        private static byte[] ConvertIntervalsArrayToByteArray(Interval[] intervals)
        {
            using var memoryStream = new MemoryStream();

            JsonSerializer.Serialize(memoryStream, intervals);

            var bytes = memoryStream.ToArray();

            return bytes;
        }

        public async Task<ChordDefinitionExistsResult> CheckChordDefinitionExists(ChordDefinitionInsertRequest request)
        {
            var (name, intervals) = (request.Name, request.Intervals);

            using var sqlConnection = new SqlConnection(_connectionString);

            await sqlConnection.OpenAsync();

            var intervalsByteArray = ConvertIntervalsArrayToByteArray(intervals!);

            var query = string.Empty;
            var hasIntervals = intervalsByteArray != null && intervalsByteArray.Length != 0;

            if (!string.IsNullOrWhiteSpace(name))
            {
                if (hasIntervals)
                {
                    query = "SELECT COUNT(1) FROM [Core].[ChordDefinition] WHERE [Name] = @name OR [Intervals] = @intervalsByteArray";

                    if (await sqlConnection.ExecuteScalarAsync<bool>(query, new { name, intervalsByteArray }))
                    {
                        return new ChordDefinitionExistsResult(true, $"Chord Definition already exists. Searched on Name: '{name}' and Intervals '{string.Join(',', intervals!)}'", intervals!, intervalsByteArray!);
                    }
                }
                else
                {
                    query = "SELECT COUNT(1) FROM [Core].[ChordDefinition] WHERE [Name] = @name";

                    if (await sqlConnection.ExecuteScalarAsync<bool>(query, new { name }))
                    {
                        return new ChordDefinitionExistsResult(true, $"Chord Definition already exists. Searched on Name: '{name}'");
                    }

                }
            }
            else if (hasIntervals)
            {
                query = "SELECT COUNT(1) FROM [Core].[ChordDefinition] WHERE [Intervals] = @intervalsByteArray";

                if (await sqlConnection.ExecuteScalarAsync<bool>(query, new { intervalsByteArray }))
                {
                    return new ChordDefinitionExistsResult(true, $"Chord Definition already exists. Searched on Intervals '{string.Join(',', intervals!)}'", intervals!, intervalsByteArray!);
                }
            }

            await sqlConnection.CloseAsync();

            return new ChordDefinitionExistsResult(false, string.Empty, intervals!, intervalsByteArray!);
        }

        public async Task<Tuple<bool, string>> InsertChordDefinition(ChordDefinitionInsertRequest chordDefinitionRequest)
        {
            var chordDefinitionExistsResult = await CheckChordDefinitionExists(chordDefinitionRequest);

            if (chordDefinitionExistsResult.Found)
            {
                return Tuple.Create(false, chordDefinitionExistsResult.Message!);
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

            var chord = await sqlCconnection.ExecuteAsync(sb.ToString(), new { chordDefinitionRequest.Name, Intervals = chordDefinitionExistsResult.Bytes });

            await sqlCconnection.CloseAsync();

            return Tuple.Create(true, string.Empty);
        }

        public Task<List<ChordDefinitionEntity>> SyncChordDefinitions(IEnumerable<int> existingChordDefinitionIds)
        {
            throw new NotImplementedException();
        }
    }
}
