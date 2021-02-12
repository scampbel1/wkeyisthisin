using KeyifyClassLibrary.Core.Domain.Helper;
using Xunit;

namespace ScaleDictionaryTests
{
    public class UserFriendlyStringUnitTest
    {
        [Theory]
        [InlineData("Eb WholeHalfDiminished", "Eb Whole Half Diminished")]
        [InlineData("BMix", "B Mix")]
        [InlineData("AbMix", "Ab Mix")]
        public void DictionaryEntryLabelReturnsUserFriendlyString(string dictionaryOutput, string expected)
        {
            var actual = ScaleDictionaryHelper.GetUserFriendlyLabel(dictionaryOutput);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("B Mix", "B Mix")]
        [InlineData("Ab Mix", "Ab Mix")]
        [InlineData("Eb Whole Half Diminished", "Eb WholeHalfDiminished")]
        public void UserFriendlyStringReturnDictionaryEntryLabel(string dictionaryOutput, string expected)
        {
            var actual = ScaleDictionaryHelper.ConvertUserFriendlyLabelIntoLabel(dictionaryOutput);

            Assert.Equal(expected, actual);
        }
    }
}