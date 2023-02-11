namespace Keyify.Web.Controller.Unit.Test.Instrument_Controller_Tests
{
    public class ChordInsturmentControllerUnitTests : InstrumentControllerUnitTests
    {
        private const string _selectedScale = "scale";
        private Note[] _selectedNotes = new[] { Note.A, Note.C, Note.G };

        [Fact]
        public void LockNoteAndChordSelection_IsSelectionLocked_IsTrue()
        {
            const bool lockSelection = true;

            var instrumentViewModel = InstrumentViewModel;

            var instrumentController = CreateNewInstrumentController(instrumentViewModel);

            instrumentController.ToggleLockSelection(_selectedScale, _selectedNotes, lockSelection);

            Assert.True(instrumentViewModel.IsSelectionLocked);
        }

        [Fact]
        public void ToggleLockSelection_LockSelection_ChordTemplateService_IsCalled()
        {
            const bool lockSelection = true;

            var instrumentViewModel = InstrumentViewModel;

            var instrumentController = CreateNewInstrumentController(instrumentViewModel);

            instrumentController.ToggleLockSelection(_selectedScale, _selectedNotes, lockSelection);

            m_MockMusicTheoryService.Verify(c => c.GetChordsTemplates(It.IsAny<string>(), It.IsAny<Note[]>()), Times.Once);
        }

        [Fact]
        public void ToggleLockSelection_UnlockSelection_ChordTemplateService_IsNotCalled()
        {
            const bool lockSelection = false;

            var instrumentViewModel = InstrumentViewModel;

            var instrumentController = CreateNewInstrumentController(instrumentViewModel);

            instrumentController.ToggleLockSelection(_selectedScale, _selectedNotes, lockSelection);

            m_MockMusicTheoryService.Verify(c => c.GetChordsTemplates(It.IsAny<string>(), It.IsAny<Note[]>()), Times.Never);
        }
    }
}
