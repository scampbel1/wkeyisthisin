using Keyify.Models.ServiceModels;
using KeyifyClassLibrary.Enums;
using System.Collections.Generic;

namespace Keyify.Service.Interfaces
{
    public interface IChordDefinitionService
    {
        public List<ChordDefinition> FindChordDefinitions(Note[] notes);
    }
}
