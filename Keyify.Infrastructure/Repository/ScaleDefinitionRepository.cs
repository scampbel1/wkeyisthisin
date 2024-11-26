﻿using Dapper;
using Keyify.Infrastructure.Models.ScaleDefinition;
using Keyify.Infrastructure.Repository.Interfaces;
using Keyify.MusicTheory.Enums;
using Keyify.Services.Formatter.Interfaces;
using Keyify.Services.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System.Text;
using System.Text.Json;

namespace Keyify.Infrastructure.Repository
{
    public class ScaleDefinitionRepository(
        ILogger<ScaleDefinitionRepository> logger,
        string connectionString,
        ISerializationFormatter serializationFormatter) : IScaleDefinitionRepository
    {
        private readonly ILogger _logger = logger;
        private readonly string _connectionString = connectionString;
        private readonly ISerializationFormatter _serializationFormatter = serializationFormatter;

        public async Task<bool> DoesScaleDefinitionExist(string name)
        {
            using var sqlConnection = new SqlConnection(_connectionString);

            await sqlConnection.OpenAsync();

            var query = "SELECT COUNT(1) FROM [Core].[ScaleDefinition] WHERE [Name] = @name";
            var isFound = await sqlConnection.ExecuteScalarAsync<bool>(query, new { name });

            await sqlConnection.CloseAsync();

            return isFound;
        }

        public Task<bool> DoesScaleDefinitionExist(Interval[] intervals)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ScaleDefinitionEntity>> GetAllScaleDefinitions()
        {
            var scaleDefinitions = new List<ScaleDefinitionEntity>();

            try
            {
                using var sqlConnection = new SqlConnection(_connectionString);

                await sqlConnection.OpenAsync();

                var query = "SELECT [Id], [Name], [Intervals], [Degrees], [AllowedRootNotes], [Popularity] FROM [Core].[ScaleDefinition] WHERE [Deleted] = 0";
                var result = await sqlConnection.ExecuteReaderAsync(query);

                while (result.Read())
                {
                    scaleDefinitions.Add(new ScaleDefinitionEntity()
                    {
                        Id = result.GetInt32(0),
                        Name = result.GetString(1),
                        Intervals = await _serializationFormatter.ConvertToIntervalArray((byte[])result[2]),
                        Degrees = await _serializationFormatter.ConvertToDegreeArray((byte[])result[3]),
                        AllowedRootNotes = await _serializationFormatter.ConvertToAllowedRootNotesArray((byte[])result[4]),
                        Popularity = result.GetInt32(5),
                    });
                }

                if (scaleDefinitions.Count != 0)
                {
                    _logger.LogInformation("Found Scale Definition Entries");
                }

                await sqlConnection.CloseAsync();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Could not retrieve Chord Definitions");
            }

            return scaleDefinitions;
        }

        public async Task InsertScaleDefinition(ScaleDefinition scaleDefinition)
        {
            if (await DoesScaleDefinitionExist(scaleDefinition.Name))
            {
                return;
            }

            using var intervalsMemoryStream = new MemoryStream();
            JsonSerializer.Serialize(intervalsMemoryStream, scaleDefinition.Intervals);

            using var degreesMemoryStream = new MemoryStream();
            JsonSerializer.Serialize(degreesMemoryStream, scaleDefinition.Degrees);

            using var allowedRootNotesMemoryStream = new MemoryStream();
            JsonSerializer.Serialize(allowedRootNotesMemoryStream, scaleDefinition.AllowedRootNotes);

            //Convert Intervals to Byte for Check

            //TODO: Implement check by interval
            //if (await DoesScaleDefinitionExist(scaleDefinition.Intervals))
            //{
            //    return;
            //}

            using var sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();

            var sqlQuery = GeneratedInsertSqlQuery();

            var sqlQueryParameters = new
            {
                scaleDefinition.Name,
                Description = "Generated by ScaleDefinitionCreator",
                Intervals = intervalsMemoryStream.ToArray(),
                Degrees = degreesMemoryStream.ToArray(),
                AllowedRootNotes = allowedRootNotesMemoryStream.ToArray()
            };

            await sqlConnection.ExecuteAsync(sqlQuery, sqlQueryParameters);

            await sqlConnection.CloseAsync();
        }

        public Task<List<ScaleDefinitionEntity>> SyncScaleDefinitions(IEnumerable<int> existingScaleDefinitionIds)
        {
            throw new NotImplementedException();
        }

        private static string GeneratedInsertSqlQuery()
        {
            var sb = new StringBuilder();

            sb.AppendLine("INSERT INTO [Core].[ScaleDefinition]");
            sb.AppendLine("(");
            sb.AppendLine("[Name],");
            sb.AppendLine("[Description],");
            sb.AppendLine("[Intervals],");
            sb.AppendLine("[Degrees],");
            sb.AppendLine("[AllowedRootNotes]");
            sb.AppendLine(")");
            sb.AppendLine("VALUES");
            sb.AppendLine("(");
            sb.AppendLine("@Name,");
            sb.AppendLine("@Description,");
            sb.AppendLine("@Intervals,");
            sb.AppendLine("@Degrees,");
            sb.AppendLine("@AllowedRootNotes");
            sb.AppendLine(")");

            return sb.ToString();
        }
    }
}
