using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ExilumBBS.Models.Response.Notify
{
    /// <summary>
    /// 消息列表响应值
    /// </summary>
    public class MessageListResponse
    {
        [JsonPropertyName("list")]
        public JsonElement List { get; set; }

        [JsonPropertyName("total")]
        public long Total { get; set; }

        [JsonPropertyName("unread_num")]
        public int UnreadNum { get; set; }
    }
}
