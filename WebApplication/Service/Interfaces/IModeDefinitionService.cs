using Keyify.Models.Service;
using System.Collections.Generic;

namespace Keyify.Service.Interface
{
    public interface IModeService
    {
        public List<ModeDefinition> Modes { get; }
    }
}