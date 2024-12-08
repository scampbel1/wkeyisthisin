using Keyify.Domain.Tunings.Bass;
using Keyify.MusicTheory.Enums;
using Keyify.Web.Factories;
using Keyify.Web.Models.Instrument;
using KeyifyWebClient.Models.Instruments;
using System;

namespace Keyify.Web.Unit.Test.InstrumentFactoryUnitTests
{
    public class InstrumentFactoryUnitTests
    {
        [Fact]
        public void ExceptionNotThrown()
        {
            var exception = Record.Exception(() => InstrumentFactory.CreateInstrument(InstrumentType.Guitar));

            Assert.Null(exception);
        }

        [Fact]
        public void ThrowsArgumentExceptionOnUndefinedType()
        {
            Assert.Throws<ArgumentException>(() => InstrumentFactory.CreateInstrument((InstrumentType)int.MaxValue));
        }

        [Fact]
        public void GuitarTypeReturnsStandardGuitarSettings()
        {
            var expectedInstrument = new Instrument(instrumentType: InstrumentType.Guitar, tuning: new StandardGuitarTuning(), fretCount: 24);
            var result = InstrumentFactory.CreateInstrument(InstrumentType.Guitar);

            Assert.Multiple(() =>
            {
                Assert.Equal(expectedInstrument.FretCount, result.FretCount);
                Assert.Equal(expectedInstrument.Tuning, result.Tuning);
                Assert.Equal(expectedInstrument.InstrumentType, result.InstrumentType);
            });
        }

        [Fact]
        public void BassTypeReturnsStandardBassSettings()
        {
            var expectedInstrument = new Instrument(instrumentType: InstrumentType.Bass, tuning: new StandardBassTuning(), fretCount: 21);
            var result = InstrumentFactory.CreateInstrument(InstrumentType.Bass);

            Assert.Multiple(() =>
            {
                Assert.Equal(expectedInstrument.FretCount, result.FretCount);
                Assert.Equal(expectedInstrument.Tuning, result.Tuning);
                Assert.Equal(expectedInstrument.InstrumentType, result.InstrumentType);
            });
        }

        [Fact]
        public void UkuleleTypeReturnsStandardUkuleleSettings()
        {
            var expectedInstrument = new Instrument(instrumentType: InstrumentType.Ukulele, tuning: new StandardUkuleleTuning(), fretCount: 13);
            var result = InstrumentFactory.CreateInstrument(InstrumentType.Ukulele);

            Assert.Multiple(() =>
            {
                Assert.Equal(expectedInstrument.FretCount, result.FretCount);
                Assert.Equal(expectedInstrument.Tuning, result.Tuning);
                Assert.Equal(expectedInstrument.InstrumentType, result.InstrumentType);
            });
        }

        [Fact]
        public void MandolinTypeReturnsStandardMandolinSettings()
        {
            var expectedInstrument = new Instrument(instrumentType: InstrumentType.Mandolin, tuning: new StandardMandolinTuning(), fretCount: 20);
            var result = InstrumentFactory.CreateInstrument(InstrumentType.Mandolin);

            Assert.Multiple(() =>
            {
                Assert.Equal(expectedInstrument.FretCount, result.FretCount);
                Assert.Equal(expectedInstrument.Tuning, result.Tuning);
                Assert.Equal(expectedInstrument.InstrumentType, result.InstrumentType);
            });
        }
    }
}
