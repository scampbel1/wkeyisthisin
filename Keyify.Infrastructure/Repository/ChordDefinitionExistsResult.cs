using Keyify.MusicTheory.Enums;

namespace Keyify.Infrastructure.Repository
{
    public class ChordDefinitionExistsResult
    {
        public bool Found { get; set; }
        public string? Message { get; set; }
        public Interval[]? Intervals { get; set; }
        public byte[]? Bytes { get; set; }

        public ChordDefinitionExistsResult(bool found, string message)
        {
            Found = found;
            Message = message;
        }

        public ChordDefinitionExistsResult(bool found, string message, Interval[] intervals, byte[] bytes) : this(found, message)
        {
            Intervals = intervals;
            Bytes = bytes;
        }
    }
}
