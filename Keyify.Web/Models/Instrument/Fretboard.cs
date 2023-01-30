using KeyifyClassLibrary.Enums;
using KeyifyClassLibrary.Models.Interfaces;
using System.Collections.Generic;

namespace KeyifyWebClient.Models.Instruments
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
            InstrumentStrings = new List<InstrumentString>(tuning.StringCount);
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
                InstrumentStrings.Add(new InstrumentString(note, FretCount));
            }

            InstrumentStrings.Reverse();
        }
    }
}