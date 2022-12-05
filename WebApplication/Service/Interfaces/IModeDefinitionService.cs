using Keyify.Models.Service;
using System.Collections.Generic;

namespace Keyify.Service.Interface
{
    public interface IModeDefinitionService
    {
        public List<ModeDefinition> Modes { get; }
    }
}