using Newtonsoft.Json;

namespace ComicVine.Portable.Models
{
    public class Character
    {
        [JsonProperty(PropertyName = "aliases")]
        public string Aliases { get; set; }

        [JsonProperty(PropertyName = "api_detail_url")]
        public string ApiDetailUrl { get; set; }

        [JsonProperty(PropertyName = "birth")]
        public string Birth { get; set; }

        [JsonProperty(PropertyName = "count_of_issue_appearances")]
        public int CountOfIssueAppearances { get; set; }

        [JsonProperty(PropertyName = "date_added")]
        public string DateAdded { get; set; }

        [JsonProperty(PropertyName = "date_last_updated")]
        public string DateLastUpdated { get; set; }

        [JsonProperty(PropertyName = "deck")]
        public string Deck { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "first_appeared_in_issue")]
        public FirstAppearedInIssue FirstAppearedInIssue { get; set; }

        [JsonProperty(PropertyName = "gender")]
        public int Gender { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "image")]
        public Image Image { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "origin")]
        public Origin Origin { get; set; }

        [JsonProperty(PropertyName = "publisher")]
        public Publisher Publisher { get; set; }

        [JsonProperty(PropertyName = "real_name")]
        public string RealName { get; set; }

        [JsonProperty(PropertyName = "site_detail_url")]
        public string SiteDetailUrl { get; set; }
    }
}
