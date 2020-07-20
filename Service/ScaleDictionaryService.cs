using System.Linq;
using System.Collections.Generic;
using Keyify.Service;
using KeyifyClassLibrary.Core.Domain;
using KeyifyClassLibrary.Core.Domain.Helper;

namespace Keyify.Models
{
    public class ScaleDictionaryService : IScaleDictionaryService
    {
        private readonly Dictionary<string, ScaleDictionaryEntry> _scaleDictionary;
        private string _currentlySelected;

        public ScaleDictionaryService(IScaleDirectoryService scaleDirectoryService)
        {
            _scaleDictionary = ScaleDictionaryHelper.GenerateDictionary(scaleDirectoryService);
        }

        public Dictionary<string, ScaleDictionaryEntry> GetScaleDictionary()
        {
            return _scaleDictionary;
        }

        public ScaleDictionaryEntry GetScale(string scaleLabel)
        {
            if (!string.IsNullOrEmpty(_currentlySelected))
                _scaleDictionary[_currentlySelected].Selected = false;

            ScaleDictionaryEntry retVal = _scaleDictionary.GetValueOrDefault(scaleLabel);

            if (retVal == null)
                retVal = _scaleDictionary.SingleOrDefault(a => a.Value.UserReadableLabel == scaleLabel).Value;

            _currentlySelected = retVal.ScaleLabel;

            return retVal;
        }
    }
}