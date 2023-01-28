using Keyify.Service.Caches;
using Keyify.Service.Interfaces;
using System.Collections.Generic;

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