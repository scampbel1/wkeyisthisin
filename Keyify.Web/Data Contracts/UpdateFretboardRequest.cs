using Keyify.MusicTheory.Enums;
using System.Collections.Generic;

namespace Keyify.Web.Data_Contracts
{
    public class UpdateFretboardRequest
    {
        public List<Note> PreviouslySelectedNotes { get; set; }

        public Note? NewlySelectedNote { get; set; }

        public string SelectedScale { get; set; }

        public bool LockScale { get; set; }

        public InstrumentType Instrument { get; set; }
    }
}
