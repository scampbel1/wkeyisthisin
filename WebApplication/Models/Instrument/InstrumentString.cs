using KeyifyClassLibrary.Enums;
using KeyifyClassLibrary.Helper;
using System.Collections.Generic;

namespace KeyifyWebClient.Models.Instruments
{
    public class InstrumentString
    {
        public List<InstrumentNote> Notes { get; set; }

        public InstrumentString(Note openNote, int fretCount)
        {
            Notes = PopulateFretboard(openNote, fretCount);
        }

        public List<InstrumentNote> PopulateFretboard(Note openNote, int fretCount)
        {
            int stringNoteIndex = (int)openNote;
            int count = 0;

            List<InstrumentNote> notes = new List<InstrumentNote>(fretCount);

            while (count < fretCount)
            {
                notes.Add(new InstrumentNote((Note)stringNoteIndex));
                stringNoteIndex++;
                count++;

                if (stringNoteIndex >= EnumHelper.GetEnumNameCount(typeof(Note)))
                    stringNoteIndex = 0;
            }

            return notes;
        }
    }
}