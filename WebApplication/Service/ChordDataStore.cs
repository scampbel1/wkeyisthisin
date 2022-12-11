using Keyify.Enums;
using Keyify.Models.Service_Models;
using KeyifyClassLibrary.Enums;
using System.Collections.Generic;

namespace Keyify.Service
{
    public class ChordDataStore
    {
        private Dictionary<ChordType, Interval[]> _chordDefinitions => GenerateChordDefinitionDictionary();

        public readonly List<ChordTemplate> Chords;

        public ChordDataStore()
        {
            Chords = GenerateChordTemplates();
        }

        private List<ChordTemplate> GenerateChordTemplates()
        {
            var chordTemplates = new List<ChordTemplate>();

            foreach (var chordDefinition in _chordDefinitions)
            {
                GenerateChordTemplatesByChordType(chordDefinition.Key, chordDefinition.Value, chordTemplates);
            }

            return chordTemplates;
        }

        private void GenerateChordTemplatesByChordType(ChordType chordType, Interval[] intervals, List<ChordTemplate> chordTemplates)
        {
            var count = 0;
            var currentNote = Note.A;

            while (count <= (int)Note.Ab)
            {
                chordTemplates.Add(new ChordTemplate(chordType, GenerateChordDefinitionNotesFromInterval(currentNote, intervals)));

                currentNote = currentNote != Note.Ab ? currentNote + 1 : Note.A;
                count++;
            }
        }

        private Dictionary<ChordType, Interval[]> GenerateChordDefinitionDictionary()
        {
            var chordDefinitions = new Dictionary<ChordType, Interval[]>();

            chordDefinitions.Add(ChordType.Major, new Interval[] { Interval.R, Interval.Wh, Interval.Wh });

            return chordDefinitions;
        }

        private Note[] GenerateChordDefinitionNotesFromInterval(Note rootNote, Interval[] intervals)
        {
            var count = 0;
            var currentNote = rootNote;
            var chordNotes = new Note[intervals.Length];

            foreach (var interval in intervals)
            {
                currentNote = interval == Interval.R ? currentNote : FindNextNote(currentNote, interval);
                chordNotes[count] = currentNote;
                count++;
            }

            return chordNotes;
        }

        private Note FindNextNote(Note currentNote, Interval interval)
        {
            var nextStep = (int)currentNote + (int)interval;

            nextStep = interval == Interval.R ? nextStep++ : nextStep;

            return nextStep > (int)Note.Ab ? (Note)(int)Note.A + (nextStep - (int)Note.Ab) : (Note)nextStep;
        }
    }
}
