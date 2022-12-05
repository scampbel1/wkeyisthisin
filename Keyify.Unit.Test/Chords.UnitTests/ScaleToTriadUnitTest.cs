using Keyify.Models.Music_Theory;
using Keyify.Models.Service;
using KeyifyClassLibrary.Core.Domain;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Keyify.Unit.Test.Chords.UnitTests
{
    //NOTE: ENSURE YOU ARE FOLLOWING TDD - MAKE THE TEST PASS THEN DEVELOP!!!
    public class ScaleToTriadUnitTest
    {
        //i.e. a Major scale's 1st note resolves to chord x, 2nd note... (so therefore I'd expect to see this chord)
        [Theory, MemberData(nameof(ChordTestParameters))]
        public void SelectedScaleDegree_GenerateChord_ProducesChordWithExpectedNotes(string noteRelativeToScale, List<KeyifyClassLibrary.Enums.Note> scaleNotes, List<KeyifyClassLibrary.Enums.Note> expectedNotes)
        {
            //Arrange - Given
            var inputNotes = expectedNotes;
            //Act - When
            var chordResult = new Chord(new KeyifyClassLibrary.Enums.Note[] { KeyifyClassLibrary.Enums.Note.F, KeyifyClassLibrary.Enums.Note.A, KeyifyClassLibrary.Enums.Note.C });
            //Assert - Then
            Assert.Equal(inputNotes, chordResult.Notes);
        }

        public static IEnumerable<object[]> ChordTestParameters => GenerateChordTestArguments();

        private static IEnumerable<object[]> GenerateChordTestArguments()
        {
            //Question: Should this service be mocked? Strictly speaking, this is beyond the scope of this test, this is currently being used for convenience.
            var scaleEntries = new ScaleService(new ModeService(new ModeDefinitionService())).Scales;

            return new List<object[]>
            {
                new object[] { "1", scaleEntries.FirstOrDefault(s => s.ScaleLabel == "FIonian").Scale.Notes, new List<KeyifyClassLibrary.Enums.Note>() { KeyifyClassLibrary.Enums.Note.F, KeyifyClassLibrary.Enums.Note.A, KeyifyClassLibrary.Enums.Note.C } },
            };
        }
    }
}

//Instead this should Test the "main" set of chords for a scale, start with a simple test
//Major Minor scales will produce these chords based on the chord types in aligned to that defnition