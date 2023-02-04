using Keyify.Web.Enums;
using Keyify.Web.Enums.Tuning;
using KeyifyClassLibrary.Enums;

namespace Keyify.Web.Models.QuickLink
{
    public class QuickLinkParameters
    {
        public InstrumentType InstrumentType { get; set; }

        public GuitarTuning Tuning { get; set; }

        public Note[] SelectedNotes { get; set; }

        public string SelectedScale { get; set; }
    }
}
