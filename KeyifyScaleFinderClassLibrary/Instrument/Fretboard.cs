using System.Collections.Generic;
using System.Linq;
using KeyifyScaleFinderClassLibrary.MusicTheory.Enums;
using KeyifyScaleFinderClassLibrary.MusicTheory.Helper;
using KeyifyScaleFinderClassLibrary.MusicTheory.Tuning;

namespace KeyifyScaleFinderClassLibrary.Instrument
{
    public static class Fretboard
    {
        public static List<string[]> PopulateFretboard(ITuning tuning, int fretCount = 24)
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