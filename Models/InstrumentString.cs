using System.Collections.Generic;
using Keyify.FrontendBuisnessLogic;
using KeyifyClassLibrary.Core.Domain.Enums;

namespace KeyifyWebClient.Core.Models
{
    public class InstrumentString
    {
        public List<FretboardNote> Notes { get; set; }

        public InstrumentString(Note openNote, int fretCount)
        {
            Notes = FretboardFunctions.Populate(openNote, fretCount);
        }        
    }
}