﻿using EnumsNET;
using Keyify.MusicTheory.Enums;
using Keyify.Services.Models;

namespace Keyify.Web.Controller.Unit.Test.Instrument_Controller_Tests
{
    public class ChordInsturmentControllerUnitTests : InstrumentControllerUnitTests
    {
        private const string _selectedScale = "scale";
        private Note[] _selectedNotes = new[] { Note.A, Note.C, Note.G };

        [Fact]
        public async Task ToggleLockSelection_True_IsSelectionLocked_IsTrue()
        {
            const bool lockSelection = true;

            var _instrumentViewModel = InstrumentViewModel;

            var _instrumentController = CreateNewInstrumentController(_instrumentViewModel);

            await _instrumentController.ToggleLockSelection(_selectedScale, _selectedNotes, lockSelection);

            Assert.True(_instrumentViewModel.IsSelectionLocked);
        }

        [Fact]
        public async Task ToggleLockSelection_False_IsSelectionLocked_IsTrue()
        {
            const bool lockSelection = false;

            var _instrumentViewModel = InstrumentViewModel;

            var _instrumentController = CreateNewInstrumentController(_instrumentViewModel);

            await _instrumentController.ToggleLockSelection(_selectedScale, _selectedNotes, lockSelection);

            Assert.False(_instrumentViewModel.IsSelectionLocked);
        }

        [Fact]
        public async Task ToggleLockSeletion_InputScale_IsTheSame()
        {
            const bool lockSelection = true;
            const string _excpectedQuickLinkScale = "CKumoi";

            var mockGeneratedScale = new GeneratedScale(
                        Note.C,
                        Note.C.ToString(),
                        new List<Note>() { Note.C },
                        new List<string>() { "C" },
                        Mode.Kumoi.AsString(EnumFormat.Description),
                        new string[] { Degree.First, Degree.Second, Degree.FlatThird, Degree.Fifth, Degree.Sixth, Degree.Eighth });

            var mockScaleResult = new ScaleEntry(mockGeneratedScale);

            var _instrumentViewModel = InstrumentViewModel;

            var _instrumentController = CreateNewInstrumentController(_instrumentViewModel);


            m_MockMusicTheoryService.Setup(m => m.FindScales(It.IsAny<IEnumerable<Note>>())).Returns(
                new[] {
                    mockScaleResult
                });

            await _instrumentController.ToggleLockSelection(_excpectedQuickLinkScale, _selectedNotes, lockSelection);

            m_MockMusicTheoryService.Reset();

            Assert.Equal(_excpectedQuickLinkScale, _instrumentViewModel.SelectedScale.ScaleLabel);
        }

        [Fact]
        public async Task ToggleLockSeletion_InputNotesArray_IsTheSame()
        {
            const bool lockSelection = true;

            var _instrumentViewModel = InstrumentViewModel;

            var _instrumentController = CreateNewInstrumentController(_instrumentViewModel);

            await _instrumentController.ToggleLockSelection(_selectedScale, _selectedNotes, lockSelection);

            Assert.Equal(_selectedNotes, _instrumentViewModel.SelectedNotes.Select(n => n.Note));
        }

        [Fact]
        public async Task ToggleLockSelection_LockSelection_ChordDefinitionsService_IsCalled()
        {
            const bool lockSelection = true;

            var _instrumentViewModel = InstrumentViewModel;

            var _instrumentController = CreateNewInstrumentController(_instrumentViewModel);

            await _instrumentController.ToggleLockSelection(_selectedScale, _selectedNotes, lockSelection);

            m_MockMusicTheoryService.Verify(c => c.GetChordsDefinitions(It.IsAny<Note[]>(), It.IsAny<Note[]>()), Times.Once);
        }

        [Fact(Skip = "Not required until Chord Implementations are present in database")]
        public async Task ToggleLockSelection_UnlockSelection_ChordDefinitionService_IsNotCalled()
        {
            const bool lockSelection = false;

            var _instrumentViewModel = InstrumentViewModel;

            var _instrumentController = CreateNewInstrumentController(_instrumentViewModel);

            await _instrumentController.ToggleLockSelection(_selectedScale, _selectedNotes, lockSelection);

            m_MockMusicTheoryService.Verify(c => c.GetChordsDefinitions(It.IsAny<Note[]>(), It.IsAny<Note[]>()), Times.Never);
        }
    }
}
