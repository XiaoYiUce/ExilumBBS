using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ExilumBBS.Models.Entity
{
    [SugarTable("user")]
    public class UserEntity
    {
        [JsonPropertyName("auth_lock")]
        public int AuthLock { get; set; }

        [JsonPropertyName("auth_type")]
        public int AuthType { get; set; }

        /// <summary>
        /// 头像URL
        /// </summary>
        [JsonPropertyName("avatar")]
        public string? Avatar { get; set; }

        /// <summary>
        /// 头像框URL
        /// </summary>
        [JsonPropertyName("avatar_frame")]
        public string? AvatarFrame { get; set; }

        [JsonPropertyName("exp")]
        public int Exp { get; set; }

        /// <summary>
        /// 粉丝数
        /// </summary>
        [JsonPropertyName("fans")]
        public int Fans { get; set; }

        [JsonPropertyName("favors")]
        public int Favors { get; set; }

        /// <summary>
        /// 关注数
        /// </summary>
        [JsonPropertyName("follows")]
        public int Follows { get; set; }

        /// <summary>
        /// 指挥官等级
        /// </summary>
        [JsonPropertyName("game_commander_level")]
        public int GameCommanderLevel { get; set; }

        /// <summary>
        /// 游戏昵称
        /// </summary>
        [JsonPropertyName("game_nick_name")]
        public string? GameNickName { get; set; }

        /// <summary>
        /// 游戏UID
        /// </summary>
        [JsonPropertyName("game_uid")]
        public long GameUid { get; set; }

        /// <summary>
        /// IP位置
        /// </summary>
        [JsonPropertyName("ip_location")]
        public string? IpLocation { get; set; }

        /// <summary>
        /// 是否为社区管理员
        /// </summary>
        [JsonPropertyName("is_admin")]
        public bool IsAdmin { get; set; }

        [JsonPropertyName("is_author")]
        public bool IsAuthor { get; set; }

        [JsonPropertyName("is_block")]
        public bool IsBlock { get; set; }

        [JsonPropertyName("is_follow")]
        public bool IsFollow { get; set; }

        /// <summary>
        /// 社区等级
        /// </summary>
        [JsonPropertyName("level")]
        public int Level { get; set; }

        /// <summary>
        /// 获赞
        /// </summary>
        [JsonPropertyName("likes")]
        public int Likes { get; set; }

        /// <summary>
        /// 下一个社区等级所需经验
        /// </summary>
        [JsonPropertyName("next_lv_exp")]
        public int NextLvExp { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        [JsonPropertyName("nick_name")]
        public string? NickName { get; set; }

        [JsonPropertyName("score")]
        public int Score { get; set; }

        [JsonPropertyName("show_fans")]
        public bool ShowFans { get; set; }

        [JsonPropertyName("show_favor")]
        public bool ShowFavor { get; set; }

        [JsonPropertyName("show_follow")]
        public bool ShowFollow { get; set; }

        [JsonPropertyName("show_game")]
        public bool ShowGame { get; set; }

        [JsonPropertyName("signature")]
        public string? Signature { get; set; }

        /// <summary>
        /// 社区UID
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
        [JsonPropertyName("uid")]
        public long Uid { get; set; }

        [JsonPropertyName("vip")]
        public string? Vip { get; set; }
    }
}
