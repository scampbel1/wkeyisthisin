using Keyify.Models.Service;
using Keyify.MusicTheory.Enums;
using Keyify.Services.Formatter.Interfaces;
using Keyify.Services.Formatter.Services;
using Keyify.Web.Unit.Test.ChordTemplates.UnitTests.Mocks;
using System.Collections.Generic;
using System.Linq;

namespace Keyify.Web.Unit.Test.ScaleDefinitionServiceTest.UnitTests
{
    public class ParralelMajorMinorChordsUnitTests
    {
        private ScaleDefinitionService _scaleDefinitionService;
        private ScaleService _scaleService;
        private INoteFormatService _noteFormatService;

        public ParralelMajorMinorChordsUnitTests()
        {
            _noteFormatService = new NoteFormatService();
            _scaleDefinitionService = new ScaleDefinitionService(new MockScaleDefinitionCache(), new MockScaleDefinitionRepository());
            _scaleService = new ScaleService(_scaleDefinitionService, _noteFormatService);
        }

        [Fact]
        public void AMajorExtended_ComparedAgainstAMinor_ReturnsAMajorWithDifferingNotes()
        {
            var actual = _scaleService.Scales.Single(s => s.ScaleLabel == "A Major*").Scale.Notes;

            var aMajorScale = _scaleService.Scales.Single(s => s.ScaleLabel == "A Major");
            var expectedDifferenceNotes = new[] { Note.Gb, Note.Db };

            var expected = new List<Note>(aMajorScale.Scale.Notes);
            expected.AddRange(expectedDifferenceNotes);

            Assert.Equal(expected, actual);
        }
    }
}
