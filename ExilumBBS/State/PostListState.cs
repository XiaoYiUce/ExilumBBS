using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ExilumBBS.State
{
    /// <summary>
    /// 帖子列表请求状态机
    /// </summary>
    public class PostListState : INotifyPropertyChanged
    {
        private int _CategoryId = 1;
        private SortTypeEnum _SortType = SortTypeEnum.NEWREPORT;
        private int _QueryType = 1;

        /// <summary>
        /// 当前浏览的分类ID
        /// </summary>
        public int CategoryId
        {
            get => _CategoryId;
            set
            {
                _CategoryId = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 排序类型
        /// </summary>
        public SortTypeEnum SortType
        {
            get => _SortType;
            set
            {
                _SortType = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// 查询类型
        /// </summary>
        public int QueryType
        {
            get => _QueryType;
            set
            {
                _QueryType = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// 通知值变化
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    /// <summary>
    /// 排序类型列表
    /// </summary>
    public enum SortTypeEnum
    {
        /// <summary>
        /// 最新回复
        /// </summary>
        NEWREPORT = 1,
        /// <summary>
        /// 最新发布
        /// </summary>
        NEWPUBLISH = 2,
        /// <summary>
        /// 按热度排序
        /// </summary>
        HOTTEST = 3
    }
}
