using KeyifyClassLibrary.Enums;
using KeyifyClassLibrary.Models.MusicTheory;
using System.Collections.Generic;

namespace Keyify.Models.Service
{
    public partial class ScaleListService
    {
        private List<ScaleEntry> GetScaleEntries(IEnumerable<ModeDefinition> modeDefinitions)
        {
            var scaleEntries = new List<ScaleEntry>();

            foreach (var modeDefinition in modeDefinitions)
            {
                scaleEntries.AddRange(GenerateScaleEntries(modeDefinition));
            }

            return scaleEntries;
        }

        private IEnumerable<ScaleEntry> GenerateScaleEntries(ModeDefinition modeDefinition)
        {
            var scaleEntry = new List<ScaleEntry>();

            foreach (Note note in modeDefinition.KeysFoundForMode)
            {
                var scale = new Scale(note, modeDefinition);

                scaleEntry.Add(new ScaleEntry(scale));
            }

            return scaleEntry;
        }
    }
}