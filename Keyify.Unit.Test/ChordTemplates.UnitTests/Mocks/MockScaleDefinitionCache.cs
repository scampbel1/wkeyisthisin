﻿using Keyify.Infrastructure.Caches.Interfaces;
using Keyify.MusicTheory.Definitions;
using Keyify.MusicTheory.Enums;
using Keyify.Services.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Keyify.Web.Unit.Test.ChordTemplates.UnitTests.Mocks
{
    public class MockScaleDefinitionCache : IScaleDefinitionCache
    {
        public List<ScaleDefinition> ScaleDefinitions { get; set; } = new List<ScaleDefinition>();

        //TODO: Handle commented out types - use duplicate tests to identify duplicates, and create new table for "alternative aliases"
        private async Task<List<ScaleDefinition>> GenerateScaleDefinitions()
        {
            var scaleDegrees = ModeDefinitions.GetScaleDegrees();
            var scaleIntervals = ModeDefinitions.GetScaleIntervals();
            var explicitRootNotes = ModeDefinitions.GetExplicitRootNoteScaleRootNotes();

            var scaleDefinitions = new List<ScaleDefinition>();

            foreach (Mode scaleType in Enum.GetValues(typeof(Mode)))
            {
                var rootNotes = Array.CreateInstance(typeof(Note), Enum.GetValues(typeof(Note)).Length);

                explicitRootNotes.TryGetValue(scaleType, out rootNotes);

                var scaleEntry = rootNotes == null ? new ScaleDefinition(scaleType, scaleIntervals[scaleType], scaleDegrees[scaleType]) : new ScaleDefinition(scaleType, scaleIntervals[scaleType], scaleDegrees[scaleType], explicitRootNotes[scaleType]);

                scaleDefinitions.Add(scaleEntry);
            }

            return await Task.FromResult(scaleDefinitions);
        }

        async Task IScaleDefinitionCache.Initialise()
        {
            ScaleDefinitions = await GenerateScaleDefinitions();
        }

        Task IScaleDefinitionCache.Sync(List<ScaleDefinition> scaleDefinitions)
        {
            throw new System.NotImplementedException();
        }
    }
}