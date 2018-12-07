using System;
using System.Collections.Generic;
using KeyifyScaleFinderClassLibrary.MusicTheory.Enums;

namespace KeyifyScaleFinderClassLibrary.MusicTheory.Helper
{
    public static class KeyifyElementStringConverter
    {
        public static Note ConvertCharNoteToNoteType(string note)
        {
            return (Note) Enum.Parse(typeof(Note), note, true);
        }

        public static Note ConvertCharNoteToNoteType(char note)
        {
            return (Note) Enum.Parse(typeof(Note), note.ToString(), true);
        }

        public static HeptatonicMode ConvertStringModeNameToModeType(string mode)
        {
            return (HeptatonicMode) Enum.Parse(typeof(HeptatonicMode), mode, true);
        }

        public static List<Note> ConvertStringArrayIntoNotes(string[] notes)
        {
            List<Note> convertedNotes = new List<Note>(notes.Length);

            foreach (string note in notes)
            {
                try
                {
                    convertedNotes.Add(note.Contains("#")
                        ? ConvertSharpNoteToFlat(note)
                        : ConvertCharNoteToNoteType(note));
                }
                catch
                {
                    throw new Exception("There was a problem converting string note into Note");
                }
            }

            return convertedNotes;
        }

        public static Note ConvertSharpNoteToFlat(string note)
        {
            if (note.Length != 2 && note[1] != '#')
                throw new InvalidOperationException("Note must be sharp");

            try
            {
                Note convertedNote = ConvertCharNoteToNoteType(note[0]);

                if ((int) convertedNote >= EnumValuesConverter.GetNotes().Count)
                {
                    convertedNote = (Note) 0;
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
            if (!IsNoteSharpOrFlat(note))
                return note.ToString();

            try
            {
                if (!convertFlatNotes) return note.ToString();

                if (note == Note.Ab)
                    return "G#";

                return note - 1 + "#";
            }
            catch
            {
                throw new Exception("Conversion went wrong");
            }
        }

        private static bool IsNoteSharpOrFlat(Note note)
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
    }
}