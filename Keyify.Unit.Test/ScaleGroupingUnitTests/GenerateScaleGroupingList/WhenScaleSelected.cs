using EnumsNET;
using Keyify.MusicTheory.Enums;
using Keyify.Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace Keyify.Web.Unit.Test.ScaleGroupingUnitTests.GenerateScaleGroupingList
{
    public class WhenScaleSelected : WhenTestingTheMethod
    {
        private const int MinimumNoteCount = 3;
        private const int ExpectedScaleCount = 1;
        private const int DefaultPopularityValue = 3;
        private const int ExpectedResultGroupCount = 1;
        private const InstrumentType ExpectedInstrumentType = InstrumentType.Guitar;
        private List<string> _expectedLabelNotes;
        private List<string> _expectedLabelSelectedNotes;

        public override void Arrange()
        {
            SelectedNotes = new List<Note>() { Note.Ab, Note.Bb, Note.C };
            InstrumentType = InstrumentType.Guitar;

            var rootNote = Note.Db;
            var sharpRootNote = "G#";
            var notes = new List<Note>() { Note.Ab, Note.Bb, Note.C, Note.Db, Note.Eb, Note.F, Note.G, };
            var sharpNotes = new List<string>();
            var mode = Mode.Ionian.AsString(EnumFormat.Description);
            var scaleDegrees = new string[6];

            Scales = new List<ScaleEntry>()
            {
                new ScaleEntry(
                    new GeneratedScale(
                        rootNote,
                        sharpRootNote,
                        notes,
                        sharpNotes,
                        mode,
                        scaleDegrees)),
            };

            SelectedScale = "G# Ionian";

            _expectedLabelNotes = new List<string>() { "G#", "A#", "C", "C#", "D#", "F", "G", };
            _expectedLabelSelectedNotes = new List<string>() { "(G#)", "(A#)", "(C)", };
        }

        [Fact]
        public void ItDoesNotThrow()
        {
            Act();

            Assert.Null(Exception);
        }

        [Fact]
        public void ItDoesNotHaveEmptyResult()
        {
            Act();

            Assert.NotEmpty(Result);
        }

        [Fact]
        public void ItHasExpectedSelectedNoteParameterCount()
        {
            Act();

            Assert.True(SelectedNotes.Count() >= MinimumNoteCount);
        }

        [Fact]
        public void ItHasExpectedScaleCount()
        {
            Act();

            Assert.Multiple(() =>
            {
                Assert.NotNull(Result);
                Assert.True(Result.Count() == ExpectedResultGroupCount);
            });
        }

        [Fact]
        public void ItHasExpectedScaleInGroup()
        {
            Act();

            Assert.Multiple(() =>
            {
                Assert.NotNull(Result.First().GroupedScales);
                Assert.True(Result.First().Count == ExpectedScaleCount);
            });
        }

        [Fact]
        public void ItHasDefaultPopularityRating()
        {
            Act();

            Assert.Multiple(() =>
            {
                Assert.True(Result.First().GroupedScales.First().Popularity == DefaultPopularityValue);
            });
        }

        [Fact]
        public void ItHasExpectedInstrument()
        {
            Act();

            Assert.Multiple(() =>
            {
                Assert.True(InstrumentType == ExpectedInstrumentType);
            });
        }

        [Fact]
        public void ItHasEmptyScaleName()
        {
            Act();

            Assert.Multiple(() =>
            {
                Assert.NotNull(SelectedScale);
                Assert.NotEmpty(SelectedScale);
            });
        }

        [Fact]
        public void ItPassesInExpectedScalesCollection()
        {
            Act();

            Assert.Multiple(() =>
            {
                Assert.NotNull(Scales);
                Assert.True(Scales.Count() == ExpectedScaleCount);
            });
        }

        [Fact]
        public void ItHasScaleGroupLabel()
        {
            Act();

            Assert.Multiple(() =>
            {
                Assert.NotNull(Result.First().NotesGroupingLabelHtml);
                Assert.True(Result.First().NotesGroupingLabelHtml.Length > 0);
            });
        }

        [Fact]
        public void ItHasScaleLabelWhichContainsScaleSharpNotes()
        {
            Act();

            var scaleGroupLabel = Result.First().NotesGroupingLabelHtml;

            Assert.Multiple(() =>
            {
                foreach (var sharpNote in _expectedLabelNotes)
                {
                    Assert.Contains(sharpNote, scaleGroupLabel);
                }
            });
        }

        [Fact]
        public void ItHasScaleLabelWhichContainsSelectedScaleSharpNotes()
        {
            Act();

            var scaleGroupLabel = Result.First().NotesGroupingLabelHtml;

            Assert.Multiple(() =>
            {
                foreach (var sharpNote in _expectedLabelSelectedNotes)
                {
                    Assert.Contains(sharpNote, scaleGroupLabel);
                }
            });
        }

        [Fact]
        public void ItHasSelectedScaleIsInResult()
        {
            Act();

            var scaleGroupLabel = Result.First().NotesGroupingLabelHtml;

            Assert.Multiple(() =>
            {
                Assert.Contains(SelectedScale, Result.First().GroupedScales.First().FormalNameLabel_Sharp);
                Assert.True(Result.First().GroupedScales.First().Selected);
            });
        }
    }
}
