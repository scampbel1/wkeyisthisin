using KeyifyScaleFinderClassLibrary.Instrument;
using KeyifyScaleFinderClassLibrary.MusicTheory.Enums;
using KeyifyScaleFinderClassLibrary.MusicTheory.Tuning;
using KeyifyScaleFinderClassLibrary.MusicTheory.Tuning.Guitar;
using NUnit.Framework;

namespace KeyifyScaleFinderClassLibrary.Unit_Tests
{
    public class GuitarComponentUnitTest
    {
        private ITuning _tuning;

        [SetUp]
        public void Init()
        {
            _tuning = new CustomGuitarTuning(new[]
            {
                Note.E,
                Note.A,
                Note.D,
                Note.G,
                Note.B,
                Note.E
            });
        }
        
        [Test]
        public void CorrectNotesPopulatedOnFretboard()
        {
            Assert.AreEqual(
                Fretboard.PopulateFretboard(_tuning),
                Fretboard.PopulateFretboard(new StandardGuitarTuning()));
        }
    }
}
