using Keyify.Enums;
using Keyify.Models.ServiceModels;
using Keyify.Service;
using Keyify.Service.Caches;
using Keyify.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Keyify.Unit.Test.ChordDefinitions.UnitTests
{
    public class ChordDefinitionServiceUnitTest
    {
        public static IEnumerable<object[]> ChordTestParameters => GenerateChordTestArguments();

        private IChordDefinitionService _chordDefinitionService = new ChordDefinitionService(new ChordDefinitionDataCache());

        [Theory, MemberData(nameof(ChordTestParameters))]
        public void PassNoteSequenceIntoChordService_ReturnsExpectedChord(KeyifyClassLibrary.Enums.Note[] selectedChordNotes, ChordDefinition expectedChordDefinition)
        {
            //Arrange - Given
            var inputNotes = selectedChordNotes;

            //Act - When
            var chordDefinitions = _chordDefinitionService.FindChordDefinitions(inputNotes);
            var result = chordDefinitions.SingleOrDefault(c => c == expectedChordDefinition);

            //Assert - Then
            Assert.Equal(expectedChordDefinition, result);
            Assert.Equal(expectedChordDefinition.Type, result.Type);
        }

        [Fact]
        public void SearchChord_A_Major_Notes_ReturnsChordWithinSet()
        {
            //Arrange - Given
            var expectedChordName = "A Major";
            var inputNotes = new[] { KeyifyClassLibrary.Enums.Note.A, KeyifyClassLibrary.Enums.Note.Db, KeyifyClassLibrary.Enums.Note.E };

            //Act - When
            var chordDefinitions = _chordDefinitionService.FindChordDefinitions(inputNotes);

            var result = chordDefinitions.SingleOrDefault(c => c.Name == expectedChordName);

            //Assert - Then
            Assert.NotNull(result);
            Assert.Equal(expectedChordName, result.Name);
        }

        [Fact]
        public void SearchChord_Gb_Minor_Notes_ReturnsChordWithinSet()
        {
            //Arrange - Given
            var expectedChordName = "Gb Minor";
            var inputNotes = new[] { KeyifyClassLibrary.Enums.Note.Gb, KeyifyClassLibrary.Enums.Note.A, KeyifyClassLibrary.Enums.Note.Db };

            //Act - When
            var chordDefinitions = _chordDefinitionService.FindChordDefinitions(inputNotes);

            var result = chordDefinitions.SingleOrDefault(c => c.Name == expectedChordName);

            //Assert - Then
            Assert.NotNull(result);
            Assert.Equal(expectedChordName, result.Name);
        }

        [Fact]
        public void Chord_SameNotes_SameChordType_DifferentSequence_AreNotStrictEqual()
        {
            //Arrange - Given
            var chord1 = new ChordDefinition(ChordType.Major, new[] { KeyifyClassLibrary.Enums.Note.F, KeyifyClassLibrary.Enums.Note.A, KeyifyClassLibrary.Enums.Note.C });

            //Act - When
            var chord2 = new ChordDefinition(ChordType.Major, new[] { KeyifyClassLibrary.Enums.Note.C, KeyifyClassLibrary.Enums.Note.A, KeyifyClassLibrary.Enums.Note.F });

            //Assert - Then
            Assert.NotStrictEqual(chord1, chord2);
        }

        //TODO: Test for Flat to Sharp name conversion

        [Fact]
        public void Chord_SameNotes_SameChordType_DifferentSequence_AreNotEqual()
        {
            //Arrange - Given
            var chord1 = new ChordDefinition(ChordType.Major, new[] { KeyifyClassLibrary.Enums.Note.F, KeyifyClassLibrary.Enums.Note.A, KeyifyClassLibrary.Enums.Note.C });

            //Act - When
            var chord2 = new ChordDefinition(ChordType.Major, new[] { KeyifyClassLibrary.Enums.Note.C, KeyifyClassLibrary.Enums.Note.A, KeyifyClassLibrary.Enums.Note.F });

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
            var dominantEleventhChordType = ChordType.DominantEleventh;
            var majorThirteenthChordType = ChordType.MajorThirteenth;
            var minorThirteenthChordType = ChordType.MinorThirteenth;
            var dominantThirteenthChordType = ChordType.DominantThirteenth;

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
            var cDominantEleventhChordNotes = new[] { KeyifyClassLibrary.Enums.Note.C, KeyifyClassLibrary.Enums.Note.E, KeyifyClassLibrary.Enums.Note.G, KeyifyClassLibrary.Enums.Note.Bb, KeyifyClassLibrary.Enums.Note.D, KeyifyClassLibrary.Enums.Note.F };
            var cMajorThirteenthChordNotes = new[] { KeyifyClassLibrary.Enums.Note.C, KeyifyClassLibrary.Enums.Note.E, KeyifyClassLibrary.Enums.Note.G, KeyifyClassLibrary.Enums.Note.B, KeyifyClassLibrary.Enums.Note.D, KeyifyClassLibrary.Enums.Note.F, KeyifyClassLibrary.Enums.Note.A };
            var cMinorThirteenthChordNotes = new[] { KeyifyClassLibrary.Enums.Note.C, KeyifyClassLibrary.Enums.Note.Eb, KeyifyClassLibrary.Enums.Note.G, KeyifyClassLibrary.Enums.Note.Bb, KeyifyClassLibrary.Enums.Note.D, KeyifyClassLibrary.Enums.Note.F, KeyifyClassLibrary.Enums.Note.A };
            var cDominantThirteenthChordNotes = new[] { KeyifyClassLibrary.Enums.Note.C, KeyifyClassLibrary.Enums.Note.E, KeyifyClassLibrary.Enums.Note.G, KeyifyClassLibrary.Enums.Note.Bb, KeyifyClassLibrary.Enums.Note.D, KeyifyClassLibrary.Enums.Note.F, KeyifyClassLibrary.Enums.Note.A };

            return new List<object[]>
            {
                new object[] { aMajorChordNotes, new ChordDefinition(majorChordType, aMajorChordNotes) },
                new object[] { bbMajorChordNotes, new ChordDefinition(majorChordType, bbMajorChordNotes) },
                new object[] { bMajorChordNotes, new ChordDefinition(majorChordType, bMajorChordNotes) },
                new object[] { cMajorChordNotes, new ChordDefinition(majorChordType, cMajorChordNotes) },
                new object[] { dbMajorChordNotes, new ChordDefinition(majorChordType, dbMajorChordNotes) },
                new object[] { dMajorChordNotes, new ChordDefinition(majorChordType, dMajorChordNotes) },
                new object[] { ebMajorChordNotes, new ChordDefinition(majorChordType, ebMajorChordNotes) },
                new object[] { eMajorChordNotes, new ChordDefinition(majorChordType, eMajorChordNotes) },
                new object[] { fMajorChordNotes, new ChordDefinition(majorChordType, fMajorChordNotes) },
                new object[] { gbMajorChordNotes, new ChordDefinition(majorChordType, gbMajorChordNotes) },
                new object[] { gMajorChordNotes, new ChordDefinition(majorChordType, gMajorChordNotes) },
                new object[] { abMajorChordNotes, new ChordDefinition(majorChordType, abMajorChordNotes) },

                new object[] { aMinorChordNotes, new ChordDefinition(minorChordType, aMinorChordNotes) },
                new object[] { bbMinorChordNotes, new ChordDefinition(minorChordType, bbMinorChordNotes) },
                new object[] { bMinorChordNotes, new ChordDefinition(minorChordType, bMinorChordNotes) },
                new object[] { cMinorChordNotes, new ChordDefinition(minorChordType, cMinorChordNotes) },
                new object[] { dbMinorChordNotes, new ChordDefinition(minorChordType, dbMinorChordNotes) },
                new object[] { dMinorChordNotes, new ChordDefinition(minorChordType, dMinorChordNotes) },
                new object[] { ebMinorChordNotes, new ChordDefinition(minorChordType, ebMinorChordNotes) },
                new object[] { eMinorChordNotes, new ChordDefinition(minorChordType, eMinorChordNotes) },
                new object[] { fMinorChordNotes, new ChordDefinition(minorChordType, fMinorChordNotes) },
                new object[] { gbMinorChordNotes, new ChordDefinition(minorChordType, gbMinorChordNotes) },
                new object[] { gMinorChordNotes, new ChordDefinition(minorChordType, gMinorChordNotes) },
                new object[] { abMinorChordNotes, new ChordDefinition(minorChordType, abMinorChordNotes) },

                new object[] { aDiminishedChordNotes, new ChordDefinition(diminishedChordType, aDiminishedChordNotes) },
                new object[] { bbDiminishedChordNotes, new ChordDefinition(diminishedChordType, bbDiminishedChordNotes) },
                new object[] { bDiminishedChordNotes, new ChordDefinition(diminishedChordType, bDiminishedChordNotes) },
                new object[] { cDiminishedChordNotes, new ChordDefinition(diminishedChordType, cDiminishedChordNotes) },
                new object[] { dbDiminishedChordNotes, new ChordDefinition(diminishedChordType, dbDiminishedChordNotes) },
                new object[] { dDiminishedChordNotes, new ChordDefinition(diminishedChordType, dDiminishedChordNotes) },
                new object[] { ebDiminishedChordNotes, new ChordDefinition(diminishedChordType, ebDiminishedChordNotes) },
                new object[] { eDiminishedChordNotes, new ChordDefinition(diminishedChordType, eDiminishedChordNotes) },
                new object[] { fDiminishedChordNotes, new ChordDefinition(diminishedChordType, fDiminishedChordNotes) },
                new object[] { gbDiminishedChordNotes, new ChordDefinition(diminishedChordType, gbDiminishedChordNotes) },
                new object[] { gDiminishedChordNotes, new ChordDefinition(diminishedChordType, gDiminishedChordNotes) },
                new object[] { abDiminishedChordNotes, new ChordDefinition(diminishedChordType, abDiminishedChordNotes) },

                new object[] { cMajorSeventhChordNotes, new ChordDefinition(majorSeventhChordType, cMajorSeventhChordNotes) },
                new object[] { cMinorSeventhChordNotes, new ChordDefinition(minorSeventhChordType, cMinorSeventhChordNotes) },
                new object[] { cDominantSeventhChordNotes, new ChordDefinition(dominantSeventhChordType, cDominantSeventhChordNotes) },
                new object[] { cSuspended2ChordNotes, new ChordDefinition(suspendedSecondChordType, cSuspended2ChordNotes) },
                new object[] { cSuspended4ChordNotes, new ChordDefinition(suspendedFourthChordType, cSuspended4ChordNotes) },
                new object[] { cAugmentedChordNotes, new ChordDefinition(augmentedChordType, cAugmentedChordNotes) },
                new object[] { cMajorNinthChordNotes, new ChordDefinition(majorNinthChordType, cMajorNinthChordNotes) },
                new object[] { cMinorNinthChordNotes, new ChordDefinition(minorNinthChordType, cMinorNinthChordNotes) },
                new object[] { cDominantNinthChordNotes, new ChordDefinition(dominantNinthChordType, cDominantNinthChordNotes) },
                new object[] { cMajorEleventhChordNotes, new ChordDefinition(majorEleventhChordType, cMajorEleventhChordNotes) },
                new object[] { cMinorEleventhChordNotes, new ChordDefinition(minorEleventhChordType, cMinorEleventhChordNotes) },
                new object[] { cDominantEleventhChordNotes, new ChordDefinition(dominantEleventhChordType, cDominantEleventhChordNotes) },
                new object[] { cMajorThirteenthChordNotes, new ChordDefinition(majorThirteenthChordType, cMajorThirteenthChordNotes) },
                new object[] { cMinorThirteenthChordNotes, new ChordDefinition(minorThirteenthChordType, cMinorThirteenthChordNotes) },
                new object[] { cDominantThirteenthChordNotes, new ChordDefinition(dominantThirteenthChordType, cDominantThirteenthChordNotes) },
            };
        }
    }
}