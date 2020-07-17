using System.Collections.Generic;
using KeyifyClassLibrary.Core.MusicTheory.Enums;
using KeyifyClassLibrary.Core.MusicTheory.Helper;

namespace KeyifyClassLibrary.Core.MusicTheory
{
    public class ScaleMatch
    {
        public readonly string ScaleLabel;
        public readonly string UserReadableLabel;

        public readonly List<Note> Scale;

        public bool Selected { get; set; }

        public ScaleMatch(string scaleName, List<Note> notes)
        {
            ScaleLabel = scaleName;
            UserReadableLabel = ScaleMatchHelper.GetUserFriendlyLabel(ScaleLabel);
            Scale = notes;
        }
    }
}
