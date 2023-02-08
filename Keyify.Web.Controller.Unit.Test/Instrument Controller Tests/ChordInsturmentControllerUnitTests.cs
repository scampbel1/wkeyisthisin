namespace Keyify.Web.Controller.Unit.Test.Instrument_Controller_Tests
{
    public class ChordInsturmentControllerUnitTests : InstrumentControllerUnitTests
    {
        private const string _selectedScale = "scale";
        private List<Note> _selectedNotes = new List<Note> { Note.A, Note.C, Note.G };

        [Fact]
        public void LockNoteAndChordSelection_IsSelectionLocked_IsTrue()
        {
            var instrumentViewModel = InstrumentViewModel;

            var instrumentController = CreateNewInstrumentController(instrumentViewModel);

            instrumentController.LockSelection(_selectedNotes.Select(n => n.ToString()).ToList(), _selectedScale);

            Assert.True(instrumentViewModel.IsSelectionLocked);
        }

        [Fact]
        public void UnlockNoteAndChordSelection_IsSelectionLocked_IsFalse()
        {
            var instrumentViewModel = InstrumentViewModel;

            var instrumentController = CreateNewInstrumentController(instrumentViewModel);

            instrumentController.UnockSelection();

            Assert.False(instrumentViewModel.IsSelectionLocked);
        }
    }
}
