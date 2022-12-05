using Keyify.Models.Service_Models;
using System.Collections.Generic;

namespace Keyify.Service.Interfaces
{
    public interface IChordService
    {
        public List<ChordDefinition> Chords { get; }
    }
}
