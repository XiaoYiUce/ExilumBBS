using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ExilumBBS.Models.Response.Hot
{
    public class HotwordItem
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("word")]
        public string Word { get; set; } = string.Empty;
        [JsonPropertyName("sort")]
        public int Sort { get; set; }
    }
}
