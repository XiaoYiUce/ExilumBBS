using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ExilumBBS.Models.Response.Exchange
{
    /// <summary>
    /// 兑换物品
    /// </summary>
    public class ExchangeItem
    {
        [JsonPropertyName("exchange_id")]
        public int ExchangeId { get; set; }
        [JsonPropertyName("item_name")]
        public string ItemName { get; set; } = "";
        [JsonPropertyName("item_count")]
        public int ItemCount { get; set; }
        [JsonPropertyName("item_pic")]
        public string ItemPic { get; set; } = "";
        [JsonPropertyName("item_context")]
        public string ItemContext { get; set; } = "";
        [JsonPropertyName("use_score")]
        public int UseScore { get; set; }
        [JsonPropertyName("exchange_count")]
        public int ExchangeCount { get; set; }
        [JsonPropertyName("max_exchange_count")]
        public int MaxExchangeCount { get; set; }
        [JsonPropertyName("cycle")]
        public string Cycle { get; set; } = "";
    }
}
