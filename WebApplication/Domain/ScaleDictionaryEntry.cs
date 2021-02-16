using Keyify.Domain.Helper;
using KeyifyClassLibrary.Core.Domain.Helper;

namespace KeyifyClassLibrary.Core.Domain
{
    public class ScaleDictionaryEntry
    {
        public Scale Scale { get; set; }
        public bool Selected { get; set; }
        public string ScaleLabel { get; set; }

        public readonly string UserReadableLabel_Flat;
        public readonly string ColloquialNameLabel_Flat;
        public readonly string UserReadableLabelIncludingColloquialism_Flat;

        public readonly string UserReadableLabel_Sharp;
        public readonly string ColloquialNameLabel_Sharp;
        public readonly string UserReadableLabelIncludingColloquialism_Sharp;

        public ScaleDictionaryEntry(Scale scale)
        {
            ScaleLabel = $"{scale.RootNote}{scale.Mode}";
            Scale = scale;
            UserReadableLabel_Flat = ScaleDictionaryHelper.GetUserFriendlyLabel(ScaleLabel);
            ColloquialNameLabel_Flat = PentatonicModeHelper.GetScaleColloquialism(scale);
            UserReadableLabelIncludingColloquialism_Flat = !string.IsNullOrWhiteSpace(ColloquialNameLabel_Flat) ? $"{UserReadableLabel_Flat}/{ColloquialNameLabel_Flat}" : $"{UserReadableLabel_Flat}";

            string sharpNote = NoteHelper.ConvertNoteToStringEquivalent(scale.RootNote, true);

            UserReadableLabel_Sharp = ScaleDictionaryHelper.GetUserFriendlyLabel($"{sharpNote}{scale.Mode}");
            ColloquialNameLabel_Sharp = PentatonicModeHelper.GetScaleColloquialism(scale, true);
            UserReadableLabelIncludingColloquialism_Sharp = !string.IsNullOrWhiteSpace(ColloquialNameLabel_Sharp) ? $"{UserReadableLabel_Sharp}/{ColloquialNameLabel_Sharp}" : $"{UserReadableLabel_Sharp}";
        }
    }
}