using System;
using System.Collections.Generic;
using System.Text;

namespace ExilumBBS.Services.ThemeService
{
    public interface IThemeService
    {
        event Action<Theme>? ThemeOnChanged;
        void SetTheme(Theme theme);
        Theme RealTheme { get; }
    }
}
