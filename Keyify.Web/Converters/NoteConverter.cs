using Keyify.MusicTheory.Enums;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Keyify.Web.Converters
{
    public class NoteConverter : JsonConverter<Note>
    {
        public override Note Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string value = reader.GetString();
            return (Note)Enum.Parse(typeof(Note), value);
        }

        public override void Write(Utf8JsonWriter writer, Note value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
