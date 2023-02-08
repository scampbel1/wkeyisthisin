using Keyify.Controllers.Instrument;
using KeyifyClassLibrary.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Keyify.Web.Controller.Unit.Test.Instrument_Controller_Tests
{
    public class CoreInstrumentControllerUnitTest : BaseInstrumentControllerUnitTest
    {
        [Fact]
        public void InstrumentController_CallIndex_NoQuickLinkTempData_NotesShouldBeEmpty()
        {
            var instrumentController = new InstrumentController(instrumentViewModel)
            {
                TempData = new TempDataDictionary(
                    Mock.Of<HttpContext>(),
                    Mock.Of<ITempDataProvider>())
            };

            instrumentController.Index();

            Assert.Empty(instrumentViewModel.SelectedNotes);
            Assert.Null(instrumentViewModel.SelectedScale);
        }

        [Fact]
        public void InstrumentController_CallIndex_ScaleOnlyInQuickLinkTempData_ScaleShouldBeNull()
        {
            var qlScale = "CKumoi";

            var instrumentController = new InstrumentController(instrumentViewModel)
            {
                TempData = new TempDataDictionary(
                    Mock.Of<HttpContext>(),
                    Mock.Of<ITempDataProvider>())
            };

            instrumentController.TempData["QLscale"] = qlScale;

            instrumentController.Index();

            Assert.Empty(instrumentViewModel.SelectedNotes);
            Assert.Null(instrumentViewModel.SelectedScale);
        }

        [Fact]
        public void InstrumentController_CallIndex_NotesnlyInQuickLinkTempData_ScaleShouldBeNull_NotesShouldContainSelectedNotes()
        {
            var qlNotes = new List<Note> { Note.A, Note.C, Note.G };

            var instrumentController = new InstrumentController(instrumentViewModel)
            {
                TempData = new TempDataDictionary(
                    Mock.Of<HttpContext>(),
                    Mock.Of<ITempDataProvider>())
            };

            instrumentController.TempData["QLnotes"] = qlNotes;

            instrumentController.Index();

            Assert.Equal(3, instrumentViewModel.SelectedNotes.Count);
            Assert.Null(instrumentViewModel.SelectedScale);
        }

        [Fact]
        public void InstrumentController_CallIndex_QuickLinkTempData_ViewModelShouldContainQuickLinkValues()
        {
            var qlNotes = new List<Note> { Note.A, Note.C, Note.G };
            var qlScale = "CKumoi";

            var instrumentController = new InstrumentController(instrumentViewModel)
            {
                TempData = new TempDataDictionary(
                    Mock.Of<HttpContext>(),
                    Mock.Of<ITempDataProvider>())
            };

            instrumentController.TempData["QLnotes"] = qlNotes;
            instrumentController.TempData["QLscale"] = qlScale;

            instrumentController.Index();

            Assert.Equal(3, instrumentViewModel.SelectedNotes.Count);
            Assert.Equal(qlScale, instrumentViewModel.SelectedScale.ScaleLabel);
        }

        [Fact]
        public void InstrumentController_UpdateFretboardModel_NewNoteAddedToSelectedNotes()
        {
            var newNote = Note.B;
            var selectedScale = "CKumoi";
            var previouslySeletedNotes = new List<Note> { Note.A, Note.C, Note.G };
            var expectedSelectedNotes = new List<Note>(previouslySeletedNotes) { newNote };

            var instrumentController = new InstrumentController(instrumentViewModel);

            instrumentController.UpdateFretboardModel(previouslySeletedNotes.Select(p => p.ToString()).ToList(), newNote.ToString(), selectedScale);

            Assert.Equal(selectedScale, instrumentViewModel.SelectedScale.ScaleLabel);
            Assert.Equal(expectedSelectedNotes.OrderBy(e => e), instrumentViewModel.SelectedNotes.Select(s => s.Note).OrderBy(o => o));
        }
    }
}
