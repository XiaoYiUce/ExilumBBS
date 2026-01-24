using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ExilumBBS.Models.Response.Search
{
    public class SearchResponse
    {
        [JsonPropertyName("list")]
        public List<SearchItem> List { get; set; } = [];
        [JsonPropertyName("total")]
        public long Total { get; set; }
    }
}
