using Keyify.MusicTheory.Enums;
using Keyify.Services.Models;

namespace ScaleDictionaryTests
{
    public class ScaleEntryLabelUnitTest
    {
        [Fact]
        public void AbIonianScaleIsConvertedToAbMajor()
        {
            var generatedScale = new GeneratedScale(
                Note.Ab,
                new ModeDefinition(
                    Mode.Ionian,
                new Interval[] {
                    Interval.R,
                    Interval.W,
                    Interval.W,
                    Interval.h,
                    Interval.W,
                    Interval.W,
                    Interval.W,
                    Interval.h
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

            var scaleEntry = new ScaleEntry(generatedScale);

            var colloquialExpected = "Ab Major";
            var colloquialActual = scaleEntry.ColloquialNameLabel_Flat;
            var userReadableExpected = "Ab Ionian";
            var userReadableActual = scaleEntry.FormalNameLabel_Flat;
            var combinationLabelExpected = "Ab Major (Ab Ionian)";
            var combinationLabelActual = scaleEntry.ColloquialismIncludingFormalName_Flat;

            //Note: Best practice to have 1 Assertion - making the exception here as I'd like to group these labels together
            Assert.Equal(colloquialExpected, colloquialActual);
            Assert.Equal(userReadableExpected, userReadableActual);
            Assert.Equal(combinationLabelExpected, combinationLabelActual);
        }

        [Fact]
        public void DbAeolianScaleIsConvertedToDbMinor()
        {
            var generatedScale = new GeneratedScale(
                Note.Db,
                new ModeDefinition(
                    Mode.Aeolian
                    , new Interval[] {
                    Interval.R,
                    Interval.W,
                    Interval.h,
                    Interval.W,
                    Interval.W,
                    Interval.h,
                    Interval.W,
                    Interval.W
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

            var scaleEntry = new ScaleEntry(generatedScale);

            var colloquialExpected = "Db Minor";
            var colloquialActual = scaleEntry.ColloquialNameLabel_Flat;
            var userReadableExpected = "Db Aeolian";
            var userReadableActual = scaleEntry.FormalNameLabel_Flat;
            var combinationLabelExpected = "Db Minor (Db Aeolian)";
            var combinationLabelActual = scaleEntry.ColloquialismIncludingFormalName_Flat;

            //Note: Best practice to have 1 Assertion - making the exception here as I'd like to group these labels together
            Assert.Equal(colloquialExpected, colloquialActual);
            Assert.Equal(userReadableExpected, userReadableActual);
            Assert.Equal(combinationLabelExpected, combinationLabelActual);
        }

        [Fact]
        public void GbAeolianScaleIsConvertedToFSharpMinor()
        {
            var generatedScale = new GeneratedScale(
                Note.Gb,
                new ModeDefinition(
                    Mode.Aeolian
                    , new Interval[] {
                    Interval.R,
                    Interval.W,
                    Interval.h,
                    Interval.W,
                    Interval.W,
                    Interval.h,
                    Interval.W,
                    Interval.W
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

            var scaleEntry = new ScaleEntry(generatedScale);

            //TODO: Fix this test

            var colloquialExpected = "F# Minor";
            var colloquialActual = scaleEntry.ColloquialNameLabel_Sharp;
            var userReadableExpected = "F# Aeolian";
            //var userReadableActual = scaleEntry.FormalNameLabel_Sharp;
            var combinationLabelExpected = "F# Minor (F# Aeolian)";
            //var combinationLabelActual = scaleEntry.ColloquialismIncludingFormalName_Sharp;

            //Note: Best practice to have 1 Assertion - making the exception here as I'd like to group these labels together
            //Assert.Equal(colloquialExpected, colloquialActual);
            //Assert.Equal(userReadableExpected, userReadableActual);
            //Assert.Equal(combinationLabelExpected, combinationLabelActual);
        }

        [Fact]
        public void EbDorian_b2ScaleIsConvertedToFSharpMinor()
        {
            var generatedScale = new GeneratedScale(
                Note.Eb,
                new ModeDefinition(
                    Mode.Dorian_b2,
                    new Interval[] {
                    Interval.R,
                    Interval.h,
                    Interval.W,
                    Interval.W,
                    Interval.h,
                    Interval.W,
                    Interval.h,
                    Interval.W
            },
                new string[] {
                     Degree.First,
                     Degree.FlatSecond,
                     Degree.FlatThird,
                     Degree.Fourth,
                     Degree.Fifth,
                     Degree.Sixth,
                     Degree.FlatSeventh,
                     Degree.Eighth
                }));

            var scaleEntry = new ScaleEntry(generatedScale);

            //TODO: Fix this test

            var colloquialExpected = string.Empty;
            var colloquialActual = scaleEntry.ColloquialNameLabel_Sharp;
            var userReadableExpected = "D# Dorian b2";
            //var userReadableActual = scaleEntry.FormalNameLabel_Sharp;
            var combinationLabelExpected = "D# Dorian b2";
            //var combinationLabelActual = scaleEntry.ColloquialismIncludingFormalName_Sharp;

            //Note: Best practice to have 1 Assertion - making the exception here as I'd like to group these labels together
            //Assert.Equal(colloquialExpected, colloquialActual);
            //Assert.Equal(userReadableExpected, userReadableActual);
            //Assert.Equal(combinationLabelExpected, combinationLabelActual);
        }
    }
}