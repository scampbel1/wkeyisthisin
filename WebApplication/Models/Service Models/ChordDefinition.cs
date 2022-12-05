using Keyify.Enums;
using KeyifyClassLibrary.Models.MusicTheory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Keyify.Models.Service_Models
{
    //What does this represent? Is it too concrete? (i.e. does the scale need to be included?)
    //Can't we say, here is the Chord Type and its steps in a scale (I - V - Vi etc.) ?
    //We then use this to say, here is a chord definition, generate a definition for each chord type for each note
    public class ChordDefinition
    {
        //TODO: Delete this...
        //You are defining a chord by a chord type (there are many)
        private ChordType _chordType;
        private GeneratedScale _scale;
        private List<int> _stepsInScale;

        //TODO: Delete this...
        //What is this for again?
        //Is this to build a triad for Chord Type relative to a selected scale?
        //... I suspect so
        public List<int> _stepsInScaleIndex => GetIndexPositionsForStepsInScale();

        public int LargestIndexInStepsInScale => _stepsInScale.Max() - 1;
        public int LargestIndexInScale => _scale.Notes.Count - 1;

        public ChordDefinition(ChordType chordType, GeneratedScale scale, List<int> stepsInScale)
        {
            _scale = scale;
            _stepsInScale = stepsInScale;
            _chordType = chordType;

            if (LargestIndexInStepsInScale > LargestIndexInScale)
            {
                throw new IndexOutOfRangeException($"Largest scale steps are out of bound of scale.");
            }
        }

        private List<int> GetIndexPositionsForStepsInScale()
        {
            var stepIndexes = new List<int>();

            foreach (var stepInScale in _stepsInScale)
            {
                stepIndexes.Add(stepInScale - 1);
            }

            return stepIndexes;
        }
    }
}
