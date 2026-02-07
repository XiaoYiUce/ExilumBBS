using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ExilumBBS.Models.DTO.Emoji
{
    /// <summary>
    /// 单个表情信息
    /// </summary>
    public class EmojiItem
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("url_path")]
        public string UrlPath { get; set; } = string.Empty;

        [JsonPropertyName("url_desc")]
        public string UrlDesc { get; set; } = string.Empty;
    }
}
