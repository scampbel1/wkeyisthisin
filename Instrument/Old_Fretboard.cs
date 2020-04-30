using System.Collections.Generic;
using System.Linq;
using KeyifyClassLibrary.Core.MusicTheory.Enums;
using KeyifyClassLibrary.Core.MusicTheory.Helper;
using KeyifyClassLibrary.Core.MusicTheory.Tuning;

namespace KeyifyClassLibrary.Core.Instrument
{
    public static class Old_Fretboard
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
                convertedNotes.Add(ElementStringConverter.ConvertNoteToStringEquivalent(note, true));
            }

            return convertedNotes.ToArray();
        }
    }
}