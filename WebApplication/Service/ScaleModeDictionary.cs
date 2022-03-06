using Keyify.Models.Service;
using KeyifyClassLibrary.Enums;
using KeyifyClassLibrary.Service_Models;
using System.Collections.Generic;

namespace KeyifyClassLibrary.Core.Domain
{
    public partial class ScaleModeDictionary
    {
        public static List<ModeDefinition> GenerateModeDefinitions()
        {
            var modeDefinitions = new List<ModeDefinition>();

            modeDefinitions.Add(new ModeDefinition(
                Mode.Ionian,
                new Step[] {
                    Step.R,
                    Step.W,
                    Step.W,
                    Step.h,
                    Step.W,
                    Step.W,
                    Step.W,
                    Step.h
                },
                new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.Third,
                     Degree.Fourth,
                     Degree.Fifth,
                     Degree.Sixth,
                     Degree.Seventh,
                     Degree.Eighth
                }));

            modeDefinitions.Add(new ModeDefinition(
                Mode.Aeolian,
                new Step[] {
                    Step.R,
                    Step.W,
                    Step.h,
                    Step.W,
                    Step.W,
                    Step.h,
                    Step.W,
                    Step.W
                 },
                new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.FlatThird,
                     Degree.Fourth,
                     Degree.Fifth,
                     Degree.FlatSixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                }));

            modeDefinitions.Add(new ModeDefinition(
                Mode.Phrygian,
                new Step[]
                {
                    Step.R,
                    Step.h,
                    Step.W,
                    Step.W,
                    Step.W,
                    Step.h,
                    Step.W,
                    Step.W
                },
                new string[] {
                     Degree.First,
                     Degree.FlatSecond,
                     Degree.FlatThird,
                     Degree.Fourth,
                     Degree.Fifth,
                     Degree.FlatSixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                }));

