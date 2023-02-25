using Keyify.Service.Interfaces;
using Keyify.Services.Models;
using Keyify.Web.Infrastructure.Caches;

namespace Keyify.Models.Service
{
    public class ScaleDefinitionService : IScaleDefinitionService
    {
        private readonly ScaleDefinitionCache _scaleDefinitionService;

        public List<ScaleDefinition> ScaleDefinitions => _scaleDefinitionService.ScaleDefinitions;

        public ScaleDefinitionService(ScaleDefinitionCache scaleDefinitionService)
        {
            _scaleDefinitionService = scaleDefinitionService;
        }
    }
}