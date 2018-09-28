using System;
using System.Text.RegularExpressions;

namespace KeyifyScaleFinderClassLibrary.MusicTheory.Tuning
{
    public class CustomTuning : StandardTuning
    {
        private readonly Note[] _notes;

        public CustomTuning(string inputNotes)
        {
            if(!ValidateMusicalNotes(inputNotes))
                throw new ArgumentException("Input string contains invalid characters");

            _notes = new Note[inputNotes.Length];

            var count = 0;

            foreach (var note in inputNotes)
            {
                try
                {
                    _notes[count] = KeyifyElementStringConverter
                        .ConvertStringNoteToNoteType(note);

                    count++;
                }
                catch (Exception e)
                {
                    throw new Exception("Problem converting input to Note", e);
                }
            }
        }

        public override Note[] ReturnNotes()
        {
            return _notes;
        }

        public static bool ValidateMusicalNotes(string input)
        {
            var validCharacters = new Regex("^[ABCDEFGb]*$");
            return validCharacters.IsMatch(input);
        }
    }
}