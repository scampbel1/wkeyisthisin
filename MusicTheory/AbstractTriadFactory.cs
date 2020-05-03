using KeyifyClassLibrary.Core.MusicTheory.Enums;

namespace KeyifyClassLibrary.Core.MusicTheory
{
    public abstract class AbstractChordGroupingFactory
    {
        public abstract TriadType[] ReturnTriadTemplate(Mode mode);
        public abstract TriadType[] ReturnTriadTemplate(PentatonicModes mode);
    }
}