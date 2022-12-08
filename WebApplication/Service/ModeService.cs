using Keyify.Service.Interfaces;
using KeyifyClassLibrary.Core.Domain;
using System.Collections.Generic;

namespace Keyify.Models.Service
{
    public class ModeService : IModeService
    {
        private readonly ModeDataStore _modeDefinitionService;

        public List<ModeDefinition> Modes => _modeDefinitionService.ModeDefinitions;

        public ModeService(ModeDataStore modeDefinitionService)
        {
            _modeDefinitionService = modeDefinitionService;
        }
    }
}