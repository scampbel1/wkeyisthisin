using System;
using System.Collections.Generic;
using KeyifyScaleFinderClassLibrary.MusicTheory.Enums;
using KeyifyScaleFinderClassLibrary.MusicTheory.Helper;

namespace KeyifyWebClient.Models
{
    public class FretboardWebModel
    {
        public readonly List<string[]> Strings;
        public readonly int Fretcount;
        public List<Tuple<string, Note>> Notes;

        public FretboardWebModel(IEnumerable<string[]> strings, int fretcount)
        {
            Strings = strings as List<string[]>;
            Fretcount = fretcount;
            Notes = new List<Tuple<string, Note>>(12);
            PopulateNotes();
        }

        private void PopulateNotes()
        {
            foreach (var note in (Note[])Enum.GetValues(typeof(Note)))
            {
                Notes.Add(new Tuple<string, Note>
                    (KeyifyElementStringConverter.ConvertNoteToStringEquivalent(note, true), note));
            }
        }
    }
}