using KeyifyClassLibrary.Core.Domain.Enums;
using KeyifyClassLibrary.Core.Domain.Tuning;
using System.Collections.Generic;

namespace KeyifyWebClient.Core.Models
{
    public class Fretboard
    {
        public int FretCount { get; set; }
        public ITuning Tuning { get; set; }
        public List<InstrumentString> InstrumentStrings { get; set; }

        public Fretboard(ITuning tuning, int fretCount)
        {
            FretCount = fretCount;
            Tuning = tuning;
            InstrumentStrings = new List<InstrumentString>(tuning.ReturnStringCount());
            PopulateFretboard();
        }

        /// <summary>
        /// Build an Instrument String for each Note in a Tuning.
        /// InstrumentStrings must be reversed because Fretboard must be viewed "upside-down" to adhere to view from player's perspective.
        /// </summary>
        private void PopulateFretboard()
        {
            foreach (Note note in Tuning.ReturnNotes())
            {
                InstrumentStrings.Add(new InstrumentString(note, FretCount));
            }

            InstrumentStrings.Reverse();
        }
    }
}