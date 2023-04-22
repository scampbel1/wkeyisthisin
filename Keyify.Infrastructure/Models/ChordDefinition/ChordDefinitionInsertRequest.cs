using Keyify.MusicTheory.Enums;

namespace Keyify.Infrastructure.Models.ChordDefinition
{
    public class ChordDefinitionInsertRequest
    {
        public string? Name { get; set; }
        public int[]? Intervals { get; set; }
    }
}
