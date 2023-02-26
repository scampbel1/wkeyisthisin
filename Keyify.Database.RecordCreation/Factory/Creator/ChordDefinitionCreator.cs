using EnumsNET;
using Keyify.Database.RecordCreation.Factory.Abstraction;
using Keyify.Infrastructure.Repository;
using Keyify.MusicTheory.Definitions;
using Keyify.MusicTheory.Enums;
using Keyify.Services.Formatter.Services;
using Keyify.Web.Infrastructure.Models.ChordDefinition;
using Keyify.Web.Infrastructure.Repository.Interfaces;
using Microsoft.Extensions.Logging;

namespace Keyify.Database.RecordCreation.Factory.Creator
{
    internal class ChordDefinitionCreator : DatabaseRecordCreator
    {
        private Dictionary<ChordType, Interval[]> _chordDefinitions;
        private IChordDefinitionRepository _chordDefinitionRepository;

        internal ChordDefinitionCreator(string connectionString) : base(connectionString)
        {
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("System", LogLevel.Warning);
            });

            var logger = loggerFactory.CreateLogger<ChordDefinitionRepository>();
            logger.LogInformation("Generating Chord Definitions");

            _chordDefinitions = ChordDefinitions.GenerateChordDefinitions();
            _chordDefinitionRepository = new ChordDefinitionRepository(logger, connectionString, new SerializationFormatter());
        }

        internal override async Task ExecuteAsync()
        {
            foreach (var chordDefinition in _chordDefinitions)
            {
                var chordName = chordDefinition.Key.AsString(EnumFormat.Description);

                Console.WriteLine($"Attempting to create record for Chord Definition: '{chordName}'");

                await _chordDefinitionRepository.InsertChordDefinition(new ChordDefinitionRequest() { Name = chordName, Intervals = chordDefinition.Value });
            }
        }
    }
}
