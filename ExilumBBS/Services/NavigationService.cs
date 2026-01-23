using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ExilumBBS.Services
{
    /// <summary>
    /// 导航服务
    /// </summary>
    public class NavigationService : INavigationService
    {
        private IJSRuntime _jsRuntime = default!;

        //private NavigationManager _navigation = default!;

        ///// <summary>
        ///// 历史URL列表
        ///// </summary>
        //private List<string> HistoryUrlList { get; set; } = [];

        //public string Uri => _navigation.Uri;

        ///// <summary>
        ///// 跳转到指定页
        ///// </summary>
        ///// <param name="url"></param>
        //public void NavigateTo(string url)
        //{
        //    HistoryUrlList.Add(url);
        //    _navigation.NavigateTo(url);
        //}

        /// <summary>
        /// 返回
        /// </summary>
        public async void NavigateBack()
        {
            Debug.WriteLine("back");
            var location = _jsRuntime.InvokeAsync<string>("window.location.pathname");
            Debug.WriteLine(location);
            await _jsRuntime.InvokeVoidAsync("history.back");
        }

        public void Initialize(IJSRuntime jSRuntime)
        {
            _jsRuntime = jSRuntime;
        }
    }
}
