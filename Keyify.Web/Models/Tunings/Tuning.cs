using KeyifyClassLibrary.Enums;
using System;
using System.Text.RegularExpressions;

namespace Keyify.Web.Models.Tunings
{
    public abstract class Tuning
    {
        public abstract Note[] Notes { get; }
        public abstract int StringCount { get; }

        public virtual Note[] ConvertStringInputToNotes(string input)
        {
            var count = 0;
            var notes = new Note[input.Length];

            if (!ValidateMusicalNotes(input))
            {
                throw new ArgumentException("Invalid string input. Unable to convert to note.");
            }
            else
            {
                foreach (char note in input)
                {
                    try
                    {
                        notes[count] = ConvertStringNoteToNoteType(note);

                        count++;
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Problem converting input to Note", e);
                    }
                }
            }

            return notes;
        }

        private static bool ValidateMusicalNotes(string input)
        {
            Regex validCharacters = new Regex("^[ABCDEFGb#]*$");
            return validCharacters.IsMatch(input);
        }

        private static Note ConvertStringNoteToNoteType(char note)
        {
            return (Note)Enum.Parse(typeof(Note), note.ToString(), true);
        }
    }
}