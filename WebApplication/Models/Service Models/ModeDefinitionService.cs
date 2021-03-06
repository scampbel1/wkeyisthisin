﻿using Keyify.Service.Interface;
using System.Collections.Generic;
using static KeyifyClassLibrary.Core.Domain.ModeDictionary;

namespace Keyify.Models.Service
{
    public class ModeDefinitionService : IModeDefinitionService
    {
        private IEnumerable<ModeDefinition> _modeDefinitions;

        public ModeDefinitionService()
        {
            _modeDefinitions = GenerateModeDefinitions();
        }

        public IEnumerable<ModeDefinition> GetModeDefinitions()
        {
            return _modeDefinitions;
        }
    }
}