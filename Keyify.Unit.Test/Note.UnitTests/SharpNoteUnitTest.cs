using Keyify.Models.Service;
using KeyifyClassLibrary.Enums;
using KeyifyClassLibrary.Helper;
using KeyifyClassLibrary.Models.MusicTheory;
using KeyifyClassLibrary.Service_Models;

namespace Keyify.Unit.Test.Note.UnitTests
{
    public class SharpNoteUnitTest
    {
        [Theory]
        [InlineData(KeyifyClassLibrary.Enums.Note.Ab, "G#")]
        [InlineData(KeyifyClassLibrary.Enums.Note.Bb, "A#")]
        [InlineData(KeyifyClassLibrary.Enums.Note.Db, "C#")]
        [InlineData(KeyifyClassLibrary.Enums.Note.Eb, "D#")]
        [InlineData(KeyifyClassLibrary.Enums.Note.Gb, "F#")]
        public void FlatNotesAreConvertedToSharpNotes(KeyifyClassLibrary.Enums.Note note, string expected)
        {
            var actual = NoteHelper.ConvertNoteToStringEquivalent(note, true);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(KeyifyClassLibrary.Enums.Note.A, "A")]
        [InlineData(KeyifyClassLibrary.Enums.Note.B, "B")]
        [InlineData(KeyifyClassLibrary.Enums.Note.C, "C")]
        [InlineData(KeyifyClassLibrary.Enums.Note.D, "D")]
        [InlineData(KeyifyClassLibrary.Enums.Note.E, "E")]
        [InlineData(KeyifyClassLibrary.Enums.Note.F, "F")]
        [InlineData(KeyifyClassLibrary.Enums.Note.G, "G")]
        public void NonFlatNotesAreNotConvertedToSharpNotes(KeyifyClassLibrary.Enums.Note note, string expected)
        {
            var actual = NoteHelper.ConvertNoteToStringEquivalent(note, true);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AbIonianScaleIsConvertedToAbMajor()
        {
            var generatedScale = new GeneratedScale(KeyifyClassLibrary.Enums.Note.Ab, new ModeDefinition(Mode.Ionian, new Interval[] {
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

            var expected = "G# Major";
            var actual = scaleEntry.ColloquialNameLabel_Sharp;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DbAeolianScaleIsConvertedToDbMinor()
        {
            var generatedScale = new GeneratedScale(KeyifyClassLibrary.Enums.Note.Db, new ModeDefinition(Mode.Aeolian, new Interval[] {
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

            var expected = "C# Minor";
            var actual = scaleEntry.ColloquialNameLabel_Sharp;

            Assert.Equal(expected, actual);
        }
    }
}