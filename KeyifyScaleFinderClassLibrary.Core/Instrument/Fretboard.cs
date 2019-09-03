using System.Collections.Generic;
using System.Linq;
using KeyifyScaleFinderClassLibrary.Core.MusicTheory.Enums;
using KeyifyScaleFinderClassLibrary.Core.MusicTheory.Helper;
using KeyifyScaleFinderClassLibrary.Core.MusicTheory.Tuning;

namespace KeyifyScaleFinderClassLibrary.Core.Instrument
{
    public static class Fretboard
    {
        public static List<string[]> PopulateFretboard(ITuning tuning, int fretCount)
        {
            var fretboard = new List<string[]>();

            foreach (Note note in tuning.ReturnNotes().Reverse())
            {
                fretboard.Add(ConvertToString(StringNotePopulater.Populate(note, fretCount)));
            }

            return fretboard;
        }

        private static string[] ConvertToString(Note[] notes)
        {
            var convertedNotes = new List<string>(notes.Length);

            foreach (var note in notes)
            {
                convertedNotes.Add(KeyifyElementStringConverter.ConvertNoteToStringEquivalent(note, true));
            }

            return convertedNotes.ToArray();
        }
    }
}