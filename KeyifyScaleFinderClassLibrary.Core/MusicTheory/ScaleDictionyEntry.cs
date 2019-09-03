namespace KeyifyScaleFinderClassLibrary.Core.MusicTheory
{
    public class ScaleDictionyEntry
    {
        public string ScaleName { get; set; }
        public Scale Scale { get; set; }

        public ScaleDictionyEntry(string name, Scale scale)
        {
            ScaleName = name;
            Scale = scale;
        }
    }
}