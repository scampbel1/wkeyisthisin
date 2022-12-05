using Keyify.Service.Interface;
using KeyifyClassLibrary.Core.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Keyify.Models.Service
{
    public class ModeDefinitionService : IModeDefinitionService
    {
        private readonly ModeService _scaleModeDictionary;
        private readonly List<ModeDefinition> _modeDefinitions;

        public ModeDefinitionService(ModeService scaleModeDictionary)
        {
            _scaleModeDictionary = scaleModeDictionary;
            _modeDefinitions = _scaleModeDictionary.ModeDefinitions.ToList();
        }

        public List<ModeDefinition> GetModeDefinitions()
        {
            return _modeDefinitions;
        }
    }
}