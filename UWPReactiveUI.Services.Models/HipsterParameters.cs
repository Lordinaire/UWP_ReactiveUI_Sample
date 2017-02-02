using Newtonsoft.Json;

namespace UWPReactiveUI.Services.Models
{
    public class HipsterParameters
    {
        [JsonProperty("paras")]
        public int Paragraphs { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
