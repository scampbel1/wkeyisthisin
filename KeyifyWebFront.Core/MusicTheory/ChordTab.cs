using System;
using System.Collections.Generic;

namespace KeyifyClassLibrary.Core.MusicTheory
{
    public class ChordTab
    {
        private List<Tuple<int, int?>> ChordMap { get; set; }

        //public ChordTab(int?[] tabs)
        //{
        //    this.ChordMap = InitNotes(tabs);
        //}

        public List<Tuple<int, int?>> GetChordMap()
        {
            return ChordMap;
        }

        //public int ReturnNoteLength()
        //{
        //    return this.ChordMap.Count;
        //}

        //private static List<Tuple<int, int?>> InitNotes(int?[] tabs)
        //{
        //    int count = 0;
        //    var ChordMapBuilder = new List<Tuple<int, int?>>();

        //    while (count <= tabs.Length - 1)
        //    {
        //        ChordMapBuilder.Add(new Tuple<int, int?>(count, tabs[count].HasValue ? tabs[count].Value : new int?()));
        //        count++;
        //    }

        //    return ChordMapBuilder;
        //}
    }
}
