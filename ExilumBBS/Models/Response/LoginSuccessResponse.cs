using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ExilumBBS.Models.Response
{
    public class LoginSuccessResponse
    {
        [JsonPropertyName("token")]
        public string Token { get; set; } = "";
        [JsonPropertyName("uid")]
        public long Uid { get; set; }
        [JsonPropertyName("platform_id")]
        public long PlatformId { get; set; }
        [JsonPropertyName("channel_id")]
        public long ChannelId { get; set; }
        [JsonPropertyName("trace_id")]
        public string TraceId { get; set; } = "";
    }
}
