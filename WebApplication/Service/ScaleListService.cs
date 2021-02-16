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
    public class ScaleListService : IScaleListService
    {
        private readonly List<ScaleListEntry> _scaleList;
        private string _currentlySelected;

        public ScaleListService(IScaleDirectoryService scaleDirectoryService)
        {
            _scaleList = GenerateScaleList(scaleDirectoryService);
        }

        public List<ScaleListEntry> GetScaleList()
        {
            return _scaleList;
        }

        public static List<ScaleListEntry> GenerateScaleList(IScaleDirectoryService scaleDirectoryService)
        {
            List<ScaleListEntry> dictionary = new List<ScaleListEntry>();

            foreach (ScaleDirectoryEntry scaleDirectoryEntry in scaleDirectoryService.GetDirectory())
            {
                foreach (Note note in Enum.GetValues(typeof(Note)))
                {
                    Scale scale = ScaleHelper.GenerateScale(note, scaleDirectoryEntry);

                    ScaleListEntry entry = new ScaleListEntry(scale);

                    dictionary.Add(entry);
                }
            }

            return dictionary;
        }
    }
}