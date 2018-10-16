using System.Collections.Generic;
using Newtonsoft.Json;

namespace ComicVine.Forms.Models
{
    public class CharactersResult
    {
        [JsonProperty(PropertyName = "error")]
        public string Error { get; set; }

        [JsonProperty(PropertyName = "limit")]
        public int Limit { get; set; }

        [JsonProperty(PropertyName = "offset")]
        public int Offset { get; set; }

        [JsonProperty(PropertyName = "number_of_page_results")]
        public int NumberOfPageResults { get; set; }

        [JsonProperty(PropertyName = "number_of_total_results")]
        public int NumberOfTotalResults { get; set; }

        [JsonProperty(PropertyName = "status_code")]
        public int StatusCode { get; set; }

        [JsonProperty(PropertyName = "results")]
        public List<Character> Results { get; set; }

        [JsonProperty(PropertyName = "version")]
        public string Version { get; set; }
    }
}
