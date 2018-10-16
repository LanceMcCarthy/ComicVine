using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

// This is only to help load values from my API keys json file. It is not necessary to use in your app.

namespace ComicVine.Forms.Models
{
    public partial class ApiKeyBase
    {
        [JsonProperty("ProtectedValues")]
        public ProtectedValues ProtectedValues { get; set; }
    }

    public class ProtectedValues
    {
        [JsonProperty("ComicVineApiKey")]
        public string ComicVineApiKey { get; set; }

        [JsonProperty("UniqueUserAgentString")]
        public string UniqueUserAgentString { get; set; }
    }

    public partial class ApiKeyBase
    {
        public static ApiKeyBase FromJson(string json) => JsonConvert.DeserializeObject<ApiKeyBase>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this ApiKeyBase self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = { new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal } },
        };
    }
}
