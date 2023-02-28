using Keyify.Services.Models;

namespace Keyify.Service.Interfaces
{
    public interface IScaleDefinitionService
    {
        public List<ScaleDefinition> ScaleDefinitions { get; }
        public Task InitialiseScaleDefinitionCache();
        public Task<List<ScaleDefinition>> Sync(int[] scaleDefinitionIds);
    }
}