using Keyify.Domain.Helper;
using KeyifyClassLibrary.Core.Domain;
using KeyifyClassLibrary.Core.Domain.Enums;
using KeyifyClassLibrary.Core.Domain.Helper;
using Xunit;

namespace Keyify.Unit.Test.Note.UnitTests
{
    public class SharpNoteUnitTest
    {
        [Theory]
        [InlineData(KeyifyClassLibrary.Core.Domain.Enums.Note.Ab, "G#")]
        [InlineData(KeyifyClassLibrary.Core.Domain.Enums.Note.Bb, "A#")]
        [InlineData(KeyifyClassLibrary.Core.Domain.Enums.Note.Db, "C#")]
        [InlineData(KeyifyClassLibrary.Core.Domain.Enums.Note.Eb, "D#")]
        [InlineData(KeyifyClassLibrary.Core.Domain.Enums.Note.Gb, "F#")]
        public void FlatNotesAreConvertedToSharpNotes(KeyifyClassLibrary.Core.Domain.Enums.Note note, string expected)
        {
            var actual = NoteHelper.ConvertNoteToStringEquivalent(note, true);

            Assert.Equal(expected, actual);
        }
        
        [Theory]
        [InlineData(KeyifyClassLibrary.Core.Domain.Enums.Note.A, "A")]
        [InlineData(KeyifyClassLibrary.Core.Domain.Enums.Note.B, "B")]
        [InlineData(KeyifyClassLibrary.Core.Domain.Enums.Note.C, "C")]
        [InlineData(KeyifyClassLibrary.Core.Domain.Enums.Note.D, "D")]
        [InlineData(KeyifyClassLibrary.Core.Domain.Enums.Note.E, "E")]
        [InlineData(KeyifyClassLibrary.Core.Domain.Enums.Note.F, "F")]
        [InlineData(KeyifyClassLibrary.Core.Domain.Enums.Note.G, "G")]
        public void NonFlatNotesAreNotConvertedToSharpNotes(KeyifyClassLibrary.Core.Domain.Enums.Note note, string expected)
        {
            var actual = NoteHelper.ConvertNoteToStringEquivalent(note, true);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AbIonianScaleIsConvertedToAbMajor()
        {
            var scale = new Scale(KeyifyClassLibrary.Core.Domain.Enums.Note.Ab, Mode.Ionian);

            var expected = "G# Major";
            var actual = PentatonicModeHelper.GetScaleColloquialism(scale, true);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DbAeolianScaleIsConvertedToDbMinor()
        {
            var scale = new Scale(KeyifyClassLibrary.Core.Domain.Enums.Note.Db, Mode.Aeolian);

            var expected = "C# Minor";
            var actual = PentatonicModeHelper.GetScaleColloquialism(scale, true);

            Assert.Equal(expected, actual);
        }
    }
}
