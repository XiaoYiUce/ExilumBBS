using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ExilumBBS.Models.Response.Category
{
    public class CategoryItem
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("topic_level")]
        public List<int> TopicLevel { get; set; } = new();

        [JsonPropertyName("comment_level")]
        public List<int> CommentLevel { get; set; } = new();

        [JsonPropertyName("is_unreal")]
        public int IsUnreal { get; set; }

        [JsonPropertyName("view_num")]
        public long ViewNum { get; set; }

        [JsonPropertyName("can_move")]
        public bool CanMove { get; set; }

        [JsonPropertyName("can_move_in")]
        public int CanMoveIn { get; set; }

        [JsonPropertyName("sort")]
        public int Sort { get; set; }

        [JsonPropertyName("img")]
        public string Img { get; set; } = string.Empty;

        [JsonPropertyName("img_c")]
        public string ImgC { get; set; } = string.Empty;

        [JsonPropertyName("hide")]
        public int Hide { get; set; }

        [JsonPropertyName("discover_page")]
        public int DiscoverPage { get; set; }

        [JsonPropertyName("show_first")]
        public int ShowFirst { get; set; }
    }
}
