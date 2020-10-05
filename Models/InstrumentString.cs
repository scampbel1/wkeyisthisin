using Keyify.FrontendBuisnessLogic;
using KeyifyClassLibrary.Core.Domain.Enums;
using System.Collections.Generic;

namespace KeyifyWebClient.Core.Models
{
    public class InstrumentString
    {
        public List<FretboardNote> Notes { get; set; }

        public InstrumentString(Note openNote, int fretCount)
        {
            Notes = FretboardFunctions.PopulateFretboard(openNote, fretCount);
        }
    }
}