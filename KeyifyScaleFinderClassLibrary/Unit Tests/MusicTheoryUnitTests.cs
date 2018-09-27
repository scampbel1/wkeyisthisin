using System.Collections.Generic;
using KeyifyScaleFinderClassLibrary.MusicTheory;
using NUnit.Framework;

namespace KeyifyScaleFinderClassLibrary.Unit_Tests
{
    [TestFixture]
    public class MusicTheoryUnitTests
    {
        [Test]
        //[ExpectedException(typeof(Exception))] //http://stackoverflow.com/questions/33895457/expectedexception-in-nunit-gave-me-an-error
        // --> Use Throws clause (see link)
        [Ignore("Decide how to implement note management")]
        public void TestExceptionForNoteCount()
        {

        }

        [Test]
        public void CorrectScaleEntryReturned()
        {
            var scale = HeptatonicScaleModeDictionary.GetScaleDirectory(HeptatonicModes.Ionian).Item2;
            var expected = new ScaleStep[]{
                    ScaleStep.R,
                    ScaleStep.W,
                    ScaleStep.W,
                    ScaleStep.h,
                    ScaleStep.W,
                    ScaleStep.W,
                    ScaleStep.W,
                    ScaleStep.h};

            Assert.AreEqual(scale, expected);
        }

        [Test]
        [Ignore("Irrelivant")]
        public void CorrectScaleCountReturned()
        {
            Assert.AreEqual(HeptatonicScaleModeDictionary.ReturnCount(), 7);
        }

        [Test]
        public void MajorScaleGeneratedCorrectlyForEachNoteAndScaleType()
        {
            var scaleSample = ScaleNoteGenerator.GenerateNotes(Note.Db,
                HeptatonicScaleModeDictionary.GetScaleDirectory(HeptatonicModes.Ionian).Item2).Notes;

            var expectedScale = new System.Collections.Generic.List<Note>()
            {
                Note.Db,
                Note.Eb,
                Note.F,
                Note.Gb,
                Note.Ab,
                Note.Bb,
                Note.C,
                Note.Db
            };

            Assert.AreEqual(scaleSample, expectedScale);
        }

        [Test]
        public void MinorScaleGeneratedCorrectlyForEachNoteAndScaleType()
        {
            var scaleSample = ScaleNoteGenerator.GenerateNotes(Note.Bb,
                HeptatonicScaleModeDictionary.GetScaleDirectory(HeptatonicModes.Aeolian).Item2).Notes;

            var expectedScale = new List<Note>()
            {
                Note.Bb,
                Note.C,
                Note.Db,
                Note.Eb,
                Note.F,
                Note.Gb,
                Note.Ab,
                Note.Bb
            };

            Assert.AreEqual(scaleSample, expectedScale);
        }

        [Test]
        public void WikipediaExamplesWorkAgainstScaleLogic()
        {
            #region ExpectedValues
            var expectedIonian = new System.Collections.Generic.List<Note>()
            {
                Note.C,
                Note.D,
                Note.E,
                Note.F,
                Note.G,
                Note.A,
                Note.B,
                Note.C
            };

            var expectedDorian = new System.Collections.Generic.List<Note>()
            {
                Note.D,
                Note.E,
                Note.F,
                Note.G,
                Note.A,
                Note.B,
                Note.C,
                Note.D
            };

            var expectedPhrygian = new System.Collections.Generic.List<Note>()
            {
                Note.E,
                Note.F,
                Note.G,
                Note.A,
                Note.B,
                Note.C,
                Note.D,
                Note.E,
            };

            var expectedLydian = new System.Collections.Generic.List<Note>()
            {
                Note.F,
                Note.G,
                Note.A,
                Note.B,
                Note.C,
                Note.D,
                Note.E,
                Note.F,
            };

            var expectedMixolydian = new System.Collections.Generic.List<Note>()
            {
                Note.G,
                Note.A,
                Note.B,
                Note.C,
                Note.D,
                Note.E,
                Note.F,
                Note.G,
            };

            var expectedAeolian = new System.Collections.Generic.List<Note>()
            {
                Note.A,
                Note.B,
                Note.C,
                Note.D,
                Note.E,
                Note.F,
                Note.G,
                Note.A,
            };

            var expectedLocrian = new System.Collections.Generic.List<Note>()
            {
                Note.B,
                Note.C,
                Note.D,
                Note.E,
                Note.F,
                Note.G,
                Note.A,
                Note.B,
            };

            var expectedLocrianF = new System.Collections.Generic.List<Note>()
            {
                Note.F,
                Note.Gb,
                Note.Ab,
                Note.Bb,
                Note.B,
                Note.Db,
                Note.Eb,
                Note.F,
            };
            #endregion

            Assert.AreEqual(ScaleNoteGenerator.GenerateNotes(Note.C,
                HeptatonicScaleModeDictionary.GetScaleDirectory(HeptatonicModes.Ionian).Item2).Notes, expectedIonian);

            Assert.AreEqual(ScaleNoteGenerator.GenerateNotes(Note.D,
                HeptatonicScaleModeDictionary.GetScaleDirectory(HeptatonicModes.Dorian).Item2).Notes, expectedDorian);

            Assert.AreEqual(ScaleNoteGenerator.GenerateNotes(Note.E,
                HeptatonicScaleModeDictionary.GetScaleDirectory(HeptatonicModes.Phrygian).Item2).Notes, expectedPhrygian);

            Assert.AreEqual(ScaleNoteGenerator.GenerateNotes(Note.F,
                HeptatonicScaleModeDictionary.GetScaleDirectory(HeptatonicModes.Lydian).Item2).Notes, expectedLydian);

            Assert.AreEqual(ScaleNoteGenerator.GenerateNotes(Note.G,
                HeptatonicScaleModeDictionary.GetScaleDirectory(HeptatonicModes.Mixolydian).Item2).Notes, expectedMixolydian);

            Assert.AreEqual(ScaleNoteGenerator.GenerateNotes(Note.A,
                HeptatonicScaleModeDictionary.GetScaleDirectory(HeptatonicModes.Aeolian).Item2).Notes, expectedAeolian);
            
            Assert.AreEqual(ScaleNoteGenerator.GenerateNotes(Note.B,
                HeptatonicScaleModeDictionary.GetScaleDirectory(HeptatonicModes.Locrian).Item2).Notes, expectedLocrian);

            Assert.AreEqual(ScaleNoteGenerator.GenerateNotes(Note.F,
                HeptatonicScaleModeDictionary.GetScaleDirectory(HeptatonicModes.Locrian).Item2).Notes, expectedLocrianF);
        }

