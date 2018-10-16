using Newtonsoft.Json;

namespace ComicVine.Forms.Models
{
    public class FirstAppearedInIssue
    {
        [JsonProperty(PropertyName = "api_detail_url")]
        public string ApiDetailUrl { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "issue_number")]
        public string IssueNumber { get; set; }
    }
}
