using Keyify.Domain.Helper;
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
            var actual = PentatonicModeHelper.GetModeNameColloquialismLabel(selectedMode);

            Assert.Equal(expected, actual);
        }
        
        [Theory]
        [InlineData(Mode.Aeolian, "Minor")]        
        public void AeolianModeEnumReturnsMinorLabel(Mode selectedMode, string expected)
        {
            var actual = PentatonicModeHelper.GetModeNameColloquialismLabel(selectedMode);

            Assert.Equal(expected, actual);
        }
        
        [Theory]
        [InlineData(Mode.Mixolydian, "")]        
        public void MixolydianModeEnumReturnsEmptyString(Mode selectedMode, string expected)
        {
            var actual = PentatonicModeHelper.GetModeNameColloquialismLabel(selectedMode);

            Assert.Equal(expected, actual);
        }
    }
}