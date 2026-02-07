using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ExilumBBS.Models.DTO.Emoji
{
    /// <summary>
    /// 表情分类
    /// </summary>
    public class EmojiCategory
    {
        [JsonPropertyName("classify_id")]
        public int ClassifyId { get; set; }

        [JsonPropertyName("img_addr")]
        public string ImgAddr { get; set; } = string.Empty;

        [JsonPropertyName("emoji_list")]
        public List<EmojiItem> EmojiList { get; set; } = [];
    }
}
