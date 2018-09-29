using KeyifyScaleFinderClassLibrary.MusicTheory.Enums;
using KeyifyScaleFinderClassLibrary.MusicTheory.Tuning;
using NUnit.Framework;

namespace KeyifyScaleFinderClassLibrary.Unit_Tests
{
    [TestFixture]
    public class TuningUnitTests
    {
        private ITuning _tuning;
        private Note[] _standardTuning;

        [SetUp]
        public void Init()
        {
            _tuning = new StandardTuning();
            _standardTuning = new Note[]
            {
                Note.E,
                Note.A,
                Note.D,
                Note.G,
                Note.B,
                Note.E
            };
        }

        [Test]
        public void StandardTuningIsCorrect()
        {
            Assert.AreEqual(
                _tuning.ReturnNotes(),
                _standardTuning);
        }
    }
}
