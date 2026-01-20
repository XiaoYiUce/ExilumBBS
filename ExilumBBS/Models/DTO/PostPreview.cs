using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ExilumBBS.Models.DTO
{
    public class PostPreview
    {
        [JsonPropertyName("avatar_frame")]
        public string? AvatarFrame { get; set; }


        [JsonPropertyName("category_id")]
        public int CategoryId { get; set; }


        [JsonPropertyName("category_name")]
        public string? CategoryName { get; set; }


        [JsonPropertyName("comment_num")]

        public long CommentNum { get; set; }


        [JsonPropertyName("content")]

        public string? Content { get; set; }


        [JsonPropertyName("create_time")]

        public string? CreateTime { get; set; } // 或改为 DateTime？见下方说明


        [JsonPropertyName("is_admin")]

        public bool IsAdmin { get; set; }


        [JsonPropertyName("is_author")]

        public bool IsAuthor { get; set; }


        [JsonPropertyName("is_favor")]

        public bool IsFavor { get; set; }


        [JsonPropertyName("is_follow")]

        public bool IsFollow { get; set; }


        [JsonPropertyName("is_like")]

        public bool IsLike { get; set; }


        [JsonPropertyName("like_num")]

        public int LikeNum { get; set; }


        [JsonPropertyName("pic_list")]

        public List<string>? PicList { get; set; }


        [JsonPropertyName("theme_info")]

        public List<object>? ThemeInfo { get; set; } // 若后续有结构，可替换为具体类


        [JsonPropertyName("title")]

        public string? Title { get; set; }


        [JsonPropertyName("topic_id")]

        public int TopicId { get; set; }


        [JsonPropertyName("user_avatar")]

        public string? UserAvatar { get; set; }


        [JsonPropertyName("user_id")]

        public int UserId { get; set; }


        [JsonPropertyName("user_level")]

        public int UserLevel { get; set; }


        [JsonPropertyName("user_nick_name")]

        public string? UserNickName { get; set; }


        [JsonPropertyName("vip")]

        public bool Vip { get; set; }
    }
}
