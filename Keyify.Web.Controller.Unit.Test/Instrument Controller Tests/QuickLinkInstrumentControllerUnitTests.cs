using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Keyify.Web.Controller.Unit.Test.Instrument_Controller_Tests
{
    public class QuickLinkInstrumentControllerUnitTests : InstrumentControllerUnitTest
    {
        [Fact]
        public void QuickLink_ScaleOnlyInQuickLinkTempData_ScaleShouldBeNull()
        {
            const string quickLinkScale = "CKumoi";

            var instrumentController = new InstrumentController(instrumentViewModel)
            {
                TempData = new TempDataDictionary(
                    Mock.Of<HttpContext>(),
                    Mock.Of<ITempDataProvider>())
            };

            instrumentController.TempData[_quickLinkScaleKey] = quickLinkScale;

            instrumentController.Index();

            Assert.Empty(instrumentViewModel.SelectedNotes);
            Assert.Null(instrumentViewModel.SelectedScale);
        }

        [Fact]
        public void QuickLink_NotesOnlyTempData_ScaleShouldBeNull_NotesShouldContainSelectedNotes()
        {
            const int _expectedNotesCount = 3;
            var qlNotes = new List<Note> { Note.A, Note.C, Note.G };

            var instrumentController = new InstrumentController(instrumentViewModel)
            {
                TempData = new TempDataDictionary(
                    Mock.Of<HttpContext>(),
                    Mock.Of<ITempDataProvider>())
            };

            instrumentController.TempData[_quickLinkNotesKey] = qlNotes;

            instrumentController.Index();

            Assert.Equal(_expectedNotesCount, instrumentViewModel.SelectedNotes.Count);
            Assert.Null(instrumentViewModel.SelectedScale);
        }

        [Fact]
        public void QuickLink_QuickLinkTempData_ViewModelShouldContainQuickLinkValues()
        {
            const int _expectedNotesCount = 3;
            const string _excpectedQuickLinkScale = "CKumoi";
            var qlNotes = new List<Note> { Note.A, Note.C, Note.G };

            var instrumentController = new InstrumentController(instrumentViewModel)
            {
                TempData = new TempDataDictionary(
                    Mock.Of<HttpContext>(),
                    Mock.Of<ITempDataProvider>())
            };

            instrumentController.TempData[_quickLinkNotesKey] = qlNotes;
            instrumentController.TempData[_quickLinkScaleKey] = _excpectedQuickLinkScale;

            instrumentController.Index();

            Assert.Equal(_expectedNotesCount, instrumentViewModel.SelectedNotes.Count);
            Assert.Equal(_excpectedQuickLinkScale, instrumentViewModel.SelectedScale.ScaleLabel);
        }
    }
}
