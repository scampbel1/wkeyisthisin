using Keyify.Models.Service;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Keyify.Unit.Test.Chord.UnitTests
{
    public class ScaleToTriadUnitTest
    {
        private static List<ScaleEntry> _scaleEntries = new ScaleListService(new ModeDefinitionService()).GetScaleList();

        [Theory, MemberData(nameof(GenerateIonianScales))]
        public void FirstTriadOfIonianScaleIsFirstThirdFifthNotes(List<KeyifyClassLibrary.Enums.Note> notes)
        {
            var scaleNotes = notes;
        }

        public static IEnumerable<object[]> GenerateIonianScales =>
        new List<object[]>
        {
            new object[] { _scaleEntries.FirstOrDefault(s => s.ScaleLabel == "FIonian").Scale.Notes },
            //new object[] { _scaleEntries.FirstOrDefault(s => s.ScaleLabel == "EAeolian").Scale.Notes },
            new object[] { _scaleEntries.FirstOrDefault(s => s.ScaleLabel == "EIonian").Scale.Notes },
        };
    }
}
