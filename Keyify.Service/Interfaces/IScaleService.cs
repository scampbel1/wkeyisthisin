using Keyify.MusicTheory.Enums;
using Keyify.Services.Models;

namespace Keyify.Service.Interfaces
{
    public interface IScaleService
    {
        public List<ScaleEntry> Scales { get; }
        public IEnumerable<ScaleEntry> FindScales(IEnumerable<Note> selectedNotes);
        public Task InitialiseScaleDefinitionService();
    }
}
