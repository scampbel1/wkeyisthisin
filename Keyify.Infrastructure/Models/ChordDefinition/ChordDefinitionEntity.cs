using Keyify.MusicTheory.Enums;

namespace Keyify.Web.Infrastructure.Models.ChordDefinition
{
    public class ChordDefinitionEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        //TODO: Deserialize db value on retrieval from Repo
        public Interval[]? Intervals { get; set; }
    }
}
