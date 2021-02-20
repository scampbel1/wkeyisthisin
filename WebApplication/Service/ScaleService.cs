using KeyifyClassLibrary.Core.Domain.Enums;
using System.Collections.Generic;
using System.Linq;
using static KeyifyClassLibrary.Core.Domain.ModeDictionary;

namespace Keyify.Service
{
    public class ScaleService : IScaleService
    {
        private List<ModeDefinition> _directory;

        public ScaleService()
        {
            _directory = GenerateDirectory();
        }

        public List<ModeDefinition> GetDirectory()
        {
            return _directory;
        }

        public ModeDefinition GetDirectoryEntry(Mode mode)
        {
            return _directory.FirstOrDefault(s => s.Mode == mode);
        }
    }
}