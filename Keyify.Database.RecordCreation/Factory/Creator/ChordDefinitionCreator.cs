﻿using EnumsNET;
using Keyify.Database.RecordCreation.Factory.Abstraction;
using Keyify.Infrastructure.Models.ChordDefinition;
using Keyify.Infrastructure.Repository;
using Keyify.Infrastructure.Repository.Interfaces;
using Keyify.MusicTheory.Definitions;
using Keyify.MusicTheory.Enums;
using Keyify.Services.Formatter.Services;
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

            _chordDefinitions = ChordDefinitions.GetChordIntervals();

            _chordDefinitionRepository = new ChordDefinitionRepository(
                logger,
                connectionString,
                serializationFormatter: new SerializationFormatter());
        }

        internal override async Task ExecuteAsync()
        {
            foreach (var chordDefinition in _chordDefinitions)
            {
                var chordName = chordDefinition.Key.AsString(EnumFormat.Description);

                await _chordDefinitionRepository.InsertChordDefinition(
                    new ChordDefinitionInsertRequest()
                    {
                        Name = chordName,
                        Intervals = chordDefinition.Value
                    });
            }
        }
    }
}
