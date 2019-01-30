using System;
using System.Collections.Generic;
using KeyifyScaleFinderClassLibrary.Core.MusicTheory.Enums;
using KeyifyScaleFinderClassLibrary.Core.MusicTheory.Helper;

namespace KeyifyWebClient.Core.Models
{
    public class FretboardWebModel
    {
        public readonly List<string[]> Tuning;
        public readonly int Fretcount;

        public List<Tuple<string, Note>> AvailableNotes;
        public HashSet<Note> SelectedNotes;

        public FretboardWebModel(IEnumerable<string[]> strings, int fretcount)
        {
            AvailableNotes = new List<Tuple<string, Note>>(12);
            SelectedNotes = new HashSet<Note>();
            Tuning = strings as List<string[]>;
            Fretcount = fretcount;
            
            PopulateNotes();
        }

        private void PopulateNotes()
        {
            foreach (var note in (Note[])Enum.GetValues(typeof(Note)))
            {
                AvailableNotes.Add(new Tuple<string, Note>
                    (KeyifyElementStringConverter.ConvertNoteToStringEquivalent(note, true), note));
            }
        }
    }
}