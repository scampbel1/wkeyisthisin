using Keyify.Web.Enums;
using Keyify.Web.Enums.Tuning;
using Keyify.Web.Models.QuickLink;
using Keyify.Web.Service;
using Keyify.Web.Service.Interfaces;
using KeyifyClassLibrary.Enums;
using System.Collections.Generic;

namespace Keyify.Web.Unit.Test.QuickLinkTest.UnitTests
{
    public class QuicklinkServiceUnitTest
    {
        public static IEnumerable<object[]> QuickLinkParameters => GenerateQuickLinkTestArguments();

        private IQuickLinkService _quickLinkService;

        public QuicklinkServiceUnitTest()
        {
            _quickLinkService = new QuickLinkService();
        }

        [Fact]
        public void QuickLink_NotesDifferentOrder_ObjectsAreEqual()
        {
            //Arrange - Given
            var quickLink1 = new QuickLink()
            {
                InstrumentType = InstrumentType.Guitar,
                Tuning = Tuning.Guitar_Standard,
                SelectedNotes = new Note[] { Note.A, Note.E, Note.Gb },
                SelectedScale = "GbAeolian"
            };

            //Act - When
            var quickLink2 = new QuickLink()
            {
                InstrumentType = InstrumentType.Guitar,
                Tuning = Tuning.Guitar_Standard,
                SelectedNotes = new Note[] { Note.E, Note.A, Note.Gb },
                SelectedScale = "GbAeolian"
            };

            //Assert - Then
            Assert.Equal(quickLink1, quickLink2);
        }

        [Fact]
        public void CreateBase64StringFromQuickLink_CreateQuickLinkFromBase64String_QuickLinksAreEqual()
        {
            //Arrange - Given
            var quickLink1 = new QuickLink()
            {
                InstrumentType = InstrumentType.Bass,
                Tuning = Tuning.Bass_Standard,
                SelectedNotes = new Note[] { Note.A, Note.E, Note.Gb },
                SelectedScale = "GbAeolian"
            };

            var quickLinkBase64String = _quickLinkService.ConvertQuickLinkToBase64(quickLink1);

            //Act - When
            var quickLink2 = _quickLinkService.DeserializeQuickLink(quickLinkBase64String);

            //Assert - Then
            Assert.Equal(quickLink1, quickLink2);
        }

        [Theory, MemberData(nameof(QuickLinkParameters))]
        public void CreateQuickLinkFromBase64(string base64, QuickLink expectedQuickLink)
        {
            var actualQuickLink = _quickLinkService.DeserializeQuickLink(base64);

            Assert.Equal(expectedQuickLink, actualQuickLink);
        }

        private static IEnumerable<object[]> GenerateQuickLinkTestArguments()
        {
            const string quickLinkCode1 = "eyJJbnN0cnVtZW50VHlwZSI6MCwiVHVuaW5nIjowLCJTZWxlY3RlZE5vdGVzIjpbMCwyLDMsNSw3LDgsMTBdLCJTZWxlY3RlZFNjYWxlIjoiQ0lvbmlhbiIsIkluc3RydW1lbnROYW1lIjoiR3VpdGFyIn0=";
            const string quickLinkCode2 = "eyJJbnN0cnVtZW50VHlwZSI6MSwiVHVuaW5nIjoxLCJTZWxlY3RlZE5vdGVzIjpbOSwxLDExLDQsNl0sIlNlbGVjdGVkU2NhbGUiOiJCSW9uaWFuIiwiSW5zdHJ1bWVudE5hbWUiOiJCYXNzIn0=";

            return new List<object[]>
            {
                new object[]
                {
                    quickLinkCode1,
                    new QuickLink() {
                        InstrumentType = InstrumentType.Guitar,
                        Tuning = Tuning.Guitar_Standard,
                        SelectedNotes = new Note[] { Note.A, Note.B, Note.C, Note.D, Note.E, Note.F, Note.G },
                        SelectedScale = "CIonian"
                    }
                },
                new object[]
                {
                    quickLinkCode2,
                    new QuickLink() {
                        InstrumentType = InstrumentType.Bass,
                        Tuning = Tuning.Bass_Standard,
                        SelectedNotes = new Note[] { Note.Gb, Note.Bb, Note.Ab, Note.Db, Note.Eb, },
                        SelectedScale = "BIonian"
                    }
                },
            };
        }
    }
}