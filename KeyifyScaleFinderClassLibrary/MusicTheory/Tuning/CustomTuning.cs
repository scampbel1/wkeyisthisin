using System;
using System.Text.RegularExpressions;
using KeyifyScaleFinderClassLibrary.MusicTheory.Enums;
using KeyifyScaleFinderClassLibrary.MusicTheory.Helper;

namespace KeyifyScaleFinderClassLibrary.MusicTheory.Tuning
{
    public class CustomTuning : StandardTuning
    {
        private readonly Note[] _notes;

        public CustomTuning(Note[] inputNotes)
        {
            _notes = inputNotes; 
        }

        public CustomTuning(string inputNotes)
        {
            _notes = ConvertStringInputToNotes(inputNotes);
        }

        public override Note[] ReturnNotes()
        {
            return _notes;
        }

        public static bool ValidateMusicalNotes(string input)
        {
            var validCharacters = new Regex("^[ABCDEFGb#]*$");
            return validCharacters.IsMatch(input);
        }

        public static Note[] ConvertStringInputToNotes(string input)
        {
            var notes = new Note[input.Length];

            if(!ValidateMusicalNotes(input))
                throw new ArgumentException("Invalid string input. Unable to convert to note.");

            var count = 0;

            foreach (var note in input)
            {
                try
                {
                    notes[count] = KeyifyElementStringConverter
                        .ConvertCharNoteToNoteType(note);

                    count++;
                }
                catch (Exception e)
                {
                    throw new Exception("Problem converting input to Note", e);
                }
            }

            return notes;
        }
    }
}