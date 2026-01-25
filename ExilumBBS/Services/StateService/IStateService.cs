using ExilumBBS.State;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExilumBBS.Services.StateService
{
    public interface IStateService
    {
        public HomeHistoryStatus? GetHomeHistoryStatus();
        public void SetHomeHistoryStatus(HomeHistoryStatus status);
        public void ClearHomeHistoryStatus();
    }
}
