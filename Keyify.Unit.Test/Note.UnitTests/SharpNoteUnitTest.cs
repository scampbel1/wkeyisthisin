using Keyify.Helper;
using Keyify.Models.Service;
using KeyifyClassLibrary.Enums;
using KeyifyClassLibrary.Helper;
using KeyifyClassLibrary.Models.MusicTheory;
using Xunit;

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
            var scale = new Scale(KeyifyClassLibrary.Enums.Note.Ab, new ModeDefinition(Mode.Ionian, new Step[] {
                    Step.R,
                    Step.W,
                    Step.W,
                    Step.h,
                    Step.W,
                    Step.W,
                    Step.W,
                    Step.h
                }, new string[] { }));

            var expected = "G# Major";
            var actual = PentatonicModeHelper.GetScaleColloquialism(scale, true);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DbAeolianScaleIsConvertedToDbMinor()
        {
            var scale = new Scale(KeyifyClassLibrary.Enums.Note.Db, new ModeDefinition(Mode.Aeolian, new Step[] {
                    Step.R,
                    Step.W,
                    Step.h,
                    Step.W,
                    Step.W,
                    Step.h,
                    Step.W,
                    Step.W
                }, new string[] { }));

            var expected = "C# Minor";
            var actual = PentatonicModeHelper.GetScaleColloquialism(scale, true);

            Assert.Equal(expected, actual);
        }
    }
}