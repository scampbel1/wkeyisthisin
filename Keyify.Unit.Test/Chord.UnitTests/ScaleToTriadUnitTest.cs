﻿using Keyify.Models.Service;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Keyify.Unit.Test.Chord.UnitTests
{
    //NOTE: ENSURE YOU ARE FOLLOWING TDD - MAKE THE TEST PASS THEN DEVELOP!!!
    public class ScaleToTriadUnitTest
    {
        //What we are trying to achieve here is... given this chord in this scale, we should get the expected chord
        //Instead this should Test the "main" set of chords for a scale, start with a simple test
        //Major Minor scales will produce these chords based on the chord types in aligned to that defnition
        //i.e. a Major scale's 1st note resolves to chord x, 2nd note... (so therefore I'd expect to see these chords)
        [Theory, MemberData(nameof(GeneratedTestParameters))]
        public void FirstTriadOfIonianScaleIsFirstThirdFifthNotes(string numbersForArgumentSake, List<KeyifyClassLibrary.Enums.Note> notes)
        {
            var nums = numbersForArgumentSake;
            var scaleNotes = notes;
        }

        public static IEnumerable<object[]> GeneratedTestParameters => GenerateFirstTriadOfIonianScaleIsFirstThirdFifthNotesTestParameter();

        //I think this is the start of what I'm trying to do above, but we could probably avoid this by
        // passing in the method call and expected notes as part of the parameter
        private static IEnumerable<object[]> GenerateFirstTriadOfIonianScaleIsFirstThirdFifthNotesTestParameter()
        {
            var scaleEntries = new ScaleListService(new ModeDefinitionService()).GetScaleList();

            //TODO: This needs converting to something we can compare the result of the generated chord to (i.e. a chord object that is predicted ahead of time - the correct chord of course)
            //TODO: Create a chord object that we'd expect to see generated when Note X of Scale Y is given as input into our service
            return new List<object[]>
            {
                new object[] { "1", scaleEntries.FirstOrDefault(s => s.ScaleLabel == "FIonian").Scale.Notes },
                new object[] { "2", scaleEntries.FirstOrDefault(s => s.ScaleLabel == "EAeolian").Scale.Notes },
                new object[] { "3", scaleEntries.FirstOrDefault(s => s.ScaleLabel == "EIonian").Scale.Notes },
            };
        }
    }
}
