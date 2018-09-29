using KeyifyScaleFinderClassLibrary.MusicTheory.Enums;

namespace KeyifyScaleFinderClassLibrary.MusicTheory
{
    public abstract class AbstractChordGroupingFactory
    {
        public abstract TriadType[] ReturnTriadTemplate(HeptatonicMode mode);
        public abstract TriadType[] ReturnTriadTemplate(PentatonicModes mode);
    }
}