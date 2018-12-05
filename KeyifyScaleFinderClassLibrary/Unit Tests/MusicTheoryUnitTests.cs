using System.Collections.Generic;
using System.Linq;
using KeyifyScaleFinderClassLibrary.MusicTheory;
using KeyifyScaleFinderClassLibrary.MusicTheory.Enums;
using KeyifyScaleFinderClassLibrary.MusicTheory.Helper;
using NUnit.Framework;

namespace KeyifyScaleFinderClassLibrary.Unit_Tests
{
    [TestFixture]
    public class MusicTheoryUnitTests
    {
        [Test]
        public void CorrectScaleEntryReturned()
        {
            var scale = HeptatonicScaleModeDictionary.GetScaleDirectory(HeptatonicMode.Ionian).ScaleSteps;
            var expected = new ScaleStep[]
            {
                ScaleStep.R,
                ScaleStep.W,
                ScaleStep.W,
                ScaleStep.h,
                ScaleStep.W,
                ScaleStep.W,
                ScaleStep.W,
                ScaleStep.h
            };

            Assert.AreEqual(scale, expected);
        }

        [Test]
        public void MajorScaleGeneratedCorrectlyForEachNoteAndScaleType()
        {
            var scaleSample = ScaleNoteGenerator.GenerateNotes(Note.Db,
                HeptatonicScaleModeDictionary.GetScaleDirectory(HeptatonicMode.Ionian).ScaleSteps).Notes;

            var expectedScale = new List<Note>()
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
                HeptatonicScaleModeDictionary.GetScaleDirectory(HeptatonicMode.Aeolian).ScaleSteps).Notes;

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
                    HeptatonicScaleModeDictionary.GetScaleDirectory(HeptatonicMode.Ionian).ScaleSteps).Notes,
                expectedIonian);

            Assert.AreEqual(ScaleNoteGenerator.GenerateNotes(Note.D,
                    HeptatonicScaleModeDictionary.GetScaleDirectory(HeptatonicMode.Dorian).ScaleSteps).Notes,
                expectedDorian);

            Assert.AreEqual(ScaleNoteGenerator.GenerateNotes(Note.E,
                    HeptatonicScaleModeDictionary.GetScaleDirectory(HeptatonicMode.Phrygian).ScaleSteps).Notes,
                expectedPhrygian);

            Assert.AreEqual(ScaleNoteGenerator.GenerateNotes(Note.F,
                    HeptatonicScaleModeDictionary.GetScaleDirectory(HeptatonicMode.Lydian).ScaleSteps).Notes,
                expectedLydian);

            Assert.AreEqual(ScaleNoteGenerator.GenerateNotes(Note.G,
                    HeptatonicScaleModeDictionary.GetScaleDirectory(HeptatonicMode.Mixolydian).ScaleSteps).Notes,
                expectedMixolydian);

            Assert.AreEqual(ScaleNoteGenerator.GenerateNotes(Note.A,
                    HeptatonicScaleModeDictionary.GetScaleDirectory(HeptatonicMode.Aeolian).ScaleSteps).Notes,
                expectedAeolian);

            Assert.AreEqual(ScaleNoteGenerator.GenerateNotes(Note.B,
                    HeptatonicScaleModeDictionary.GetScaleDirectory(HeptatonicMode.Locrian).ScaleSteps).Notes,
                expectedLocrian);

            Assert.AreEqual(ScaleNoteGenerator.GenerateNotes(Note.F,
                    HeptatonicScaleModeDictionary.GetScaleDirectory(HeptatonicMode.Locrian).ScaleSteps).Notes,
                expectedLocrianF);
        }

        [Test]
        public void AbCandFMatchesMoreThanTenScales()
        {
            var results = ScaleMatcher.GetMatchedScales(
                new Note[] {Note.Ab, Note.C, Note.F}
            );

            Assert.True(results.Count > 10);
        }

        [Test]
        public void AdgbbFMatchesMoreThanTenScales()
        {
            var results = ScaleMatcher.GetMatchedScales(
                new Note[] {Note.A, Note.D, Note.G, Note.Bb, Note.F}
            );

            Assert.True(results.Count > 10);
        }

        [Test]
        public void DbEbFgbAbBbCMatchesAnyScale()
        {
            var results = ScaleMatcher.GetMatchedScales(
                new Note[]
                {
                    Note.Db,
                    Note.Eb,
                    Note.F,
                    Note.Gb,
                    Note.Ab,
                    Note.Bb,
                    Note.C
                }
            );

            Assert.True(results.Any());
        }

        [Test]
        public void DbEbGbMatchesAnyScale()
        {
            var results = ScaleMatcher.GetMatchedScales(
                new Note[]
                {
                    Note.Db,
                    Note.Eb,
                    Note.Gb
                }
            );

            Assert.True(results.Any());
        }

        [Test]
        public void ReturnsCorrectUnconvertedChords()
        {
            var testTriad = new ChordGroupingFactory();

            Assert.AreEqual(testTriad.GenerateChords(HeptatonicMode.Ionian, Note.C),
                new List<string>() {"C", "Dm", "Em", "F", "G", "Am", "Bo"});
            Assert.AreEqual(testTriad.GenerateChords(HeptatonicMode.Lydian, Note.Bb),
                new List<string>() {"Bb", "C", "Dm", "Eo", "F", "Gm", "Am"});
            Assert.AreEqual(testTriad.GenerateChords(HeptatonicMode.Locrian, Note.F),
                new List<string>() {"Fo", "Gb", "Abm", "Bbm", "B", "Db", "Ebm"});
            Assert.AreEqual(testTriad.GenerateChords(HeptatonicMode.Locrian, Note.D),
                new List<string>() {"Do", "Eb", "Fm", "Gm", "Ab", "Bb", "Cm"});
            Assert.AreEqual(testTriad.GenerateChords(HeptatonicMode.Mixolydian, Note.A),
                new List<string>() {"A", "Bm", "Dbo", "D", "Em", "Gbm", "G"});
            Assert.AreEqual(testTriad.GenerateChords(HeptatonicMode.Phrygian, Note.E),
                new List<string>() {"Em", "F", "G", "Am", "Bo", "C", "Dm"});
            Assert.AreEqual(testTriad.GenerateChords(HeptatonicMode.Dorian, Note.B),
                new List<string>() {"Bm", "Dbm", "D", "E", "Gbm", "Abo", "A"});
            Assert.AreEqual(testTriad.GenerateChords(HeptatonicMode.Aeolian, Note.G),
                new List<string>() {"Gm", "Ao", "Bb", "Cm", "Dm", "Eb", "F"});
        }

        [Test]
        public void ModeDescriptionReturnsCorrectScale()
        {
            var expectedMixolydian = new List<Note>()
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
                ScaleDictionary.GenerateEntryFromString("G Mixolydian").Scale.Notes,
                expectedMixolydian);
        }

        [Test]
        public void CsharpIsConvertedCorrectlyToDflat()
        {
            const string note = "C#";
            Note conversion = KeyifyElementStringConverter.ConvertSharpNoteToFlat(note);

            Assert.AreEqual(Note.Db, conversion);
        }

        [Test]
        public void GsharpIsConvertedCorrectlyToAflat()
        {
            const string note = "G#";
            Note conversion = KeyifyElementStringConverter.ConvertSharpNoteToFlat(note);

            Assert.AreEqual(Note.Ab, conversion);
        }

        [Test]
        public void NoteIsConvertedToString()
        {
            Note note = Note.Eb;
            string conversion = KeyifyElementStringConverter.ConvertNoteToStringEquivalent(note);

            Assert.AreEqual("Eb", conversion);
        }

        [Test]
        public void FlatNoteIsConvertedToSharpString()
        {
            Note note = Note.Eb;
            string conversion = KeyifyElementStringConverter.ConvertNoteToStringEquivalent(note);

            Assert.AreEqual("Eb", conversion);
        }

        [Test]
        public void AflatIsConvertedToGSharp()
        {
            Note note = Note.Ab;
            const string expected = "G#";

            string conversion = KeyifyElementStringConverter.ConvertNoteToStringEquivalent(note, true);

            Assert.AreEqual(expected, conversion);
        }

        [Test]
        public void BflatIsConvertedToASharp()
        {
            Note note = Note.Bb;
            const string expected = "A#";

            string conversion = KeyifyElementStringConverter.ConvertNoteToStringEquivalent(note, true);

            Assert.AreEqual(expected, conversion);
        }

        [Test]
        public void DflatIsConvertedToCSharp()
        {
            Note note = Note.Db;
            const string expected = "C#";

            string conversion = KeyifyElementStringConverter.ConvertNoteToStringEquivalent(note, true);

            Assert.AreEqual(expected, conversion);
        }

        [Test]
        public void EflatIsConvertedToDSharp()
        {
            Note note = Note.Eb;
            const string expected = "D#";

            string conversion = KeyifyElementStringConverter.ConvertNoteToStringEquivalent(note, true);

            Assert.AreEqual(expected, conversion);
        }

        [Test]
        public void GflatIsConvertedToFSharp()
        {
            Note note = Note.Gb;
            const string expected = "F#";

            string conversion = KeyifyElementStringConverter.ConvertNoteToStringEquivalent(note, true);

            Assert.AreEqual(expected, conversion);
        }
    }
}