        [Test]
        [Ignore("Irrelivant")]
        public void ScaleDictionaryCountIsCorrect()
        {
            Assert.AreEqual(ScaleDictionary.GenerateDictionary().Count, 84);
        }

        [Test]
        public void AbCandFMatchesMoreThanTenScales()
        {
            var results = ScaleMatcher.GetMatchedScales(
                new Note[] { Note.Ab, Note.C, Note.F },
                0
                );

            Assert.True(results.Count > 10);
        }

        [Test]
        public void AdgbbFMatchesMoreThanTenScales()
        {
            var results = ScaleMatcher.GetMatchedScales(
                new Note[] { Note.A, Note.D, Note.G, Note.Bb, Note.F },
                0
                );

            Assert.True(results.Count > 10);
        }

        [Test]
        [Ignore("Irrelivant")]
        public void HandlesArrayWithRepeatingNote()
        {
            var results = ScaleMatcher.GetMatchedScales(
                new Note[] { Note.A, Note.A, Note.A, Note.D, Note.D, Note.G, Note.Bb, Note.F },
                0
                );

            Assert.AreEqual(results.Count, 14);
        }

        [Test]
        public void ReturnsCorrectUnconvertedChords()
        {
            var testTriad = new Triad();

            Assert.AreEqual(testTriad.GenerateChords(HeptatonicModes.Ionian, Note.C), new List<string>() { "C", "Dm", "Em", "F", "G", "Am", "Bo" });
            Assert.AreEqual(testTriad.GenerateChords(HeptatonicModes.Lydian, Note.Bb), new List<string>() { "Bb", "C", "Dm", "Eo", "F", "Gm", "Am" });
            Assert.AreEqual(testTriad.GenerateChords(HeptatonicModes.Locrian, Note.F), new List<string>() { "Fo", "Gb", "Abm", "Bbm", "B", "Db", "Ebm" });
            Assert.AreEqual(testTriad.GenerateChords(HeptatonicModes.Locrian, Note.D), new List<string>() { "Do", "Eb", "Fm", "Gm", "Ab", "Bb", "Cm" });
            Assert.AreEqual(testTriad.GenerateChords(HeptatonicModes.Mixolydian, Note.A), new List<string>() { "A", "Bm", "Dbo", "D", "Em", "Gbm", "G" });
            Assert.AreEqual(testTriad.GenerateChords(HeptatonicModes.Phrygian, Note.E), new List<string>() { "Em", "F", "G", "Am", "Bo", "C", "Dm" });
            Assert.AreEqual(testTriad.GenerateChords(HeptatonicModes.Dorian, Note.B), new List<string>() { "Bm", "Dbm", "D", "E", "Gbm", "Abo", "A" });
            Assert.AreEqual(testTriad.GenerateChords(HeptatonicModes.Aeolian, Note.G), new List<string>() { "Gm", "Ao", "Bb", "Cm", "Dm", "Eb", "F" });
        }

        [Test]
        public void ModeDescriptionReturnsCorrectScale()
        {
            var expectedMixolydian = new System.Collections.Generic.List<Note>()
            {
                Note.G,
                Note.A,
                Note.B,
                Note.C,
                Note.D,
                Note.E,
                Note.F,
                Note.G,
            };

            Assert.AreEqual(
                ScaleDictionary.GenerateEntryFromString("G Mixolydian").Item2.Notes,
                expectedMixolydian);
        }
    }
}
