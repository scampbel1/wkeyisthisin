using System.Collections.Generic;
using Keyify.Service;
using KeyifyClassLibrary.Core.Domain;
using KeyifyClassLibrary.Core.Domain.Helper;

namespace Keyify.Models
{
    public class ScaleDictionaryService : IScaleDictionaryService
    {
        private readonly Dictionary<string, ScaleDictionaryEntry> _scaleDictionary;

        public ScaleDictionaryService(IScaleDirectoryService scaleDirectoryService)
        {
            _scaleDictionary = ScaleDictionaryHelper.GenerateDictionary(scaleDirectoryService);
        }

        public Dictionary<string, ScaleDictionaryEntry> GetScaleDictionary()
        {
            return _scaleDictionary;
        }
    }
}