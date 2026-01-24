using ExilumBBS.Services.ThemeService;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExilumBBS.Services.SettingService
{
    public class SettingService : ISettingService
    {
        public Theme GetTheme()
        {
            var themeInt = Microsoft.Maui.Storage.Preferences.Get(nameof(Setting.Theme), 0);
            // 将数字转为主题枚举
            var theme = (Theme)themeInt;
            return theme;
        }
    }
}
