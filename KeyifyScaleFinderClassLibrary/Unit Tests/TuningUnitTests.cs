using System;
using KeyifyScaleFinderClassLibrary.MusicTheory;
using NUnit.Framework;

namespace KeyifyScaleFinderClassLibrary.Unit_Tests
{
    [TestFixture]
    public class TuningUnitTests
    {
        ITuning _tuning;

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
        [Ignore("Alter code to restrict numeric values")]
        public void TestInvalidTuningInputNumbersFails()
        {
            Assert.That(() => new CustomTuning("A123BC"),
                Throws.Exception
                .TypeOf<ArgumentException>());
        }
    }
}
