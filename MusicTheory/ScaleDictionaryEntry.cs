namespace KeyifyClassLibrary.Core.MusicTheory
{
    public class ScaleDictionaryEntry
    {
        public string ScaleName { get; set; }
        public Scale Scale { get; set; }

        public ScaleDictionaryEntry(string name, Scale scale)
        {
            ScaleName = name;
            Scale = scale;
        }
    }
}