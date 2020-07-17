using KeyifyClassLibrary.Core.Domain.Enums;

namespace KeyifyClassLibrary.Core.Domain.Tuning
{
    public interface ITuning
    {
        Note[] ReturnNotes();
        int ReturnStringCount();
    }
}