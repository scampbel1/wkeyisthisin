using Keyify.Enums;
using KeyifyClassLibrary.Models.MusicTheory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Keyify.Models.Service_Models
{
    public class ChordDefinition
    {
        private ChordType _chordType;
        private Scale _scale;
        private List<int> _stepsInScale;

        public List<int> _stepsInScaleIndex => GetIndexPositionsForStepsInScale();

        public int LargestIndexInStepsInScale => _stepsInScale.Max() - 1;
        public int LargestIndexInScale => _scale.Notes.Count - 1;

        public ChordDefinition(ChordType chordType, Scale scale, List<int> stepsInScale)
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
