using System.Collections.Generic;
using Newtonsoft.Json;

namespace ComicVine.Portable.Models
{
    public class Video
    {
        [JsonProperty(PropertyName = "api_detail_url")]
        public string ApiDetailUrl { get; set; }

        [JsonProperty(PropertyName = "deck")]
        public string Deck { get; set; }

        [JsonProperty(PropertyName = "high_url")]
        public string HighUrl { get; set; }

        [JsonProperty(PropertyName = "low_url")]
        public string LowUrl { get; set; }

        [JsonProperty(PropertyName = "embed_player")]
        public string EmbedPlayer { get; set; }

        [JsonProperty(PropertyName = "guid")]
        public string Guid { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "length_seconds")]
        public int LengthSeconds { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "publish_date")]
        public string PublishDate { get; set; }

        [JsonProperty(PropertyName = "site_detail_url")]
        public string SiteDetailUrl { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "image")]
        public Image Image { get; set; }

        [JsonProperty(PropertyName = "user")]
        public string User { get; set; }

        [JsonProperty(PropertyName = "video_type")]
        public string VideoType { get; set; }

        [JsonProperty(PropertyName = "video_show")]
        public object VideoShow { get; set; }

        [JsonProperty(PropertyName = "video_categories")]
        public List<VideoCategories> VideoCategories { get; set; }

        [JsonProperty(PropertyName = "saved_time")]
        public object SavedTime { get; set; }

        [JsonProperty(PropertyName = "youtube_id")]
        public string YoutubeId { get; set; }
    }
}
