using Keyify.MusicTheory.Enums;

namespace Keyify.Services.Formatter.Interfaces
{
    public interface ISerializationFormatter
    {
        public Task<Interval[]?> ConvertToIntervalArray(byte[] bytes);
        public Task<string[]?> ConvertToDegreeArray(byte[] bytes);
        public Task<Note[]?> ConvertToAllowedRootNotesArray(byte[] bytes);
    }
}
