using KeyifyClassLibrary.Core.Domain.Helper;

namespace KeyifyClassLibrary.Core.Domain
{
    public class ScaleDictionaryEntry
    {
        public string ScaleLabel { get; set; }
        public string UserReadableLabel { get; set; }
        public Scale Scale { get; set; }
        public bool Selected { get; set; }

        public ScaleDictionaryEntry(string name, Scale scale)
        {
            ScaleLabel = name;
            Scale = scale;
            UserReadableLabel = ScaleDictionaryHelper.GetUserFriendlyLabel(ScaleLabel);
        }
    }
}