using Keyify.Web.Enums;
using Keyify.Web.Enums.Tuning;
using Keyify.Web.Models.QuickLink;
using KeyifyClassLibrary.Enums;
using Xunit;

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
                Tuning = GuitarTuning.Standard,
                SelectedNotes = new Note[] { Note.A, Note.E, Note.Gb },
                SelectedScale = "GbAeolian"
            };

            //Assert - Then
            Assert.Equal(expected, quickLink1.InstrumentName);
        }
    }
}
