using ExilumBBS.Models.DTO.Emoji;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ExilumBBS.Models.Response.Emoji
{
    public class EmojiResponse
    {
        [JsonPropertyName("list")]
        public List<EmojiCategory>? List { get; set; }
    }
}
