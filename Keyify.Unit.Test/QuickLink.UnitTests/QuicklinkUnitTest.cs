using Keyify.Web.Enums;
using Keyify.Web.Enums.Tuning;
using Keyify.Web.Models.QuickLink;
using KeyifyClassLibrary.Enums;
using Xunit;

namespace Keyify.Web.Unit.Test.QuickLink.UnitTests
{
    public class QuicklinkUnitTest
    {
        [Fact]
        public void QuickLinkParameters_NotesSameButDifferentOrder_Base64StringsAreEqual()
        {
            //Arrange - Given
            var quickLinkParameters1 = new QuickLinkParameters
            {
                InstrumentType = InstrumentType.Guitar,
                Tuning = GuitarTuning.Standard,
                SelectedNotes = new Note[] { Note.A, Note.E, Note.Gb },
                SelectedScale = "GbAeolian"
            };

            var quickLinkParameters2 = new QuickLinkParameters
            {
                InstrumentType = InstrumentType.Guitar,
                Tuning = GuitarTuning.Standard,
                SelectedNotes = new Note[] { Note.E, Note.A, Note.Gb },
                SelectedScale = "GbAeolian"
            };

            //Act - When
            var parameterBase64Representation1 = quickLinkParameters1.Base64;
            var parameterBase64Representation2 = quickLinkParameters2.Base64;

            //Assert - Then
            Assert.Equal(parameterBase64Representation1, parameterBase64Representation2);
        }

        [Fact(Skip = "Not yet implemented")]
        public void CreateBase64StringFromParams_DeserializeBase64String_SameParametersValuesReturned()
        {

        }
    }
}