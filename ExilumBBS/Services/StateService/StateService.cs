using ExilumBBS.State;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExilumBBS.Services.StateService
{
    public class StateService : IStateService
    {
        private HomeHistoryStatus? _homeHistoryStatus = null;

        /// <summary>
        /// 清空首页历史状态
        /// </summary>
        public void ClearHomeHistoryStatus()
        {
            _homeHistoryStatus = null;
        }

        /// <summary>
        /// 获取缓存的首页历史状态
        /// </summary>
        /// <returns></returns>
        public HomeHistoryStatus? GetHomeHistoryStatus()
        {
            return _homeHistoryStatus;
        }

        /// <summary>
        /// 设置首页历史状态
        /// </summary>
        /// <param name="status"></param>
        public void SetHomeHistoryStatus(HomeHistoryStatus status)
        {
            _homeHistoryStatus = status;
        }
    }
}
