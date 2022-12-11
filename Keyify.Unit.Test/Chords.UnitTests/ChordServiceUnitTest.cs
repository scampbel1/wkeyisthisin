﻿using Keyify.Enums;
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
        public void PassNoteSequenceIntoChordService_ReturnsExpectedChord(KeyifyClassLibrary.Enums.Note[] selectedChordNotes, ChordTemplate expectedChord)
        {
            //Arrange - Given
            var inputNotes = selectedChordNotes;
            //Act - When
            var chordResult = _chordService.FindChordWithNoteSequence(inputNotes).SingleOrDefault();
            //Assert - Then
            Assert.Equal(expected: expectedChord, actual: chordResult);
            Assert.Equal(expected: expectedChord.ChordType, actual: chordResult.ChordType);
        }

        [Fact]
        public void Chord_SameNotes_SameChordType_DifferentSequence_AreNotStrictEqual()
        {
            //Arrange - Given
            var chord1 = new ChordTemplate(new[] { KeyifyClassLibrary.Enums.Note.F, KeyifyClassLibrary.Enums.Note.A, KeyifyClassLibrary.Enums.Note.C });
            //Act - When
            var chord2 = new ChordTemplate(new[] { KeyifyClassLibrary.Enums.Note.C, KeyifyClassLibrary.Enums.Note.A, KeyifyClassLibrary.Enums.Note.F });
            //Assert - Then
            Assert.NotStrictEqual(chord1, chord2);
        }

        [Fact]
        public void Chord_SameNotes_SameChordType_DifferentSequence_AreNotEqual()
        {
            //Arrange - Given
            var chord1 = new ChordTemplate(new[] { KeyifyClassLibrary.Enums.Note.F, KeyifyClassLibrary.Enums.Note.A, KeyifyClassLibrary.Enums.Note.C });
            //Act - When
            var chord2 = new ChordTemplate(new[] { KeyifyClassLibrary.Enums.Note.C, KeyifyClassLibrary.Enums.Note.A, KeyifyClassLibrary.Enums.Note.F });
            //Assert - Then
            Assert.NotEqual(chord1, chord2);
        }

        private static IEnumerable<object[]> GenerateChordTestArguments()
        {
            var aMajorChordNotes = new[] { KeyifyClassLibrary.Enums.Note.A, KeyifyClassLibrary.Enums.Note.Db, KeyifyClassLibrary.Enums.Note.E };
            var bbMajorChordNotes = new[] { KeyifyClassLibrary.Enums.Note.Bb, KeyifyClassLibrary.Enums.Note.D, KeyifyClassLibrary.Enums.Note.F };
            var bMajorChordNotes = new[] { KeyifyClassLibrary.Enums.Note.B, KeyifyClassLibrary.Enums.Note.Eb, KeyifyClassLibrary.Enums.Note.Gb };
            var cMajorChordNotes = new[] { KeyifyClassLibrary.Enums.Note.C, KeyifyClassLibrary.Enums.Note.E, KeyifyClassLibrary.Enums.Note.G };
            var dbMajorChordNotes = new[] { KeyifyClassLibrary.Enums.Note.Db, KeyifyClassLibrary.Enums.Note.F, KeyifyClassLibrary.Enums.Note.Ab };
            var dMajorChordNotes = new[] { KeyifyClassLibrary.Enums.Note.D, KeyifyClassLibrary.Enums.Note.Gb, KeyifyClassLibrary.Enums.Note.A };
            var ebMajorChordNotes = new[] { KeyifyClassLibrary.Enums.Note.Eb, KeyifyClassLibrary.Enums.Note.G, KeyifyClassLibrary.Enums.Note.Bb };
            var eMajorChordNotes = new[] { KeyifyClassLibrary.Enums.Note.E, KeyifyClassLibrary.Enums.Note.Ab, KeyifyClassLibrary.Enums.Note.B };
            var fMajorChordNotes = new[] { KeyifyClassLibrary.Enums.Note.F, KeyifyClassLibrary.Enums.Note.A, KeyifyClassLibrary.Enums.Note.C };
            var gbMajorChordNotes = new[] { KeyifyClassLibrary.Enums.Note.Gb, KeyifyClassLibrary.Enums.Note.Bb, KeyifyClassLibrary.Enums.Note.Db };
            var gMajorChordNotes = new[] { KeyifyClassLibrary.Enums.Note.G, KeyifyClassLibrary.Enums.Note.B, KeyifyClassLibrary.Enums.Note.D };
            var abMajorChordNotes = new[] { KeyifyClassLibrary.Enums.Note.Ab, KeyifyClassLibrary.Enums.Note.C, KeyifyClassLibrary.Enums.Note.Eb };

            var aMinorChordNotes = new[] { KeyifyClassLibrary.Enums.Note.A, KeyifyClassLibrary.Enums.Note.C, KeyifyClassLibrary.Enums.Note.E };
            var bbMinorChordNotes = new[] { KeyifyClassLibrary.Enums.Note.Bb, KeyifyClassLibrary.Enums.Note.Db, KeyifyClassLibrary.Enums.Note.F };
            var bMinorChordNotes = new[] { KeyifyClassLibrary.Enums.Note.B, KeyifyClassLibrary.Enums.Note.D, KeyifyClassLibrary.Enums.Note.Gb };
            var cMinorChordNotes = new[] { KeyifyClassLibrary.Enums.Note.C, KeyifyClassLibrary.Enums.Note.Eb, KeyifyClassLibrary.Enums.Note.G };
            var dbMinorChordNotes = new[] { KeyifyClassLibrary.Enums.Note.Db, KeyifyClassLibrary.Enums.Note.E, KeyifyClassLibrary.Enums.Note.Ab };
            var dMinorChordNotes = new[] { KeyifyClassLibrary.Enums.Note.D, KeyifyClassLibrary.Enums.Note.F, KeyifyClassLibrary.Enums.Note.A };
            var ebMinorChordNotes = new[] { KeyifyClassLibrary.Enums.Note.Eb, KeyifyClassLibrary.Enums.Note.Gb, KeyifyClassLibrary.Enums.Note.Bb };
            var eMinorChordNotes = new[] { KeyifyClassLibrary.Enums.Note.E, KeyifyClassLibrary.Enums.Note.G, KeyifyClassLibrary.Enums.Note.B };
            var fMinorChordNotes = new[] { KeyifyClassLibrary.Enums.Note.F, KeyifyClassLibrary.Enums.Note.Ab, KeyifyClassLibrary.Enums.Note.C };
            var gbMinorChordNotes = new[] { KeyifyClassLibrary.Enums.Note.Gb, KeyifyClassLibrary.Enums.Note.A, KeyifyClassLibrary.Enums.Note.Db };
            var gMinorChordNotes = new[] { KeyifyClassLibrary.Enums.Note.G, KeyifyClassLibrary.Enums.Note.Bb, KeyifyClassLibrary.Enums.Note.D };
            var abMinorChordNotes = new[] { KeyifyClassLibrary.Enums.Note.Ab, KeyifyClassLibrary.Enums.Note.B, KeyifyClassLibrary.Enums.Note.Eb };

            return new List<object[]>
            {
                new object[] { aMajorChordNotes, new ChordTemplate(ChordType.Major, aMajorChordNotes) },
                new object[] { bbMajorChordNotes, new ChordTemplate(ChordType.Major, bbMajorChordNotes) },
                new object[] { bMajorChordNotes, new ChordTemplate(ChordType.Major, bMajorChordNotes) },
                new object[] { cMajorChordNotes, new ChordTemplate(ChordType.Major, cMajorChordNotes) },
                new object[] { dbMajorChordNotes, new ChordTemplate(ChordType.Major, dbMajorChordNotes) },
                new object[] { dMajorChordNotes, new ChordTemplate(ChordType.Major, dMajorChordNotes) },
                new object[] { ebMajorChordNotes, new ChordTemplate(ChordType.Major, ebMajorChordNotes) },
                new object[] { eMajorChordNotes, new ChordTemplate(ChordType.Major, eMajorChordNotes) },
                new object[] { fMajorChordNotes, new ChordTemplate(ChordType.Major, fMajorChordNotes) },
                new object[] { gbMajorChordNotes, new ChordTemplate(ChordType.Major, gbMajorChordNotes) },
                new object[] { gMajorChordNotes, new ChordTemplate(ChordType.Major, gMajorChordNotes) },
                new object[] { abMajorChordNotes, new ChordTemplate(ChordType.Major, abMajorChordNotes) },

                new object[] { aMinorChordNotes, new ChordTemplate(ChordType.Minor, aMinorChordNotes) },
                new object[] { bbMinorChordNotes, new ChordTemplate(ChordType.Minor, bbMinorChordNotes) },
                new object[] { bMinorChordNotes, new ChordTemplate(ChordType.Minor, bMinorChordNotes) },
                new object[] { cMinorChordNotes, new ChordTemplate(ChordType.Minor, cMinorChordNotes) },
                new object[] { dbMinorChordNotes, new ChordTemplate(ChordType.Minor, dbMinorChordNotes) },
                new object[] { dMinorChordNotes, new ChordTemplate(ChordType.Minor, dMinorChordNotes) },
                new object[] { ebMinorChordNotes, new ChordTemplate(ChordType.Minor, ebMinorChordNotes) },
                new object[] { eMinorChordNotes, new ChordTemplate(ChordType.Minor, eMinorChordNotes) },
                new object[] { fMinorChordNotes, new ChordTemplate(ChordType.Minor, fMinorChordNotes) },
                new object[] { gbMinorChordNotes, new ChordTemplate(ChordType.Minor, gbMinorChordNotes) },
                new object[] { gMinorChordNotes, new ChordTemplate(ChordType.Minor, gMinorChordNotes) },
                new object[] { abMinorChordNotes, new ChordTemplate(ChordType.Minor, abMinorChordNotes) },
            };
        }
    }
}