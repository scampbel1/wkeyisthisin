using Keyify.Domain.Helper;
using KeyifyClassLibrary.Core.Domain.Enums;
using KeyifyClassLibrary.Core.Domain.Helper;

namespace KeyifyClassLibrary.Core.Domain
{
    public class ScaleDictionaryEntry
    {
        public Mode Mode { get; set; }
        public Scale Scale { get; set; }
        public bool Selected { get; set; }
        public string ScaleLabel { get; set; }
        public string UserReadableLabel { get; set; }
        public string ColloquialNameLabel { get; set; }

        public ScaleDictionaryEntry(string name, Scale scale)
        {
            ScaleLabel = name;
            Scale = scale;
            UserReadableLabel = ScaleDictionaryHelper.GetUserFriendlyLabel(name);
        }

        public ScaleDictionaryEntry(string name, Scale scale, Mode mode) : this(name, scale)
        {
            Mode = mode;
            ColloquialNameLabel = PentatonicModeHelper.GetScaleColloquialism(mode, scale);
        }
    }
}