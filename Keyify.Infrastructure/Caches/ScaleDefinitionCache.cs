using Keyify.Infrastructure.Caches.Interfaces;
using Keyify.Infrastructure.Models.ScaleDefinition;
using Keyify.Services.Models;

namespace Keyify.Infrastructure.Caches
{
    public class ScaleDefinitionCache : IScaleDefinitionCache
    {
        public List<ScaleDefinition> ScaleDefinitions { get; set; }

        public async Task Initialise(List<ScaleDefinitionEntity> scaleDefinitionEntities)
        {
            var scaleDefinitions = new List<ScaleDefinition>();

            foreach (var entity in scaleDefinitionEntities)
            {
                var scaleEntry = entity.AllowedRootNotes == null ? new ScaleDefinition(entity.Name, entity.Intervals, entity.Degrees) : new ScaleDefinition(entity.Name, entity.Intervals, entity.Degrees, entity.AllowedRootNotes);

                scaleDefinitions.Add(scaleEntry);
            }

            await Task.FromResult(ScaleDefinitions = scaleDefinitions);
        }

        public Task Sync(List<ScaleDefinition> scaleDefinitions)
        {
            throw new NotImplementedException();
        }
    }
}
