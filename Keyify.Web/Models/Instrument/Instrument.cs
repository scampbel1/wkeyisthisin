using Keyify.MusicTheory.Enums;
using Keyify.Web.Models.Tunings;

namespace Keyify.Web.Models.Instrument
{
    public record Instrument
    {
        public readonly InstrumentType InstrumentType;
        public readonly Tuning Tuning;
        public readonly int FretCount;

        public Instrument(InstrumentType instrumentType, Tuning tuning, int fretCount)
        {
            InstrumentType = instrumentType;
            Tuning = tuning;
            FretCount = fretCount;
        }
    }
}
