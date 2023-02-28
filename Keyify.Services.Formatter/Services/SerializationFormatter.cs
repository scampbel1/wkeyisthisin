using Keyify.MusicTheory.Enums;
using Keyify.Services.Formatter.Interfaces;
using System.Text.Json;

namespace Keyify.Services.Formatter.Services
{
    public class SerializationFormatter : ISerializationFormatter
    {
        public async Task<Note[]?> ConvertToAllowedRootNotesArray(byte[] bytes)
        {
            using var memoryStream = new MemoryStream(bytes);

            var allowedRootNotes = await JsonSerializer.DeserializeAsync<Note[]?>(memoryStream);

            return allowedRootNotes;
        }

        public async Task<string[]?> ConvertToDegreeArray(byte[] bytes)
        {
            using var memoryStream = new MemoryStream(bytes);

            var degrees = await JsonSerializer.DeserializeAsync<string[]>(memoryStream);

            return degrees;
        }

        public async Task<Interval[]?> ConvertToIntervalArray(byte[] bytes)
        {
            using var memoryStream = new MemoryStream(bytes);

            var intervals = await JsonSerializer.DeserializeAsync<Interval[]>(memoryStream);

            return intervals;
        }
    }
}
