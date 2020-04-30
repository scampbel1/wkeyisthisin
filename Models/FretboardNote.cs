using KeyifyClassLibrary.Core.MusicTheory.Enums;

namespace KeyifyWebClient.Core.Models
{
    public class FretboardNote
    {
        public Note Note { get; set; }
        public bool Selected { get; set; }
        public bool InSelectedScale { get; set; }

        public FretboardNote(Note note)
        {
            Note = note;
            Selected = false;
            InSelectedScale = false;
        }
    }
}