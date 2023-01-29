using Keyify.Enums;
using KeyifyClassLibrary.Enums;

namespace Keyify.Models.Service_Models
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
