using KeyifyClassLibrary.Core.Domain.Enums;
using System;

namespace Keyify.Music_Theory.Helper
{
    public static class ModeHelper
    {
        public static Mode ConvertStringModeNameToModeType(string mode)
        {
            return (Mode)Enum.Parse(typeof(Mode), mode, true);
        }
    }
}
