﻿using KeyifyClassLibrary.Core.Domain.Enums;
using System.Collections.Generic;
using System.Linq;
using static KeyifyClassLibrary.Core.Domain.ScaleModeDictionary;

namespace Keyify.Service
{
    public class ScaleDirectoryService : IScaleDirectoryService
    {
        private List<ScaleDirectoryEntry> _directory;

        public ScaleDirectoryService()
        {
            _directory = GenerateDirectory();
        }

        public List<ScaleDirectoryEntry> GetDirectory()
        {
            return _directory;
        }

        public ScaleDirectoryEntry GetDirectoryEntry(Mode mode)
        {
            return _directory.FirstOrDefault(s => s.Mode == mode);
        }
    }
}