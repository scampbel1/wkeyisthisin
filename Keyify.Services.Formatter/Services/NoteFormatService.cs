using Keyify.MusicTheory.Enums;
using Keyify.Services.Formatter.Interfaces;

namespace Keyify.Services.Formatter.Services
{
    public class NoteFormatService : INoteFormatService
    {
        public Dictionary<Note, string> SharpNoteDictionary => GenerateSharpNoteDictionary();

        private Dictionary<Note, string> GenerateSharpNoteDictionary()
        {
            var sharpNotes = new Dictionary<Note, string>((int)Note.Ab + 1);

            foreach (var note in Enum.GetValues(typeof(Note)).Cast<Note>())
            {
                var sharpNote = MapNoteToString(note);

                sharpNotes.Add(note, sharpNote);
            }

            return sharpNotes;
        }

        private string MapNoteToString(Note note)
        {
            switch (note)
            {
                case Note.A:
                    return Note.A.ToString();
                case Note.Bb:
                    return "A#";
                case Note.B:
                    return Note.B.ToString();
                case Note.C:
                    return Note.C.ToString();
                case Note.Db:
                    return "C#";
                case Note.D:
                    return Note.D.ToString();
                case Note.Eb:
                    return "D#";
                case Note.E:
                    return Note.E.ToString();
                case Note.F:
                    return Note.F.ToString();
                case Note.Gb:
                    return "F#";
                case Note.G:
                    return Note.G.ToString();
                case Note.Ab:
                    return "G#";
                default:
                    throw new ArgumentException($"Note with value '{note}' was not found and could not be mapped.");
            }
        }
    }
}
