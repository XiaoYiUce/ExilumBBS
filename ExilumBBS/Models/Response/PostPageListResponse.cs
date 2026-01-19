using ExilumBBS.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ExilumBBS.Models.Response
{
    /// <summary>
    /// 社区帖子分页返回数据
    /// </summary>
    public class PostPageListResponse
    {
        [JsonPropertyName("hot_value")]
        public long HotValue { get; set; }

        [JsonPropertyName("last_tid")]
        public long LastTid { get; set; }

        [JsonPropertyName("list")]
        public List<PostPreview> List { get; set; } = [];

        /// <summary>
        /// 是否还有下一页
        /// </summary>
        [JsonPropertyName("next_page")]
        public bool NextPage { get; set; }

        [JsonPropertyName("pub_time")]
        public long PubTime { get; set; }

        [JsonPropertyName("reply_time")]
        public long ReplyTime { get; set; }
    }
}
