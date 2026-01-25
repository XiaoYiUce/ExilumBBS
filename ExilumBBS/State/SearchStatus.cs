using ExilumBBS.Models.Response.Hot;
using ExilumBBS.Models.Response.Search;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExilumBBS.State
{
    /// <summary>
    /// 搜索页状态
    /// </summary>
    public class SearchStatus
    {
        /// <summary>
        /// 搜索关键词
        /// </summary>
        public string SearchKeyword = string.Empty;

        /// <summary>
        /// 搜索完成后是否有数据
        /// </summary>
        public bool HasResponse { get; set; } = true;

        /// <summary>
        /// 热词
        /// </summary>
        public List<HotwordItem> Hotwords { get; set; } = [];

        /// <summary>
        /// 搜索结果
        /// </summary>
        public List<SearchItem> SearchResults { get; set; } = [];

        /// <summary>
        /// 搜索类型
        /// </summary>
        public int SearchType { get; set; } = 1;

        public long PageNum { get; set; } = 1;

        public long PageSize { get; set; } = 10;

        public long Total { get; set; }

        public string LastSearchKeyword { get; set; } = string.Empty;

        public long ScrollY { get; set; }
    }
}
