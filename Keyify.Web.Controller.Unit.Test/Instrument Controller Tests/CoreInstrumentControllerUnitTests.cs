﻿using Keyify.MusicTheory.Enums;
using Keyify.Services.Models;
using Keyify.Web.Data_Contracts;

namespace Keyify.Web.Controller.Unit.Test.Instrument_Controller_Tests
{
    public class CoreInstrumentControllerUnitTests : InstrumentControllerUnitTests
    {

        [Fact]
        public void InstrumentController_CallIndex_NoQuickLinkTempData_NotesShouldBeEmpty()
        {
            var instrumentViewModel = InstrumentViewModel;

            var instrumentController = CreateNewInstrumentController(instrumentViewModel);

            _ = instrumentController.Index();

            m_MockScaleGroupingHtmlService.Verify(m => m.GenerateScalesTable(
                It.IsAny<IEnumerable<Note>>(),
                It.IsAny<InstrumentType>(),
                It.IsAny<List<ScaleGroupingEntry>>(),
                It.IsAny<string>()),
                Times.Once);

            m_MockChordDefinitionsGroupingHtmlService.Verify(m => m.GenerateChordDefinitionsHtml(It.IsAny<IEnumerable<ChordDefinition>>()), Times.Never);

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

            var fretboardRequest = new UpdateFretboardRequest()
            {
                LockScale = false,
                NewlySelectedNote = Note.G,
                PreviouslySelectedNotes = [Note.A, Note.C],
                SelectedScale = selectedScale,
            };

            var instrumentViewModel = InstrumentViewModel;
            var instrumentController = CreateNewInstrumentController(instrumentViewModel);

            //new GeneratedScale(
            //            Note.C,
            //            new ModeDefinition(
            //                Mode.Kumoi,
            //                new Interval[] { Interval.R, Interval.W, Interval.h, Interval.WW, Interval.W, Interval.Wh },
            //                new string[] { Degree.First, Degree.Second, Degree.FlatThird, Degree.Fifth, Degree.Sixth, Degree.Eighth }))

            //m_MockMusicTheoryService.Setup(m => m.FindScales(It.IsAny<IEnumerable<Note>>())).ReturnsAsync(new[] {
            //        new ScaleEntry()
            //});

            _ = instrumentController.UpdateFretboardModel(fretboardRequest);

            m_MockScaleGroupingHtmlService.Verify(m => m.GenerateScalesTable(
                It.IsAny<IEnumerable<Note>>(),
                It.IsAny<InstrumentType>(),
                It.IsAny<List<ScaleGroupingEntry>>(),
                It.IsAny<string>()),
                Times.Once);

            m_MockChordDefinitionsGroupingHtmlService.Verify(m => m.GenerateChordDefinitionsHtml(It.IsAny<IEnumerable<ChordDefinition>>()), Times.Once);

            m_MockMusicTheoryService.Reset();
            m_MockScaleGroupingHtmlService.Reset();
            m_MockChordDefinitionsGroupingHtmlService.Reset();

            //Assert.Equal(selectedScale, instrumentViewModel.SelectedScale.ScaleLabel);
            //Assert.Equal(expectedSelectedNotes.OrderBy(e => e), instrumentViewModel.SelectedNotes.Select(s => s.Note).OrderBy(o => o));
        }
    }
}
