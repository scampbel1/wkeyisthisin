﻿using EnumsNET;
using Keyify.Database.RecordCreation.Factory.Abstraction;
using Keyify.Infrastructure.Repository;
using Keyify.Infrastructure.Repository.Interfaces;
using Keyify.MusicTheory.Definitions;
using Keyify.MusicTheory.Enums;
using Keyify.Services.Formatter.Services;
using Keyify.Services.Models;
using Microsoft.Extensions.Logging;

namespace Keyify.Database.RecordCreation.Factory.Creator
{
    internal class ScaleDefinitionCreator : DatabaseRecordCreator
    {
        private Dictionary<Mode, Interval[]> _scaleIntervals;
        private Dictionary<Mode, string[]> _scaleDegrees;
        private Dictionary<Mode, Note[]> _scaleAllowedRootNotes;

        private IScaleDefinitionRepository _scaleDefinitionRepository;

        public ScaleDefinitionCreator(string connectionString) : base(connectionString)
        {
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("System", LogLevel.Warning);
            });

            var logger = loggerFactory.CreateLogger<ScaleDefinitionRepository>();
            logger.LogInformation("Generating Chord Definitions");

            _scaleIntervals = ModeDefinitions.GetScaleIntervals();
            _scaleDegrees = ModeDefinitions.GetScaleDegrees();
            _scaleAllowedRootNotes = ModeDefinitions.GetExplicitRootNoteScaleRootNotes();

            _scaleDefinitionRepository = new ScaleDefinitionRepository(logger, connectionString, new SerializationFormatter());
        }

        internal override async Task ExecuteAsync()
        {
            foreach (Mode scaleType in Enum.GetValues(typeof(Mode)))
            {
                var scaleIntervals = _scaleIntervals[scaleType];
                var scaleDegrees = _scaleDegrees[scaleType];

                var rootNotes = (Note[])Enum.GetValues(typeof(Note));

                _scaleAllowedRootNotes.TryGetValue(scaleType, out rootNotes);

                var scaleEntry = rootNotes == null ? new ScaleDefinition(scaleType.AsString(EnumFormat.Description), scaleIntervals, scaleDegrees) : new ScaleDefinition(scaleType.AsString(EnumFormat.Description), scaleIntervals, scaleDegrees, rootNotes);

                //Map ScaleDefinition to request

                await _scaleDefinitionRepository.InsertScaleDefinition(scaleEntry);
            }
        }
    }
}
