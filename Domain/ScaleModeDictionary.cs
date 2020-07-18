using System.Linq;
using System.Collections.Generic;
using KeyifyClassLibrary.Core.Domain.Enums;

namespace KeyifyClassLibrary.Core.Domain
{
    public static partial class ScaleModeDictionary
    {
        public static ScaleDirectoryEntry GetScaleDirectory(Mode mode)
        {
            return GenerateDictionary().FirstOrDefault(s => s.Mode == mode);
        }

        private static List<ScaleDirectoryEntry> GenerateDictionary()
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
                Mode.Augmented, //(W+h) h (W+h) h (W+h) h 
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
                Mode.PentatonicMinor, //(W+h) + W + W (W+h) + W
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
                Mode.PentatonicMajor, //W-W-(Wh)-W-(Wh)
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
                Mode.Blues, // WH-W-H-H-WH-W
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
                Mode.WholeTone, // W-W-W-W-W-W
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
                Mode.WholeHalfDiminished, //  W-H-W-H-W-H-W-H
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
                Mode.HalfWholeDiminished, // H-W-H-W-H-W-H-W
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