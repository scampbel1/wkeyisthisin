using KeyifyClassLibrary.Core.Domain;
using System.Collections.Generic;

namespace Keyify.Models
{
    public interface IScaleDictionaryService
    {
        Dictionary<string, ScaleDictionaryEntry> GetScaleDictionary();
        ScaleDictionaryEntry GetScale(string ScaleLabel);
    }
}
