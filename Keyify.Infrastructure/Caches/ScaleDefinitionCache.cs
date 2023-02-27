using Keyify.Infrastructure.Caches.Interfaces;
using Keyify.Services.Models;

namespace Keyify.Infrastructure.Caches
{
    public class ScaleDefinitionCache : IScaleDefinitionCache
    {
        public List<ScaleDefinition> ScaleDefinitions { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Task Initialise()
        {
            throw new NotImplementedException();
        }

        public Task Sync(List<ScaleDefinition> scaleDefinitions)
        {
            throw new NotImplementedException();
        }
    }
}
