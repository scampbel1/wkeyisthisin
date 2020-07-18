﻿using System;
using KeyifyClassLibrary.Core.Domain.Enums;

namespace Keyify.Music_Theory.Helper
{
    public static class ModeHelper
    {
        public static Mode ConvertStringModeNameToModeType(string mode)
        {
            return (Mode)Enum.Parse(typeof(Mode), mode, true);
        }

        public static string ConvertModeToModeLabel(Mode mode)
        {
            return mode.ToString();
        }
    }
}