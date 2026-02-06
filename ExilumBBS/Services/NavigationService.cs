using ExilumBBS.State;
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
        private NavigationManager _navigation = default!;
        private PostCommentState _postCommentState = default!;
        public NavigationService(PostCommentState postCommentState)
        {
            _postCommentState = postCommentState;
        }

        /// <summary>
        /// 历史URL列表
        /// </summary>
        private List<string> HistoryUrlList { get; set; } = [];

        /// <summary>
        /// 跳转到指定页
        /// </summary>
        /// <param name="url"></param>
        public void NavigateTo(string url, bool forceload = false)
        {
            var isJoin = true;
            if (HistoryUrlList.Count > 0)
            {
                if (HistoryUrlList.Last() == url)
                {
                    isJoin = false;
                }
            }

            if (HistoryUrlList.Count == 0 && url == "/")
            {
                isJoin = false;
            }

            if (isJoin)
            {
                HistoryUrlList.Add(url);
            }

            if (forceload)
            {
                _navigation.NavigateTo(url, true);
            }
            else
            {
                _navigation.NavigateTo(url);
            }
        }

        /// <summary>
        /// 返回
        /// </summary>
        public async void NavigateBack()
        {
            if (HistoryUrlList.Count > 0)
            {
                if (_postCommentState.IsOpenComment)
                {
                    _postCommentState.SetCommentStat(false);
                }
                else
                {
                    HistoryUrlList.RemoveAt(HistoryUrlList.Count - 1);
                    _navigation.NavigateTo("javascript:history.back()");
                }

            }
            else
            {
                Application.Current?.Quit();
            }

        }

        public void Initialize(NavigationManager navigation)
        {
            _navigation = navigation;
            _navigation.LocationChanged += (sender, e) =>
            {
            };

            _navigation.RegisterLocationChangingHandler(async x =>
            {
                if (_postCommentState.IsOpenComment)
                {
                    x.PreventNavigation();
                }
            });
        }
    }
}
