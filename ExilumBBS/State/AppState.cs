using Masa.Blazor;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExilumBBS.State
{
    public class AppState
    {
        /// <summary>
        /// 当前选中菜单项
        /// </summary>
        public StringNumber CurrentMenu { get; set; } = 1;

        /// <summary>
        /// WithbackLayout状态缓存
        /// </summary>
        public WithbackLayoutState WithbackLayoutState { get; set; } = new();

        /// <summary>
        /// MainLayout状态缓存
        /// </summary>
        public MainLayoutState MainLayoutState { get; set; } = new();
    }
}
