﻿using Keyify.MusicTheory.Enums;
using Keyify.Services.Models;
using Keyify.Web.Infrastructure.Models.ChordDefinition;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Keyify.Web.Unit.Test.ChordTemplates.UnitTests.Mocks
{
    //TODO: Work out where this should live, and split out methods so that it can be used be tooling
    public class MockChordDefinitionCache : IMemoryCache
    {
        public Dictionary<ChordType, Interval[]> ChordTemplateDefinitions;

        public List<ChordDefinition> ChordDefinitions { get; set; }

        public const string _chordDefinitionsCacheKey = "ChordDefinitions";

        public async Task Initialise(List<ChordDefinitionEntity> chordDefinitions)
        {
            var generatedChordDefinitions = new List<ChordDefinition>();

            foreach (var chordDefinition in chordDefinitions)
            {
                await GenerateChordTemplatesByChordType(chordDefinition.Name, chordDefinition.Intervals, generatedChordDefinitions);
            }

            ChordDefinitions = generatedChordDefinitions;
        }

        private async Task GenerateChordTemplatesByChordType(string chordType, Interval[] intervals, List<ChordDefinition> chordTemplates)
        {
            var currentNote = Note.A;

            while (currentNote <= Note.Ab)
            {
                chordTemplates.Add(new ChordDefinition(chordType, await GenerateChordTemplateDefinitionNotes(currentNote, intervals)));
                currentNote++;
            }
        }

        private async Task<Note[]> GenerateChordTemplateDefinitionNotes(Note rootNote, Interval[] intervals)
        {
            var count = 0;
            var currentNote = rootNote;
            var chordNotes = new Note[intervals.Length];

            foreach (var interval in intervals)
            {
                currentNote = interval == Interval.R ? currentNote : await FindNextNote(currentNote, interval);
                chordNotes[count] = currentNote;
                count++;
            }

            return chordNotes;
        }

        private async Task<Note> FindNextNote(Note currentNote, Interval interval)
        {
            var nextStepIndex = (int)currentNote + (int)interval;

            var result = nextStepIndex > (int)Note.Ab
                ? (Note)(nextStepIndex - (int)Note.Ab) - 1
                : (Note)nextStepIndex;

            return await Task.FromResult(result);
        }

        public ICacheEntry CreateEntry(object key)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(object key)
        {
            throw new System.NotImplementedException();
        }

        public bool TryGetValue(object key, out object value)
        {
            if (key is string cacheKey && cacheKey == _chordDefinitionsCacheKey)
            {
                value = ChordDefinitions;
                return true;
            }

            value = null;
            return false;
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}