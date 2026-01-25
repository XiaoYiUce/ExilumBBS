using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ExilumBBS.Models.Response.Point
{
    /// <summary>
    /// 每月签到返回
    /// </summary>
    public class MonthSigninResponse
    {
        [JsonPropertyName("start_date")]
        public string StartDate { get; set; } = string.Empty;
        [JsonPropertyName("end_date")]
        public string EndDate { get; set; } = string.Empty;
        [JsonPropertyName("sign_in_days")]
        public int SignInDays { get; set; }
        [JsonPropertyName("list")]
        public List<MonthSigninItem> List { get; set; } = [];
    }
}
