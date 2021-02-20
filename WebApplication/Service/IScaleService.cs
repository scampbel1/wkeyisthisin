using KeyifyClassLibrary.Core.Domain.Enums;
using System.Collections.Generic;
using static KeyifyClassLibrary.Core.Domain.ModeDictionary;

namespace Keyify.Service
{
    public interface IScaleService
    {
        List<ModeDefinition> GetDirectory();
        ModeDefinition GetDirectoryEntry(Mode mode);
    }
}