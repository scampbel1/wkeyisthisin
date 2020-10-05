using KeyifyClassLibrary.Core.Domain.Enums;
using System.Collections.Generic;

namespace KeyifyClassLibrary.Core.Domain
{
    public static partial class ScaleModeDictionary
    {
        public static List<ScaleDirectoryEntry> GenerateDirectory()
        {
            List<ScaleDirectoryEntry> scaleDictionary = new List<ScaleDirectoryEntry>();

            #region Scales

            //Major Scale

            scaleDictionary.Add(new ScaleDirectoryEntry(
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

            //Minor Scale

            scaleDictionary.Add(new ScaleDirectoryEntry(
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

            scaleDictionary.Add(new ScaleDirectoryEntry(
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

            scaleDictionary.Add(new ScaleDirectoryEntry(
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

            scaleDictionary.Add(new ScaleDirectoryEntry(
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

            scaleDictionary.Add(new ScaleDirectoryEntry(
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

            scaleDictionary.Add(new ScaleDirectoryEntry(
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

            scaleDictionary.Add(new ScaleDirectoryEntry(
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

            scaleDictionary.Add(new ScaleDirectoryEntry(
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

            scaleDictionary.Add(new ScaleDirectoryEntry(
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

            scaleDictionary.Add(new ScaleDirectoryEntry(
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

            scaleDictionary.Add(new ScaleDirectoryEntry(
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

            scaleDictionary.Add(new ScaleDirectoryEntry(
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

            scaleDictionary.Add(new ScaleDirectoryEntry(
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

            scaleDictionary.Add(new ScaleDirectoryEntry(
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

            scaleDictionary.Add(new ScaleDirectoryEntry(
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