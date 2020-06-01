using KeyifyClassLibrary.Core.MusicTheory;
using System;
using System.Collections.Generic;

namespace Keyify.Models
{
    public class ScaleDictionaryService : IScaleDictionaryService
    {
        private readonly List<ScaleDictionaryEntry> _scaleDictionary;

        public ScaleDictionaryService()
        {
            _scaleDictionary = ScaleDictionary.GenerateDictionary();
        }

        public List<ScaleDictionaryEntry> GetDictionary()
        {
            return _scaleDictionary;
        }
    }
}
