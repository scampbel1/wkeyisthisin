using Keyify.Service;
using KeyifyClassLibrary.Core.Domain;
using KeyifyClassLibrary.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using static KeyifyClassLibrary.Core.Domain.ModeDictionary;

namespace Keyify.Models
{
    public class ScaleListService : IScaleListService
    {
        private readonly IScaleService _scaleDirectoryService;
        private readonly IEnumerable<ScaleListEntry> _scaleList;

        public ScaleListService(IScaleService scaleDirectoryService)
        {
            _scaleDirectoryService = scaleDirectoryService;
            _scaleList = GenerateScaleList();
        }

        public IEnumerable<ScaleListEntry> GetScaleList()
        {
            return _scaleList;
        }

        public IEnumerable<ScaleListEntry> FindScales(IEnumerable<Note> selectedNotes)
        {
            return _scaleList.Where(a => a.Scale.NoteSet.IsSupersetOf(selectedNotes));
        }

        public IEnumerable<ScaleListEntry> GenerateScaleList()
        {
            List<ScaleListEntry> dictionary = new List<ScaleListEntry>();

            foreach (ModeDefinition scaleDirectoryEntry in _scaleDirectoryService.GetDirectory())
            {
                foreach (Note note in Enum.GetValues(typeof(Note)))
                {
                    var scale = new Scale(note, scaleDirectoryEntry);

                    dictionary.Add(new ScaleListEntry(scale));
                }
            }

            return dictionary;
        }
    }
}