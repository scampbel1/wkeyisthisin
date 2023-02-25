using Keyify.MusicTheory.Enums;

namespace Keyify.Web.Infrastructure.Models.ChordDefinition
{
    public class ChordDefinitionRequest
    {
        public string? Name { get; set; }
        public Interval[]? Intervals { get; set; }
    }
}
