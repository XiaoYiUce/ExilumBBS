using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ExilumBBS.Models.Response.Notify
{
    /// <summary>
    /// 点赞消息
    /// </summary>
    public class LikeMessageItem : BaseMessageItem
    {
        [JsonPropertyName("topic_id")]
        public long TopicId { get; set; }

        [JsonPropertyName("comment_id")]
        public long CommentId { get; set; }

        [JsonPropertyName("comment_floor")]
        public long CommentFloor { get; set; }

        [JsonPropertyName("avatar_url")]
        public string AvatarUrl { get; set; } = string.Empty;
    }
}
