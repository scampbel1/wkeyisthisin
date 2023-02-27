using EnumsNET;

namespace Keyify.Services.Models
{
    //TODO: Move all of this to the GeneratedScale class, it should only be generated once and should only be one class!
    public class ScaleEntry
    {
        public ScaleEntry(GeneratedScale scale)
        {
            Scale = scale;
        }

        public GeneratedScale Scale { get; set; }
        public bool Selected { get; set; }


        public string ScaleLabel => $"{Scale.RootNote}{Scale.Mode}";
        public bool IsKey => Scale.IsKey;

        public string FormalNameLabel_Flat => $"{Scale.RootNote} {Scale.Mode.AsString(EnumFormat.Description)}";
        public string ColloquialNameLabel_Flat => Scale.FlatColloquialism;
        public string ColloquialismIncludingFormalName_Flat => !string.IsNullOrWhiteSpace(ColloquialNameLabel_Flat) ? $"{ColloquialNameLabel_Flat} ({FormalNameLabel_Flat})" : $"{FormalNameLabel_Flat}";

        public string FormalNameLabel_Sharp => $"{Scale.SharpRootNote} {Scale.Mode.AsString(EnumFormat.Description)}";
        public string ColloquialNameLabel_Sharp => Scale.SharpColloquialism;
        public string ColloquialismIncludingFormalName_Sharp => !string.IsNullOrWhiteSpace(ColloquialNameLabel_Sharp) ? $"{ColloquialNameLabel_Sharp} ({FormalNameLabel_Sharp})" : $"{FormalNameLabel_Sharp}";
    }
}