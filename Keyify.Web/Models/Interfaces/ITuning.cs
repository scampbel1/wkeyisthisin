using KeyifyClassLibrary.Enums;

namespace KeyifyClassLibrary.Models.Interfaces
{
    public interface ITuning
    {
        Note[] ReturnNotes();
        int ReturnStringCount();
    }
}