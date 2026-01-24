
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ExilumBBS.Models.DTO.Search
{
    /// <summary>
    /// 搜索DTO
    /// </summary>
    public class SearchDTO
    {
        [JsonPropertyName("content")]
        public string? Content { get; set; } = string.Empty;
        [JsonPropertyName("page_num")]
        public long PageNum { get; set; }
        [JsonPropertyName("page_size")]
        public long PageSize { get; set; }
        [JsonPropertyName("search_type")]
        public long SearchType { get; set; }
    }
}
