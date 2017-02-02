using Newtonsoft.Json;

namespace UWPReactiveUI.Services.Models
{
    public class HipsterSentence
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("params")]
        public HipsterParameters Parameters { get; set; }
    }
}
