namespace KeyifyScaleFinderClassLibrary.MusicTheory
{
    public class StandardTuning : ITuning
    {
        private readonly Note[] _notes = new Note[6]
        {
            Note.E,
            Note.A,
            Note.D,
            Note.G,
            Note.B,
            Note.E
        };

        public virtual Note[] ReturnNotes()
        {
            return _notes;
        }
    }
}