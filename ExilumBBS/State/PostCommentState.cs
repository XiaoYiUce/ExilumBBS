using System;
using System.Collections.Generic;
using System.Text;

namespace ExilumBBS.State
{
    /// <summary>
    /// 帖子评论展开状态
    /// </summary>
    public class PostCommentState
    {
        public bool IsOpenComment { get; set; } = false;
        public event Action<bool>? CommentStateChange;
        public void SetCommentStat(bool state)
        {
            IsOpenComment = state;
            CommentStateChange?.Invoke(state);
        }
    }
}
