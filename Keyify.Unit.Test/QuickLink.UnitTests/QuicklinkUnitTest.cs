using Keyify.Web.Enums;
using Keyify.Web.Enums.Tuning;
using Keyify.Web.Models.QuickLink;
using KeyifyClassLibrary.Enums;
using System;
using System.Text;
using System.Text.Json;
using Xunit;

namespace Keyify.Web.Unit.Test.QuickLink.UnitTests
{
    public class QuicklinkUnitTest
    {
        [Fact]
        public void QuickLinkParameters_NotesSameButDifferentOrder_ObjectsAreEqual()
        {
            //Arrange - Given
            var quickLinkParameters1 = new QuickLinkParameters
            {
                InstrumentType = InstrumentType.Guitar,
                Tuning = GuitarTuning.Standard,
                SelectedNotes = new Note[] { Note.A, Note.E, Note.Gb },
                SelectedScale = "GbAeolian"
            };

            //Act - When
            var quickLinkParameters2 = new QuickLinkParameters
            {
                InstrumentType = InstrumentType.Guitar,
                Tuning = GuitarTuning.Standard,
                SelectedNotes = new Note[] { Note.E, Note.A, Note.Gb },
                SelectedScale = "GbAeolian"
            };

            //Assert - Then
            Assert.Equal(quickLinkParameters1, quickLinkParameters2);
        }

        [Fact]
        public void CreateBase64StringFromQuickLinkParameters_CreateCopyFromBase64String_SameParametersValuesReturned()
        {
            //Arrange - Given
            var expectedQuickLink = new QuickLinkParameters
            {
                InstrumentType = InstrumentType.Guitar,
                Tuning = GuitarTuning.Standard,
                SelectedNotes = new Note[] { Note.A, Note.E, Note.Gb },
                SelectedScale = "GbAeolian"
            };

            var base64String = GenerateBase64(expectedQuickLink);

            //Act - When
            var result = new QuickLinkParameters(base64String);

            //Assert - Then
            Assert.Equal(expectedQuickLink, result);
        }

        //TODO: Move this elsewhere
        private string GenerateBase64(QuickLinkParameters quickLinkParameters)
        {
            var quickLinkParameterJson = JsonSerializer.Serialize(quickLinkParameters);
            var quickLinkParameterBytes = Encoding.Default.GetBytes(quickLinkParameterJson);

            return Convert.ToBase64String(quickLinkParameterBytes);
        }
    }
}