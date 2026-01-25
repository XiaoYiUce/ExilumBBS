using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ExilumBBS.Models.Response.Point
{
    /// <summary>
    /// 任务列表
    /// </summary>
    public class TaskResponse
    {
        [JsonPropertyName("daily_task")]
        public List<TaskItem> DailyTask { get; set; } = [];
        [JsonPropertyName("more_task")]
        public List<TaskItem> MoreTask { get; set; } = [];
    }
}
