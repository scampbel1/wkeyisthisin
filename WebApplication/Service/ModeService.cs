using Keyify.Service.Interface;
using KeyifyClassLibrary.Core.Domain;
using System.Collections.Generic;

namespace Keyify.Models.Service
{
    public class ModeService : IModeService
    {
        private readonly ModeDefinitionService _modeDefinitionService;

        public List<ModeDefinition> Modes => _modeDefinitionService.ModeDefinitions;

        public ModeService(ModeDefinitionService modeDefinitionService)
        {
            _modeDefinitionService = modeDefinitionService;
        }
    }
}