using KeyifyScaleFinderClassLibrary.MusicTheory.Enums;

namespace KeyifyScaleFinderClassLibrary.MusicTheory
{
    public static class ScaleNoteGenerator
    {
        public static Scale GenerateNotes(Note key, ScaleStep[] scaleSteps)
        {
            var scale = new Scale(key);
            var noteNumber = (int)key;

            foreach (var scaleStep in scaleSteps)
            {
                noteNumber += (int)scaleStep;
                if (noteNumber > 11) noteNumber -= 12; //number of notes will never be larger than 12
                scale.AddNote((Note)noteNumber);
            }

            return scale;
        }
    }
}