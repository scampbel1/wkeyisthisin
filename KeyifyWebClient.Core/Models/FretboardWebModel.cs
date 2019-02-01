using System;
using System.Collections.Generic;
using KeyifyScaleFinderClassLibrary.Core.Instrument;
using KeyifyScaleFinderClassLibrary.Core.MusicTheory.Enums;
using KeyifyScaleFinderClassLibrary.Core.MusicTheory.Tuning.Guitar;

namespace KeyifyWebClient.Core.Models
{
    public class FretboardWebModel
    {
        public readonly List<string[]> Tuning;
        public readonly int Fretcount;

        public List<Tuple<string, bool>> Notes;

        public FretboardWebModel()
        {
            Notes = new List<Tuple<string, bool>>();
            Tuning = Fretboard.PopulateFretboard(new StandardGuitarTuning());
            Fretcount = 24;
            PopulateNotes();
        }

        private void PopulateNotes()
        {
            foreach (var note in (Note[])Enum.GetValues(typeof(Note)))
            {
                Notes.Add(new Tuple<string, bool>(note.ToString(), false));
            }
        }
    }
}