using Keyify.MusicTheory.Enums;

namespace Keyify.Infrastructure.Models.ScaleDefinition
{
    public class ScaleDefinitionRequest
    {
        public string? Name { get; set; }
        public Interval[]? Intervals { get; set; }
    }
}
