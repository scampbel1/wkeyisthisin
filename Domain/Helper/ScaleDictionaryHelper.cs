using System.Linq;
using System.Text;
using System.Collections.Generic;
using Keyify.Models;
using Keyify.Music_Theory.Helper;
using KeyifyClassLibrary.Core.Domain.Enums;
using static KeyifyClassLibrary.Core.Domain.ScaleModeDictionary;

namespace KeyifyClassLibrary.Core.Domain.Helper
{
    public static class ScaleDictionaryHelper
    {
        public static List<ScaleDictionaryEntry> GetMatchedScales(IEnumerable<Note> selectedNotes, IScaleDictionaryService dictionary)
        {
            return dictionary.GetDictionary().Where(a => a.Scale.NotesSet.IsSupersetOf(selectedNotes)).ToList();
        }

        public static List<ScaleDictionaryEntry> GenerateDictionary()
        {
            var dictionary = new List<ScaleDictionaryEntry>();

            foreach (var mode in EnumHelper.GetAllModeNames())
            {
                foreach (var note in EnumHelper.GetAllNoteNames())
                {
                    string scaleLabel = note + " " + mode;

                    Note realNote = NoteHelper.ConvertStringNoteToNoteType(note);
                    Mode realMode = ModeHelper.ConvertStringModeNameToModeType(mode);

                    ScaleDirectoryEntry scaleDirectory = GetScaleDirectory(realMode);

                    Step[] scaleSteps = scaleDirectory.ScaleSteps;

                    dictionary.Add(new ScaleDictionaryEntry(scaleLabel, ScaleHelper.GenerateScaleFromKey(realNote, scaleSteps)));
                }
            }

            return dictionary;
        }

        public static ScaleDictionaryEntry GenerateEntryFromString(string inputScale)
        {
            inputScale = ConvertUserFriendlyLabelIntoLabel(inputScale);

            string note = inputScale.Substring(0, inputScale.IndexOf(' '));
            string mode = inputScale.Substring(inputScale.IndexOf(' '), inputScale.Length - (note.Length));

            if (note.Length > 1)
                if (note[1] == '#')
                    note = NoteHelper.ConvertSharpNoteStringToFlatNote(note).ToString();

            Note realNote = NoteHelper.ConvertStringNoteToNoteType(note);
            ScaleDirectoryEntry realScale = GetScaleDirectory(ModeHelper.ConvertStringModeNameToModeType(mode));
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