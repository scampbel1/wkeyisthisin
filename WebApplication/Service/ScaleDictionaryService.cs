using Keyify.Music_Theory.Helper;
using Keyify.Service;
using KeyifyClassLibrary.Core.Domain;
using KeyifyClassLibrary.Core.Domain.Enums;
using KeyifyClassLibrary.Core.Domain.Helper;
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
                retVal = _scaleDictionary.SingleOrDefault(a => a.Value.UserReadableLabel == scaleLabel).Value;

            _currentlySelected = retVal.ScaleLabel;

            return retVal;
        }

        public static Dictionary<string, ScaleDictionaryEntry> GenerateDictionary(IScaleDirectoryService scaleDirectoryService)
        {
            Dictionary<string, ScaleDictionaryEntry> dictionary = new Dictionary<string, ScaleDictionaryEntry>();

            foreach (ScaleDirectoryEntry scaleDirectoryEntry in scaleDirectoryService.GetDirectory())
            {
                foreach (string note in EnumHelper.GetAllEnumNames(typeof(Note)))
                {
                    string scaleLabel = $"{note} {scaleDirectoryEntry.Label}";

                    Note realNote = NoteHelper.ConvertStringNoteToNoteType(note);

                    ScaleDictionaryEntry entry = new ScaleDictionaryEntry(scaleLabel, ScaleHelper.GenerateScaleFromKey(realNote, scaleDirectoryEntry.ScaleSteps), scaleDirectoryEntry.Mode);

                    dictionary.Add(scaleLabel, entry);
                }
            }

            return dictionary;
        }

        public static ScaleDictionaryEntry GenerateEntryFromString(string inputScale, IScaleDirectoryService scaleDirectoryService)
        {
            inputScale = ScaleDictionaryHelper.ConvertUserFriendlyLabelIntoLabel(inputScale);

            string note = inputScale.Substring(0, inputScale.IndexOf(' '));
            string mode = inputScale.Substring(inputScale.IndexOf(' '), inputScale.Length - (note.Length));

            if (note.Length > 1)
                if (note[1] == '#')
                    note = NoteHelper.ConvertSharpNoteStringToFlatNote(note).ToString();

            Note realNote = NoteHelper.ConvertStringNoteToNoteType(note);

            ScaleDirectoryEntry realScale = scaleDirectoryService.GetDirectoryEntry(ModeHelper.ConvertStringModeNameToModeType(mode));

            Scale generatedScale = ScaleHelper.GenerateScaleFromKey(realNote, realScale.ScaleSteps);

            return new ScaleDictionaryEntry(inputScale, generatedScale);
        }
    }
}