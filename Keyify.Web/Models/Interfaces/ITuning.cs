using KeyifyClassLibrary.Enums;

namespace KeyifyClassLibrary.Models.Interfaces
{
    public interface ITuning
    {
        Note[] Notes { get; }
        int StringCount { get; }
    }
}