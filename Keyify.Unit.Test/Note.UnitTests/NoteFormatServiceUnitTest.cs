using Keyify.MusicTheory.Enums;
using Keyify.Services.Formatter.Interfaces;
using Keyify.Services.Formatter.Services;
using Keyify.Services.Models;
using System.Collections.Generic;

namespace Keyify.Unit.Test.Note.UnitTests
{
    public class NoteFormatServiceUnitTest
    {
        private readonly INoteFormatService _noteFormatService;

        public NoteFormatServiceUnitTest()
        {
            _noteFormatService = new NoteFormatService();
        }

        [Theory]
        [InlineData(MusicTheory.Enums.Note.Ab, "G#")]
        [InlineData(MusicTheory.Enums.Note.Bb, "A#")]
        [InlineData(MusicTheory.Enums.Note.Db, "C#")]
        [InlineData(MusicTheory.Enums.Note.Eb, "D#")]
        [InlineData(MusicTheory.Enums.Note.Gb, "F#")]
        public void FlatNotesAreConvertedToSharpNotes(MusicTheory.Enums.Note note, string expected)
        {
            var actual = _noteFormatService.SharpNoteDictionary[note];

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(MusicTheory.Enums.Note.A, "A")]
        [InlineData(MusicTheory.Enums.Note.B, "B")]
        [InlineData(MusicTheory.Enums.Note.C, "C")]
        [InlineData(MusicTheory.Enums.Note.D, "D")]
        [InlineData(MusicTheory.Enums.Note.E, "E")]
        [InlineData(MusicTheory.Enums.Note.F, "F")]
        [InlineData(MusicTheory.Enums.Note.G, "G")]
        public void NonFlatNotesAreNotConvertedToSharpNotes(MusicTheory.Enums.Note note, string expected)
        {
            var actual = _noteFormatService.SharpNoteDictionary[note];

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AbIonianGeneratedScaleIsConvertedToGSharpMajorScaleEntry()
        {
            var rootNote = MusicTheory.Enums.Note.Db;
            var sharpRootNote = "G#";
            var notes = new List<MusicTheory.Enums.Note>();
            var sharpNotes = new List<string>();
            var mode = Mode.Ionian;
            var scaleDegrees = new string[6];

            var generatedScale = new GeneratedScale(rootNote, sharpRootNote, notes, sharpNotes, mode, scaleDegrees);
            var scaleEntry = new ScaleEntry(generatedScale);

            var expected = "G# Major";
            var actual = scaleEntry.ColloquialNameLabel_Sharp;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DbAeolianGeneratedScaleIsConvertedToCSharpMinorScaleEntry()
        {
            var rootNote = MusicTheory.Enums.Note.Db;
            var sharpRootNote = "C#";
            var notes = new List<MusicTheory.Enums.Note>();
            var sharpNotes = new List<string>();
            var mode = Mode.Aeolian;
            var scaleDegrees = new string[6];

            var generatedScale = new GeneratedScale(rootNote, sharpRootNote, notes, sharpNotes, mode, scaleDegrees);
            var scaleEntry = new ScaleEntry(generatedScale);

            var expected = "C# Minor";
            var actual = scaleEntry.ColloquialNameLabel_Sharp;

            Assert.Equal(expected, actual);
        }
    }
}