using System;
using KeyifyScaleFinderClassLibrary.Theory;

namespace GuitarKeyFinder
{
    public interface Tuning
    {
        Note[] ReturnNotes();
    }

    public abstract class BaseTuning : Tuning
    {
        private Note[] _notes = new Note[6]
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

    public class StandardTuning : BaseTuning
    {
        public override Note[] ReturnNotes()
        {
            return base.ReturnNotes();
        }
    }

    public class CustomTuning : BaseTuning
    {
        private Note[] _notes;

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
                    throw e;
                }
            }
        }

        public override Note[] ReturnNotes()
        {
            return _notes;
        }
    }
}