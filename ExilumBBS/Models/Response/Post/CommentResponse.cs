using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ExilumBBS.Models.Response.Post
{
    public class CommentResponse
    {
        [JsonPropertyName("avatar_frame")]
        public string AvatarFrame { get; set; } = string.Empty;

        [JsonPropertyName("comment_id")]
        public long CommentId { get; set; }

        [JsonPropertyName("comment_reply")]
        public List<CommentWithReplyToResponse>? CommentReply { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; } = string.Empty;

        [JsonPropertyName("create_time")]
        public string CreateTime { get; set; } = string.Empty; // 也可转为 DateTime

        [JsonPropertyName("dislike_num")]
        public int DislikeNum { get; set; }

        [JsonPropertyName("floor_num")]
        public int FloorNum { get; set; }

        [JsonPropertyName("ip_location")]
        public string IpLocation { get; set; } = string.Empty;

        [JsonPropertyName("is_admin")]
        public bool IsAdmin { get; set; }

        [JsonPropertyName("is_author")]
        public bool IsAuthor { get; set; }

        [JsonPropertyName("is_comment_author")]
        public bool IsCommentAuthor { get; set; }

        [JsonPropertyName("is_dislike")]
        public bool IsDislike { get; set; }

        [JsonPropertyName("is_like")]
        public bool IsLike { get; set; }

        [JsonPropertyName("like_num")]
        public int LikeNum { get; set; }

        [JsonPropertyName("pic_list")]
        public List<string>? PicList { get; set; }

        [JsonPropertyName("reply_num")]
        public int ReplyNum { get; set; }

        [JsonPropertyName("user_avatar")]
        public string UserAvatar { get; set; } = string.Empty;

        [JsonPropertyName("user_id")]
        public long UserId { get; set; }

        [JsonPropertyName("user_level")]
        public int UserLevel { get; set; }

        [JsonPropertyName("user_nick_name")]
        public string UserNickName { get; set; } = string.Empty;

        [JsonPropertyName("vip")]
        public bool Vip { get; set; }
    }
}
