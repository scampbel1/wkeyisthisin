using Keyify.Models.Service;
using KeyifyClassLibrary.Enums;
using KeyifyClassLibrary.Service_Models;
using System.Collections.Generic;
using System.Linq;

namespace KeyifyClassLibrary.Core.Domain
{
    public class ModeDataStore
    {
        public List<ModeDefinition> ModeDefinitions => GenerateModeDefinitions();

        //TODO: Add duplicate Modes that contain the same note sets
        private List<ModeDefinition> GenerateModeDefinitions()
        {
            var modeDefinitionDictionary = new Dictionary<string, ModeDefinition>();

            var ionianSteps = new Step[] {
                    Step.R,
                    Step.W,
                    Step.W,
                    Step.h,
                    Step.W,
                    Step.W,
                    Step.W,
                    Step.h
                };

            var ionianDegrees = new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.Third,
                     Degree.Fourth,
                     Degree.Fifth,
                     Degree.Sixth,
                     Degree.Seventh,
                     Degree.Eighth
                };

            var aeolianSteps = new Step[] {
                    Step.R,
                    Step.W,
                    Step.h,
                    Step.W,
                    Step.W,
                    Step.h,
                    Step.W,
                    Step.W
                 };

            var aeolianDegrees = new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.FlatThird,
                     Degree.Fourth,
                     Degree.Fifth,
                     Degree.FlatSixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                };

            var phrygianSteps = new Step[]
                {
                    Step.R,
                    Step.h,
                    Step.W,
                    Step.W,
                    Step.W,
                    Step.h,
                    Step.W,
                    Step.W
                };

            var phrygianDegrees = new string[] {
                     Degree.First,
                     Degree.FlatSecond,
                     Degree.FlatThird,
                     Degree.Fourth,
                     Degree.Fifth,
                     Degree.FlatSixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                };

            var lydianSteps = new Step[]
                {
                    Step.R,
                    Step.W,
                    Step.W,
                    Step.W,
                    Step.h,
                    Step.W,
                    Step.W,
                    Step.h
                };

