using Masa.Blazor;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExilumBBS.State
{
    internal class AppState
    {
        /// <summary>
        /// 当前选中菜单项
        /// </summary>
        public StringNumber CurrentMenu { get; set; } = 1;
    }
}
