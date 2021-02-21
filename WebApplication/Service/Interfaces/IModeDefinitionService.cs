using Keyify.Models.Service;
using System.Collections.Generic;

namespace Keyify.Service.Interface
{
    public interface IModeDefinitionService
    {
        IEnumerable<ModeDefinition> GetModeDefinitions();
    }
}