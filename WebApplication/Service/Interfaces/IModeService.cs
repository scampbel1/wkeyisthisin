using Keyify.Models.Service;
using System.Collections.Generic;

namespace Keyify.Service.Interfaces
{
    public interface IModeService
    {
        public List<ModeDefinition> Modes { get; }
    }
}