﻿namespace Keyify.Web.Controller.Unit.Test.Instrument_Controller_Tests
{
    public class ChordInsturmentControllerUnitTests : InstrumentControllerUnitTests
    {
        private const string _selectedScale = "scale";
        private Note[] _selectedNotes = new [] { Note.A, Note.C, Note.G };

        [Fact]
        public void LockNoteAndChordSelection_IsSelectionLocked_IsTrue()
        {
            var instrumentViewModel = InstrumentViewModel;

            var instrumentController = CreateNewInstrumentController(instrumentViewModel);

            instrumentController.LockSelection(_selectedScale, _selectedNotes);

            Assert.True(instrumentViewModel.IsSelectionLocked);
        }

        [Fact]
        public void LockNoteAndChordSelection_ChordTemplateService_IsCalled()
        {
            var instrumentViewModel = InstrumentViewModel;

            var instrumentController = CreateNewInstrumentController(instrumentViewModel);

            instrumentController.LockSelection(_selectedScale, _selectedNotes);

            m_MockChordTemplateService.Verify(c => c.FindChordTemplateWithNoteSequence(It.IsAny<Note[]>()), Times.Once);

            m_MockChordTemplateService.VerifyAll();

            m_MockChordTemplateService.Reset();
        }

        [Fact]
        public void UnlockNoteAndChordSelection_IsSelectionLocked_IsFalse()
        {
            var instrumentViewModel = InstrumentViewModel;

            var instrumentController = CreateNewInstrumentController(instrumentViewModel);

            instrumentController.UnockSelection(_selectedScale, _selectedNotes);

            Assert.False(instrumentViewModel.IsSelectionLocked);
        }
    }
}
