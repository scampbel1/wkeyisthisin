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
        public void PassNoteSequenceIntoChordService_ReturnsExpectedChord(KeyifyClassLibrary.Enums.Note[] selectedNotes, ChordTemplate expectedChord)
        {
            //Arrange - Given
            var inputNotes = selectedNotes;
            //Act - When
            var chordResult = _chordService.FindChordWithNoteSequence(selectedNotes).FirstOrDefault();
            //Assert - Then
            Assert.Equal(expected: expectedChord, actual: chordResult);
        }

        [Fact]
        public void Chord_SameNotes_SameChordType_DifferentSequence_AreNotStrictEqual()
        {
            //Arrange - Given
            var chord1 = new ChordTemplate(ChordType.Minor, new[] { KeyifyClassLibrary.Enums.Note.F, KeyifyClassLibrary.Enums.Note.A, KeyifyClassLibrary.Enums.Note.C });
            //Act - When
            var chord2 = new ChordTemplate(ChordType.Minor, new[] { KeyifyClassLibrary.Enums.Note.C, KeyifyClassLibrary.Enums.Note.A, KeyifyClassLibrary.Enums.Note.F });
            //Assert - Then
            Assert.NotStrictEqual(chord1, chord2);
        }

        [Fact]
        public void Chord_SameNotes_SameChordType_DifferentSequence_AreNotEqual()
        {
            //Arrange - Given
            var chord1 = new ChordTemplate(ChordType.Minor, new[] { KeyifyClassLibrary.Enums.Note.F, KeyifyClassLibrary.Enums.Note.A, KeyifyClassLibrary.Enums.Note.C });
            //Act - When
            var chord2 = new ChordTemplate(ChordType.Minor, new[] { KeyifyClassLibrary.Enums.Note.C, KeyifyClassLibrary.Enums.Note.A, KeyifyClassLibrary.Enums.Note.F });
            //Assert - Then
            Assert.NotEqual(chord1, chord2);
        }

        private static IEnumerable<object[]> GenerateChordTestArguments()
        {
            var expectedChordNotes1 = new[] { KeyifyClassLibrary.Enums.Note.F, KeyifyClassLibrary.Enums.Note.A, KeyifyClassLibrary.Enums.Note.C };

            return new List<object[]>
            {
                new object[] { expectedChordNotes1, new ChordTemplate(ChordType.Major, expectedChordNotes1) },
            };
        }
    }
}