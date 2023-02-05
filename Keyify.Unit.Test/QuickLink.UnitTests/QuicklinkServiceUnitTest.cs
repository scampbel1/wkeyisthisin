﻿using Keyify.Web.Enums;
using Keyify.Web.Enums.Tuning;
using Keyify.Web.Models.QuickLink;
using Keyify.Web.Service;
using Keyify.Web.Service.Interfaces;
using KeyifyClassLibrary.Enums;
using Xunit;

namespace Keyify.Web.Unit.Test.QuickLinkTest.UnitTests
{
    public class QuicklinkServiceUnitTest
    {
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
                Tuning = GuitarTuning.Standard,
                SelectedNotes = new Note[] { Note.A, Note.E, Note.Gb },
                SelectedScale = "GbAeolian"
            };

            //Act - When
            var quickLink2 = new QuickLink()
            {
                InstrumentType = InstrumentType.Guitar,
                Tuning = GuitarTuning.Standard,
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
                InstrumentType = InstrumentType.Guitar,
                Tuning = GuitarTuning.Standard,
                SelectedNotes = new Note[] { Note.A, Note.E, Note.Gb },
                SelectedScale = "GbAeolian"
            };

            var quickLinkBase64String = _quickLinkService.ConvertQuickLinkToBase64(quickLink1);

            //Act - When
            var quickLink2 = _quickLinkService.DeserializeQuickLink(quickLinkBase64String);

            //Assert - Then
            Assert.Equal(quickLink1, quickLink2);
        }

        //TODO: Add tests based on Base64 values (copy and paste)

        //TODO: Add tests for objects that don't contain notes, scales, both, null values etc.
    }
}