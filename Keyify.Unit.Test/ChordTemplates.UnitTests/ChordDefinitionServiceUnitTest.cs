using Keyify.Infrastructure.Caches.Interfaces;
using Keyify.MusicTheory.Enums;
using Keyify.Service;
using Keyify.Service.Interfaces;
using Keyify.Services.Models;
using Keyify.Web.Infrastructure.Repository.Interfaces;
using Keyify.Web.Unit.Test.ChordTemplates.UnitTests.Mocks;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Keyify.Unit.Test.ChordDefinitions.UnitTests
{
    public class ChordDefinitionServiceUnitTest
    {
        private static IChordDefinitionDataCache _dataCache = new MockChordDefinitionDataCache();
        private static IChordDefinitionRepository _repository = new MockChordDefinitionRepository();
        private static IChordDefinitionService _chordDefinitionService = new ChordDefinitionService(_dataCache, _repository);

        public static IEnumerable<object[]> ChordTestParameters => GenerateChordTestArguments();

        [Theory, MemberData(nameof(ChordTestParameters))]
        public async Task PassNoteSequenceIntoChordService_ReturnsExpectedChord(MusicTheory.Enums.Note[] selectedChordNotes, ChordDefinition expectedChordDefinition)
        {
            //Arrange - Given
            var inputNotes = selectedChordNotes;

            //Act - When
            var chordDefinitions = await _chordDefinitionService.FindChordDefinitions(inputNotes);
            var result = chordDefinitions.SingleOrDefault(c => c == expectedChordDefinition);

            //Assert - Then
            Assert.Equal(expectedChordDefinition, result);
            Assert.Equal(expectedChordDefinition.Type, result.Type);
        }

        [Fact]
        public async Task SearchChord_A_Major_Notes_ReturnsChordWithinSet()
        {
            //Arrange - Given
            var expectedChordName = "A Major";
            var inputNotes = new[] { MusicTheory.Enums.Note.A, MusicTheory.Enums.Note.Db, MusicTheory.Enums.Note.E };

            //Act - When
            var chordDefinitions = await _chordDefinitionService.FindChordDefinitions(inputNotes);

            var result = chordDefinitions.SingleOrDefault(c => c.Name == expectedChordName);

            //Assert - Then
            Assert.NotNull(result);
            Assert.Equal(expectedChordName, result.Name);
        }

        [Fact]
        public async Task SearchChord_Gb_Minor_Notes_ReturnsChordWithinSet()
        {
            var dataCache = new MockChordDefinitionDataCache();
            var repository = new MockChordDefinitionRepository();
            var chordDefinitionService = new ChordDefinitionService(dataCache, repository);

            //Arrange - Given
            var expectedChordName = "Gb Minor";
            var inputNotes = new[] { MusicTheory.Enums.Note.Gb, MusicTheory.Enums.Note.A, MusicTheory.Enums.Note.Db };

            //Act - When
            var chordDefinitions = await chordDefinitionService.FindChordDefinitions(inputNotes);

            var result = chordDefinitions.SingleOrDefault(c => c.Name == expectedChordName);

            //Assert - Then
            Assert.NotNull(result);
            Assert.Equal(expectedChordName, result.Name);
        }

        [Fact]
        public void Chord_SameNotes_SameChordType_DifferentSequence_AreNotStrictEqual()
        {
            //Arrange - Given
            var chord1 = new ChordDefinition(ChordType.Major.ToString(), new[] { MusicTheory.Enums.Note.F, MusicTheory.Enums.Note.A, MusicTheory.Enums.Note.C });

            //Act - When
            var chord2 = new ChordDefinition(ChordType.Major.ToString(), new[] { MusicTheory.Enums.Note.C, MusicTheory.Enums.Note.A, MusicTheory.Enums.Note.F });

            //Assert - Then
            Assert.NotStrictEqual(chord1, chord2);
        }

        //TODO: Test for Flat to Sharp name conversion

        [Fact]
        public void Chord_SameNotes_SameChordType_DifferentSequence_AreNotEqual()
        {
            //Arrange - Given
            var chord1 = new ChordDefinition(ChordType.Major.ToString(), new[] { MusicTheory.Enums.Note.F, MusicTheory.Enums.Note.A, MusicTheory.Enums.Note.C });

            //Act - When
            var chord2 = new ChordDefinition(ChordType.Major.ToString(), new[] { MusicTheory.Enums.Note.C, MusicTheory.Enums.Note.A, MusicTheory.Enums.Note.F });

            //Assert - Then
            Assert.NotEqual(chord1, chord2);
        }

        private static IEnumerable<object[]> GenerateChordTestArguments()
        {
            var majorChordType = ChordType.Major.ToString();
            var minorChordType = ChordType.Minor.ToString();
            var diminishedChordType = ChordType.Diminished.ToString();
            var majorSeventhChordType = ChordType.MajorSeventh.ToString();
            var minorSeventhChordType = ChordType.MinorSeventh.ToString();
            var dominantSeventhChordType = ChordType.DominantSeventh.ToString();
            var suspendedSecondChordType = ChordType.SuspendedSecond.ToString();
            var suspendedFourthChordType = ChordType.SuspendedFourth.ToString();
            var augmentedChordType = ChordType.Augmented.ToString();
            var majorNinthChordType = ChordType.MajorNinth.ToString();
            var minorNinthChordType = ChordType.MinorNinth.ToString();
            var dominantNinthChordType = ChordType.DominantNinth.ToString();
            var majorEleventhChordType = ChordType.MajorEleventh.ToString();
            var minorEleventhChordType = ChordType.MinorEleventh.ToString();
            var dominantEleventhChordType = ChordType.DominantEleventh.ToString();
            var majorThirteenthChordType = ChordType.MajorThirteenth.ToString();
            var minorThirteenthChordType = ChordType.MinorThirteenth.ToString();
            var dominantThirteenthChordType = ChordType.DominantThirteenth.ToString();

            //TODO: Throw exception if not all chord types are tested

            var aMajorChordNotes = new[] { MusicTheory.Enums.Note.A, MusicTheory.Enums.Note.Db, MusicTheory.Enums.Note.E };
            var bbMajorChordNotes = new[] { MusicTheory.Enums.Note.Bb, MusicTheory.Enums.Note.D, MusicTheory.Enums.Note.F };
            var bMajorChordNotes = new[] { MusicTheory.Enums.Note.B, MusicTheory.Enums.Note.Eb, MusicTheory.Enums.Note.Gb };
            var cMajorChordNotes = new[] { MusicTheory.Enums.Note.C, MusicTheory.Enums.Note.E, MusicTheory.Enums.Note.G };
            var dbMajorChordNotes = new[] { MusicTheory.Enums.Note.Db, MusicTheory.Enums.Note.F, MusicTheory.Enums.Note.Ab };
            var dMajorChordNotes = new[] { MusicTheory.Enums.Note.D, MusicTheory.Enums.Note.Gb, MusicTheory.Enums.Note.A };
            var ebMajorChordNotes = new[] { MusicTheory.Enums.Note.Eb, MusicTheory.Enums.Note.G, MusicTheory.Enums.Note.Bb };
            var eMajorChordNotes = new[] { MusicTheory.Enums.Note.E, MusicTheory.Enums.Note.Ab, MusicTheory.Enums.Note.B };
            var fMajorChordNotes = new[] { MusicTheory.Enums.Note.F, MusicTheory.Enums.Note.A, MusicTheory.Enums.Note.C };
            var gbMajorChordNotes = new[] { MusicTheory.Enums.Note.Gb, MusicTheory.Enums.Note.Bb, MusicTheory.Enums.Note.Db };
            var gMajorChordNotes = new[] { MusicTheory.Enums.Note.G, MusicTheory.Enums.Note.B, MusicTheory.Enums.Note.D };
            var abMajorChordNotes = new[] { MusicTheory.Enums.Note.Ab, MusicTheory.Enums.Note.C, MusicTheory.Enums.Note.Eb };

            var aMinorChordNotes = new[] { MusicTheory.Enums.Note.A, MusicTheory.Enums.Note.C, MusicTheory.Enums.Note.E };
            var bbMinorChordNotes = new[] { MusicTheory.Enums.Note.Bb, MusicTheory.Enums.Note.Db, MusicTheory.Enums.Note.F };
            var bMinorChordNotes = new[] { MusicTheory.Enums.Note.B, MusicTheory.Enums.Note.D, MusicTheory.Enums.Note.Gb };
            var cMinorChordNotes = new[] { MusicTheory.Enums.Note.C, MusicTheory.Enums.Note.Eb, MusicTheory.Enums.Note.G };
            var dbMinorChordNotes = new[] { MusicTheory.Enums.Note.Db, MusicTheory.Enums.Note.E, MusicTheory.Enums.Note.Ab };
            var dMinorChordNotes = new[] { MusicTheory.Enums.Note.D, MusicTheory.Enums.Note.F, MusicTheory.Enums.Note.A };
            var ebMinorChordNotes = new[] { MusicTheory.Enums.Note.Eb, MusicTheory.Enums.Note.Gb, MusicTheory.Enums.Note.Bb };
            var eMinorChordNotes = new[] { MusicTheory.Enums.Note.E, MusicTheory.Enums.Note.G, MusicTheory.Enums.Note.B };
            var fMinorChordNotes = new[] { MusicTheory.Enums.Note.F, MusicTheory.Enums.Note.Ab, MusicTheory.Enums.Note.C };
            var gbMinorChordNotes = new[] { MusicTheory.Enums.Note.Gb, MusicTheory.Enums.Note.A, MusicTheory.Enums.Note.Db };
            var gMinorChordNotes = new[] { MusicTheory.Enums.Note.G, MusicTheory.Enums.Note.Bb, MusicTheory.Enums.Note.D };
            var abMinorChordNotes = new[] { MusicTheory.Enums.Note.Ab, MusicTheory.Enums.Note.B, MusicTheory.Enums.Note.Eb };

            var aDiminishedChordNotes = new[] { MusicTheory.Enums.Note.A, MusicTheory.Enums.Note.C, MusicTheory.Enums.Note.Eb };
            var bbDiminishedChordNotes = new[] { MusicTheory.Enums.Note.Bb, MusicTheory.Enums.Note.Db, MusicTheory.Enums.Note.E };
            var bDiminishedChordNotes = new[] { MusicTheory.Enums.Note.B, MusicTheory.Enums.Note.D, MusicTheory.Enums.Note.F };
            var cDiminishedChordNotes = new[] { MusicTheory.Enums.Note.C, MusicTheory.Enums.Note.Eb, MusicTheory.Enums.Note.Gb };
            var dbDiminishedChordNotes = new[] { MusicTheory.Enums.Note.Db, MusicTheory.Enums.Note.E, MusicTheory.Enums.Note.G };
            var dDiminishedChordNotes = new[] { MusicTheory.Enums.Note.D, MusicTheory.Enums.Note.F, MusicTheory.Enums.Note.Ab };
            var ebDiminishedChordNotes = new[] { MusicTheory.Enums.Note.Eb, MusicTheory.Enums.Note.Gb, MusicTheory.Enums.Note.A };
            var eDiminishedChordNotes = new[] { MusicTheory.Enums.Note.E, MusicTheory.Enums.Note.G, MusicTheory.Enums.Note.Bb };
            var fDiminishedChordNotes = new[] { MusicTheory.Enums.Note.F, MusicTheory.Enums.Note.Ab, MusicTheory.Enums.Note.B };
            var gbDiminishedChordNotes = new[] { MusicTheory.Enums.Note.Gb, MusicTheory.Enums.Note.A, MusicTheory.Enums.Note.C };
            var gDiminishedChordNotes = new[] { MusicTheory.Enums.Note.G, MusicTheory.Enums.Note.Bb, MusicTheory.Enums.Note.Db };
            var abDiminishedChordNotes = new[] { MusicTheory.Enums.Note.Ab, MusicTheory.Enums.Note.B, MusicTheory.Enums.Note.D };

            var cMajorSeventhChordNotes = new[] { MusicTheory.Enums.Note.C, MusicTheory.Enums.Note.E, MusicTheory.Enums.Note.G, MusicTheory.Enums.Note.B };
            var cMinorSeventhChordNotes = new[] { MusicTheory.Enums.Note.C, MusicTheory.Enums.Note.Eb, MusicTheory.Enums.Note.G, MusicTheory.Enums.Note.Bb };
            var cDominantSeventhChordNotes = new[] { MusicTheory.Enums.Note.C, MusicTheory.Enums.Note.E, MusicTheory.Enums.Note.G, MusicTheory.Enums.Note.Bb };
            var cSuspended2ChordNotes = new[] { MusicTheory.Enums.Note.C, MusicTheory.Enums.Note.D, MusicTheory.Enums.Note.G };
            var cSuspended4ChordNotes = new[] { MusicTheory.Enums.Note.C, MusicTheory.Enums.Note.F, MusicTheory.Enums.Note.G };
            var cAugmentedChordNotes = new[] { MusicTheory.Enums.Note.C, MusicTheory.Enums.Note.E, MusicTheory.Enums.Note.Ab };
            var cMajorNinthChordNotes = new[] { MusicTheory.Enums.Note.C, MusicTheory.Enums.Note.E, MusicTheory.Enums.Note.G, MusicTheory.Enums.Note.B, MusicTheory.Enums.Note.D };
            var cMinorNinthChordNotes = new[] { MusicTheory.Enums.Note.C, MusicTheory.Enums.Note.Eb, MusicTheory.Enums.Note.G, MusicTheory.Enums.Note.Bb, MusicTheory.Enums.Note.D };
            var cDominantNinthChordNotes = new[] { MusicTheory.Enums.Note.C, MusicTheory.Enums.Note.E, MusicTheory.Enums.Note.G, MusicTheory.Enums.Note.Bb, MusicTheory.Enums.Note.D };
            var cMajorEleventhChordNotes = new[] { MusicTheory.Enums.Note.C, MusicTheory.Enums.Note.E, MusicTheory.Enums.Note.G, MusicTheory.Enums.Note.B, MusicTheory.Enums.Note.D, MusicTheory.Enums.Note.F };
            var cMinorEleventhChordNotes = new[] { MusicTheory.Enums.Note.C, MusicTheory.Enums.Note.Eb, MusicTheory.Enums.Note.G, MusicTheory.Enums.Note.Bb, MusicTheory.Enums.Note.D, MusicTheory.Enums.Note.F };
            var cDominantEleventhChordNotes = new[] { MusicTheory.Enums.Note.C, MusicTheory.Enums.Note.E, MusicTheory.Enums.Note.G, MusicTheory.Enums.Note.Bb, MusicTheory.Enums.Note.D, MusicTheory.Enums.Note.F };
            var cMajorThirteenthChordNotes = new[] { MusicTheory.Enums.Note.C, MusicTheory.Enums.Note.E, MusicTheory.Enums.Note.G, MusicTheory.Enums.Note.B, MusicTheory.Enums.Note.D, MusicTheory.Enums.Note.F, MusicTheory.Enums.Note.A };
            var cMinorThirteenthChordNotes = new[] { MusicTheory.Enums.Note.C, MusicTheory.Enums.Note.Eb, MusicTheory.Enums.Note.G, MusicTheory.Enums.Note.Bb, MusicTheory.Enums.Note.D, MusicTheory.Enums.Note.F, MusicTheory.Enums.Note.A };
            var cDominantThirteenthChordNotes = new[] { MusicTheory.Enums.Note.C, MusicTheory.Enums.Note.E, MusicTheory.Enums.Note.G, MusicTheory.Enums.Note.Bb, MusicTheory.Enums.Note.D, MusicTheory.Enums.Note.F, MusicTheory.Enums.Note.A };

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