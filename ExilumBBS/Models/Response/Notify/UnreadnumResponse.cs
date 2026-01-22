using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ExilumBBS.Models.Response.Notify
{
    /// <summary>
    /// 未读消息数量响应
    /// </summary>
    public class UnreadnumResponse
    {
        /// <summary>
        /// 评论未读数量
        /// </summary>
        [JsonPropertyName("comment_unread_num")]
        public long CommentUnreadNum { get; set; }

        /// <summary>
        /// 关注未读数量
        /// </summary>
        [JsonPropertyName("follow_unread_num")]
        public long FollowUnreadNum { get; set; }

        /// <summary>
        /// 获赞未读数量
        /// </summary>
        [JsonPropertyName("like_unread_num")]
        public long LikeUnreadNum { get; set; }

        /// <summary>
        /// 通知未读数量
        ///</summary>
        [JsonPropertyName("notice_unread_num")]
        public long NoticeUnreadNum { get; set; }
    }
}
