using Keyify.MusicTheory.Enums;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Keyify.Web.Converters
{
    public class NoteListConverter : JsonConverter<List<Note>>
    {
        public override List<Note> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            List<Note> notes = new List<Note>();
            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndArray)
                {
                    break;
                }
                string value = reader.GetString();
                notes.Add((Note)Enum.Parse(typeof(Note), value));
            }
            return notes;
        }

        public override void Write(Utf8JsonWriter writer, List<Note> value, JsonSerializerOptions options)
        {
            writer.WriteStartArray();
            foreach (Note note in value)
            {
                writer.WriteStringValue(note.ToString());
            }
            writer.WriteEndArray();
        }
    }
}
