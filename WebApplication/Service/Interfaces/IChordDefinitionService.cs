using Keyify.Models.Service_Models;
using System.Collections.Generic;

namespace Keyify.Service.Interfaces
{
    public interface IChordDefinitionService
    {
        IEnumerable<ChordDefinition> GetChordDefinitions();
    }
}
