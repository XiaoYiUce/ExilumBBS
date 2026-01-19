using ExilumBBS.Models.Response.Post;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ExilumBBS.Models.Response
{
    /// <summary>
    /// 评论分页返回结果
    /// </summary>
    public class CommentPageListResponse
    {
        [JsonPropertyName("hot_value")]
        public long HotValue { get; set; }
        [JsonPropertyName("last_id")]
        public long LastId { get; set; }
        [JsonPropertyName("list")]
        public List<CommentResponse> List { get; set; } = [];

        [JsonPropertyName("next_page")]
        public bool NextPage { get; set; }
    }
}
