using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ExilumBBS.Models.Response.Point
{
    /// <summary>
    /// 每日签到物品
    /// </summary>
    public class MonthSigninItem
    {
        [JsonPropertyName("item_name")]
        public string ItemName { get; set; } = string.Empty;
        [JsonPropertyName("item_pic")]
        public string ItemPic { get; set; } = string.Empty;
        [JsonPropertyName("item_count")]
        public int ItemCount { get; set; }
    }
}
