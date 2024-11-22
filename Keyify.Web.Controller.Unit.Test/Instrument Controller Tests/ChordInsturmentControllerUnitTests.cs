﻿using EnumsNET;
using Keyify.Controllers.Instrument;
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
            const string selectedScale = "CKumoi";

            var newNote = Note.G;
            var previouslySeletedNotes = new List<Note> { Note.A, Note.C };
            var expectedSelectedNotes = new List<Note>(previouslySeletedNotes) { newNote };

            var _instrumentViewModel = InstrumentViewModel;

            var _instrumentController = CreateNewInstrumentController(_instrumentViewModel);

            _ = _instrumentController.UpdateFretboardModel(
                previouslySeletedNotes,
                newNote,
                selectedScale,
                lockScale: true);

            Assert.True(_instrumentViewModel.IsSelectionLocked);
        }

        [Fact]
        public async Task ToggleLockSelection_False_IsSelectionLocked_IsTrue()
        {
            var _instrumentViewModel = InstrumentViewModel;

            var _instrumentController = CreateNewInstrumentController(_instrumentViewModel);

            Assert.False(_instrumentViewModel.IsSelectionLocked);
        }

        [Fact]
        public async Task ToggleLockSeletion_InputScale_IsTheSame()
        {
            const string _excpectedQuickLinkScale = "CKumoi";

            var mockGeneratedScale = new GeneratedScale(
                        Note.C,
                        Note.C.ToString(),
                        new List<Note>() { Note.C },
                        new List<string>() { "C" },
                        Mode.Kumoi.AsString(EnumFormat.Description) ?? string.Empty,
                        new string[] { Degree.First, Degree.Second, Degree.FlatThird, Degree.Fifth, Degree.Sixth, Degree.Eighth });

            var mockScaleResult = new ScaleEntry(mockGeneratedScale);

            const string selectedScale = "CKumoi";

            var newNote = Note.G;
            var previouslySeletedNotes = new List<Note> { Note.A, Note.C };
            var expectedSelectedNotes = new List<Note>(previouslySeletedNotes) { newNote };

            var _instrumentViewModel = InstrumentViewModel;

            var _instrumentController = CreateNewInstrumentController(_instrumentViewModel);

            m_MockMusicTheoryService.Setup(m => m.FindScales(It.IsAny<IEnumerable<Note>>())).Returns(
                new[] {
                    mockScaleResult
                });

            _ = _instrumentController.UpdateFretboardModel(
                previouslySeletedNotes,
                newNote,
                selectedScale,
                lockScale: true);

            m_MockMusicTheoryService.Reset();

            Assert.Equal(_excpectedQuickLinkScale, _instrumentViewModel.SelectedScale.ScaleLabel);
        }

        [Fact]
        public async Task ToggleLockSeletion_InputNotesArray_IsTheSame()
        {
            const string selectedScale = "CKumoi";

            var newNote = Note.G;
            var previouslySeletedNotes = new List<Note> { Note.A, Note.C };
            var expectedSelectedNotes = new List<Note>(previouslySeletedNotes) { newNote };

            var instrumentViewModel = InstrumentViewModel;
            var instrumentController = CreateNewInstrumentController(instrumentViewModel);

            _ = instrumentController.UpdateFretboardModel(
                previouslySeletedNotes,
                newNote,
                selectedScale,
                lockScale: true);

            Assert.Equal(_selectedNotes, instrumentViewModel.SelectedNotes.Select(n => n.Note));
        }

        [Fact]
        public async Task ToggleLockSelection_LockSelection_ChordDefinitionsService_IsCalled()
        {
            const string selectedScale = "CKumoi";

            var newNote = Note.G;
            var previouslySeletedNotes = new List<Note> { Note.A, Note.C };
            var expectedSelectedNotes = new List<Note>(previouslySeletedNotes) { newNote };

            var instrumentViewModel = InstrumentViewModel;
            var instrumentController = CreateNewInstrumentController(instrumentViewModel);

            _ = instrumentController.UpdateFretboardModel(
                previouslySeletedNotes,
                newNote,
                selectedScale,
                lockScale: true);

            m_MockMusicTheoryService.Verify(c => c.GetChordsDefinitions(It.IsAny<Note[]>(), It.IsAny<Note[]>()), Times.Once);
        }
    }
}
