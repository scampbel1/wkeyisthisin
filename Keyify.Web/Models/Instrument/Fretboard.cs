using Keyify.MusicTheory.Enums;
using Keyify.Web.Models.Tunings;
using System.Collections.Generic;

namespace Keyify.Web.Models.Instruments
{
    public class Fretboard
    {
        public readonly Dictionary<Note, string> SharpNotesDictionary;

        public InstrumentType InstrumentType { get; set; }
        public int FretCount { get; set; }
        public Tuning Tuning { get; set; }
        public List<FretboardString> InstrumentStrings { get; set; } = new List<FretboardString>();

        public Fretboard(Dictionary<Note, string> sharpNotesDictionary)
        {
            SharpNotesDictionary = sharpNotesDictionary;
        }

        public void UpdateFretboard(InstrumentType instrumentType, Tuning tuning, int fretCount)
        {
            InstrumentStrings = null;

            InstrumentType = instrumentType;
            FretCount = fretCount;
            Tuning = tuning;
            InstrumentStrings = new List<FretboardString>(tuning.StringCount);

            PopulateFretboard();
        }

        /// <summary>
        /// Build an Instrument String for each Note in a Tuning.
        /// InstrumentStrings must be reversed because Fretboard must be viewed "upside-down" to adhere to view from player's perspective.
        /// </summary>
        private void PopulateFretboard()
        {
            foreach (Note note in Tuning.Notes)
            {
                var fretboardString = CreateFretboardString(note, FretCount);

                InstrumentStrings.Add(new FretboardString(fretboardString));
            }

            InstrumentStrings.Reverse();
        }

        //TODO: The characteristics of the note should be set in this method (this is currently happening in ApplySelectedNotesToFretboard)

        public List<FretboardNote> CreateFretboardString(Note openNote, int fretCount)
        {
            var count = 0;
            var currentNote = openNote;
            var currentSharpNote = SharpNotesDictionary[currentNote];

            var notes = new List<FretboardNote>(fretCount);

            while (count < fretCount)
            {
                notes.Add(new FretboardNote(currentNote, currentSharpNote));

                currentNote = currentNote == Note.Ab ? Note.A : currentNote + 1;
                currentSharpNote = SharpNotesDictionary[currentNote];
                count++;
            }

            return notes;
        }
    }
}