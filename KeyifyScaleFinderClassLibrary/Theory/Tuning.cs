using System;

namespace KeyifyScaleFinderClassLibrary.Theory
{
    public interface ITuning
    {
        Note[] ReturnNotes();
    }

    public abstract class BaseTuning : ITuning
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

    public class StandardTuning : BaseTuning
    {
        public override Note[] ReturnNotes()
        {
            return base.ReturnNotes();
        }
    }

    public class CustomTuning : BaseTuning
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