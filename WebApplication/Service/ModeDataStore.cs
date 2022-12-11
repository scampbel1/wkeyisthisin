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

            var ionianSteps = new Interval[] {
                    Interval.R,
                    Interval.W,
                    Interval.W,
                    Interval.h,
                    Interval.W,
                    Interval.W,
                    Interval.W,
                    Interval.h
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

            var aeolianSteps = new Interval[] {
                    Interval.R,
                    Interval.W,
                    Interval.h,
                    Interval.W,
                    Interval.W,
                    Interval.h,
                    Interval.W,
                    Interval.W
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

            var phrygianSteps = new Interval[]
                {
                    Interval.R,
                    Interval.h,
                    Interval.W,
                    Interval.W,
                    Interval.W,
                    Interval.h,
                    Interval.W,
                    Interval.W
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

            var lydianSteps = new Interval[]
                {
                    Interval.R,
                    Interval.W,
                    Interval.W,
                    Interval.W,
                    Interval.h,
                    Interval.W,
                    Interval.W,
                    Interval.h
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

            var mixolydianSteps = new Interval[]
                {
                    Interval.R,
                    Interval.W,
                    Interval.W,
                    Interval.h,
                    Interval.W,
                    Interval.W,
                    Interval.h,
                    Interval.W
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

            var locrianSteps = new Interval[]
            {
                    Interval.R,
                    Interval.h,
                    Interval.W,
                    Interval.W,
                    Interval.h,
                    Interval.W,
                    Interval.W,
                    Interval.W
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

            var dorianSteps = new Interval[]
            {
                    Interval.R,
                    Interval.W,
                    Interval.h,
                    Interval.W,
                    Interval.W,
                    Interval.W,
                    Interval.h,
                    Interval.W
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

            var harmonicMinorSteps = new Interval[]
             {
                    Interval.R,
                    Interval.W,
                    Interval.h,
                    Interval.W,
                    Interval.W,
                    Interval.h,
                    Interval.Wh,
                    Interval.h
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

            var melodicMinorSteps = new Interval[]
            {
                    Interval.R,
                    Interval.W,
                    Interval.h,
                    Interval.W,
                    Interval.W,
                    Interval.W,
                    Interval.W,
                    Interval.h
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

            var augmentedSteps = new Interval[]
            {
                    Interval.R,
                    Interval.Wh,
                    Interval.h,
                    Interval.Wh,
                    Interval.h,
                    Interval.Wh,
                    Interval.h
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

            var minorPentatonicSteps = new Interval[]
            {
                    Interval.R,
                    Interval.Wh,
                    Interval.W,
                    Interval.W,
                    Interval.Wh,
                    Interval.W
            };

            var minorPentatonicDegrees = new string[] {
                     Degree.First,
                     Degree.FlatThird,
                     Degree.Fourth,
                     Degree.Fifth,
                     Degree.FlatSeventh,
                     Degree.Eighth
            };

            var majorPentatonicSteps = new Interval[]
              {
                    Interval.R,
                    Interval.W,
                    Interval.W,
                    Interval.Wh,
                    Interval.W,
                    Interval.Wh
               };

            var majorPentatonicDegrees = new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.Third,
                     Degree.Fifth,
                     Degree.Sixth,
                     Degree.Eighth
                };

            var bluesSteps = new Interval[]
             {
                    Interval.R,
                    Interval.Wh,
                    Interval.W,
                    Interval.h,
                    Interval.h,
                    Interval.Wh,
                    Interval.W
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

            var wholeToneSteps = new Interval[]
             {
                    Interval.R,
                    Interval.W,
                    Interval.W,
                    Interval.W,
                    Interval.W,
                    Interval.W,
                    Interval.W
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

            var diminishedWholeHalfSteps = new Interval[]
                {
                    Interval.R,
                    Interval.W,
                    Interval.h,
                    Interval.W,
                    Interval.h,
                    Interval.W,
                    Interval.h,
                    Interval.W,
                    Interval.h
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

            var diminishedHalfWholeSteps = new Interval[]
            {
                    Interval.R,
                    Interval.h,
                    Interval.W,
                    Interval.h,
                    Interval.W,
                    Interval.h,
                    Interval.W,
                    Interval.h,
                    Interval.W
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

            var arabianSteps = new Interval[]
                        {
                    Interval.R,
                    Interval.W,
                    Interval.W,
                    Interval.h,
                    Interval.h,
                    Interval.W,
                    Interval.W,
                    Interval.W
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

            var augmentedLydianSteps = new Interval[]
            {
                    Interval.R,
                    Interval.W,
                    Interval.W,
                    Interval.W,
                    Interval.W,
                    Interval.h,
                    Interval.W,
                    Interval.h
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

            var byzantineSteps = new Interval[]
            {
                    Interval.R,
                    Interval.h,
                    Interval.Wh,
                    Interval.h,
                    Interval.W,
                    Interval.h,
                    Interval.Wh,
                    Interval.h
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

            var egyptianSteps = new Interval[]
              {
                    Interval.R,
                    Interval.W,
                    Interval.Wh,
                    Interval.W,
                    Interval.Wh,
                    Interval.W
              };

            var egyptianDegrees = new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.Fourth,
                     Degree.Fifth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                };

            var hungarianMajorSteps = new Interval[]
            {
                    Interval.R,
                    Interval.Wh,
                    Interval.h,
                    Interval.W,
                    Interval.h,
                    Interval.W,
                    Interval.h,
                    Interval.W
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

            var neopolitanMajorSteps = new Interval[]
            {
                    Interval.R,
                    Interval.h,
                    Interval.W,
                    Interval.W,
                    Interval.W,
                    Interval.W,
                    Interval.W,
                    Interval.h
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

            var balinesePelogSteps = new Interval[]
            {
                    Interval.R,
                    Interval.h,
                    Interval.W,
                    Interval.WW,
                    Interval.h,
                    Interval.WW
             };

            var balinesePelogDegrees = new string[] {
                     Degree.First,
                     Degree.FlatSecond,
                     Degree.FlatThird,
                     Degree.Fifth,
                     Degree.FlatSixth,
                     Degree.Eighth
                };

            var prometheusSteps = new Interval[]
            {
                    Interval.R,
                    Interval.W,
                    Interval.W,
                    Interval.W,
                    Interval.Wh,
                    Interval.h,
                    Interval.W
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

            var sixToneSymmertricalSteps = new Interval[] {
                    Interval.R,
                    Interval.h,
                    Interval.Wh,
                    Interval.h,
                    Interval.Wh,
                    Interval.h,
                    Interval.Wh
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

            var alteredSteps = new Interval[]
            {
                    Interval.R,
                    Interval.h,
                    Interval.W,
                    Interval.h,
                    Interval.W,
                    Interval.W,
                    Interval.W,
                    Interval.W
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

            var chineseSteps = new Interval[]
           {
                    Interval.R,
                    Interval.WW,
                    Interval.W,
                    Interval.h,
                    Interval.WW,
                    Interval.h
             };

            var chineseDegrees = new string[] {
                     Degree.First,
                     Degree.Third,
                     Degree.SharpFourth,
                     Degree.Fifth,
                     Degree.Seventh,
                     Degree.Eighth
                };

            var diminishedLydianSteps = new Interval[]
{
                    Interval.R,
                    Interval.W,
                    Interval.h,
                    Interval.Wh,
                    Interval.h,
                    Interval.W,
                    Interval.W,
                    Interval.h
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

            var eightToneSpanishSteps = new Interval[]
            {
                    Interval.R,
                    Interval.h,
                    Interval.W,
                    Interval.h,
                    Interval.h,
                    Interval.h,
                    Interval.W,
                    Interval.W,
                    Interval.W
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

            var hinduSteps = new Interval[]
           {
                    Interval.R,
                    Interval.W,
                    Interval.W,
                    Interval.h,
                    Interval.W,
                    Interval.h,
                    Interval.W,
                    Interval.W
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

            var hungarianMinorSteps = new Interval[]
            {
                    Interval.R,
                    Interval.W,
                    Interval.h,
                    Interval.Wh,
                    Interval.h,
                    Interval.h,
                    Interval.Wh,
                    Interval.h
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

            var kumoiSteps = new Interval[]
            {
                    Interval.R,
                    Interval.W,
                    Interval.h,
                    Interval.WW,
                    Interval.W,
                    Interval.Wh
            };

            var kumoiDegrees = new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.FlatThird,
                     Degree.Fifth,
                     Degree.Sixth,
                     Degree.Eighth
                };

            var locrian2Steps = new Interval[]
            {
                    Interval.R,
                    Interval.W,
                    Interval.h,
                    Interval.W,
                    Interval.h,
                    Interval.W,
                    Interval.W,
                    Interval.W
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

            var lydian9Steps = new Interval[]
            {
                    Interval.R,
                    Interval.Wh,
                    Interval.h,
                    Interval.W,
                    Interval.h,
                    Interval.W,
                    Interval.W,
                    Interval.h
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

            var minorLyrdianSteps = new Interval[]
           {
                    Interval.R,
                    Interval.W,
                    Interval.W,
                    Interval.W,
                    Interval.h,
                    Interval.h,
                    Interval.W,
                    Interval.W
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

            var mixolydianB6Steps = new Interval[]
           {
                    Interval.R,
                    Interval.W,
                    Interval.W,
                    Interval.h,
                    Interval.W,
                    Interval.h,
                    Interval.W,
                    Interval.W
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

            var persianSteps = new Interval[]
            {
                    Interval.R,
                    Interval.h,
                    Interval.Wh,
                    Interval.h,
                    Interval.h,
                    Interval.W,
                    Interval.Wh,
                    Interval.h
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

            var prometheusNeopolitanSteps = new Interval[]
           {
                    Interval.R,
                    Interval.h,
                    Interval.Wh,
                    Interval.W,
                    Interval.Wh,
                    Interval.h,
                    Interval.W
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

            var todiThetaSteps = new Interval[]
            {
                    Interval.R,
                    Interval.h,
                    Interval.W,
                    Interval.Wh,
                    Interval.h,
                    Interval.h,
                    Interval.Wh,
                    Interval.h
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

            var alteredBb7Steps = new Interval[]
   {
                    Interval.R,
                    Interval.h,
                    Interval.W,
                    Interval.h,
                    Interval.W,
                    Interval.W,
                    Interval.h,
                    Interval.Wh
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

            var augmentedIonianSteps = new Interval[]
            {
                    Interval.R,
                    Interval.W,
                    Interval.W,
                    Interval.h,
                    Interval.Wh,
                    Interval.h,
                    Interval.W,
                    Interval.h
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

            var enigmaticSteps = new Interval[]
{
                    Interval.R,
                    Interval.h,
                    Interval.Wh,
                    Interval.W,
                    Interval.W,
                    Interval.W,
                    Interval.h,
                    Interval.h
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

            var hirajoshiSteps = new Interval[]
{
                    Interval.R,
                    Interval.W,
                    Interval.h,
                    Interval.WW,
                    Interval.h,
                    Interval.WW
};

            var hirajoshiDegrees = new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.FlatThird,
                     Degree.Fifth,
                     Degree.FlatSixth,
                     Degree.Eighth
                };

            var ichikosuchoSteps = new Interval[]
            {
                    Interval.R,
                    Interval.W,
                    Interval.W,
                    Interval.h,
                    Interval.h,
                    Interval.h,
                    Interval.W,
                    Interval.W,
                    Interval.h
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

            var leadingWholeToneSteps = new Interval[]
 {
                    Interval.R,
                    Interval.W,
                    Interval.W,
                    Interval.W,
                    Interval.W,
                    Interval.W,
                    Interval.h,
                    Interval.h
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

            var lydianB7Steps = new Interval[]
            {
                    Interval.R,
                    Interval.h,
                    Interval.W,
                    Interval.W,
                    Interval.h,
                    Interval.Wh,
                    Interval.h,
                    Interval.W
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

            var majorPhrygianSteps = new Interval[]
{
                    Interval.R,
                    Interval.h,
                    Interval.Wh,
                    Interval.h,
                    Interval.W,
                    Interval.h,
                    Interval.W,
                    Interval.W
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

            var neopolitanSteps = new Interval[]
{
                    Interval.R,
                    Interval.h,
                    Interval.W,
                    Interval.W,
                    Interval.W,
                    Interval.h,
                    Interval.Wh,
                    Interval.h
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

            var overtoneSteps = new Interval[]
            {
                    Interval.R,
                    Interval.W,
                    Interval.W,
                    Interval.W,
                    Interval.h,
                    Interval.W,
                    Interval.h,
                    Interval.W
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

            var purviThetaSteps = new Interval[]
            {
                    Interval.R,
                    Interval.h,
                    Interval.Wh,
                    Interval.W,
                    Interval.h,
                    Interval.h,
                    Interval.Wh,
                    Interval.h
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

            var dorian_b2Steps = new Interval[]
             {
                    Interval.R,
                    Interval.h,
                    Interval.W,
                    Interval.W,
                    Interval.h,
                    Interval.W,
                    Interval.h,
                    Interval.W
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

        private void InsertDictionaryEntry(Dictionary<string, ModeDefinition> dictionary, Mode mode, Interval[] steps, string[] degrees)
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