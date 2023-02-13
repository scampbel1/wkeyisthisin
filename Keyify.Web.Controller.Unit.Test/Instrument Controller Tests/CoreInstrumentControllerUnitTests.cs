using Keyify.Models.Service;
using Keyify.Models.ServiceModels;
using Keyify.Models.ViewModels.Misc;
using Keyify.Web.Enums;
using KeyifyClassLibrary.Models.MusicTheory;
using KeyifyClassLibrary.Service_Models;

namespace Keyify.Web.Controller.Unit.Test.Instrument_Controller_Tests
{
    public class CoreInstrumentControllerUnitTests : InstrumentControllerUnitTests
    {

        [Fact]
        public void InstrumentController_CallIndex_NoQuickLinkTempData_NotesShouldBeEmpty()
        {
            var instrumentViewModel = InstrumentViewModel;

            var instrumentController = CreateNewInstrumentController(instrumentViewModel);

            instrumentController.Index();

            m_MockScaleGroupingHtmlService.Verify(m => m.GenerateAvailableKeysAndScalesTable(It.IsAny<IEnumerable<Note>>(), It.IsAny<InstrumentType>(), It.IsAny<List<ScaleGroupingEntry>>(), It.IsAny<List<ScaleGroupingEntry>>()), Times.Once);
            m_MockChordDefinitionsGroupingHtmlService.Verify(m => m.GenerateChordDefinitionsTableHtml(It.IsAny<IEnumerable<ChordDefinition>>()), Times.Once);

            m_MockScaleGroupingHtmlService.Reset();
            m_MockChordDefinitionsGroupingHtmlService.Reset();

            Assert.Empty(instrumentViewModel.SelectedNotes);
            Assert.Null(instrumentViewModel.SelectedScale);
        }

        [Fact]
        public void InstrumentController_UpdateFretboardModel_NewNoteAddedToSelectedNotes()
        {
            const string selectedScale = "CKumoi";

            var newNote = Note.B;
            var previouslySeletedNotes = new List<Note> { Note.A, Note.C, Note.G };
            var expectedSelectedNotes = new List<Note>(previouslySeletedNotes) { newNote };

            var instrumentViewModel = InstrumentViewModel;
            var instrumentController = CreateNewInstrumentController(instrumentViewModel);


            m_MockMusicTheoryService.Setup(m => m.FindScales(It.IsAny<IEnumerable<Note>>())).Returns(new[] {
                    new ScaleEntry(new GeneratedScale(
                        Note.C,
                        new ModeDefinition(
                            Mode.Kumoi,
                            new Interval[] { Interval.R, Interval.W, Interval.h, Interval.WW, Interval.W, Interval.Wh},
                            new string[] { Degree.First, Degree.Second, Degree.FlatThird, Degree.Fifth, Degree.Sixth, Degree.Eighth })))
            });

            instrumentController.UpdateFretboardModel(previouslySeletedNotes, newNote, selectedScale);

            m_MockScaleGroupingHtmlService.Verify(m => m.GenerateAvailableKeysAndScalesTable(It.IsAny<IEnumerable<Note>>(), It.IsAny<InstrumentType>(), It.IsAny<List<ScaleGroupingEntry>>(), It.IsAny<List<ScaleGroupingEntry>>()), Times.Once);
            m_MockChordDefinitionsGroupingHtmlService.Verify(m => m.GenerateChordDefinitionsTableHtml(It.IsAny<IEnumerable<ChordDefinition>>()), Times.Once);

            m_MockMusicTheoryService.Reset();
            m_MockScaleGroupingHtmlService.Reset();
            m_MockChordDefinitionsGroupingHtmlService.Reset();

            Assert.Equal(selectedScale, instrumentViewModel.SelectedScale.ScaleLabel);
            Assert.Equal(expectedSelectedNotes.OrderBy(e => e), instrumentViewModel.SelectedNotes.Select(s => s.Note).OrderBy(o => o));
        }
    }
}
