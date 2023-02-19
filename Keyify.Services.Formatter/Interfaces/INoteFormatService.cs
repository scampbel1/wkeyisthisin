using Keyify.MusicTheory.Enums;

namespace Keyify.Services.Formatter.Interfaces
{
    public interface INoteFormatService
    {
        public Dictionary<Note, string> SharpNoteDictionary { get; }
    }
}
