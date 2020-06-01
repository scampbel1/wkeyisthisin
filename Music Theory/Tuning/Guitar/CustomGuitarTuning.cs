using System;
using System.Text.RegularExpressions;
using KeyifyClassLibrary.Core.MusicTheory.Enums;
using KeyifyClassLibrary.Core.MusicTheory.Helper;

namespace KeyifyClassLibrary.Core.MusicTheory.Tuning.Guitar
{
    public class CustomStandardGuitarTuning : StandardGuitarTuning
    {
        private readonly Note[] _notes;

        public CustomStandardGuitarTuning(Note[] inputNotes)
        {
            _notes = inputNotes; 
        }

        public CustomStandardGuitarTuning(string inputNotes)
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
                    notes[count] = ElementStringConverter
                        .ConvertStringNoteToNoteType(note);

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