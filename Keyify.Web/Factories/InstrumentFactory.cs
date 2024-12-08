using Keyify.Domain.Tunings.Bass;
using Keyify.MusicTheory.Enums;
using Keyify.Web.Models.Instrument;
using KeyifyWebClient.Models.Instruments;
using System;

namespace Keyify.Web.Factories
{
    public static class InstrumentFactory
    {
        public static Instrument CreateInstrument(InstrumentType instrumentType)
        {
            return instrumentType switch
            {
                InstrumentType.Guitar => new Instrument(InstrumentType.Guitar, new StandardGuitarTuning(), 24),
                InstrumentType.Bass => new Instrument(InstrumentType.Bass, new StandardBassTuning(), 21),
                InstrumentType.Ukulele => new Instrument(InstrumentType.Ukulele, new StandardUkuleleTuning(), 13),
                InstrumentType.Mandolin => new Instrument(InstrumentType.Mandolin, new StandardMandolinTuning(), 20),
                _ => throw new ArgumentException("Unsupported instrument type", nameof(instrumentType))
            };
        }
    }
}
