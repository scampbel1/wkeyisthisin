using Keyify.Models.Service;
using KeyifyClassLibrary.Enums;
using System.Collections.Generic;

namespace KeyifyClassLibrary.Core.Domain
{
    public partial class ModeDictionary
    {
        public static IEnumerable<ModeDefinition> GenerateModeDefinitions()
        {
            var modeDefinitions = new List<ModeDefinition>();

            #region Scale Steps

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
                }));

            modeDefinitions.Add(new ModeDefinition(
                Mode.PentatonicMinor,
                new Step[]
                {
                    Step.R,
                    Step.Wh,
                    Step.W,
                    Step.W,
                    Step.Wh,
                    Step.W
                }));

            modeDefinitions.Add(new ModeDefinition(
                Mode.PentatonicMajor,
                new Step[]
                {
                    Step.R,
                    Step.W,
                    Step.W,
                    Step.Wh,
                    Step.W,
                    Step.Wh
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
                }, new[] {
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
                }, new[] {
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
                new[] {
                    Note.C,
                    Note.Db,
                    Note.D
                }));

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
                }));

            //Dorian #4
            modeDefinitions.Add(new ModeDefinition(
                Mode.LydianDiminished,
                new Step[]
                {
                    Step.R,
                    Step.W,
                    Step.h,
                    Step.Wh,
                    Step.h,
                    Step.W,
                    Step.h,
                    Step.W
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
                }));

            modeDefinitions.Add(new ModeDefinition(
                Mode.Pelog,
                new Step[]
                {
                    Step.R,
                    Step.h,
                    Step.W,
                    Step.WW,
                    Step.h,
                    Step.WW
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
                 }));

            //Duplicate of Pelog
            modeDefinitions.Add(new ModeDefinition(
             Mode.Balinese,
             new Step[]
             {
                    Step.R,
                    Step.h,
                    Step.W,
                    Step.WW,
                    Step.h,
                    Step.WW
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
             }));

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
             }));

            modeDefinitions.Add(new ModeDefinition(
             Mode.DorianB2,
             new Step[]
             {
                    Step.R,
                    Step.h,
                    Step.W,
                    Step.W,
                    Step.W,
                    Step.W,
                    Step.h,
                    Step.W
             }));

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
             }));

            //Lydian #9
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
             }));

            //https://www.scales-chords.com/scalenav.php

            #endregion

            return modeDefinitions;
        }
    }
}