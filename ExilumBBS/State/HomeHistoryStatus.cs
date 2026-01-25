using ExilumBBS.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExilumBBS.State
{
    /// <summary>
    /// 首页的历史状态，用于退出首页进入如详细页的时候缓存上次的首页状态
    /// </summary>
    public class HomeHistoryStatus
    {
        /// <summary>
        /// 置顶帖子
        /// </summary>
        public List<TopPostPreview> TopPostPreviews { get; set; } = [];

        /// <summary>
        /// 帖子列表
        /// </summary>
        public List<PostPreview> PostList { get; set; } = [];

        /// <summary>
        /// 控制组件是否可见
        /// </summary>
        public bool ShowPage { get; set; } = false;

        /// <summary>
        /// 是否还有下一页内容
        /// </summary>
        public bool NextPage { get; set; } = true;

        public long ScrollY { get; set; }

        #region 分页参数
        public long LastTid { get; set; } = 0;
        public long PubTime { get; set; } = 0;
        public long ReplyTime { get; set; } = 0;
        public long HotValue { get; set; } = 0;
        #endregion 
    }
}
