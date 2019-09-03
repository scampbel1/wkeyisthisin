using KeyifyScaleFinderClassLibrary.Core.MusicTheory.Enums;

namespace KeyifyScaleFinderClassLibrary.Core.MusicTheory
{
    public abstract class AbstractChordGroupingFactory
    {
        public abstract TriadType[] ReturnTriadTemplate(HeptatonicMode mode);
        public abstract TriadType[] ReturnTriadTemplate(PentatonicModes mode);
    }
}