using Keyify.Models.Service;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Keyify.Unit.Test.Chord.UnitTests
{
    public class ScaleToTriadUnitTest
    {
        private static List<ScaleEntry> _scaleEntries = new ScaleListService(new ModeDefinitionService()).GetScaleList();


        //What we are trying to achieve here is... given this chord in this scale, we should get the expected chord
        //Instead this should Test the "main" set of chords for a scale, start with a simple test
        //Major Minor scales will produce these chords based on the chord types in aligned to that defnition
        //i.e. a Major scale's 1st note resolves to chord x, 2nd note... (so therefore I'd expect to see these chords)
        [Theory, MemberData(nameof(GenerateIonianScales))]
        public void FirstTriadOfIonianScaleIsFirstThirdFifthNotes(List<KeyifyClassLibrary.Enums.Note> notes)
        {
            var scaleNotes = notes;
        }

        //I think this is the start of what I'm trying to do above, but we could probably avoid this by
        // passing in the method call and expected notes as part of the parameter
        public static IEnumerable<object[]> GenerateIonianScales =>
        new List<object[]>
        {
            new object[] { _scaleEntries.FirstOrDefault(s => s.ScaleLabel == "FIonian").Scale.Notes },
            //new object[] { _scaleEntries.FirstOrDefault(s => s.ScaleLabel == "EAeolian").Scale.Notes },
            new object[] { _scaleEntries.FirstOrDefault(s => s.ScaleLabel == "EIonian").Scale.Notes },
        };
    }
}
