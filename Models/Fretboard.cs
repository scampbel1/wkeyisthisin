using KeyifyClassLibrary.Core.MusicTheory.Enums;
using KeyifyClassLibrary.Core.MusicTheory.Tuning;
using System.Collections.Generic;

namespace KeyifyWebClient.Core.Models
{
    public class Fretboard
    {
        public List<InstrumentString> InstrumentStrings { get; set; }
        public ITuning Tuning { get; set; }
        public int FretCount { get; set; }

        public Fretboard(ITuning tuning, int fretCount)
        {
            FretCount = fretCount;
            Tuning = tuning;
            InstrumentStrings = new List<InstrumentString>(tuning.ReturnStringCount());
            PopulateFretboard();
        }

        private void PopulateFretboard()
        {
            foreach(Note note in Tuning.ReturnNotes())
            {
                InstrumentStrings.Add(new InstrumentString(note, FretCount));
            }
            
            //Fretboard must be viewed "upside-down" to adhere to view from player's perspective
            InstrumentStrings.Reverse();
        }
    }
}