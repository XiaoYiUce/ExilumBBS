using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace ExilumBBS.Models.Response
{
    public class BBSResponse
    {
        /// <summary>
        /// 响应代码
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 响应信息
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        [JsonPropertyName("data")]
        public JsonElement? Data { get; set; }
    }
}
