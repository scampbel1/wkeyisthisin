using Keyify.Enums;
using Keyify.Models.Service_Models;
using KeyifyClassLibrary.Enums;
using System.Collections.Generic;

namespace Keyify.Service
{
    public class ChordDataStore
    {
        private Dictionary<ChordType, Interval[]> chordDefinitions;

        public readonly List<ChordTemplate> Chords;

        public ChordDataStore()
        {
            Chords = GenerateChordTemplates();
        }

        private List<ChordTemplate> GenerateChordTemplates()
        {
            var chordTemplates = new List<ChordTemplate>();

            //TODO: Generate Chord Templates

            //foreach(var chordType in )

            /*
             * loop through each chord type (in chord type enum)
             * loop through each letter (in note enum)
             * generate chord for chord type using steps relative to current letter
             * add chord definition to list
            */

            return chordTemplates;
        }

        private void GenerateChordTemplatesByChordType(ChordType chordType, List<ChordTemplate> chordTemplates)
        {
            var count = 0;
            var currentNote = Note.A;

            while (count <= (int)Note.Ab)
            {
                currentNote = currentNote != Note.Ab ? currentNote + 1 : Note.A;
                count++;
            }
        }
    }
}
