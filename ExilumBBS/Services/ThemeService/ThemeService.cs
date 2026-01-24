using System;
using System.Collections.Generic;
using System.Text;

namespace ExilumBBS.Services.ThemeService
{
    public class ThemeService : IThemeService
    {
        private Theme? _theme;

        /// <summary>
        /// 获取系统真实颜色模式
        /// </summary>
        public Theme RealTheme => _theme switch
        {
            Theme.System => Application.Current!.RequestedTheme == AppTheme.Light ? Theme.Light : Theme.Dark,
            Theme.Dark => Theme.Dark,
            _ => Theme.Light
        };

        public event Action<Theme>? ThemeOnChanged;

        public void SetTheme(Theme theme)
        {
            if (_theme == theme)
            {
                return;
            }

            if (theme == Theme.System)
            {
                Application.Current!.RequestedThemeChanged += HandleAppthemeChanged;
            }
            else
            {
                // 取消订阅系统主题变化事件
                Application.Current!.RequestedThemeChanged -= HandleAppthemeChanged;
            }

            _theme = theme;

            ThemeOnChanged?.Invoke(RealTheme);
        }

        private void HandleAppthemeChanged(object? sender, AppThemeChangedEventArgs e)
        {
            ThemeOnChanged?.Invoke(RealTheme);
        }
    }

    /// <summary>
    /// 主题枚举
    /// </summary>
    public enum Theme
    {
        System = 0,
        Light = 1,
        Dark = 2
    }
}
