using KeyifyClassLibrary.Core.Domain;
using KeyifyClassLibrary.Core.Domain.Helper;
using System.Collections.Generic;

namespace Keyify.Models
{
    public class ScaleDictionaryService : IScaleDictionaryService
    {
        private readonly List<ScaleDictionaryEntry> _scaleDictionary;

        public ScaleDictionaryService()
        {
            _scaleDictionary = ScaleDictionaryHelper.GenerateDictionary();
        }

        public List<ScaleDictionaryEntry> GetDictionary()
        {
            return _scaleDictionary;
        }
    }
}
