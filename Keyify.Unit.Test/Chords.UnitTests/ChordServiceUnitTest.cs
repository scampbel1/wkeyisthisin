using Keyify.Enums;
using Keyify.Models.Service_Models;
using Keyify.Service;
using Keyify.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Keyify.Unit.Test.Chords.UnitTests
{
    public class ChordServiceUnitTest
    {
        public static IEnumerable<object[]> ChordTestParameters => GenerateChordTestArguments();

        private IChordService _chordService = new ChordService(new ChordDataStore());

        [Theory, MemberData(nameof(ChordTestParameters))]
        public void PassNoteSequenceIntoChordService_ReturnsExpectedChord(KeyifyClassLibrary.Enums.Note[] selectedNotes, ChordDefinition expectedChord)
        {
            //Arrange - Given
            var inputNotes = selectedNotes;
            //Act - When
            var chordResult = _chordService.FindChordWithNoteSequence(selectedNotes).FirstOrDefault();
            //Assert - Then
            Assert.Equal(expected: expectedChord, actual: chordResult);
        }

        private static IEnumerable<object[]> GenerateChordTestArguments()
        {
            var expectedChordNotes1 = new[] { KeyifyClassLibrary.Enums.Note.F, KeyifyClassLibrary.Enums.Note.A, KeyifyClassLibrary.Enums.Note.C };

            return new List<object[]>
            {
                new object[] { expectedChordNotes1, new ChordDefinition(ChordType.Major, expectedChordNotes1) },
            };
        }
    }
}