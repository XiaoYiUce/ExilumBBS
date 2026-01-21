using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ExilumBBS.Models.Response.Point
{
    public class Scorelog
    {
        /// <summary>
        /// 使用积分数
        /// </summary>
        [JsonPropertyName("score")]
        public int Score { get; set; }

        /// <summary>
        /// 积分用途
        /// </summary>
        [JsonPropertyName("reason")]
        public string Reason { get; set; } = string.Empty;

        /// <summary>
        /// 记录时间
        /// </summary>
        [JsonPropertyName("log_time")]
        public string LogTime { get; set; } = string.Empty;
    }
}
