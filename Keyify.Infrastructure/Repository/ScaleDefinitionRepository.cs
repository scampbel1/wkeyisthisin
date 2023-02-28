﻿using Dapper;
using Keyify.Infrastructure.Models.ScaleDefinition;
using Keyify.Infrastructure.Repository.Interfaces;
using Keyify.MusicTheory.Enums;
using Keyify.Services.Formatter.Interfaces;
using Keyify.Services.Models;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using System.Text;
using System.Text.Json;

namespace Keyify.Infrastructure.Repository
{
    public class ScaleDefinitionRepository : IScaleDefinitionRepository
    {
        private readonly ILogger _logger;
        private readonly string _connectionString;
        private readonly ISerializationFormatter _serializationFormatter;

        public ScaleDefinitionRepository(ILogger<ScaleDefinitionRepository> logger, string connectionString, ISerializationFormatter serializationFormatter)
        {
            _logger = logger;
            _connectionString = connectionString;
            _serializationFormatter = serializationFormatter;
        }

        public Task<bool> DoesScaleDefinitionExist(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DoesScaleDefinitionExist(Interval[] intervals)
        {
            throw new NotImplementedException();
        }

        public Task<List<ScaleDefinitionEntity>> GetAllScaleDefinitions()
        {
            throw new NotImplementedException();
        }

        public async Task InsertScaleDefinition(ScaleDefinition scaleDefinition)
        {
            if (await DoesScaleDefinitionExist(scaleDefinition.Name))
            {
                return;
            }

            //TODO: Implement
            //if (await DoesScaleDefinitionExist(scaleDefinition.Intervals))
            //{
            //    return;
            //}

            _logger.LogInformation($"Create Scale Definition for '{scaleDefinition.Name}'");

            using var sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();

            using var intervalsMemoryStream = new MemoryStream();
            JsonSerializer.Serialize(intervalsMemoryStream, scaleDefinition.Intervals);

            using var degreesMemoryStream = new MemoryStream();
            JsonSerializer.Serialize(degreesMemoryStream, scaleDefinition.Degrees);

            using var allowedRootNotesMemoryStream = new MemoryStream();
            JsonSerializer.Serialize(allowedRootNotesMemoryStream, scaleDefinition.AllowedRootNotes);

            var sqlQuery = GeneratedInsertSqlQuery();

            var sqlQueryParameters = new
            {
                Name = scaleDefinition.Name,
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

        private string GeneratedInsertSqlQuery()
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
