using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ExilumBBS.Models.Response.Exchange
{
    /// <summary>
    /// 获取可兑换物品列表
    /// </summary>
    public class ExchangeResponse
    {
        [JsonPropertyName("list")]
        public List<ExchangeItem>? List { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }
    }
}
