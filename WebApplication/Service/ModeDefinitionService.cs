using Keyify.Service.Interface;
using System.Collections.Generic;
using static KeyifyClassLibrary.Core.Domain.ScaleModeDictionary;

namespace Keyify.Models.Service
{
    public class ModeDefinitionService : IModeDefinitionService
    {
        private readonly List<ModeDefinition> _modeDefinitions;

        public ModeDefinitionService()
        {
            _modeDefinitions = GenerateModeDefinitions();
        }

        public List<ModeDefinition> GetModeDefinitions()
        {
            return _modeDefinitions;
        }
    }
}