            modeDefinitions.Add(new ModeDefinition(
                Mode.Lydian,
                new Step[]
                {
                    Step.R,
                    Step.W,
                    Step.W,
                    Step.W,
                    Step.h,
                    Step.W,
                    Step.W,
                    Step.h
                },
                new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.Third,
                     Degree.SharpFourth,
                     Degree.Fifth,
                     Degree.Sixth,
                     Degree.Seventh,
                     Degree.Eighth
                }));

            modeDefinitions.Add(new ModeDefinition(
                Mode.Mixolydian,
                new Step[]
                {
                    Step.R,
                    Step.W,
                    Step.W,
                    Step.h,
                    Step.W,
                    Step.W,
                    Step.h,
                    Step.W
                },
                new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.Third,
                     Degree.Fourth,
                     Degree.Fifth,
                     Degree.Sixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                }));

            modeDefinitions.Add(new ModeDefinition(
                Mode.Locrian,
                new Step[]
                {
                    Step.R,
                    Step.h,
                    Step.W,
                    Step.W,
                    Step.h,
                    Step.W,
                    Step.W,
                    Step.W
                },
                new string[] {
                     Degree.First,
                     Degree.FlatSecond,
                     Degree.FlatThird,
                     Degree.Fourth,
                     Degree.FlatFifth,
                     Degree.FlatSixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                }));

            modeDefinitions.Add(new ModeDefinition(
                Mode.Dorian,
                new Step[]
                {
                    Step.R,
                    Step.W,
                    Step.h,
                    Step.W,
                    Step.W,
                    Step.W,
                    Step.h,
                    Step.W
                },
                new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.FlatThird,
                     Degree.Fourth,
                     Degree.Fifth,
                     Degree.Sixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                }));

            modeDefinitions.Add(new ModeDefinition(
                Mode.HarmonicMinor,
                new Step[]
                {
                    Step.R,
                    Step.W,
                    Step.h,
                    Step.W,
                    Step.W,
                    Step.h,
                    Step.Wh,
                    Step.h
                 },
                new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.FlatThird,
                     Degree.Fourth,
                     Degree.Fifth,
                     Degree.FlatSixth,
                     Degree.Seventh,
                     Degree.Eighth
                }));

            modeDefinitions.Add(new ModeDefinition(
                Mode.MelodicMinor,
                new Step[]
                {
                    Step.R,
                    Step.W,
                    Step.h,
                    Step.W,
                    Step.W,
                    Step.W,
                    Step.W,
                    Step.h
                 },
                new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.FlatThird,
                     Degree.Fourth,
                     Degree.Fifth,
                     Degree.Sixth,
                     Degree.Seventh,
                     Degree.Eighth
                }));

            modeDefinitions.Add(new ModeDefinition(
                Mode.Augmented,
                new Step[]
                {
                    Step.R,
                    Step.Wh,
                    Step.h,
                    Step.Wh,
                    Step.h,
                    Step.Wh,
                    Step.h
                 },
                new string[] {
                     Degree.First,
                     Degree.FlatThird,
                     Degree.Third,
                     Degree.Fifth,
                     Degree.SharpFifth,
                     Degree.Seventh,
                     Degree.Eighth
                }));

            modeDefinitions.Add(new ModeDefinition(
                Mode.MinorPentatonic,
                new Step[]
                {
                    Step.R,
                    Step.Wh,
                    Step.W,
                    Step.W,
                    Step.Wh,
                    Step.W
                 },
                new string[] {
                     Degree.First,
                     Degree.FlatThird,
                     Degree.Fourth,
                     Degree.Fifth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                }));

            modeDefinitions.Add(new ModeDefinition(
                Mode.MajorPentatonic,
                new Step[]
                {
                    Step.R,
                    Step.W,
                    Step.W,
                    Step.Wh,
                    Step.W,
                    Step.Wh
                 },
                new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.Third,
                     Degree.Fifth,
                     Degree.Sixth,
                     Degree.Eighth
                }));

            modeDefinitions.Add(new ModeDefinition(
                Mode.Blues,
                new Step[]
                {
                    Step.R,
                    Step.Wh,
                    Step.W,
                    Step.h,
                    Step.h,
                    Step.Wh,
                    Step.W
                 },
                new string[] {
                     Degree.First,
                     Degree.FlatThird,
                     Degree.Fourth,
                     Degree.SharpFourth,
                     Degree.Fifth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                }));

            modeDefinitions.Add(new ModeDefinition(
                Mode.WholeTone,
                new Step[]
                {
                    Step.R,
                    Step.W,
                    Step.W,
                    Step.W,
                    Step.W,
                    Step.W,
                    Step.W
                },
                new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.Third,
                     Degree.SharpFourth,
                     Degree.SharpFifth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                },
                new[] {
                    Note.D,
                    Note.F
                }));

            modeDefinitions.Add(new ModeDefinition(
                Mode.DiminishedWholeHalf,
                new Step[]
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
                },
                new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.FlatThird,
                     Degree.Fourth,
                     Degree.FlatFifth,
                     Degree.FlatSixth,
                     Degree.Sixth,
                     Degree.Seventh,
                     Degree.Eighth
                },
                new[] {
                    Note.C,
                    Note.Db,
                    Note.D
                }));

            modeDefinitions.Add(new ModeDefinition(
                Mode.DiminishedHalfWhole,
                new Step[]
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
                },
                new string[] {
                     Degree.First,
                     Degree.FlatSecond,
                     Degree.FlatThird,
                     Degree.FlatFourth,
                     Degree.FlatFifth,
                     Degree.Fifth,
                     Degree.Sixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                },
                new[] {
                    Note.C,
                    Note.Db,
                    Note.D
                }));

            //The same as Major Pentatonic
            modeDefinitions.Add(new ModeDefinition(
                Mode.Mongolian,
                new Step[]
                {
                    Step.R,
                    Step.W,
                    Step.W,
                    Step.Wh,
                    Step.W,
                    Step.Wh,
                },
                new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.Third,
                     Degree.Fifth,
                     Degree.Sixth,
                     Degree.Eighth
                }));

            modeDefinitions.Add(new ModeDefinition(
                Mode.Arabian,
                new Step[]
                {
                    Step.R,
                    Step.W,
                    Step.W,
                    Step.h,
                    Step.h,
                    Step.W,
                    Step.W,
                    Step.W
                 },
                new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.Third,
                     Degree.Fourth,
                     Degree.SharpFourth,
                     Degree.SharpFifth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                }));

            modeDefinitions.Add(new ModeDefinition(
                Mode.AugmentedLydian,
                new Step[]
                {
                    Step.R,
                    Step.W,
                    Step.W,
                    Step.W,
                    Step.W,
                    Step.h,
                    Step.W,
                    Step.h
                 },
                new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.Third,
                     Degree.SharpFourth,
                     Degree.SharpFifth,
                     Degree.Sixth,
                     Degree.Seventh,
                     Degree.Eighth
                }));

            modeDefinitions.Add(new ModeDefinition(
                Mode.Byzantine,
                new Step[]
                {
                    Step.R,
                    Step.h,
                    Step.Wh,
                    Step.h,
                    Step.W,
                    Step.h,
                    Step.Wh,
                    Step.h
                  },
                new string[] {
                     Degree.First,
                     Degree.FlatSecond,
                     Degree.Third,
                     Degree.Fourth,
                     Degree.Fifth,
                     Degree.FlatSixth,
                     Degree.Seventh,
                     Degree.Eighth
                }));

            modeDefinitions.Add(new ModeDefinition(
                Mode.Egyptian,
                new Step[]
                {
                    Step.R,
                    Step.W,
                    Step.Wh,
                    Step.W,
                    Step.Wh,
                    Step.W
                },
                new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.Fourth,
                     Degree.Fifth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                }));

            modeDefinitions.Add(new ModeDefinition(
                Mode.HungarianMajor,
                new Step[]
                {
                    Step.R,
                    Step.Wh,
                    Step.h,
                    Step.W,
                    Step.h,
                    Step.W,
                    Step.h,
                    Step.W
                },
                new string[] {
                     Degree.First,
                     Degree.SharpSecond,
                     Degree.Third,
                     Degree.SharpFourth,
                     Degree.Fifth,
                     Degree.Sixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                }));

            modeDefinitions.Add(new ModeDefinition(
                Mode.NeopolitanMajor,
                new Step[]
                {
                    Step.R,
                    Step.h,
                    Step.W,
                    Step.W,
                    Step.W,
                    Step.W,
                    Step.W,
                    Step.h
                },
                new string[] {
                     Degree.First,
                     Degree.FlatSecond,
                     Degree.FlatThird,
                     Degree.Fourth,
                     Degree.Fifth,
                     Degree.Sixth,
                     Degree.Seventh,
                     Degree.Eighth
                }));

            modeDefinitions.Add(new ModeDefinition(
                Mode.BalinesePelog,
                new Step[]
                {
                    Step.R,
                    Step.h,
                    Step.W,
                    Step.WW,
                    Step.h,
                    Step.WW
                 },
                new string[] {
                     Degree.First,
                     Degree.FlatSecond,
                     Degree.FlatThird,
                     Degree.Fifth,
                     Degree.FlatSixth,
                     Degree.Eighth
                }));

            modeDefinitions.Add(new ModeDefinition(
                 Mode.Prometheus,
                 new Step[]
                 {
                    Step.R,
                    Step.W,
                    Step.W,
                    Step.W,
                    Step.Wh,
                    Step.h,
                    Step.W
                  },
                new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.Third,
                     Degree.FlatFifth,
                     Degree.Sixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                }));

            modeDefinitions.Add(new ModeDefinition(
                 Mode.SixToneSymmetrical,
                 new Step[]
                 {
                    Step.R,
                    Step.h,
                    Step.Wh,
                    Step.h,
                    Step.Wh,
                    Step.h,
                    Step.Wh
                 },
                new string[] {
                     Degree.First,
                     Degree.FlatSecond,
                     Degree.Third,
                     Degree.Fourth,
                     Degree.SharpFifth,
                     Degree.Sixth,
                     Degree.Eighth
                }));

            modeDefinitions.Add(new ModeDefinition(
                 Mode.Altered,
                 new Step[]
                 {
                    Step.R,
                    Step.h,
                    Step.W,
                    Step.h,
                    Step.W,
                    Step.W,
                    Step.W,
                    Step.W
                 },
                new string[] {
                     Degree.First,
                     Degree.FlatSecond,
                     Degree.FlatThird,
                     Degree.FlatFourth,
                     Degree.FlatFifth,
                     Degree.FlatSixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                }));

            modeDefinitions.Add(new ModeDefinition(
             Mode.Chinese,
             new Step[]
             {
                    Step.R,
                    Step.WW,
                    Step.W,
                    Step.h,
                    Step.WW,
                    Step.h
               },
                new string[] {
                     Degree.First,
                     Degree.Third,
                     Degree.SharpFourth,
                     Degree.Fifth,
                     Degree.Seventh,
                     Degree.Eighth
                }));

            //Dorian #4
            modeDefinitions.Add(new ModeDefinition(
             Mode.DiminishedLydian,
             new Step[]
             {
                    Step.R,
                    Step.W,
                    Step.h,
                    Step.Wh,
                    Step.h,
                    Step.W,
                    Step.W,
                    Step.h
             },
              new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.FlatThird,
                     Degree.SharpFourth,
                     Degree.Fifth,
                     Degree.Sixth,
                     Degree.Seventh,
                     Degree.Eighth
                }));

            //Note: this one is messed up
            //
            //
            ////TODO: Sort out the Name of this... it should be "b2" not "B2"
            //modeDefinitions.Add(new ModeDefinition(
            // Mode.DorianB2,
            // new Step[]
            // {
            //        Step.R,
            //        Step.h,
            //        Step.W,
            //        Step.W,
            //        Step.h,
            //        Step.W,
            //        Step.h,
            //        Step.W
            // },
            //  new string[] {
            //         Degree.First,
            //         Degree.FlatSecond,
            //         Degree.FlatThird,
            //         Degree.Fourth,
            //         Degree.Fifth,
            //         Degree.Sixth,
            //         Degree.FlatSeventh,
            //         Degree.Eighth
            //    }));

            modeDefinitions.Add(new ModeDefinition(
             Mode.EightToneSpanish,
             new Step[]
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
             },
              new string[] {
                     Degree.First,
                     Degree.FlatSecond,
                     Degree.SharpSecond,
                     Degree.Third,
                     Degree.Fourth,
                     Degree.FlatFifth,
                     Degree.FlatSixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                }));

            modeDefinitions.Add(new ModeDefinition(
             Mode.Hindu,
             new Step[]
             {
                    Step.R,
                    Step.W,
                    Step.W,
                    Step.h,
                    Step.W,
                    Step.h,
                    Step.W,
                    Step.W
             },
              new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.Third,
                     Degree.Fourth,
                     Degree.Fifth,
                     Degree.FlatSixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                }));

            modeDefinitions.Add(new ModeDefinition(
             Mode.HungarianMinor,
             new Step[]
             {
                    Step.R,
                    Step.W,
                    Step.h,
                    Step.Wh,
                    Step.h,
                    Step.h,
                    Step.Wh,
                    Step.h
             },
              new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.FlatThird,
                     Degree.SharpFourth,
                     Degree.Fifth,
                     Degree.FlatSixth,
                     Degree.Seventh,
                     Degree.Eighth
                }));

            modeDefinitions.Add(new ModeDefinition(
             Mode.Kumoi,
             new Step[]
             {
                    Step.R,
                    Step.W,
                    Step.h,
                    Step.WW,
                    Step.W,
                    Step.Wh
             },
              new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.FlatThird,
                     Degree.Fifth,
                     Degree.Sixth,
                     Degree.Eighth
                }));

            modeDefinitions.Add(new ModeDefinition(
             Mode.Locrian2,
             new Step[]
             {
                    Step.R,
                    Step.W,
                    Step.h,
                    Step.W,
                    Step.h,
                    Step.W,
                    Step.W,
                    Step.W
             },
              new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.FlatThird,
                     Degree.Fourth,
                     Degree.FlatFifth,
                     Degree.FlatSixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                }));

            ////Lydian #9
            modeDefinitions.Add(new ModeDefinition(
             Mode.Lydian9,
             new Step[]
             {
                    Step.R,
                    Step.Wh,
                    Step.h,
                    Step.W,
                    Step.h,
                    Step.W,
                    Step.W,
                    Step.h
             },
              new string[] {
                     Degree.First,
                     Degree.SharpSecond,
                     Degree.Third,
                     Degree.SharpFourth,
                     Degree.Fifth,
                     Degree.Sixth,
                     Degree.Seventh,
                     Degree.Eighth
                }));

            modeDefinitions.Add(new ModeDefinition(
             Mode.MinorLydian,
             new Step[]
             {
                    Step.R,
                    Step.W,
                    Step.W,
                    Step.W,
                    Step.h,
                    Step.h,
                    Step.W,
                    Step.W
              },
              new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.Third,
                     Degree.SharpFourth,
                     Degree.Fifth,
                     Degree.FlatSixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                }));

            modeDefinitions.Add(new ModeDefinition(
             Mode.MixolydianB6,
             new Step[]
             {
                    Step.R,
                    Step.W,
                    Step.W,
                    Step.h,
                    Step.W,
                    Step.h,
                    Step.W,
                    Step.W
             },
              new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.Third,
                     Degree.SharpFourth,
                     Degree.Fifth,
                     Degree.FlatSixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                }));

            modeDefinitions.Add(new ModeDefinition(
             Mode.NeopolitanMinor,
             new Step[]
             {
                    Step.R,
                    Step.h,
                    Step.W,
                    Step.W,
                    Step.W,
                    Step.h,
                    Step.W,
                    Step.W,
              },
              new string[] {
                     Degree.First,
                     Degree.FlatSecond,
                     Degree.FlatThird,
                     Degree.Fourth,
                     Degree.Fifth,
                     Degree.FlatSixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                }));

            modeDefinitions.Add(new ModeDefinition(
             Mode.Persian,
             new Step[]
             {
                    Step.R,
                    Step.h,
                    Step.Wh,
                    Step.h,
                    Step.h,
                    Step.W,
                    Step.Wh,
                    Step.h
             },
              new string[] {
                     Degree.First,
                     Degree.FlatSecond,
                     Degree.FlatThird,
                     Degree.Fourth,
                     Degree.FlatFifth,
                     Degree.FlatSixth,
                     Degree.Seventh,
                     Degree.Eighth
                }));

            modeDefinitions.Add(new ModeDefinition(
             Mode.PrometheusNeopolitan,
             new Step[]
             {
                    Step.R,
                    Step.h,
                    Step.Wh,
                    Step.W,
                    Step.Wh,
                    Step.h,
                    Step.W
             },
              new string[] {
                     Degree.First,
                     Degree.FlatSecond,
                     Degree.Third,
                     Degree.FlatFifth,
                     Degree.Sixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                }));

            modeDefinitions.Add(new ModeDefinition(
             Mode.TodiTheta,
             new Step[]
             {
                    Step.R,
                    Step.h,
                    Step.W,
                    Step.Wh,
                    Step.h,
                    Step.h,
                    Step.Wh,
                    Step.h
             },
              new string[] {
                     Degree.First,
                     Degree.FlatSecond,
                     Degree.FlatThird,
                     Degree.SharpFourth,
                     Degree.Fifth,
                     Degree.FlatSixth,
                     Degree.Seventh,
                     Degree.Eighth
                }));

            modeDefinitions.Add(new ModeDefinition(
             Mode.AlteredBb7,
             new Step[]
             {
                    Step.R,
                    Step.h,
                    Step.W,
                    Step.h,
                    Step.W,
                    Step.W,
                    Step.h,
                    Step.Wh
             },
              new string[] {
                     Degree.First,
                     Degree.FlatSecond,
                     Degree.FlatThird,
                     Degree.FlatFourth,
                     Degree.FlatFifth,
                     Degree.FlatSixth,
                     Degree.FlatFlatSeventh,
                     Degree.Eighth
                }));

            modeDefinitions.Add(new ModeDefinition(
             Mode.AugmentedIonian,
             new Step[]
             {
                    Step.R,
                    Step.W,
                    Step.W,
                    Step.h,
                    Step.Wh,
                    Step.h,
                    Step.W,
                    Step.h
             },
              new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.Third,
                     Degree.Fourth,
                     Degree.SharpFifth,
                     Degree.Sixth,
                     Degree.Seventh,
                     Degree.Eighth
                }));

            modeDefinitions.Add(new ModeDefinition(
             Mode.DoubleHarmonic,
             new Step[]
             {
                    Step.R,
                    Step.h,
                    Step.Wh,
                    Step.h,
                    Step.W,
                    Step.h,
                    Step.Wh,
                    Step.h
             },
              new string[] {
                     Degree.First,
                     Degree.FlatSecond,
                     Degree.Third,
                     Degree.Fourth,
                     Degree.Fifth,
                     Degree.FlatSixth,
                     Degree.Seventh,
                     Degree.Eighth
                }));

            modeDefinitions.Add(new ModeDefinition(
             Mode.Enigmatic,
             new Step[]
             {
                    Step.R,
                    Step.h,
                    Step.Wh,
                    Step.W,
                    Step.W,
                    Step.W,
                    Step.h,
                    Step.h
              },
              new string[] {
                     Degree.First,
                     Degree.FlatSecond,
                     Degree.Third,
                     Degree.SharpFourth,
                     Degree.SharpFifth,
                     Degree.SharpSixth,
                     Degree.Seventh,
                     Degree.Eighth
                }));

            modeDefinitions.Add(new ModeDefinition(
             Mode.Hirajoshi,
             new Step[]
             {
                    Step.R,
                    Step.W,
                    Step.h,
                    Step.WW,
                    Step.h,
                    Step.WW
             },
              new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.FlatThird,
                     Degree.Fifth,
                     Degree.FlatSixth,
                     Degree.Eighth
                }));

            modeDefinitions.Add(new ModeDefinition(
             Mode.Ichikosucho,
             new Step[]
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
             },
              new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.Third,
                     Degree.Fourth,
                     Degree.SharpFourth,
                     Degree.Fifth,
                     Degree.Sixth,
                     Degree.Seventh,
                     Degree.Eighth
                }));

            modeDefinitions.Add(new ModeDefinition(
             Mode.LeadingWholeTone,
             new Step[]
             {
                    Step.R,
                    Step.W,
                    Step.W,
                    Step.W,
                    Step.W,
                    Step.W,
                    Step.h,
                    Step.h
             },
              new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.Third,
                     Degree.SharpFourth,
                     Degree.SharpFifth,
                     Degree.SharpSixth,
                     Degree.Seventh,
                     Degree.Eighth
                }));

            modeDefinitions.Add(new ModeDefinition(
             Mode.LydianB7,
             new Step[]
             {
                    Step.R,
                    Step.h,
                    Step.W,
                    Step.W,
                    Step.h,
                    Step.Wh,
                    Step.h,
                    Step.W
             },
              new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.Third,
                     Degree.SharpFourth,
                     Degree.Fifth,
                     Degree.Sixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                }));

            modeDefinitions.Add(new ModeDefinition(
             Mode.MajorPhrygian,
             new Step[]
             {
                    Step.R,
                    Step.h,
                    Step.Wh,
                    Step.h,
                    Step.W,
                    Step.h,
                    Step.W,
                    Step.W
             },
              new string[] {
                     Degree.First,
                     Degree.FlatSecond,
                     Degree.Third,
                     Degree.Fourth,
                     Degree.Fifth,
                     Degree.FlatSixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                }));

            modeDefinitions.Add(new ModeDefinition(
             Mode.Neopolitan,
             new Step[]
             {
                    Step.R,
                    Step.h,
                    Step.W,
                    Step.W,
                    Step.W,
                    Step.h,
                    Step.Wh,
                    Step.h
              },
              new string[] {
                     Degree.First,
                     Degree.FlatSecond,
                     Degree.FlatThird,
                     Degree.Fourth,
                     Degree.Fifth,
                     Degree.FlatSixth,
                     Degree.Seventh,
                     Degree.Eighth
                }));

            modeDefinitions.Add(new ModeDefinition(
             Mode.Overtone,
             new Step[]
             {
                    Step.R,
                    Step.W,
                    Step.W,
                    Step.W,
                    Step.h,
                    Step.W,
                    Step.h,
                    Step.W
             },
              new string[] {
                     Degree.First,
                     Degree.Second,
                     Degree.Third,
                     Degree.SharpFourth,
                     Degree.Fifth,
                     Degree.Sixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                }));

            modeDefinitions.Add(new ModeDefinition(
             Mode.PurviTheta,
             new Step[]
             {
                    Step.R,
                    Step.h,
                    Step.Wh,
                    Step.W,
                    Step.h,
                    Step.h,
                    Step.Wh,
                    Step.h
              },
              new string[] {
                     Degree.First,
                     Degree.FlatSecond,
                     Degree.Third,
                     Degree.SharpFourth,
                     Degree.Fifth,
                     Degree.FlatSixth,
                     Degree.Seventh,
                     Degree.Eighth
                }));

            return modeDefinitions;
        }
    }
}