            var lydianDegrees = new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.Third,
                     Degree.SharpFourth,
                     Degree.Fifth,
                     Degree.Sixth,
                     Degree.Seventh,
                     Degree.Eighth
                };

            var mixolydianSteps = new Step[]
                {
                    Step.R,
                    Step.W,
                    Step.W,
                    Step.h,
                    Step.W,
                    Step.W,
                    Step.h,
                    Step.W
                };

            var mixolydianDegrees = new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.Third,
                     Degree.Fourth,
                     Degree.Fifth,
                     Degree.Sixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                };

            var locrianSteps = new Step[]
            {
                    Step.R,
                    Step.h,
                    Step.W,
                    Step.W,
                    Step.h,
                    Step.W,
                    Step.W,
                    Step.W
            };

            var locrianDegrees = new string[] {
                     Degree.First,
                     Degree.FlatSecond,
                     Degree.FlatThird,
                     Degree.Fourth,
                     Degree.FlatFifth,
                     Degree.FlatSixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                };

            var dorianSteps = new Step[]
            {
                    Step.R,
                    Step.W,
                    Step.h,
                    Step.W,
                    Step.W,
                    Step.W,
                    Step.h,
                    Step.W
            };

            var dorianDegrees = new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.FlatThird,
                     Degree.Fourth,
                     Degree.Fifth,
                     Degree.Sixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                };

            var harmonicMinorSteps = new Step[]
             {
                    Step.R,
                    Step.W,
                    Step.h,
                    Step.W,
                    Step.W,
                    Step.h,
                    Step.Wh,
                    Step.h
              };

            var harmonicMinorDegrees = new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.FlatThird,
                     Degree.Fourth,
                     Degree.Fifth,
                     Degree.FlatSixth,
                     Degree.Seventh,
                     Degree.Eighth
                };

            var melodicMinorSteps = new Step[]
            {
                    Step.R,
                    Step.W,
                    Step.h,
                    Step.W,
                    Step.W,
                    Step.W,
                    Step.W,
                    Step.h
             };

            var melodicMinorDegrees = new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.FlatThird,
                     Degree.Fourth,
                     Degree.Fifth,
                     Degree.Sixth,
                     Degree.Seventh,
                     Degree.Eighth
                };

            var augmentedSteps = new Step[]
            {
                    Step.R,
                    Step.Wh,
                    Step.h,
                    Step.Wh,
                    Step.h,
                    Step.Wh,
                    Step.h
             };

            var augmentedDegrees = new string[] {
                     Degree.First,
                     Degree.FlatThird,
                     Degree.Third,
                     Degree.Fifth,
                     Degree.SharpFifth,
                     Degree.Seventh,
                     Degree.Eighth
                };

            var minorPentatonicSteps = new Step[]
            {
                    Step.R,
                    Step.Wh,
                    Step.W,
                    Step.W,
                    Step.Wh,
                    Step.W
            };

            var minorPentatonicDegrees = new string[] {
                     Degree.First,
                     Degree.FlatThird,
                     Degree.Fourth,
                     Degree.Fifth,
                     Degree.FlatSeventh,
                     Degree.Eighth
            };

            var majorPentatonicSteps = new Step[]
              {
                    Step.R,
                    Step.W,
                    Step.W,
                    Step.Wh,
                    Step.W,
                    Step.Wh
               };

            var majorPentatonicDegrees = new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.Third,
                     Degree.Fifth,
                     Degree.Sixth,
                     Degree.Eighth
                };

            var bluesSteps = new Step[]
             {
                    Step.R,
                    Step.Wh,
                    Step.W,
                    Step.h,
                    Step.h,
                    Step.Wh,
                    Step.W
              };

            var bluesDegrees = new string[] {
                     Degree.First,
                     Degree.FlatThird,
                     Degree.Fourth,
                     Degree.SharpFourth,
                     Degree.Fifth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                };

            var wholeToneSteps = new Step[]
             {
                    Step.R,
                    Step.W,
                    Step.W,
                    Step.W,
                    Step.W,
                    Step.W,
                    Step.W
             };

            var wholeToneDegrees = new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.Third,
                     Degree.SharpFourth,
                     Degree.SharpFifth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                };

            var diminishedWholeHalfSteps = new Step[]
                {
                    Step.R,
                    Step.W,
                    Step.h,
                    Step.W,
                    Step.h,
                    Step.W,
                    Step.h,
                    Step.W,
                    Step.h
                };

            var diminishedWholeHalfDegrees = new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.FlatThird,
                     Degree.Fourth,
                     Degree.FlatFifth,
                     Degree.FlatSixth,
                     Degree.Sixth,
                     Degree.Seventh,
                     Degree.Eighth
                };

            var diminishedHalfWholeSteps = new Step[]
            {
                    Step.R,
                    Step.h,
                    Step.W,
                    Step.h,
                    Step.W,
                    Step.h,
                    Step.W,
                    Step.h,
                    Step.W
            };

            var diminishedHalfWholeDegrees = new string[] {
                     Degree.First,
                     Degree.FlatSecond,
                     Degree.FlatThird,
                     Degree.FlatFourth,
                     Degree.FlatFifth,
                     Degree.Fifth,
                     Degree.Sixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                };

            var arabianSteps = new Step[]
                        {
                    Step.R,
                    Step.W,
                    Step.W,
                    Step.h,
                    Step.h,
                    Step.W,
                    Step.W,
                    Step.W
                         };

            var arabianDegrees = new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.Third,
                     Degree.Fourth,
                     Degree.SharpFourth,
                     Degree.SharpFifth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                };

            var augmentedLydianSteps = new Step[]
            {
                    Step.R,
                    Step.W,
                    Step.W,
                    Step.W,
                    Step.W,
                    Step.h,
                    Step.W,
                    Step.h
             };

            var augmentedLydianDegrees = new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.Third,
                     Degree.SharpFourth,
                     Degree.SharpFifth,
                     Degree.Sixth,
                     Degree.Seventh,
                     Degree.Eighth
                };

            var byzantineSteps = new Step[]
            {
                    Step.R,
                    Step.h,
                    Step.Wh,
                    Step.h,
                    Step.W,
                    Step.h,
                    Step.Wh,
                    Step.h
              };

            var byzantineDegrees = new string[] {
                     Degree.First,
                     Degree.FlatSecond,
                     Degree.Third,
                     Degree.Fourth,
                     Degree.Fifth,
                     Degree.FlatSixth,
                     Degree.Seventh,
                     Degree.Eighth
                };

            var egyptianSteps = new Step[]
              {
                    Step.R,
                    Step.W,
                    Step.Wh,
                    Step.W,
                    Step.Wh,
                    Step.W
              };

            var egyptianDegrees = new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.Fourth,
                     Degree.Fifth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                };

            var hungarianMajorSteps = new Step[]
            {
                    Step.R,
                    Step.Wh,
                    Step.h,
                    Step.W,
                    Step.h,
                    Step.W,
                    Step.h,
                    Step.W
            };

            var hungarianMajorDegrees = new string[] {
                     Degree.First,
                     Degree.SharpSecond,
                     Degree.Third,
                     Degree.SharpFourth,
                     Degree.Fifth,
                     Degree.Sixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                };

            var neopolitanMajorSteps = new Step[]
            {
                    Step.R,
                    Step.h,
                    Step.W,
                    Step.W,
                    Step.W,
                    Step.W,
                    Step.W,
                    Step.h
            };

            var neopolitanMajorDegrees = new string[] {
                     Degree.First,
                     Degree.FlatSecond,
                     Degree.FlatThird,
                     Degree.Fourth,
                     Degree.Fifth,
                     Degree.Sixth,
                     Degree.Seventh,
                     Degree.Eighth
                };

            var balinesePelogSteps = new Step[]
            {
                    Step.R,
                    Step.h,
                    Step.W,
                    Step.WW,
                    Step.h,
                    Step.WW
             };

            var balinesePelogDegrees = new string[] {
                     Degree.First,
                     Degree.FlatSecond,
                     Degree.FlatThird,
                     Degree.Fifth,
                     Degree.FlatSixth,
                     Degree.Eighth
                };

            var prometheusSteps = new Step[]
            {
                    Step.R,
                    Step.W,
                    Step.W,
                    Step.W,
                    Step.Wh,
                    Step.h,
                    Step.W
             };

            var prometheusDegrees = new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.Third,
                     Degree.FlatFifth,
                     Degree.Sixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                };

            var sixToneSymmertricalSteps = new Step[] {
                    Step.R,
                    Step.h,
                    Step.Wh,
                    Step.h,
                    Step.Wh,
                    Step.h,
                    Step.Wh
                 };

            var sixToneSymmertricalDegrees = new string[] {
                     Degree.First,
                     Degree.FlatSecond,
                     Degree.Third,
                     Degree.Fourth,
                     Degree.SharpFifth,
                     Degree.Sixth,
                     Degree.Eighth
                };

            var alteredSteps = new Step[]
            {
                    Step.R,
                    Step.h,
                    Step.W,
                    Step.h,
                    Step.W,
                    Step.W,
                    Step.W,
                    Step.W
            };

            var alteredDegrees = new string[] {
                     Degree.First,
                     Degree.FlatSecond,
                     Degree.FlatThird,
                     Degree.FlatFourth,
                     Degree.FlatFifth,
                     Degree.FlatSixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                };

            var chineseSteps = new Step[]
           {
                    Step.R,
                    Step.WW,
                    Step.W,
                    Step.h,
                    Step.WW,
                    Step.h
             };

            var chineseDegrees = new string[] {
                     Degree.First,
                     Degree.Third,
                     Degree.SharpFourth,
                     Degree.Fifth,
                     Degree.Seventh,
                     Degree.Eighth
                };

            var diminishedLydianSteps = new Step[]
{
                    Step.R,
                    Step.W,
                    Step.h,
                    Step.Wh,
                    Step.h,
                    Step.W,
                    Step.W,
                    Step.h
};

            var diminishedLydianDegrees = new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.FlatThird,
                     Degree.SharpFourth,
                     Degree.Fifth,
                     Degree.Sixth,
                     Degree.Seventh,
                     Degree.Eighth
                };

            var eightToneSpanishSteps = new Step[]
            {
                    Step.R,
                    Step.h,
                    Step.W,
                    Step.h,
                    Step.h,
                    Step.h,
                    Step.W,
                    Step.W,
                    Step.W
            };

            var eightToneSpanishDegrees = new string[] {
                     Degree.First,
                     Degree.FlatSecond,
                     Degree.SharpSecond,
                     Degree.Third,
                     Degree.Fourth,
                     Degree.FlatFifth,
                     Degree.FlatSixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                };

            var hinduSteps = new Step[]
           {
                    Step.R,
                    Step.W,
                    Step.W,
                    Step.h,
                    Step.W,
                    Step.h,
                    Step.W,
                    Step.W
           };

            var hinduDegrees = new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.Third,
                     Degree.Fourth,
                     Degree.Fifth,
                     Degree.FlatSixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                };

            var hungarianMinorSteps = new Step[]
            {
                    Step.R,
                    Step.W,
                    Step.h,
                    Step.Wh,
                    Step.h,
                    Step.h,
                    Step.Wh,
                    Step.h
            };

            var hungarianMinorDegrees = new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.FlatThird,
                     Degree.SharpFourth,
                     Degree.Fifth,
                     Degree.FlatSixth,
                     Degree.Seventh,
                     Degree.Eighth
                };

            var kumoiSteps = new Step[]
            {
                    Step.R,
                    Step.W,
                    Step.h,
                    Step.WW,
                    Step.W,
                    Step.Wh
            };

            var kumoiDegrees = new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.FlatThird,
                     Degree.Fifth,
                     Degree.Sixth,
                     Degree.Eighth
                };

            var locrian2Steps = new Step[]
            {
                    Step.R,
                    Step.W,
                    Step.h,
                    Step.W,
                    Step.h,
                    Step.W,
                    Step.W,
                    Step.W
            };

            var locrian2Degrees = new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.FlatThird,
                     Degree.Fourth,
                     Degree.FlatFifth,
                     Degree.FlatSixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                };

            var lydian9Steps = new Step[]
            {
                    Step.R,
                    Step.Wh,
                    Step.h,
                    Step.W,
                    Step.h,
                    Step.W,
                    Step.W,
                    Step.h
            };

            var lydian9Degrees = new string[] {
                     Degree.First,
                     Degree.SharpSecond,
                     Degree.Third,
                     Degree.SharpFourth,
                     Degree.Fifth,
                     Degree.Sixth,
                     Degree.Seventh,
                     Degree.Eighth
                };

            var minorLyrdianSteps = new Step[]
           {
                    Step.R,
                    Step.W,
                    Step.W,
                    Step.W,
                    Step.h,
                    Step.h,
                    Step.W,
                    Step.W
            };

            var minorLyrdianDegrees = new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.Third,
                     Degree.SharpFourth,
                     Degree.Fifth,
                     Degree.FlatSixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                };

            var mixolydianB6Steps = new Step[]
           {
                    Step.R,
                    Step.W,
                    Step.W,
                    Step.h,
                    Step.W,
                    Step.h,
                    Step.W,
                    Step.W
           };

            var mixolydianB6Degrees = new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.Third,
                     Degree.Fourth,
                     Degree.Fifth,
                     Degree.FlatSixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                };

            var persianSteps = new Step[]
            {
                    Step.R,
                    Step.h,
                    Step.Wh,
                    Step.h,
                    Step.h,
                    Step.W,
                    Step.Wh,
                    Step.h
            };

            var persianDegrees = new string[] {
                     Degree.First,
                     Degree.FlatSecond,
                     Degree.FlatThird,
                     Degree.Fourth,
                     Degree.FlatFifth,
                     Degree.FlatSixth,
                     Degree.Seventh,
                     Degree.Eighth
                };

            var prometheusNeopolitanSteps = new Step[]
           {
                    Step.R,
                    Step.h,
                    Step.Wh,
                    Step.W,
                    Step.Wh,
                    Step.h,
                    Step.W
           };

            var prometheusNeopolitanDegree = new string[] {
                     Degree.First,
                     Degree.FlatSecond,
                     Degree.Third,
                     Degree.FlatFifth,
                     Degree.Sixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                };

            var todiThetaSteps = new Step[]
            {
                    Step.R,
                    Step.h,
                    Step.W,
                    Step.Wh,
                    Step.h,
                    Step.h,
                    Step.Wh,
                    Step.h
            };

            var todiThetaDegrees = new string[] {
                     Degree.First,
                     Degree.FlatSecond,
                     Degree.FlatThird,
                     Degree.SharpFourth,
                     Degree.Fifth,
                     Degree.FlatSixth,
                     Degree.Seventh,
                     Degree.Eighth
                };

            var alteredBb7Steps = new Step[]
   {
                    Step.R,
                    Step.h,
                    Step.W,
                    Step.h,
                    Step.W,
                    Step.W,
                    Step.h,
                    Step.Wh
   };

            var alteredBb7Degrees = new string[] {
                     Degree.First,
                     Degree.FlatSecond,
                     Degree.FlatThird,
                     Degree.FlatFourth,
                     Degree.FlatFifth,
                     Degree.FlatSixth,
                     Degree.FlatFlatSeventh,
                     Degree.Eighth
                };

            var augmentedIonianSteps = new Step[]
            {
                    Step.R,
                    Step.W,
                    Step.W,
                    Step.h,
                    Step.Wh,
                    Step.h,
                    Step.W,
                    Step.h
            };

            var augmentedIonianDegrees = new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.Third,
                     Degree.Fourth,
                     Degree.SharpFifth,
                     Degree.Sixth,
                     Degree.Seventh,
                     Degree.Eighth
                };

            var enigmaticSteps = new Step[]
{
                    Step.R,
                    Step.h,
                    Step.Wh,
                    Step.W,
                    Step.W,
                    Step.W,
                    Step.h,
                    Step.h
 };

            var enigmaticDegrees = new string[] {
                     Degree.First,
                     Degree.FlatSecond,
                     Degree.Third,
                     Degree.SharpFourth,
                     Degree.SharpFifth,
                     Degree.SharpSixth,
                     Degree.Seventh,
                     Degree.Eighth
                };

            var hirajoshiSteps = new Step[]
{
                    Step.R,
                    Step.W,
                    Step.h,
                    Step.WW,
                    Step.h,
                    Step.WW
};

            var hirajoshiDegrees = new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.FlatThird,
                     Degree.Fifth,
                     Degree.FlatSixth,
                     Degree.Eighth
                };

            var ichikosuchoSteps = new Step[]
            {
                    Step.R,
                    Step.W,
                    Step.W,
                    Step.h,
                    Step.h,
                    Step.h,
                    Step.W,
                    Step.W,
                    Step.h
            };

            var ichikosuchoDegrees = new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.Third,
                     Degree.Fourth,
                     Degree.SharpFourth,
                     Degree.Fifth,
                     Degree.Sixth,
                     Degree.Seventh,
                     Degree.Eighth
                };

            var leadingWholeToneSteps = new Step[]
 {
                    Step.R,
                    Step.W,
                    Step.W,
                    Step.W,
                    Step.W,
                    Step.W,
                    Step.h,
                    Step.h
 };

            var leadingWholeToneDegrees = new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.Third,
                     Degree.SharpFourth,
                     Degree.SharpFifth,
                     Degree.SharpSixth,
                     Degree.Seventh,
                     Degree.Eighth
                };

            var lydianB7Steps = new Step[]
            {
                    Step.R,
                    Step.h,
                    Step.W,
                    Step.W,
                    Step.h,
                    Step.Wh,
                    Step.h,
                    Step.W
            };

            var lydianB7Degrees = new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.Third,
                     Degree.SharpFourth,
                     Degree.Fifth,
                     Degree.Sixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                };

            var majorPhrygianSteps = new Step[]
{
                    Step.R,
                    Step.h,
                    Step.Wh,
                    Step.h,
                    Step.W,
                    Step.h,
                    Step.W,
                    Step.W
};

            var majorPhrygianDegrees = new string[] {
                     Degree.First,
                     Degree.FlatSecond,
                     Degree.Third,
                     Degree.Fourth,
                     Degree.Fifth,
                     Degree.FlatSixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                };

            var neopolitanSteps = new Step[]
{
                    Step.R,
                    Step.h,
                    Step.W,
                    Step.W,
                    Step.W,
                    Step.h,
                    Step.Wh,
                    Step.h
 };

            var neopolitanDegrees = new string[] {
                     Degree.First,
                     Degree.FlatSecond,
                     Degree.FlatThird,
                     Degree.Fourth,
                     Degree.Fifth,
                     Degree.FlatSixth,
                     Degree.Seventh,
                     Degree.Eighth
                };

            var overtoneSteps = new Step[]
            {
                    Step.R,
                    Step.W,
                    Step.W,
                    Step.W,
                    Step.h,
                    Step.W,
                    Step.h,
                    Step.W
            };

            var overtoneDegrees = new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.Third,
                     Degree.SharpFourth,
                     Degree.Fifth,
                     Degree.Sixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                };

            var purviThetaSteps = new Step[]
            {
                    Step.R,
                    Step.h,
                    Step.Wh,
                    Step.W,
                    Step.h,
                    Step.h,
                    Step.Wh,
                    Step.h
            };

            var purviThetaDegrees = new string[] {
                     Degree.First,
                     Degree.FlatSecond,
                     Degree.Third,
                     Degree.SharpFourth,
                     Degree.Fifth,
                     Degree.FlatSixth,
                     Degree.Seventh,
                     Degree.Eighth
                };

            var dorian_b2Steps = new Step[]
             {
                    Step.R,
                    Step.h,
                    Step.W,
                    Step.W,
                    Step.h,
                    Step.W,
                    Step.h,
                    Step.W
             };

            var dorian_b2Degrees = new string[] {
                     Degree.First,
                     Degree.FlatSecond,
                     Degree.FlatThird,
                     Degree.Fourth,
                     Degree.Fifth,
                     Degree.Sixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                };

            InsertDictionaryEntry(modeDefinitionDictionary, Mode.Ionian, ionianSteps, ionianDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.Aeolian, aeolianSteps, aeolianDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.Phrygian, phrygianSteps, phrygianDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.Lydian, lydianSteps, lydianDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.Mixolydian, mixolydianSteps, mixolydianDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.Locrian, locrianSteps, locrianDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.Dorian, dorianSteps, dorianDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.HarmonicMinor, harmonicMinorSteps, harmonicMinorDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.MelodicMinor, melodicMinorSteps, melodicMinorDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.Augmented, augmentedSteps, augmentedDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.MinorPentatonic, minorPentatonicSteps, minorPentatonicDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.MajorPentatonic, majorPentatonicSteps, majorPentatonicDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.Blues, bluesSteps, bluesDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.WholeTone, wholeToneSteps, wholeToneDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.DiminishedWholeHalf, diminishedWholeHalfSteps, diminishedWholeHalfDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.DiminishedHalfWhole, diminishedHalfWholeSteps, diminishedHalfWholeDegrees);
            //InsertDictionaryEntry(modeDefinitionDictionary, Mode.Mongolian, mongolianSteps, mongolianDegrses); //The same as Major Pentatonic
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.Arabian, arabianSteps, arabianDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.AugmentedLydian, augmentedLydianSteps, augmentedLydianDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.Byzantine, byzantineSteps, byzantineDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.Egyptian, egyptianSteps, egyptianDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.HungarianMajor, hungarianMajorSteps, hungarianMajorDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.NeopolitanMajor, neopolitanMajorSteps, neopolitanMajorDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.BalinesePelog, balinesePelogSteps, balinesePelogDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.Prometheus, prometheusSteps, prometheusDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.SixToneSymmetrical, sixToneSymmertricalSteps, sixToneSymmertricalDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.Altered, alteredSteps, alteredDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.Chinese, chineseSteps, chineseDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.DiminishedLydian, diminishedLydianSteps, diminishedLydianDegrees); //Dorian #4
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.EightToneSpanish, eightToneSpanishSteps, eightToneSpanishDegrees);
            //InsertDictionaryEntry(modeDefinitionDictionary, Mode.Hindu, hinduSteps, hinduDegrees); //The Hindu scale (also known as the Aeolian dominant scale, Olympian Scale, Mixolydian ♭6 [or ♭13], Aeolian major, and melodic major
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.HungarianMinor, hungarianMinorSteps, hungarianMinorDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.Kumoi, kumoiSteps, kumoiDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.Locrian2, locrian2Steps, locrian2Degrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.Lydian9, lydian9Steps, lydian9Degrees); //Lydian #9
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.MinorLydian, minorLyrdianSteps, minorLyrdianDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.MixolydianB6, mixolydianB6Steps, mixolydianB6Degrees);
            //InsertDictionaryEntry(modeDefinitionDictionary, Mode.NeopolitanMinor, neopolitanMinorSteps, neopolitanMinorDegrees); //Same as Phrygian
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.Persian, persianSteps, persianDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.PrometheusNeopolitan, prometheusNeopolitanSteps, prometheusNeopolitanDegree);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.TodiTheta, todiThetaSteps, todiThetaDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.AlteredBb7, alteredBb7Steps, alteredBb7Degrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.AugmentedIonian, augmentedIonianSteps, augmentedIonianDegrees);
            //InsertDictionaryEntry(modeDefinitionDictionary, Mode.DoubleHarmonic, doubleHarmonicSteps, doubleHarmonicDegrees); //Same as Byzantine
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.Enigmatic, enigmaticSteps, enigmaticDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.Ichikosucho, ichikosuchoSteps, ichikosuchoDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.Hirajoshi, hirajoshiSteps, hirajoshiDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.LeadingWholeTone, leadingWholeToneSteps, leadingWholeToneDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.LydianB7, lydianB7Steps, lydianB7Degrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.MajorPhrygian, majorPhrygianSteps, majorPhrygianDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.Neopolitan, neopolitanSteps, neopolitanDegrees);
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.PurviTheta, purviThetaSteps, purviThetaDegrees);
            //InsertDictionaryEntry(modeDefinitionDictionary, Mode.Overtone, overtoneSteps, overtoneDegrees); //Same as Lydian b7
            InsertDictionaryEntry(modeDefinitionDictionary, Mode.Dorian_b2, dorian_b2Steps, dorian_b2Degrees);

            return modeDefinitionDictionary.Select(m => m.Value).ToList();
        }

        private void InsertDictionaryEntry(Dictionary<string, ModeDefinition> dictionary, Mode mode, Step[] steps, string[] degrees)
        {
            var key = string.Join(',', degrees);

            switch (mode)
            {
                case Mode.WholeTone:
                    dictionary.Add(key, new ModeDefinition(mode, steps, degrees, new[] { Note.D, Note.F }));
                    break;
                case Mode.DiminishedWholeHalf:
                case Mode.DiminishedHalfWhole:
                    dictionary.Add(key, new ModeDefinition(mode, steps, degrees, new[] { Note.C, Note.Db, Note.D }));
                    break;
                default:
                    dictionary.Add(key, new ModeDefinition(mode, steps, degrees));
                    break;
            }
        }
    }
}