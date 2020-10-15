using Keyify.Models;
using Keyify.Music_Theory.Helper;
using Keyify.Service;
using KeyifyClassLibrary.Core.Domain.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static KeyifyClassLibrary.Core.Domain.ScaleModeDictionary;

namespace KeyifyClassLibrary.Core.Domain.Helper
{
    public static class ScaleDictionaryHelper
    {
        public static Dictionary<string, ScaleDictionaryEntry> GetMatchedScales(IEnumerable<Note> selectedNotes, IScaleDictionaryService dictionary)
        {
            Dictionary<string, ScaleDictionaryEntry> dictionaryPointer = dictionary.GetScaleDictionary();

            return dictionaryPointer.Values.Where(a => a.Scale.NotesSet.IsSupersetOf(selectedNotes)).ToDictionary(a => a.ScaleLabel, b => b);
        }

        public static Dictionary<string, ScaleDictionaryEntry> GenerateDictionary(IScaleDirectoryService scaleDirectoryService)
        {
            Dictionary<string, ScaleDictionaryEntry> dictionary = new Dictionary<string, ScaleDictionaryEntry>();

            foreach (ScaleDirectoryEntry mode in scaleDirectoryService.GetDirectory())
            {
                foreach (string note in EnumHelper.GetAllNoteNames())
                {
                    string scaleLabel = note + " " + mode.Label;

                    Note realNote = NoteHelper.ConvertStringNoteToNoteType(note);

                    ScaleDictionaryEntry entry = new ScaleDictionaryEntry(scaleLabel, ScaleHelper.GenerateScaleFromKey(realNote, mode.ScaleSteps));

                    dictionary.Add(scaleLabel, entry);
                }
            }

            return dictionary;
        }

        public static ScaleDictionaryEntry GenerateEntryFromString(string inputScale, IScaleDirectoryService scaleDirectoryService)
        {
            inputScale = ConvertUserFriendlyLabelIntoLabel(inputScale);

            string note = inputScale.Substring(0, inputScale.IndexOf(' '));
            string mode = inputScale.Substring(inputScale.IndexOf(' '), inputScale.Length - (note.Length));

            if (note.Length > 1)
                if (note[1] == '#')
                    note = NoteHelper.ConvertSharpNoteStringToFlatNote(note).ToString();

            Note realNote = NoteHelper.ConvertStringNoteToNoteType(note);

            ScaleDirectoryEntry realScale = scaleDirectoryService.GetDirectoryEntry(ModeHelper.ConvertStringModeNameToModeType(mode));

            Scale generatedScale = ScaleHelper.GenerateScaleFromKey(realNote, realScale.ScaleSteps);

            return new ScaleDictionaryEntry(inputScale, generatedScale);
        }

        public static string GetUserFriendlyLabel(string label)
        {
            StringBuilder sb = new StringBuilder().Append(label);
            int count = 1;

            while (count < sb.Length - 1)
            {
                if (char.IsUpper(sb[count]) && sb[count - 1] != ' ')
                    sb.Insert(count, ' ');

                count++;
            }

            return sb.ToString();
        }

        public static string ConvertUserFriendlyLabelIntoLabel(string inputScale)
        {
            StringBuilder sb = new StringBuilder().Append(inputScale);

            for (int i = 4; i <= sb.Length - 1; i++)
            {
                if (sb[i] == ' ')
                    sb.Remove(i, 1);
            }

            return sb.ToString();
        }
    }
}