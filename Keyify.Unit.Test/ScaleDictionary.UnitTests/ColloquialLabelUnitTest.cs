using Keyify.Domain.Helper;
using KeyifyClassLibrary.Core.Domain;
using KeyifyClassLibrary.Core.Domain.Enums;
using Xunit;

namespace ScaleDictionaryTests
{
    public class ColloquialLabelUnitTest
    {
        [Theory]
        [InlineData(Mode.Ionian, "Major")]        
        public void IonianModeEnumReturnsMajorLabel(Mode selectedMode, string expected)
        {
            var actual = PentatonicModeHelper.GetModeNameColloquialismModeLabel(selectedMode);

            Assert.Equal(expected, actual);
        }
        
        [Theory]
        [InlineData(Mode.Aeolian, "Minor")]        
        public void AeolianModeEnumReturnsMinorLabel(Mode selectedMode, string expected)
        {
            var actual = PentatonicModeHelper.GetModeNameColloquialismModeLabel(selectedMode);

            Assert.Equal(expected, actual);
        }
        
        [Theory]
        [InlineData(Mode.Mixolydian, "")]        
        public void MixolydianModeEnumReturnsEmptyString(Mode selectedMode, string expected)
        {
            var actual = PentatonicModeHelper.GetModeNameColloquialismModeLabel(selectedMode);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AbIonianScaleIsConvertedToAbMajor()
        {
            var scale = new Scale(Note.Ab);

            var expected = "Ab Major";
            var actual = PentatonicModeHelper.GetScaleColloquialism(Mode.Ionian, scale);

            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void DbAeolianScaleIsConvertedToDbMinor()
        {
            var scale = new Scale(Note.Db);

            var expected = "Db Minor";
            var actual = PentatonicModeHelper.GetScaleColloquialism(Mode.Aeolian, scale);

            Assert.Equal(expected, actual);
        }
    }
}