using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ExilumBBS.Models.Response.Notify
{
    /// <summary>
    /// 评论回复消息实体
    /// </summary>
    public class CommentMessageItem : BaseMessageItem
    {
        [JsonPropertyName("topic_id")]
        public long TopicId { get; set; }

        [JsonPropertyName("comment_id")]
        public long CommentId { get; set; }

        [JsonPropertyName("comment_floor")]
        public long CommentFloor { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; } = string.Empty;

        [JsonPropertyName("avatar_url")]
        public string AvatarUrl { get; set; } = string.Empty;
    }
}
