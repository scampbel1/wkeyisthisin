using Keyify.Infrastructure.Caches.Interfaces;
using Keyify.MusicTheory.Enums;
using Keyify.Services.Formatter.Interfaces;
using Keyify.Services.Models;

namespace Keyify.Infrastructure.Caches
{
    public class ChordDefinitionCache : IChordDefinitionCache
    {
        private readonly INoteFormatService _noteFormatService;

        public List<ChordDefinition>? ChordDefinitions { get; set; }

        public ChordDefinitionCache(INoteFormatService noteFormatService)
        {
            _noteFormatService = noteFormatService;
        }

        public async Task Initialise(Dictionary<string, Interval[]> chordDefinitions)
        {
            ChordDefinitions = await GenerateChordDefintions(chordDefinitions);
        }

        public Task Sync(List<ChordDefinition> chordDefinitions)
        {
            throw new NotImplementedException();
        }

        //TODO: Move to some sort of generator tool
        private async Task<List<ChordDefinition>> GenerateChordDefintions(Dictionary<string, Interval[]> chordDefinitions)
        {
            var result = new List<ChordDefinition>();

            foreach (var chordDefinition in chordDefinitions)
            {
                await GenerateChordDefinitionByChordType(chordDefinition.Key, chordDefinition.Value, result);
            }

            return result;
        }

        //TODO: Move to some sort of generator tool
        private async Task GenerateChordDefinitionByChordType(string chordType, Interval[] intervals, List<ChordDefinition> chordDefinitions)
        {
            var currentNote = Note.A;

            while (currentNote <= Note.Ab)
            {
                var notes = await GenerateChordDefinitionNotes(currentNote, intervals);
                var sharpNote = _noteFormatService.SharpNoteDictionary[notes[0]];

                chordDefinitions.Add(new ChordDefinition(chordType, notes, sharpNote));
                currentNote++;
            }
        }

        //TODO: Move to some sort of generator tool
        private async Task<Note[]> GenerateChordDefinitionNotes(Note rootNote, Interval[] intervals)
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

        //TODO: Move to some sort of generator tool
        private async Task<Note> FindNextNote(Note currentNote, Interval interval)
        {
            var nextStepIndex = (int)currentNote + (int)interval;

            var result = nextStepIndex > (int)Note.Ab
                ? (Note)(nextStepIndex - (int)Note.Ab) - 1
                : (Note)nextStepIndex;

            return await Task.FromResult(result);
        }
    }
}
