using System.Collections.Generic;

namespace Keyify.Web.Models.Instruments
{
    public class FretboardString
    {
        public List<FretboardNote> Notes { get; private set; }

        public FretboardString(List<FretboardNote> notes)
        {
            Notes = notes;
        }
    }
}