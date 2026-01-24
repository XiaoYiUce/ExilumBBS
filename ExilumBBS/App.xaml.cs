using ExilumBBS.Services.SettingService;
using ExilumBBS.Services.ThemeService;
using System.Diagnostics;

namespace ExilumBBS
{
    public partial class App : Application
    {
        private Color backgroundColor = default!;
        private readonly IThemeService _themeService;
        private readonly Masa.Blazor.MasaBlazor _masaBlazor;

        public App(IThemeService themeService, Masa.Blazor.MasaBlazor masaBlazor)
        {
            _themeService = themeService;
            _masaBlazor = masaBlazor;
            InitializeComponent();

            InitTheme();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = new Window(new MainPage()) { Title = "ExilumBBS" };
            window.Created += WindowCreated;
            return window;
        }

        protected void WindowCreated(object? sender, EventArgs eventArgs)
        {
            ThemeChanged(_themeService.RealTheme);
        }


        private void InitTheme()
        {
            var themeInt = Microsoft.Maui.Storage.Preferences.Get(nameof(Setting.Theme), 0);
            // 将数字转为主题枚举
            var theme = (Theme)themeInt;
            _themeService.SetTheme(theme);

            _themeService.ThemeOnChanged += ThemeChanged;

            bool dark = _themeService.RealTheme == Theme.Dark;

            // 6. 根据主题设置背景颜色（使用自定义颜色常量）
            backgroundColor = Color.FromArgb(dark ? "#121212" : "#f4f7fa");
        }

        private void ThemeChanged(Theme theme)
        {
            _masaBlazor.SetTheme(theme == Theme.Dark);

            bool dark = theme == Theme.Dark;
        }
    }
}
