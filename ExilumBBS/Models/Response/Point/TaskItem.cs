using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ExilumBBS.Models.Response.Point
{
    /// <summary>
    /// 任务项
    /// </summary>
    public class TaskItem
    {
        /// <summary>
        /// 任务名称
        /// </summary>
        [JsonPropertyName("task_name")]
        public string TaskName { get; set; } = string.Empty;
        /// <summary>
        /// 任务描述
        /// </summary>
        [JsonPropertyName("task_context")]
        public string TaskContext { get; set; } = string.Empty;
        /// <summary>
        /// 完成数量
        /// </summary>
        [JsonPropertyName("complete_count")]
        public int CompleteCount { get; set; }
        /// <summary>
        /// 最大完成数
        /// </summary>
        [JsonPropertyName("max_complete_count")]
        public int MaxCompleteCount { get; set; }
    }
}
