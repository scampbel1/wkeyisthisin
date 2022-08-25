using Keyify.Models.Service;
using Xunit;

namespace ScaleDictionaryTests
{
    public class UserReadableStringUnitTest
    {
        [Theory]
        [InlineData("Eb WholeHalfDiminished", "Eb Whole Half Diminished")]
        [InlineData("BMix", "B Mix")]
        [InlineData("AbMix", "Ab Mix")]
        public void DictionaryEntryLabelReturnsUserReadableString(string dictionaryOutput, string expected)
        {
            var actual = ScaleEntry.GetUserFriendlyLabel(dictionaryOutput);

            Assert.Equal(expected, actual);
        }
    }
}