using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ExilumBBS.Models.DTO.Post
{
    public class PostCommentFilterDTO
    {
        [JsonPropertyName("hot_value")]
        public long HotValue { get; set; }
        [JsonPropertyName("last_id")]
        public long LastId { get; set; }
        /// <summary>
        /// 只看楼主
        /// </summary>
        [JsonPropertyName("only_author")]
        public bool OnlyAuthor { get; set; } = false;
        /// <summary>
        /// 排序方式
        /// </summary>
        [JsonPropertyName("sort")]
        public int Sort { get; set; } = 0;
        [JsonPropertyName("topic_id")]
        public long TopicId { get; set; }
    }
}
