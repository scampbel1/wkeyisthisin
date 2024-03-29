﻿using Keyify.MusicTheory.Enums;

namespace Keyify.Web.Controller.Unit.Test.Instrument_Controller_Tests
{
    public class QuickLinkInstrumentControllerUnitTests : InstrumentControllerUnitTests
    {
        [Fact]
        public async Task QuickLink_ScaleOnlyInQuickLinkTempData_ScaleShouldBeNull()
        {
            const string quickLinkScale = "CKumoi";

            var instrumentViewModel = InstrumentViewModel;
            var instrumentController = CreateNewInstrumentController(instrumentViewModel);

            instrumentController.TempData[_quickLinkScaleKey] = quickLinkScale;

            await instrumentController.Index();

            Assert.Empty(instrumentViewModel.SelectedNotes);
            Assert.Null(instrumentViewModel.SelectedScale);
        }

        [Fact]
        public async Task QuickLink_NotesOnlyTempData_ScaleShouldBeNull_NotesShouldContainSelectedNotes()
        {
            const int _expectedNotesCount = 3;
            var qlNotes = new List<Note> { Note.A, Note.C, Note.G };

            var instrumentViewModel = InstrumentViewModel;
            var instrumentController = CreateNewInstrumentController(instrumentViewModel);

            instrumentController.TempData[_quickLinkNotesKey] = qlNotes;

            await instrumentController.Index();

            Assert.Equal(_expectedNotesCount, instrumentViewModel.SelectedNotes.Count);
            Assert.Null(instrumentViewModel.SelectedScale);
        }

        [Fact]
        public async Task QuickLink_QuickLinkTempData_ViewModelShouldContainQuickLinkValues()
        {
            const int _expectedNotesCount = 3;
            const string _excpectedQuickLinkScale = "CKumoi";
            var qlNotes = new List<Note> { Note.A, Note.C, Note.G };

            var instrumentViewModel = InstrumentViewModel;
            var instrumentController = CreateNewInstrumentController(instrumentViewModel);

            //new GeneratedScale(
            //            Note.C,
            //            new ModeDefinition(
            //                Mode.Kumoi,
            //                new Interval[] { Interval.R, Interval.W, Interval.h, Interval.WW, Interval.W, Interval.Wh },
            //                new string[] { Degree.First, Degree.Second, Degree.FlatThird, Degree.Fifth, Degree.Sixth, Degree.Eighth }))

            //m_MockMusicTheoryService.Setup(m => m.FindScales(It.IsAny<IEnumerable<Note>>())).ReturnsAsync(
            //    new[] {
            //        new ScaleEntry()
            //    });

            instrumentController.TempData[_quickLinkNotesKey] = qlNotes;
            instrumentController.TempData[_quickLinkScaleKey] = _excpectedQuickLinkScale;

            await instrumentController.Index();

            m_MockMusicTheoryService.Reset();

            Assert.Equal(_expectedNotesCount, instrumentViewModel.SelectedNotes.Count);
            //Assert.Equal(_excpectedQuickLinkScale, instrumentViewModel.SelectedScale.ScaleLabel);
        }
    }
}
