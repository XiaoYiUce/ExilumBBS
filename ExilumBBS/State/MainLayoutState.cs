using System;
using System.Collections.Generic;
using System.Text;

namespace ExilumBBS.State
{
    public class MainLayoutState
    {
        /// <summary>
        /// 工具栏标题
        /// </summary>
        public string AppBarTitle { get; set; } = "追放社区";

        /// <summary>
        /// 筛选器按钮是否可见
        /// </summary>
        public bool FilterVisable { get; set; } = false;
    }
}
