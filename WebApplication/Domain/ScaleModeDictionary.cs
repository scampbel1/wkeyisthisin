using KeyifyClassLibrary.Core.Domain.Enums;
using System.Collections.Generic;

namespace KeyifyClassLibrary.Core.Domain
{
    public partial class ModeDictionary
    {
        public static List<ModeDefinition> GenerateDirectory()
        {
            List<ModeDefinition> scaleDictionary = new List<ModeDefinition>();

            #region Scale Steps

            scaleDictionary.Add(new ModeDefinition(
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

            scaleDictionary.Add(new ModeDefinition(
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

            scaleDictionary.Add(new ModeDefinition(
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

            scaleDictionary.Add(new ModeDefinition(
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

            scaleDictionary.Add(new ModeDefinition(
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

            scaleDictionary.Add(new ModeDefinition(
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

            scaleDictionary.Add(new ModeDefinition(
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

            scaleDictionary.Add(new ModeDefinition(
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

            scaleDictionary.Add(new ModeDefinition(
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

            scaleDictionary.Add(new ModeDefinition(
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

            scaleDictionary.Add(new ModeDefinition(
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

            scaleDictionary.Add(new ModeDefinition(
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

            scaleDictionary.Add(new ModeDefinition(
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

            scaleDictionary.Add(new ModeDefinition(
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
                }));

            scaleDictionary.Add(new ModeDefinition(
                Mode.WholeHalfDiminished,
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
                }));

            scaleDictionary.Add(new ModeDefinition(
                Mode.HalfWholeDiminished,
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
                }));

            #endregion

            return scaleDictionary;
        }
    }
}