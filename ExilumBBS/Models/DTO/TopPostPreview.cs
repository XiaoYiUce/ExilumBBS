using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ExilumBBS.Models.DTO
{
    /// <summary>
    /// 分区置顶帖子预览
    /// </summary>
    public class TopPostPreview
    {
        [JsonPropertyName("create_time")]
        public string CreateTime { get; set; } = "";
        /// <summary>
        /// 帖子标题
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; } = "";
        /// <summary>
        /// 帖子ID
        /// </summary>
        [JsonPropertyName("topic_id")]
        public long TopicId { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; } = "";
    }
}
