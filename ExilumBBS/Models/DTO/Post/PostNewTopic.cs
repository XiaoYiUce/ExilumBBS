using ExilumBBS.Models.Response.HotTheme;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ExilumBBS.Models.DTO.Post
{
    public class PostNewTopic
    {
        /// <summary>
        /// 草稿箱ID
        /// </summary>
        [JsonPropertyName("draft_id")]
        public int DraftId { get; set; } = 0;

        [JsonPropertyName("category_id")]
        public int CategoryId { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("content")]
        public string Content { get; set; } = string.Empty;

        [JsonPropertyName("pictures")]
        public List<string> Pictures { get; set; } = new();

        [JsonPropertyName("code")]
        public string Code { get; set; } = string.Empty;

        [JsonPropertyName("theme_info")]
        public List<HotThemeItem> ThemeInfo { get; set; } = new();

        [JsonPropertyName("declare")]
        public int Declare { get; set; }
    }
}
