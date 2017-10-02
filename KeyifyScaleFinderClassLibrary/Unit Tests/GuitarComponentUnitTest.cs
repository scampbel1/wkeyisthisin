using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarKeyFinder.Unit_Tests
{
    class GuitarComponentUnitTest
    {
        Tuning tuning;

        [SetUp]
        public void Init()
        {
            tuning = new CustomTuning("EADGBE");
        }
        
        [Test]
        public void CorrectNotesPopulatedOnFretboard()
        {
            Assert.AreEqual(
                Fretboard.PopulateFretboard(tuning),
                Fretboard.PopulateFretboard(new StandardTuning())
                );
        }
    }
}
