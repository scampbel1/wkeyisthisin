using Keyify.MusicTheory.Enums;
using Keyify.Services.Formatter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Keyify.Services.Formatter.Services
{
    public class SerializationFormatter : ISerializationFormatter
    {
        public async Task<Interval[]?> ConvertToIntervalArray(byte[] bytes)
        {
            using var memoryStream = new MemoryStream(bytes);
            
            var intervals = await JsonSerializer.DeserializeAsync<Interval[]>(memoryStream);

            return intervals;
        }
    }
}
