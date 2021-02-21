using Keyify;
using KeyifyClassLibrary.Core.Domain.Enums;
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

            #endregion

            return modeDefinitions;
        }
    }
}