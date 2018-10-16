using Newtonsoft.Json;

namespace ComicVine.Forms.Models
{
    public class Image
    {
        [JsonProperty(PropertyName = "icon_url")]
        public string IconUrl { get; set; }

        [JsonProperty(PropertyName = "medium_url")]
        public string MediumUrl { get; set; }

        [JsonProperty(PropertyName = "screen_url")]
        public string ScreenUrl { get; set; }

        [JsonProperty(PropertyName = "screen_large_url")]
        public string ScreenLargeUrl { get; set; }

        [JsonProperty(PropertyName = "small_url")]
        public string SmallUrl { get; set; }

        [JsonProperty(PropertyName = "super_url")]
        public string SuperUrl { get; set; }

        [JsonProperty(PropertyName = "thumb_url")]
        public string ThumbUrl { get; set; }

        [JsonProperty(PropertyName = "tiny_url")]
        public string TinyUrl { get; set; }

        [JsonProperty(PropertyName = "original_url")]
        public string OriginalUrl { get; set; }

        [JsonProperty(PropertyName = "image_tags")]
        public string ImageTags { get; set; }
    }
}
