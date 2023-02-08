using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Keyify.Web.Controller.Unit.Test.Instrument_Controller_Tests
{
    public class CoreInstrumentControllerUnitTest : InstrumentControllerUnitTest
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
        public void InstrumentController_UpdateFretboardModel_NewNoteAddedToSelectedNotes()
        {
            var newNote = Note.B;
            const string selectedScale = "CKumoi";
            var previouslySeletedNotes = new List<Note> { Note.A, Note.C, Note.G };
            var expectedSelectedNotes = new List<Note>(previouslySeletedNotes) { newNote };

            var instrumentController = new InstrumentController(instrumentViewModel);

            instrumentController.UpdateFretboardModel(previouslySeletedNotes.Select(p => p.ToString()).ToList(), newNote.ToString(), selectedScale);

            Assert.Equal(selectedScale, instrumentViewModel.SelectedScale.ScaleLabel);
            Assert.Equal(expectedSelectedNotes.OrderBy(e => e), instrumentViewModel.SelectedNotes.Select(s => s.Note).OrderBy(o => o));
        }
    }
}
