﻿using System.Collections.Generic;
using KeyifyClassLibrary.Core.Domain.Enums;
using static KeyifyClassLibrary.Core.Domain.ScaleModeDictionary;

namespace Keyify.Service
{
    public interface IScaleDirectoryService
    {
        List<ScaleDirectoryEntry> GetDirectory();
        ScaleDirectoryEntry GetDirectoryEntry(Mode mode);
    }
}
