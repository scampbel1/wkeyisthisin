using KeyifyClassLibrary.Core.MusicTheory;
using System.Collections.Generic;

namespace Keyify.Models
{
    public interface IScaleDictionaryService
    {
        List<ScaleDictionaryEntry> GetDictionary();
    }
}
