using KeyifyClassLibrary.Core.Domain;
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
            var actual = ScaleEntry.GetUserFriendlyLabel(dictionaryOutput);

            Assert.Equal(expected, actual);
        }
    }
}