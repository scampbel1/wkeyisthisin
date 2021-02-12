using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyifyClassLibrary.Core.Domain.Helper
{
    public static class EnumHelper
    {
        public static List<string> GetAllEnumNames(Type type)
        {
            return Enum.GetNames(type).ToList();
        }

        public static int GetEnumNameCount(Type type)
        {
            return GetAllEnumNames(type).Count;
        }
    }
}