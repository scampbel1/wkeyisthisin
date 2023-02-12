﻿using Keyify.Enums;
using Keyify.Models.ServiceModels;
using KeyifyClassLibrary.Enums;
using System.Collections.Generic;

namespace Keyify.Service.Caches
{
    public class ChordTemplateDataCache
    {
        private Dictionary<ChordType, Interval[]> _chordTemplateDefinitions => GenerateChordTemplateDefinitions();

        public readonly List<ChordTemplate> ChordTemplates;

        public ChordTemplateDataCache()
        {
            ChordTemplates = GenerateChordTemplates();
        }

        private List<ChordTemplate> GenerateChordTemplates()
        {
            var chordTemplates = new List<ChordTemplate>();

            foreach (var chordTemplateDefinition in _chordTemplateDefinitions)
            {
                GenerateChordTemplatesByChordType(chordTemplateDefinition.Key, chordTemplateDefinition.Value, chordTemplates);
            }

            return chordTemplates;
        }

        private void GenerateChordTemplatesByChordType(ChordType chordType, Interval[] intervals, List<ChordTemplate> chordTemplates)
        {
            var currentNote = Note.A;

            while (currentNote <= Note.Ab)
            {
                chordTemplates.Add(new ChordTemplate(chordType, GenerateChordTemplateDefinitionNotes(currentNote, intervals)));
                currentNote++;
            }
        }

        private Note[] GenerateChordTemplateDefinitionNotes(Note rootNote, Interval[] intervals)
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
            var nextStepIndex = (int)currentNote + (int)interval;

            return nextStepIndex > (int)Note.Ab
                ? (Note)(nextStepIndex - (int)Note.Ab) - 1
                : (Note)nextStepIndex;
        }

        private Dictionary<ChordType, Interval[]> GenerateChordTemplateDefinitions()
        {
            var chordDefinitions = new Dictionary<ChordType, Interval[]>();

            chordDefinitions.Add(ChordType.Major, new Interval[] { Interval.R, Interval.WW, Interval.Wh });
            chordDefinitions.Add(ChordType.Minor, new Interval[] { Interval.R, Interval.Wh, Interval.WW });
            chordDefinitions.Add(ChordType.Diminished, new Interval[] { Interval.R, Interval.Wh, Interval.Wh });
            chordDefinitions.Add(ChordType.MajorSeventh, new Interval[] { Interval.R, Interval.WW, Interval.Wh, Interval.WW });
            chordDefinitions.Add(ChordType.MinorSeventh, new Interval[] { Interval.R, Interval.Wh, Interval.WW, Interval.Wh });
            chordDefinitions.Add(ChordType.DominantSeventh, new Interval[] { Interval.R, Interval.WW, Interval.Wh, Interval.Wh });
            chordDefinitions.Add(ChordType.SuspendedSecond, new Interval[] { Interval.R, Interval.W, Interval.WWh });
            chordDefinitions.Add(ChordType.SuspendedFourth, new Interval[] { Interval.R, Interval.WWh, Interval.W });
            chordDefinitions.Add(ChordType.Augmented, new Interval[] { Interval.R, Interval.WW, Interval.WW });
            chordDefinitions.Add(ChordType.MajorNinth, new Interval[] { Interval.R, Interval.WW, Interval.Wh, Interval.WW, Interval.Wh });
            chordDefinitions.Add(ChordType.MinorNinth, new Interval[] { Interval.R, Interval.Wh, Interval.WW, Interval.Wh, Interval.WW });
            chordDefinitions.Add(ChordType.DominantNinth, new Interval[] { Interval.R, Interval.WW, Interval.Wh, Interval.Wh, Interval.WW });
            chordDefinitions.Add(ChordType.MajorEleventh, new Interval[] { Interval.R, Interval.WW, Interval.Wh, Interval.WW, Interval.Wh, Interval.Wh });
            chordDefinitions.Add(ChordType.MinorEleventh, new Interval[] { Interval.R, Interval.Wh, Interval.WW, Interval.Wh, Interval.WW, Interval.Wh });
            chordDefinitions.Add(ChordType.DominantEleventh, new Interval[] { Interval.R, Interval.WW, Interval.Wh, Interval.Wh, Interval.WW, Interval.Wh });
            chordDefinitions.Add(ChordType.MajorThirteenth, new Interval[] { Interval.R, Interval.WW, Interval.Wh, Interval.WW, Interval.Wh, Interval.Wh, Interval.WW });
            chordDefinitions.Add(ChordType.MinorThirteenth, new Interval[] { Interval.R, Interval.Wh, Interval.WW, Interval.Wh, Interval.WW, Interval.Wh, Interval.WW });
            chordDefinitions.Add(ChordType.DominantThirteenth, new Interval[] { Interval.R, Interval.WW, Interval.Wh, Interval.Wh, Interval.WW, Interval.Wh, Interval.WW });

            return chordDefinitions;
        }
    }
}
