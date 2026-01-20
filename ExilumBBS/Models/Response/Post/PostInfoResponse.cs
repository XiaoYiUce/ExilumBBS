using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ExilumBBS.Models.Response.Post
{
    public class PostInfoResponse
    {
        [JsonPropertyName("author_comment_num")]
        public long AuthorCommentNum { get; set; }

        [JsonPropertyName("avatar_frame")]
        public string? AvatarFrame { get; set; }

        [JsonPropertyName("bad_num")]
        public int BadNum { get; set; }

        [JsonPropertyName("category_id")]
        public int CategoryId { get; set; }

        [JsonPropertyName("category_name")]
        public string? CategoryName { get; set; }

        [JsonPropertyName("comment_num")]
        public string CommentNum { get; set; } = "";

        [JsonPropertyName("content")]
        public string? Content { get; set; }

        [JsonPropertyName("create_time")]
        public string? CreateTime { get; set; } // 可考虑转为 DateTime?，但原始是 "2026-01-13"

        [JsonPropertyName("declare")]
        public int Declare { get; set; }

        [JsonPropertyName("favor_num")]
        public int FavorNum { get; set; }

        [JsonPropertyName("ip_location")]
        public string? IpLocation { get; set; }

        [JsonPropertyName("is_admin")]
        public bool IsAdmin { get; set; }

        [JsonPropertyName("is_author")]
        public bool IsAuthor { get; set; }

        [JsonPropertyName("is_bad")]
        public bool IsBad { get; set; }

        [JsonPropertyName("is_favor")]
        public bool IsFavor { get; set; }

        [JsonPropertyName("is_follow")]
        public bool IsFollow { get; set; }

        [JsonPropertyName("is_like")]
        public bool IsLike { get; set; }

        [JsonPropertyName("like_num")]
        public int LikeNum { get; set; }

        [JsonPropertyName("like_user_avatar_frame")]
        public List<string>? LikeUserAvatarFrame { get; set; }

        [JsonPropertyName("like_user_avatars")]
        public List<string>? LikeUserAvatars { get; set; }

        [JsonPropertyName("pic_list")]
        public List<string>? PicList { get; set; }

        [JsonPropertyName("theme_info")]
        public List<object>? ThemeInfo { get; set; } // 原始为空数组 []，类型未知，用 object 或自定义类

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("topic_id")]
        public int TopicId { get; set; }

        [JsonPropertyName("update_time")]
        public string? UpdateTime { get; set; }

        [JsonPropertyName("user_avatar")]
        public string? UserAvatar { get; set; }

        [JsonPropertyName("user_id")]
        public int UserId { get; set; }

        [JsonPropertyName("user_level")]
        public int UserLevel { get; set; }

        [JsonPropertyName("user_nick_name")]
        public string? UserNickName { get; set; }

        [JsonPropertyName("view_num")]
        public string ViewNum { get; set; } = "";

        [JsonPropertyName("vip")]
        public bool Vip { get; set; }
    }
}
