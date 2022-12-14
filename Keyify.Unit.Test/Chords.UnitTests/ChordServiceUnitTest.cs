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
            Assert.Equal(expected: expectedChord.Type, actual: chordResult.Type);
        }

        [Fact]
        public void SearchChord_A_Major_CorrectNotes_ReturnsChord_CorrectName()
        {
            //Arrange - Given
            var expectedChordName = "A Major";
            var inputNotes = new[] { KeyifyClassLibrary.Enums.Note.A, KeyifyClassLibrary.Enums.Note.Db, KeyifyClassLibrary.Enums.Note.E };
            //Act - When
            var chordResult = _chordService.FindChordWithNoteSequence(inputNotes).SingleOrDefault();
            //Assert - Then
            Assert.Equal(expectedChordName, chordResult.Name);
        }

        [Fact]
        public void SearchChord_Gb_Minor_CorrectNotes_ReturnsChord_CorrectName()
        {
            //Arrange - Given
            var expectedChordName = "Gb Minor";
            var inputNotes = new[] { KeyifyClassLibrary.Enums.Note.Gb, KeyifyClassLibrary.Enums.Note.A, KeyifyClassLibrary.Enums.Note.Db };
            //Act - When
            var chordResult = _chordService.FindChordWithNoteSequence(inputNotes).SingleOrDefault();
            //Assert - Then
            Assert.Equal(expectedChordName, chordResult.Name);
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

        //TODO: Test for Flat to Sharp name conversion

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
            var majorChordType = ChordType.Major;
            var minorChordType = ChordType.Minor;
            var diminishedChordType = ChordType.Diminished;
            var majorSeventhChordType = ChordType.MajorSeventh;
            var minorSeventhChordType = ChordType.MinorSeventh;
            var dominantSeventhChordType = ChordType.DominantSeventh;
            var suspendedSecondChordType = ChordType.SuspendedSecond;
            var suspendedFourthChordType = ChordType.SuspendedFourth;
            var augmentedChordType = ChordType.Augmented;
            var majorNinthChordType = ChordType.MajorNinth;
            var minorNinthChordType = ChordType.MinorNinth;
            var dominantNinthChordType = ChordType.DominantNinth;
            var majorEleventhChordType = ChordType.MajorEleventh;
            var minorEleventhChordType = ChordType.MinorEleventh;
            var majorThirteenthChordType = ChordType.MajorThirteenth;
            var minorThirteenthChordType = ChordType.MinorThirteenth;

            //TODO: Throw exception if not all chord types are tested

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

            var aDiminishedChordNotes = new[] { KeyifyClassLibrary.Enums.Note.A, KeyifyClassLibrary.Enums.Note.C, KeyifyClassLibrary.Enums.Note.Eb };
            var bbDiminishedChordNotes = new[] { KeyifyClassLibrary.Enums.Note.Bb, KeyifyClassLibrary.Enums.Note.Db, KeyifyClassLibrary.Enums.Note.E };
            var bDiminishedChordNotes = new[] { KeyifyClassLibrary.Enums.Note.B, KeyifyClassLibrary.Enums.Note.D, KeyifyClassLibrary.Enums.Note.F };
            var cDiminishedChordNotes = new[] { KeyifyClassLibrary.Enums.Note.C, KeyifyClassLibrary.Enums.Note.Eb, KeyifyClassLibrary.Enums.Note.Gb };
            var dbDiminishedChordNotes = new[] { KeyifyClassLibrary.Enums.Note.Db, KeyifyClassLibrary.Enums.Note.E, KeyifyClassLibrary.Enums.Note.G };
            var dDiminishedChordNotes = new[] { KeyifyClassLibrary.Enums.Note.D, KeyifyClassLibrary.Enums.Note.F, KeyifyClassLibrary.Enums.Note.Ab };
            var ebDiminishedChordNotes = new[] { KeyifyClassLibrary.Enums.Note.Eb, KeyifyClassLibrary.Enums.Note.Gb, KeyifyClassLibrary.Enums.Note.A };
            var eDiminishedChordNotes = new[] { KeyifyClassLibrary.Enums.Note.E, KeyifyClassLibrary.Enums.Note.G, KeyifyClassLibrary.Enums.Note.Bb };
            var fDiminishedChordNotes = new[] { KeyifyClassLibrary.Enums.Note.F, KeyifyClassLibrary.Enums.Note.Ab, KeyifyClassLibrary.Enums.Note.B };
            var gbDiminishedChordNotes = new[] { KeyifyClassLibrary.Enums.Note.Gb, KeyifyClassLibrary.Enums.Note.A, KeyifyClassLibrary.Enums.Note.C };
            var gDiminishedChordNotes = new[] { KeyifyClassLibrary.Enums.Note.G, KeyifyClassLibrary.Enums.Note.Bb, KeyifyClassLibrary.Enums.Note.Db };
            var abDiminishedChordNotes = new[] { KeyifyClassLibrary.Enums.Note.Ab, KeyifyClassLibrary.Enums.Note.B, KeyifyClassLibrary.Enums.Note.D };

            var cMajorSeventhChordNotes = new[] { KeyifyClassLibrary.Enums.Note.C, KeyifyClassLibrary.Enums.Note.E, KeyifyClassLibrary.Enums.Note.G, KeyifyClassLibrary.Enums.Note.B };
            var cMinorSeventhChordNotes = new[] { KeyifyClassLibrary.Enums.Note.C, KeyifyClassLibrary.Enums.Note.Eb, KeyifyClassLibrary.Enums.Note.G, KeyifyClassLibrary.Enums.Note.Bb };
            var cDominantSeventhChordNotes = new[] { KeyifyClassLibrary.Enums.Note.C, KeyifyClassLibrary.Enums.Note.E, KeyifyClassLibrary.Enums.Note.G, KeyifyClassLibrary.Enums.Note.Bb };
            var cSuspended2ChordNotes = new[] { KeyifyClassLibrary.Enums.Note.C, KeyifyClassLibrary.Enums.Note.D, KeyifyClassLibrary.Enums.Note.G };
            var cSuspended4ChordNotes = new[] { KeyifyClassLibrary.Enums.Note.C, KeyifyClassLibrary.Enums.Note.F, KeyifyClassLibrary.Enums.Note.G };
            var cAugmentedChordNotes = new[] { KeyifyClassLibrary.Enums.Note.C, KeyifyClassLibrary.Enums.Note.E, KeyifyClassLibrary.Enums.Note.Ab };
            var cMajorNinthChordNotes = new[] { KeyifyClassLibrary.Enums.Note.C, KeyifyClassLibrary.Enums.Note.E, KeyifyClassLibrary.Enums.Note.G, KeyifyClassLibrary.Enums.Note.B, KeyifyClassLibrary.Enums.Note.D };
            var cMinorNinthChordNotes = new[] { KeyifyClassLibrary.Enums.Note.C, KeyifyClassLibrary.Enums.Note.Eb, KeyifyClassLibrary.Enums.Note.G, KeyifyClassLibrary.Enums.Note.Bb, KeyifyClassLibrary.Enums.Note.D };
            var cDominantNinthChordNotes = new[] { KeyifyClassLibrary.Enums.Note.C, KeyifyClassLibrary.Enums.Note.E, KeyifyClassLibrary.Enums.Note.G, KeyifyClassLibrary.Enums.Note.Bb, KeyifyClassLibrary.Enums.Note.D };
            var cMajorEleventhChordNotes = new[] { KeyifyClassLibrary.Enums.Note.C, KeyifyClassLibrary.Enums.Note.E, KeyifyClassLibrary.Enums.Note.G, KeyifyClassLibrary.Enums.Note.B, KeyifyClassLibrary.Enums.Note.D, KeyifyClassLibrary.Enums.Note.F };
            var cMinorEleventhChordNotes = new[] { KeyifyClassLibrary.Enums.Note.C, KeyifyClassLibrary.Enums.Note.Eb, KeyifyClassLibrary.Enums.Note.G, KeyifyClassLibrary.Enums.Note.Bb, KeyifyClassLibrary.Enums.Note.D, KeyifyClassLibrary.Enums.Note.F };
            var cMajorThirteenthChordNotes = new[] { KeyifyClassLibrary.Enums.Note.C, KeyifyClassLibrary.Enums.Note.E, KeyifyClassLibrary.Enums.Note.G, KeyifyClassLibrary.Enums.Note.B, KeyifyClassLibrary.Enums.Note.D, KeyifyClassLibrary.Enums.Note.F, KeyifyClassLibrary.Enums.Note.A };
            var cMinorThirteenthChordNotes = new[] { KeyifyClassLibrary.Enums.Note.C, KeyifyClassLibrary.Enums.Note.Eb, KeyifyClassLibrary.Enums.Note.G, KeyifyClassLibrary.Enums.Note.Bb, KeyifyClassLibrary.Enums.Note.D, KeyifyClassLibrary.Enums.Note.F, KeyifyClassLibrary.Enums.Note.A };

            return new List<object[]>
            {
                new object[] { aMajorChordNotes, new ChordTemplate(majorChordType, aMajorChordNotes) },
                new object[] { bbMajorChordNotes, new ChordTemplate(majorChordType, bbMajorChordNotes) },
                new object[] { bMajorChordNotes, new ChordTemplate(majorChordType, bMajorChordNotes) },
                new object[] { cMajorChordNotes, new ChordTemplate(majorChordType, cMajorChordNotes) },
                new object[] { dbMajorChordNotes, new ChordTemplate(majorChordType, dbMajorChordNotes) },
                new object[] { dMajorChordNotes, new ChordTemplate(majorChordType, dMajorChordNotes) },
                new object[] { ebMajorChordNotes, new ChordTemplate(majorChordType, ebMajorChordNotes) },
                new object[] { eMajorChordNotes, new ChordTemplate(majorChordType, eMajorChordNotes) },
                new object[] { fMajorChordNotes, new ChordTemplate(majorChordType, fMajorChordNotes) },
                new object[] { gbMajorChordNotes, new ChordTemplate(majorChordType, gbMajorChordNotes) },
                new object[] { gMajorChordNotes, new ChordTemplate(majorChordType, gMajorChordNotes) },
                new object[] { abMajorChordNotes, new ChordTemplate(majorChordType, abMajorChordNotes) },

                new object[] { aMinorChordNotes, new ChordTemplate(minorChordType, aMinorChordNotes) },
                new object[] { bbMinorChordNotes, new ChordTemplate(minorChordType, bbMinorChordNotes) },
                new object[] { bMinorChordNotes, new ChordTemplate(minorChordType, bMinorChordNotes) },
                new object[] { cMinorChordNotes, new ChordTemplate(minorChordType, cMinorChordNotes) },
                new object[] { dbMinorChordNotes, new ChordTemplate(minorChordType, dbMinorChordNotes) },
                new object[] { dMinorChordNotes, new ChordTemplate(minorChordType, dMinorChordNotes) },
                new object[] { ebMinorChordNotes, new ChordTemplate(minorChordType, ebMinorChordNotes) },
                new object[] { eMinorChordNotes, new ChordTemplate(minorChordType, eMinorChordNotes) },
                new object[] { fMinorChordNotes, new ChordTemplate(minorChordType, fMinorChordNotes) },
                new object[] { gbMinorChordNotes, new ChordTemplate(minorChordType, gbMinorChordNotes) },
                new object[] { gMinorChordNotes, new ChordTemplate(minorChordType, gMinorChordNotes) },
                new object[] { abMinorChordNotes, new ChordTemplate(minorChordType, abMinorChordNotes) },

                new object[] { aDiminishedChordNotes, new ChordTemplate(diminishedChordType, aDiminishedChordNotes) },
                new object[] { bbDiminishedChordNotes, new ChordTemplate(diminishedChordType, bbDiminishedChordNotes) },
                new object[] { bDiminishedChordNotes, new ChordTemplate(diminishedChordType, bDiminishedChordNotes) },
                new object[] { cDiminishedChordNotes, new ChordTemplate(diminishedChordType, cDiminishedChordNotes) },
                new object[] { dbDiminishedChordNotes, new ChordTemplate(diminishedChordType, dbDiminishedChordNotes) },
                new object[] { dDiminishedChordNotes, new ChordTemplate(diminishedChordType, dDiminishedChordNotes) },
                new object[] { ebDiminishedChordNotes, new ChordTemplate(diminishedChordType, ebDiminishedChordNotes) },
                new object[] { eDiminishedChordNotes, new ChordTemplate(diminishedChordType, eDiminishedChordNotes) },
                new object[] { fDiminishedChordNotes, new ChordTemplate(diminishedChordType, fDiminishedChordNotes) },
                new object[] { gbDiminishedChordNotes, new ChordTemplate(diminishedChordType, gbDiminishedChordNotes) },
                new object[] { gDiminishedChordNotes, new ChordTemplate(diminishedChordType, gDiminishedChordNotes) },
                new object[] { abDiminishedChordNotes, new ChordTemplate(diminishedChordType, abDiminishedChordNotes) },

                new object[] { cMajorSeventhChordNotes, new ChordTemplate(majorSeventhChordType, cMajorSeventhChordNotes) },
                new object[] { cMinorSeventhChordNotes, new ChordTemplate(minorSeventhChordType, cMinorSeventhChordNotes) },
                new object[] { cDominantSeventhChordNotes, new ChordTemplate(dominantSeventhChordType, cDominantSeventhChordNotes) },
                new object[] { cSuspended2ChordNotes, new ChordTemplate(suspendedSecondChordType, cSuspended2ChordNotes) },
                new object[] { cSuspended4ChordNotes, new ChordTemplate(suspendedFourthChordType, cSuspended4ChordNotes) },
                new object[] { cAugmentedChordNotes, new ChordTemplate(augmentedChordType, cAugmentedChordNotes) },
                new object[] { cMajorNinthChordNotes, new ChordTemplate(majorNinthChordType, cMajorNinthChordNotes) },
                new object[] { cMinorNinthChordNotes, new ChordTemplate(minorNinthChordType, cMinorNinthChordNotes) },
                new object[] { cDominantNinthChordNotes, new ChordTemplate(dominantNinthChordType, cDominantNinthChordNotes) },
                new object[] { cMajorEleventhChordNotes, new ChordTemplate(majorEleventhChordType, cMajorEleventhChordNotes) },
                new object[] { cMinorEleventhChordNotes, new ChordTemplate(minorEleventhChordType, cMinorEleventhChordNotes) },
                new object[] { cMajorThirteenthChordNotes, new ChordTemplate(majorThirteenthChordType, cMajorThirteenthChordNotes) },
                new object[] { cMinorThirteenthChordNotes, new ChordTemplate(minorThirteenthChordType, cMinorThirteenthChordNotes) },
            };
        }
    }
}