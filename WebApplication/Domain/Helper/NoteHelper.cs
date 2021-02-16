using KeyifyClassLibrary.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace KeyifyClassLibrary.Core.Domain.Helper
{
    public static class NoteHelper
    {
        public static bool IsSharpOrFlat(Note note)
        {
            switch (note)
            {
                case Note.Ab:
                    return true;
                case Note.Bb:
                    return true;
                case Note.Eb:
                    return true;
                case Note.Db:
                    return true;
                case Note.Gb:
                    return true;
                default:
                    return false;
            }
        }

        public static bool ValidateMusicalNotes(string input)
        {
            Regex validCharacters = new Regex("^[ABCDEFGb#]*$");
            return validCharacters.IsMatch(input);
        }

        public static Note ConvertStringNoteToNoteType(string note)
        {
            return (Note)Enum.Parse(typeof(Note), note, true);
        }

        public static Note ConvertStringNoteToNoteType(char note)
        {
            return (Note)Enum.Parse(typeof(Note), note.ToString(), true);
        }

        public static Note[] ConvertStringInputToNotes(string input)
        {
            Note[] notes = new Note[input.Length];

            if (!ValidateMusicalNotes(input))
                throw new ArgumentException("Invalid string input. Unable to convert to note.");

            int count = 0;

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

            return notes;
        }

        public static List<Note> ConvertNoteStringArrayIntoNotes(string[] notes)
        {
            List<Note> convertedNotes = new List<Note>(notes.Length);

            foreach (string note in notes)
            {
                try
                {
                    convertedNotes.Add(note.Contains("#")
                        ? ConvertSharpNoteStringToFlatNote(note)
                        : ConvertStringNoteToNoteType(note));
                }
                catch
                {
                    throw new Exception($"There was a problem converting string note into Note: {note}");
                }
            }

            return convertedNotes;
        }

        public static Note ConvertSharpNoteStringToFlatNote(string note)
        {
            if (note.Length != 2) return ConvertStringNoteToNoteType(note);

            if (note[1] != '#')
                throw new InvalidOperationException("Note must be sharp");

            try
            {
                Note convertedNote = ConvertStringNoteToNoteType(note[0]);

                if ((int)convertedNote >= EnumHelper.GetEnumNameCount(typeof(Note)))
                {
                    convertedNote = (Note)0;
                }
                else
                {
                    convertedNote = convertedNote + 1;
                }

                return convertedNote;
            }
            catch
            {
                throw new Exception("Conversion went wrong");
            }
        }

        public static string ConvertNoteToStringEquivalent(Note note, bool convertFlatNotes = false)
        {
            if (!convertFlatNotes || !IsSharpOrFlat(note))
                return note.ToString();

            if (note == Note.Ab)
                return "G#";

            return note - 1 + "#";
        }
    }
}