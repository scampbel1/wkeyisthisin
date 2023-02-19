using Keyify.MusicTheory.Enums;

namespace Keyify.Services.Formatter.Interfaces
{
    public interface INoteFormatService
    {
        public bool IsSharpOrFlat(Note note);
        public string ConvertNoteToStringEquivalent(Note note, bool convertFlatNoteToSharp = false);
    }
}
