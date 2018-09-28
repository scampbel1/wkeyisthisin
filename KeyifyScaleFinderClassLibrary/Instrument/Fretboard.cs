using System.Collections.Generic;
using System.Linq;
using KeyifyScaleFinderClassLibrary.MusicTheory;

namespace KeyifyScaleFinderClassLibrary.Instrument
{
    public static class Fretboard
    {
        public static List<Note[]> PopulateFretboard(ITuning tuning, int fretCount = 24)
        {
            var fretboard = new List<Note[]>();

            foreach (Note note in tuning.ReturnNotes().Reverse())
            {
                fretboard.Add(StringNotePopulater.Populate(note, fretCount));
            }

            return fretboard;
        }
    }
}