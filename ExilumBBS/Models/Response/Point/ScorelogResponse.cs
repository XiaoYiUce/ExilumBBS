using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ExilumBBS.Models.Response.Point
{
    public class ScorelogResponse
    {
        /// <summary>
        /// 记录列表
        /// </summary>
        [JsonPropertyName("list")]
        public List<Scorelog>? List { get; set; }
        /// <summary>
        /// 总记录数量
        /// </summary>
        [JsonPropertyName("total")]
        public int Total { get; set; }
    }
}
