using Keyify.MusicTheory.Enums;
using Keyify.Web.Models.QuickLink;

namespace Keyify.Web.Unit.Test.QuickLinkTest.UnitTests
{
    public class QuickLinkUnitTest
    {
        [Fact]
        public void QuickLinkInstrumentName_StringConvertedFromEnum_IsExpectedValue()
        {
            //Arrange - Given
            var expected = "Guitar";

            //Act - When
            var quickLink1 = new QuickLink()
            {
                InstrumentType = InstrumentType.Guitar,
                Tuning = [Note.E, Note.A, Note.D, Note.G, Note.B, Note.E],
                SelectedNotes = [Note.A, Note.E, Note.Gb],
                SelectedScale = "GbAeolian"
            };

            //Assert - Then
            Assert.Equal(expected, quickLink1.InstrumentType.ToString());
        }
    }
}
