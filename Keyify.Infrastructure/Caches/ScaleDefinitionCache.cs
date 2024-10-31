using Keyify.Infrastructure.Caches.Interfaces;
using Keyify.Infrastructure.Models.ScaleDefinition;
using Keyify.Services.Models;

namespace Keyify.Infrastructure.Caches
{
    public class ScaleDefinitionCache : IScaleDefinitionCache
    {
        public List<ScaleDefinition> ScaleDefinitions { get; set; } = new List<ScaleDefinition>();

        public async Task Initialise(List<ScaleDefinitionEntity> scaleDefinitionEntities)
        {
            foreach (var entity in scaleDefinitionEntities)
            {
                var scaleEntry = new ScaleDefinition(entity.Name!, entity.Intervals!, entity.Degrees!, entity.Description!, entity.AllowedRootNotes);

                ScaleDefinitions.Add(scaleEntry);
            }

            await Task.FromResult(ScaleDefinitions);
        }

        public Task Sync(List<ScaleDefinition> scaleDefinitions)
        {
            throw new NotImplementedException();
        }
    }
}
