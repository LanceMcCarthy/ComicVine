using Newtonsoft.Json;

namespace ComicVine.Portable.Models
{
    public class VideoCategories
    {
        [JsonProperty(PropertyName = "api_detail_url")]
        public string ApiDetailUrl { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "site_detail_url")]
        public string SiteDetailUrl { get; set; }
    }
}
