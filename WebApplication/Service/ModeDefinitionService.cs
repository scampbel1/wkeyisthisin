using Keyify.Service.Interface;
using KeyifyClassLibrary.Core.Domain;
using System.Collections.Generic;

namespace Keyify.Models.Service
{
    public class ModeDefinitionService : IModeDefinitionService
    {
        private readonly ModeService _scaleModeDictionary;
        public List<ModeDefinition> Modes => _scaleModeDictionary.ModeDefinitions;

        public ModeDefinitionService(ModeService scaleModeDictionary)
        {
            _scaleModeDictionary = scaleModeDictionary;
        }
    }
}