using System;

namespace KeyifyScaleFinderClassLibrary.MusicTheory
{
    public class CustomTuning : StandardTuning
    {
        private readonly Note[] _notes;

        public CustomTuning(string inputNotes)
        {
            _notes = new Note[inputNotes.Length];

            int count = 0;

            foreach (char note in inputNotes)
            {
                try
                {
                    _notes[count] = KeyifyElementStringConverter.ConvertStringNoteToNoteType(note);
                    count++;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
            }
        }

        public override Note[] ReturnNotes()
        {
            return _notes;
        }
    }
}