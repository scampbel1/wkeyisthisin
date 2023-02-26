using Keyify.MusicTheory.Enums;
using Keyify.Services.Models;
using System.Collections.Generic;

namespace ScaleDictionaryTests
{
    public class ScaleEntryLabelUnitTest
    {
        [Fact]
        public void AbIonianScaleIsConvertedToAbMajor()
        {
            var rootNote = Note.Ab;
            var sharpRootNote = "Ab";
            var notes = new List<Note>();
            var sharpNotes = new List<string>();
            var mode = Mode.Ionian;
            var scaleDegrees = new string[6];

            var generatedScale = new GeneratedScale(rootNote, sharpRootNote, notes, sharpNotes, mode, scaleDegrees);

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
            var rootNote = Note.Db;
            var sharpRootNote = "Db";
            var notes = new List<Note>();
            var sharpNotes = new List<string>();
            var mode = Mode.Aeolian;
            var scaleDegrees = new string[6];

            var generatedScale = new GeneratedScale(rootNote, sharpRootNote, notes, sharpNotes, mode, scaleDegrees);

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
            var rootNote = Note.Gb;
            var sharpRootNote = "F#";
            var notes = new List<Note>();
            var sharpNotes = new List<string>();
            var mode = Mode.Aeolian;
            var scaleDegrees = new string[6];

            var generatedScale = new GeneratedScale(rootNote, sharpRootNote, notes, sharpNotes, mode, scaleDegrees);

            var scaleEntry = new ScaleEntry(generatedScale);

            var colloquialExpected = "F# Minor";
            var colloquialActual = scaleEntry.ColloquialNameLabel_Sharp;
            var userReadableExpected = "F# Aeolian";
            var userReadableActual = scaleEntry.FormalNameLabel_Sharp;
            var combinationLabelExpected = "F# Minor (F# Aeolian)";
            var combinationLabelActual = scaleEntry.ColloquialismIncludingFormalName_Sharp;

            //Note: Best practice to have 1 Assertion - making the exception here as I'd like to group these labels together
            Assert.Equal(colloquialExpected, colloquialActual);
            Assert.Equal(userReadableExpected, userReadableActual);
            Assert.Equal(combinationLabelExpected, combinationLabelActual);
        }

        [Fact]
        public void EbDorian_b2ScaleIsConvertedToFSharpMinor()
        {
            var rootNote = Note.Eb;
            var sharpRootNote = "D#";
            var notes = new List<Note>();
            var sharpNotes = new List<string>();
            var mode = Mode.DorianB2;
            var scaleDegrees = new string[6];

            var generatedScale = new GeneratedScale(rootNote, sharpRootNote, notes, sharpNotes, mode, scaleDegrees);

            var scaleEntry = new ScaleEntry(generatedScale);

            var colloquialExpected = string.Empty;
            var colloquialActual = scaleEntry.ColloquialNameLabel_Sharp;
            var userReadableExpected = "D# Dorian b2";
            var userReadableActual = scaleEntry.FormalNameLabel_Sharp;
            var combinationLabelExpected = "D# Dorian b2";
            var combinationLabelActual = scaleEntry.ColloquialismIncludingFormalName_Sharp;

            //Note: Best practice to have 1 Assertion - making the exception here as I'd like to group these labels together
            Assert.Equal(colloquialExpected, colloquialActual);
            Assert.Equal(userReadableExpected, userReadableActual);
            Assert.Equal(combinationLabelExpected, combinationLabelActual);
        }
    }
}