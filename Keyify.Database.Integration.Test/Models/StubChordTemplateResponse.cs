using Keyify.MusicTheory.Enums;

namespace Keyify.Database.Integration.Test.Models
{
    internal class StubChordTemplateResponse
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Note[]? AllowedRootNotes { get; set; }
    }
}
