namespace KeyifyScaleFinderClassLibrary.MusicTheory
{
    public abstract class AbstractTriadFactory
    {
        public abstract TriadType[] ReturnTriadSteps(HeptatonicModes mode);
        //public abstract TriadType[] ReturnTriadSteps(PentatonicModes mode);
    }
}