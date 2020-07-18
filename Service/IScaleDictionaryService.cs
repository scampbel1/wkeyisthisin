using System.Collections.Generic;
using KeyifyClassLibrary.Core.Domain;

namespace Keyify.Models
{
    public interface IScaleDictionaryService
    {
        Dictionary<string, ScaleDictionaryEntry> GetScaleDictionary();
    }
}
