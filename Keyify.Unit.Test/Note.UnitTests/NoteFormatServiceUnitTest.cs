using Keyify.MusicTheory.Enums;
using Keyify.Services.Formatter.Interfaces;
using Keyify.Services.Formatter.Services;
using Keyify.Services.Models;

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
            var actual = _noteFormatService.ConvertNoteToStringEquivalent(note, true);

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
            var actual = _noteFormatService.ConvertNoteToStringEquivalent(note, true);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AbIonianGeneratedScaleIsConvertedToGSharpMajorScaleEntry()
        {
            var generatedScale = new GeneratedScale(MusicTheory.Enums.Note.Ab, new ModeDefinition(Mode.Ionian, new Interval[] {
                    Interval.R,
                    Interval.W,
                    Interval.W,
                    Interval.h,
                    Interval.W,
                    Interval.W,
                    Interval.W,
                    Interval.h
                },
                new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.Third,
                     Degree.Fourth,
                     Degree.Fifth,
                     Degree.Sixth,
                     Degree.Seventh,
                     Degree.Eighth
                }));

            var scaleEntry = new ScaleEntry(generatedScale);

            //TODO: Fix this test

            var expected = "G# Major";
            var actual = scaleEntry.ColloquialNameLabel_Sharp;

            //Assert.Equal(expected, actual);
        }

        [Fact]
        public void DbAeolianGeneratedScaleIsConvertedToCSharpMinorScaleEntry()
        {
            var generatedScale = new GeneratedScale(MusicTheory.Enums.Note.Db, new ModeDefinition(Mode.Aeolian, new Interval[] {
                    Interval.R,
                    Interval.W,
                    Interval.h,
                    Interval.W,
                    Interval.W,
                    Interval.h,
                    Interval.W,
                    Interval.W
                },
                new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.FlatThird,
                     Degree.Fourth,
                     Degree.Fifth,
                     Degree.FlatSixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                }));

            var scaleEntry = new ScaleEntry(generatedScale);

            //TODO: Fix this test

            var expected = "C# Minor";
            var actual = scaleEntry.ColloquialNameLabel_Sharp;

            //Assert.Equal(expected, actual);
        }
    }
}