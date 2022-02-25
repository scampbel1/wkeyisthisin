﻿using Keyify.Models.Interfaces;
using Keyify.Models.Service;
using KeyifyClassLibrary.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Keyify.Models.View_Models.Misc
{
    public class ScalesGroupingService : IScalesGroupingService
    {
        private List<ScaleGroupingEntry> KeyGroupingEntries { get; init; } = new List<ScaleGroupingEntry>();
        private List<ScaleGroupingEntry> ScaleGroupingEntries { get; init; } = new List<ScaleGroupingEntry>();

        public List<ScaleGroupingEntry> GetGroupedScales()
        {
            return ScaleGroupingEntries;
        }

        public List<ScaleGroupingEntry> GetGroupedKeys()
        {
            return KeyGroupingEntries;
        }

        public int GetTotalScaleCount()
        {
            return ScaleGroupingEntries.Sum(s => s.Count);
        }

        public int GetTotalKeyCount()
        {
            return KeyGroupingEntries.Sum(k => k.Count);
        }

        public void UpdateScaleGroupingModel(List<ScaleEntry> scales)
        {
            ScaleGroupingEntries.Clear();

            var noteHashSets = GenerateNoteHashSets(scales);

            //TODO: Remove boilerplate code
            foreach (var scaleNotes in noteHashSets)
            {
                var groupedScales = scales.Where(s => s.IsKey == false && s.Scale.NoteSet.SetEquals(scaleNotes)).ToList();

                if (groupedScales.Any())
                {
                    ScaleGroupingEntries.Add(new ScaleGroupingEntry(string.Join(',', scaleNotes), groupedScales));
                }
            }

            foreach (var scaleNotes in noteHashSets)
            {
                var groupedKeys = scales.Where(s => s.IsKey == true && s.Scale.NoteSet.SetEquals(scaleNotes)).ToList();

                if (groupedKeys.Any())
                {
                    KeyGroupingEntries.Add(new ScaleGroupingEntry(string.Join(',', scaleNotes), groupedKeys));
                }
            }
        }

        private List<HashSet<Note>> GenerateNoteHashSets(List<ScaleEntry> scales)
        {
            var distinctSets = new List<HashSet<Note>>();

            foreach (var scale in scales)
            {
                if (!distinctSets.Where(ds => ds.SetEquals(scale.Scale.NoteSet)).Any())
                {
                    distinctSets.Add(scale.Scale.NoteSet);
                }
            }

            return distinctSets;
        }
    }
}