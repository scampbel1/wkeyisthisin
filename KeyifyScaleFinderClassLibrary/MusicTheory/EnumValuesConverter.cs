using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyifyScaleFinderClassLibrary.MusicTheory
{
    /*https://www.guitarmasterclass.net/guitar_forum/index.php?showtopic=6023
     *https://www.guitarmasterclass.net/guitar_forum/index.php?showtopic=3630
    */

    public static class EnumValuesConverter
    {
        public static List<string> GetNotes()
        {
            return Enum.GetNames(typeof(Note)).ToList();
        }

        public static List<string> GetModes()
        {
            return Enum.GetNames(typeof(HeptatonicModes)).ToList();
        }
    }
}