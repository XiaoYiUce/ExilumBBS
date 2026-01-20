using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ExilumBBS.Models.Response.Post
{
    /// <summary>
    /// 在基础的评论上加了回复评论来源列
    /// </summary>
    public class CommentWithReplyToResponse : CommentResponse
    {
        [JsonPropertyName("reply_to")]
        public string? ReplyTo { get; set; }

        [JsonPropertyName("reply_to_uid")]
        public long ReplyToUid { get; set; }
    }
}
