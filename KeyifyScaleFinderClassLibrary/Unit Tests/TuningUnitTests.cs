using System;
using KeyifyScaleFinderClassLibrary.MusicTheory;
using KeyifyScaleFinderClassLibrary.MusicTheory.Tuning;
using NUnit.Framework;

namespace KeyifyScaleFinderClassLibrary.Unit_Tests
{
    [TestFixture]
    public class TuningUnitTests
    {
        private ITuning _tuning;

        [SetUp]
        public void Init()
        {
            _tuning = new StandardTuning();
        }

        [Test]
        public void StandardTuningIsCorrect()
        {
            Assert.AreEqual(
                _tuning.ReturnNotes(),
                new Note[]
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
        public void InvalidTuningInputLettersFails()
        {
            Assert.That(() => new CustomTuning("ABCDEZ"),
                Throws.Exception
                .TypeOf<ArgumentException>());
        }

        [Test]
        public void TestInvalidTuningInputNumbersFails()
        {
            Assert.That(() => new CustomTuning("A123BC"),
                Throws.Exception
                .TypeOf<ArgumentException>());
        }

        [Test]
        public void TestTuningWithFlats()
        {
            Assert.That(() => new CustomTuning("AbAbAbAbAbAb"),
                Throws.Exception);
        }
    }
}
