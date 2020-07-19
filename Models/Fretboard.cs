using System.Collections.Generic;
using KeyifyClassLibrary.Core.Domain.Enums;
using KeyifyClassLibrary.Core.Domain.Tuning;

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

        private void PopulateFretboard()
        {
            foreach (Note note in Tuning.ReturnNotes())
            {
                InstrumentStrings.Add(new InstrumentString(note, FretCount));
            }

            //Fretboard must be viewed "upside-down" to adhere to view from player's perspective
            InstrumentStrings.Reverse();
        }
    }
}