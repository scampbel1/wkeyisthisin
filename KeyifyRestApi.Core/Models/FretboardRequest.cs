using Newtonsoft.Json;

namespace KeyifyRestApi.Core.Models
{
    public class FretboardRequest
    {
        [JsonProperty("Tuning")]
        public string Tuning { get; set; }

        [JsonProperty("Fretcount")]
        public int FretCount { get; set; }
    }
}