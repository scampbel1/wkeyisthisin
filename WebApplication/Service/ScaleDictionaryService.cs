using Keyify.Music_Theory.Helper;
using Keyify.Service;
using KeyifyClassLibrary.Core.Domain;
using KeyifyClassLibrary.Core.Domain.Enums;
using KeyifyClassLibrary.Core.Domain.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using static KeyifyClassLibrary.Core.Domain.ScaleModeDictionary;

namespace Keyify.Models
{
    public class ScaleDictionaryService : IScaleDictionaryService
    {
        private readonly Dictionary<string, ScaleDictionaryEntry> _scaleDictionary;
        private string _currentlySelected;

        public ScaleDictionaryService(IScaleDirectoryService scaleDirectoryService)
        {
            _scaleDictionary = GenerateDictionary(scaleDirectoryService);
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
                retVal = _scaleDictionary.SingleOrDefault(a => a.Value.UserReadableLabel_Flat == scaleLabel).Value;

            _currentlySelected = retVal.ScaleLabel;

            return retVal;
        }

        public static Dictionary<string, ScaleDictionaryEntry> GenerateDictionary(IScaleDirectoryService scaleDirectoryService)
        {
            Dictionary<string, ScaleDictionaryEntry> dictionary = new Dictionary<string, ScaleDictionaryEntry>();

            foreach (ScaleDirectoryEntry scaleDirectoryEntry in scaleDirectoryService.GetDirectory())
            {
                foreach (Note note in Enum.GetValues(typeof(Note)))
                {
                    Scale scale = ScaleHelper.GenerateScale(note, scaleDirectoryEntry);

                    ScaleDictionaryEntry entry = new ScaleDictionaryEntry(scale);

                    dictionary.Add(entry.ScaleLabel, entry);
                }
            }

            return dictionary;
        }        
    }
}