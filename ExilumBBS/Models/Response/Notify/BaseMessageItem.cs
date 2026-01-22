using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ExilumBBS.Models.Response.Notify
{
    public class BaseMessageItem
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("log_time")]
        public DateTime LogTime { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("is_read")]
        public bool IsRead { get; set; }
    }
}
