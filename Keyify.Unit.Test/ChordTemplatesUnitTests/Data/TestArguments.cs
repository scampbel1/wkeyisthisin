using Keyify.MusicTheory.Enums;
using Keyify.Services.Models;
using System.Collections.Generic;

namespace Keyify.Web.Unit.Test.ChordTemplates.UnitTests.Data
{
    public static class TestArguments
    {
        public static List<object[]> ChordTemplateParams
        {
            get
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

                var aMajorChordNotes = new[] { Note.A, Note.Db, Note.E };
                var bbMajorChordNotes = new[] { Note.Bb, Note.D, Note.F };
                var bMajorChordNotes = new[] { Note.B, Note.Eb, Note.Gb };
                var cMajorChordNotes = new[] { Note.C, Note.E, Note.G };
                var dbMajorChordNotes = new[] { Note.Db, Note.F, Note.Ab };
                var dMajorChordNotes = new[] { Note.D, Note.Gb, Note.A };
                var ebMajorChordNotes = new[] { Note.Eb, Note.G, Note.Bb };
                var eMajorChordNotes = new[] { Note.E, Note.Ab, Note.B };
                var fMajorChordNotes = new[] { Note.F, Note.A, Note.C };
                var gbMajorChordNotes = new[] { Note.Gb, Note.Bb, Note.Db };
                var gMajorChordNotes = new[] { Note.G, Note.B, Note.D };
                var abMajorChordNotes = new[] { Note.Ab, Note.C, Note.Eb };

                var aMinorChordNotes = new[] { Note.A, Note.C, Note.E };
                var bbMinorChordNotes = new[] { Note.Bb, Note.Db, Note.F };
                var bMinorChordNotes = new[] { Note.B, Note.D, Note.Gb };
                var cMinorChordNotes = new[] { Note.C, Note.Eb, Note.G };
                var dbMinorChordNotes = new[] { Note.Db, Note.E, Note.Ab };
                var dMinorChordNotes = new[] { Note.D, Note.F, Note.A };
                var ebMinorChordNotes = new[] { Note.Eb, Note.Gb, Note.Bb };
                var eMinorChordNotes = new[] { Note.E, Note.G, Note.B };
                var fMinorChordNotes = new[] { Note.F, Note.Ab, Note.C };
                var gbMinorChordNotes = new[] { Note.Gb, Note.A, Note.Db };
                var gMinorChordNotes = new[] { Note.G, Note.Bb, Note.D };
                var abMinorChordNotes = new[] { Note.Ab, Note.B, Note.Eb };

                var aDiminishedChordNotes = new[] { Note.A, Note.C, Note.Eb };
                var bbDiminishedChordNotes = new[] { Note.Bb, Note.Db, Note.E };
                var bDiminishedChordNotes = new[] { Note.B, Note.D, Note.F };
                var cDiminishedChordNotes = new[] { Note.C, Note.Eb, Note.Gb };
                var dbDiminishedChordNotes = new[] { Note.Db, Note.E, Note.G };
                var dDiminishedChordNotes = new[] { Note.D, Note.F, Note.Ab };
                var ebDiminishedChordNotes = new[] { Note.Eb, Note.Gb, Note.A };
                var eDiminishedChordNotes = new[] { Note.E, Note.G, Note.Bb };
                var fDiminishedChordNotes = new[] { Note.F, Note.Ab, Note.B };
                var gbDiminishedChordNotes = new[] { Note.Gb, Note.A, Note.C };
                var gDiminishedChordNotes = new[] { Note.G, Note.Bb, Note.Db };
                var abDiminishedChordNotes = new[] { Note.Ab, Note.B, Note.D };

                var cMajorSeventhChordNotes = new[] { Note.C, Note.E, Note.G, Note.B };
                var cMinorSeventhChordNotes = new[] { Note.C, Note.Eb, Note.G, Note.Bb };
                var cDominantSeventhChordNotes = new[] { Note.C, Note.E, Note.G, Note.Bb };
                var cSuspended2ChordNotes = new[] { Note.C, Note.D, Note.G };
                var cSuspended4ChordNotes = new[] { Note.C, Note.F, Note.G };
                var cAugmentedChordNotes = new[] { Note.C, Note.E, Note.Ab };
                var cMajorNinthChordNotes = new[] { Note.C, Note.E, Note.G, Note.B, Note.D };
                var cMinorNinthChordNotes = new[] { Note.C, Note.Eb, Note.G, Note.Bb, Note.D };
                var cDominantNinthChordNotes = new[] { Note.C, Note.E, Note.G, Note.Bb, Note.D };
                var cMajorEleventhChordNotes = new[] { Note.C, Note.E, Note.G, Note.B, Note.D, Note.F };
                var cMinorEleventhChordNotes = new[] { Note.C, Note.Eb, Note.G, Note.Bb, Note.D, Note.F };
                var cDominantEleventhChordNotes = new[] { Note.C, Note.E, Note.G, Note.Bb, Note.D, Note.F };
                var cMajorThirteenthChordNotes = new[] { Note.C, Note.E, Note.G, Note.B, Note.D, Note.F, Note.A };
                var cMinorThirteenthChordNotes = new[] { Note.C, Note.Eb, Note.G, Note.Bb, Note.D, Note.F, Note.A };
                var cDominantThirteenthChordNotes = new[] { Note.C, Note.E, Note.G, Note.Bb, Note.D, Note.F, Note.A };

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
}
