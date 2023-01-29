using KeyifyClassLibrary.Enums;
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

        //TODO: The characteristics of the note should be set in this method (this is currently happening in ApplySelectedNotesToFretboard)

        public List<InstrumentNote> PopulateFretboard(Note openNote, int fretCount)
        {
            var count = 0;
            var currentNote = openNote;
            var notes = new List<InstrumentNote>(fretCount);

            while (count < fretCount)
            {
                notes.Add(new InstrumentNote(currentNote));

                currentNote = currentNote == Note.Ab ? Note.A : currentNote + 1;
                count++;
            }

            return notes;
        }
    }
}