using KeyifyClassLibrary.Enums;
using KeyifyClassLibrary.Models.MusicTheory;
using System.Collections.Generic;
using System.Linq;

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
            if (modeDefinition.ExplicitNotesForMode != null)
            {
                scaleEntry.AddRange(from Note note in modeDefinition.ExplicitNotesForMode
                                    let scale = new GeneratedScale(note, modeDefinition)
                                    select new ScaleEntry(scale));
            }

            return scaleEntry;
        }
    }
}