using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ExilumBBS.Models.Response.Hot
{
    public class HotwordResponse
    {
        [JsonPropertyName("list")]
        public List<HotwordItem> List { get; set; } = [];
    }
}
