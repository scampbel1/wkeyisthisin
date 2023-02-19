using Keyify.Service.Interfaces;
using Keyify.Services.Models;
using Keyify.Web.Infrastructure.Caches;

namespace Keyify.Models.Service
{
    public class ModeService : IModeService
    {
        private readonly ModeDataCache _modeDefinitionService;

        public List<ModeDefinition> Modes => _modeDefinitionService.ModeDefinitions;

        public ModeService(ModeDataCache modeDefinitionService)
        {
            _modeDefinitionService = modeDefinitionService;
        }
    }
}