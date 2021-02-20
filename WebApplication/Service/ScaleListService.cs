using Keyify.Service;
using KeyifyClassLibrary.Core.Domain;
using KeyifyClassLibrary.Core.Domain.Enums;
using KeyifyClassLibrary.Core.Domain.Helper;
using System;
using System.Collections.Generic;
using static KeyifyClassLibrary.Core.Domain.ModeDictionary;

namespace Keyify.Models
{
    public class ScaleListService : IScaleListService
    {
        private readonly List<ScaleListEntry> _scaleList;        

        public ScaleListService(IScaleService scaleDirectoryService)
        {
            _scaleList = GenerateScaleList(scaleDirectoryService);
        }

        public List<ScaleListEntry> GetScaleList()
        {
            return _scaleList;
        }

        public static List<ScaleListEntry> GenerateScaleList(IScaleService scaleDirectoryService)
        {
            List<ScaleListEntry> dictionary = new List<ScaleListEntry>();

            foreach (ModeDefinition scaleDirectoryEntry in scaleDirectoryService.GetDirectory())
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