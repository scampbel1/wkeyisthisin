using System;
using System.Collections.Generic;
using KeyifyScaleFinderClassLibrary.MusicTheory.Enums;
using KeyifyScaleFinderClassLibrary.MusicTheory.Helper;

namespace KeyifyWebClient.Models
{
    public class FretboardWebModel
    {
        public readonly List<Note[]> Strings;
        public readonly int Fretcount;
        public List<Tuple<string, string>> Notes;

        public FretboardWebModel(IEnumerable<Note[]> strings, int fretcount)
        {
            Strings = strings as List<Note[]>;
            Fretcount = fretcount;
            Notes = new List<Tuple<string, string>>(12);
            PopulateNotes();
        }

        private void PopulateNotes()
        {
            foreach (var note in EnumValuesConverter.GetNotes())
            {
                Notes.Add(new Tuple<string, string>
                    (note, note));
                
                //KeyifyElementStringConverter.ConvertFlatNoteStringToSharpString
            }
        }
    }
}