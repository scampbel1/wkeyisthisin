using KeyifyClassLibrary.Core.Domain;
using System.Collections.Generic;

namespace Keyify.Models
{
    public interface IScaleDictionaryService
    {
        List<ScaleDictionaryEntry> GetDictionary();
    }
}
