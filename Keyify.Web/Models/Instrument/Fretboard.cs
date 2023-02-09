using Keyify.Web.Enums;
using Keyify.Web.Models.Tunings;
using KeyifyClassLibrary.Enums;
using System.Collections.Generic;

namespace KeyifyWebClient.Models.Instruments
{
    public class Fretboard
    {
        public InstrumentType InstrumentType { get; set; }
        public int FretCount { get; set; }
        public Tuning Tuning { get; set; }
        public List<FretboardString> InstrumentStrings { get; set; } = new List<FretboardString>();

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
                InstrumentStrings.Add(new FretboardString(note, FretCount));
            }

            InstrumentStrings.Reverse();
        }
    }
}