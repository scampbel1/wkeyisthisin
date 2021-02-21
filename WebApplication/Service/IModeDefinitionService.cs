using System.Collections.Generic;

namespace Keyify.Service
{
    public interface IModeDefinitionService
    {
        IEnumerable<ModeDefinition> GetModeDefinitions();
    }
}