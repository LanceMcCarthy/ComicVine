using Newtonsoft.Json;

// This is only to help load values from my API keys json file. It is not necessary to use in your app.
namespace ComicVine.Forms.Models
{
    public class ApiKeyBase
    {
        [JsonProperty("ComicVineApiKey")]
        public string ComicVineApiKey { get; set; }

        [JsonProperty("UniqueUserAgentString")]
        public string UniqueUserAgentString { get; set; }
    }
}