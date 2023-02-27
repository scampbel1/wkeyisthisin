using Keyify.Services.Models;

namespace Keyify.Service.Interfaces
{
    public interface IScaleDefinitionService
    {
        public List<ScaleDefinition> ScaleDefinitions { get; set; }
        public Task InitialiseChordDefinitionCache();
    }
}