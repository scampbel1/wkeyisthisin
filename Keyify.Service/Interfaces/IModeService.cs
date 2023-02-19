using Keyify.Services.Models;

namespace Keyify.Service.Interfaces
{
    public interface IModeService
    {
        public List<ModeDefinition> Modes { get; }
    }
}