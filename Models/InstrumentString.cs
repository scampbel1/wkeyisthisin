using KeyifyClassLibrary.Core.MusicTheory.Enums;
using KeyifyClassLibrary.Core.MusicTheory.Helper;
using System.Collections.Generic;

namespace KeyifyWebClient.Core.Models
{
    public class InstrumentString
    {
        public List<FretboardNote> Notes { get; set; }

        public InstrumentString(Note openNote, int fretCount)
        {
            Notes = Populate(openNote, fretCount);
        }

        private static List<FretboardNote> Populate(Note openNote, int fretCount)
        {
            var stringNoteIndex = (int)openNote;
            var count = 0;

            List<FretboardNote> notes = new List<FretboardNote>(fretCount);

            while (count < fretCount)
            {
                notes.Add(new FretboardNote((Note)stringNoteIndex));
                stringNoteIndex++;
                count++;

                if (stringNoteIndex >= EnumValuesConverter.GetNotes().Count)
                {
                    stringNoteIndex = 0;
                }
            }

            return notes;
        }
    }
}