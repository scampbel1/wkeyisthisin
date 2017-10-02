using System;
using NUnit.Framework;

namespace GuitarKeyFinder.Unit_Tests
{
    [TestFixture]
    class TuningUnitTests
    {
        Tuning tuning;

        [SetUp]
        public void Init()
        {
            tuning = new StandardTuning();
        }

        [Test]
        public void StandardTuningIsCorrect()
        {
            Assert.AreEqual(
                tuning.ReturnNotes(),
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
