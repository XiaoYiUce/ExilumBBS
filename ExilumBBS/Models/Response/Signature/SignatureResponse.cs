using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ExilumBBS.Models.Response.Signature
{
    /// <summary>
    /// OSS签名申请回调
    /// </summary>
    public class SignatureResponse
    {
        [JsonPropertyName("accessid")]
        public string AccessId { get; set; } = string.Empty;
        [JsonPropertyName("host")]
        public string Host { get; set; } = string.Empty;
        [JsonPropertyName("cdn_host")]
        public string CDNHost { get; set; } = string.Empty;
        [JsonPropertyName("expire")]
        public long Expire { get; set; }
        [JsonPropertyName("signature")]
        public string Signature { get; set; } = string.Empty;
        [JsonPropertyName("policy")]
        public string Policy { get; set; } = string.Empty;
        [JsonPropertyName("dir")]
        public string Dir { get; set; } = string.Empty;
        [JsonPropertyName("callback")]
        public string Callback { get; set; } = string.Empty;
    }
}
