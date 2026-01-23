using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExilumBBS.Services
{
    public interface INavigationService
    {
        //public string Uri { get; }

        /// <summary>
        /// 跳转到指定路由
        /// </summary>
        /// <param name="url"></param>
        public void NavigateTo(string url);

        /// <summary>
        /// 返回上一层路由
        /// </summary>
        public void NavigateBack();

        //public void Initialize(IJSRuntime jSRuntime);
        public void Initialize(NavigationManager navigationManager);
    }
}
