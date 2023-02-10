using Keyify.Models.Service;
using Keyify.Models.ViewModels.Misc;
using Keyify.Web.Service.Interfaces;
using KeyifyClassLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Keyify.Web.Service
{
    public class GroupedScalesService : IGroupedScalesService
    {
        private List<ScaleGroupingEntry> KeyGroupingEntries { get; init; } = new List<ScaleGroupingEntry>();
        private List<ScaleGroupingEntry> ScaleGroupingEntries { get; init; } = new List<ScaleGroupingEntry>();

        public List<ScaleGroupingEntry> GroupedScales => ScaleGroupingEntries;
        public List<ScaleGroupingEntry> GroupedKeys => KeyGroupingEntries;

        public int TotalScaleCount => ScaleGroupingEntries.Sum(s => s.Count);
        public int TotalKeyCount => KeyGroupingEntries.Sum(k => k.Count);

        public void UpdateScaleGroupingModel(IEnumerable<ScaleEntry> scales, IEnumerable<Note> selectedNotes)
        {
            KeyGroupingEntries.Clear();
            ScaleGroupingEntries.Clear();

            var noteHashSets = GenerateNoteHashSets(scales);

            foreach (var scaleNotes in noteHashSets)
            {
                var allScales = scales.Where(s => s.Scale.NoteSet.SetEquals(scaleNotes)).ToList();
                var groupedKeys = allScales.Where(s => s.IsKey == true).ToList();
                var groupedScales = allScales.Where(s => s.IsKey == false).ToList();

                if (groupedScales.Any())
                {
                    ScaleGroupingEntries.Add(new ScaleGroupingEntry(groupedScales, selectedNotes));
                }

                if (groupedKeys.Any())
                {
                    KeyGroupingEntries.Add(new ScaleGroupingEntry(groupedKeys, selectedNotes));
                }
            }
        }

        private IEnumerable<HashSet<Note>> GenerateNoteHashSets(IEnumerable<ScaleEntry> scales)
        {
            var distinctSets = new List<HashSet<Note>>();

            foreach (var scale in scales)
            {
                if (!distinctSets.Where(ds => ds.SetEquals(scale.Scale.NoteSet)).Any())
                {
                    distinctSets.Add(scale.Scale.NoteSet);
                }
            }

            return distinctSets;
        }

        private List<Note> ConvertNoteStringArrayIntoNotes(IEnumerable<string> notes)
        {
            var convertedNotes = new List<Note>();

            foreach (string note in notes)
            {
                try
                {
                    convertedNotes.Add(note.Contains("#") ? ConvertSharpNoteStringToFlatNote(note) : ConvertStringNoteToNoteType(note));
                }
                catch
                {
                    throw new Exception($"There was a problem converting string note into Note: {note}");
                }
            }

            return convertedNotes;
        }

        private Note ConvertSharpNoteStringToFlatNote(string note)
        {
            if (note.Length != 2) return ConvertStringNoteToNoteType(note);

            if (note[1] != '#')
                throw new InvalidOperationException("Note must be sharp");

            try
            {
                var convertedNote = ConvertStringNoteToNoteType(note[0]);

                if (convertedNote == Note.Ab)
                {
                    convertedNote = Note.A;
                }
                else
                {
                    convertedNote = convertedNote + 1;
                }

                return convertedNote == Note.Ab ? Note.A : convertedNote + 1;
            }
            catch
            {
                throw new Exception("Conversion went wrong");
            }
        }

        private Note ConvertStringNoteToNoteType(string note)
        {
            return (Note)Enum.Parse(typeof(Note), note, true);
        }

        private Note ConvertStringNoteToNoteType(char note)
        {
            return (Note)Enum.Parse(typeof(Note), note.ToString(), true);
        }
    }
}
