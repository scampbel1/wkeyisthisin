using Keyify.MusicTheory.Enums;

namespace Keyify.Services.Models
{
    public class ChordTypeDefinition
    {
        public readonly ChordType ChordType;
        public readonly Interval[] Intervals;

        public ChordTypeDefinition(ChordType chordType, Interval[] intervals)
        {
            ChordType = chordType;
            Intervals = intervals;
        }
    }
}
