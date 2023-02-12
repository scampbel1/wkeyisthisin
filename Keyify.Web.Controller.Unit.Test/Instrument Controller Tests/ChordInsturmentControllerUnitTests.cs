using Keyify.Models.Service;
using KeyifyClassLibrary.Models.MusicTheory;
using KeyifyClassLibrary.Service_Models;

namespace Keyify.Web.Controller.Unit.Test.Instrument_Controller_Tests
{
    public class ChordInsturmentControllerUnitTests : InstrumentControllerUnitTests
    {
        private const string _selectedScale = "scale";
        private Note[] _selectedNotes = new[] { Note.A, Note.C, Note.G };

        [Fact]
        public void ToggleLockSelection_True_IsSelectionLocked_IsTrue()
        {
            const bool lockSelection = true;

            var _instrumentViewModel = InstrumentViewModel;

            var _instrumentController = CreateNewInstrumentController(_instrumentViewModel);

            _instrumentController.ToggleLockSelection(_selectedScale, _selectedNotes, lockSelection);

            Assert.True(_instrumentViewModel.IsSelectionLocked);
        }

        [Fact]
        public void ToggleLockSelection_False_IsSelectionLocked_IsTrue()
        {
            const bool lockSelection = false;

            var _instrumentViewModel = InstrumentViewModel;

            var _instrumentController = CreateNewInstrumentController(_instrumentViewModel);

            _instrumentController.ToggleLockSelection(_selectedScale, _selectedNotes, lockSelection);

            Assert.False(_instrumentViewModel.IsSelectionLocked);
        }

        [Fact]
        public void ToggleLockSeletion_InputScale_IsTheSame()
        {
            const bool lockSelection = true;
            const string _excpectedQuickLinkScale = "CKumoi";

            var _instrumentViewModel = InstrumentViewModel;

            var _instrumentController = CreateNewInstrumentController(_instrumentViewModel);

            m_MockMusicTheoryService.Setup(m => m.FindScales(It.IsAny<IEnumerable<Note>>())).Returns(
                new[] {
                    new ScaleEntry(new GeneratedScale(
                        Note.C,
                        new ModeDefinition(
                            Mode.Kumoi,
                            new Interval[] { Interval.R, Interval.W, Interval.h, Interval.WW, Interval.W, Interval.Wh},
                            new string[] { Degree.First, Degree.Second, Degree.FlatThird, Degree.Fifth, Degree.Sixth, Degree.Eighth })))
                });

            _instrumentController.ToggleLockSelection(_excpectedQuickLinkScale, _selectedNotes, lockSelection);

            m_MockMusicTheoryService.Reset();

            Assert.Equal(_excpectedQuickLinkScale, _instrumentViewModel.SelectedScale.ScaleLabel);
        }

        [Fact]
        public void ToggleLockSeletion_InputNotesArray_IsTheSame()
        {
            const bool lockSelection = true;

            var _instrumentViewModel = InstrumentViewModel;

            var _instrumentController = CreateNewInstrumentController(_instrumentViewModel);

            _instrumentController.ToggleLockSelection(_selectedScale, _selectedNotes, lockSelection);

            Assert.Equal(_selectedNotes, _instrumentViewModel.SelectedNotes.Select(n => n.Note));
        }

        [Fact]
        public void ToggleLockSelection_LockSelection_ChordTemplateService_IsCalled()
        {
            const bool lockSelection = true;

            var _instrumentViewModel = InstrumentViewModel;

            var _instrumentController = CreateNewInstrumentController(_instrumentViewModel);

            _instrumentController.ToggleLockSelection(_selectedScale, _selectedNotes, lockSelection);

            m_MockMusicTheoryService.Verify(c => c.GetChordsTemplates(It.IsAny<Note[]>(), It.IsAny<Note[]>()), Times.Once);
        }

        [Fact(Skip = "Not required until Chord Implementations are present in database")]
        public void ToggleLockSelection_UnlockSelection_ChordTemplateService_IsNotCalled()
        {
            const bool lockSelection = false;

            var _instrumentViewModel = InstrumentViewModel;

            var _instrumentController = CreateNewInstrumentController(_instrumentViewModel);

            _instrumentController.ToggleLockSelection(_selectedScale, _selectedNotes, lockSelection);

            m_MockMusicTheoryService.Verify(c => c.GetChordsTemplates(It.IsAny<Note[]>(), It.IsAny<Note[]>()), Times.Never);
        }
    }
}
