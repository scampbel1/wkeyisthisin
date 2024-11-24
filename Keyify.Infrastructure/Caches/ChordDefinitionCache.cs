using Keyify.Infrastructure.Caches.Interfaces;
using Keyify.MusicTheory.Enums;
using Keyify.Services.Formatter.Interfaces;
using Keyify.Services.Models;
using Keyify.Web.Infrastructure.Models.ChordDefinition;

namespace Keyify.Infrastructure.Caches
{
    public class ChordDefinitionCache(INoteFormatService noteFormatService) : IChordDefinitionCache
    {
        private readonly INoteFormatService _noteFormatService = noteFormatService;

        public List<ChordDefinition> ChordDefinitions { get; set; } = [];

        public async Task Initialise(List<ChordDefinitionEntity> chordDefinitionEntities)
        {
            ChordDefinitions = await GenerateChordDefintions(chordDefinitionEntities);
        }

        public Task Sync(List<ChordDefinition> chordDefinitions)
        {
            throw new NotImplementedException();
        }

        //TODO: Move to some sort of generator tool
        private async Task<List<ChordDefinition>> GenerateChordDefintions(List<ChordDefinitionEntity> chordDefinitionEntities)
        {
            var result = new List<ChordDefinition>();

            foreach (var chordDefinitionEntity in chordDefinitionEntities)
            {
                await GenerateChordDefinitionByChordType(chordDefinitionEntity, result);
            }

            return result;
        }

        //TODO: Move to some sort of generator tool
        private async Task GenerateChordDefinitionByChordType(ChordDefinitionEntity chordDefinitionEntity, List<ChordDefinition> chordDefinitions)
        {
            if (chordDefinitionEntity is null || chordDefinitionEntity.Intervals is null)
            {
                return;
            }

            var currentNote = Note.A;

            while (currentNote <= Note.Ab)
            {
                var notes = await GenerateChordDefinitionNotes(currentNote, chordDefinitionEntity.Intervals);
                var sharpNote = _noteFormatService.SharpNoteDictionary[notes[0]];

                chordDefinitions.Add(new ChordDefinition(
                    chordType: chordDefinitionEntity.Name ?? "Name not found!",
                    notes,
                    rootNote: sharpNote,
                    chordDefinitionEntity.Popularity));

                currentNote++;
            }
        }

        //TODO: Move to some sort of generator tool
        private static async Task<Note[]> GenerateChordDefinitionNotes(Note rootNote, Interval[] intervals)
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
        private static async Task<Note> FindNextNote(Note currentNote, Interval interval)
        {
            var nextStepIndex = (int)currentNote + (int)interval;

            var result = nextStepIndex > (int)Note.Ab
                ? (Note)(nextStepIndex - (int)Note.Ab) - 1
                : (Note)nextStepIndex;

            return await Task.FromResult(result);
        }
    }
}
