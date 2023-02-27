using Keyify.Infrastructure.Models.ScaleDefinition;
using Keyify.Services.Models;

namespace Keyify.Infrastructure.Caches.Interfaces
{
    public interface IScaleDefinitionCache
    {
        public List<ScaleDefinition> ScaleDefinitions { get; set; }

        public Task Initialise(List<ScaleDefinitionEntity> scaleDefinitionEntities);

        public Task Sync(List<ScaleDefinition> scaleDefinitions);
    }
}
