using ExilumBBS.Services.SettingService;
using ExilumBBS.Services.ThemeService;

namespace ExilumBBS
{
    public partial class App : Application
    {
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
            return new Window(new MainPage()) { Title = "ExilumBBS" };
        }

        private void InitTheme()
        {
            var themeInt = Microsoft.Maui.Storage.Preferences.Get(nameof(Setting.Theme), 0);
            // 将数字转为主题枚举
            var theme = (Theme)themeInt;
            _themeService.SetTheme(theme);

            _themeService.ThemeOnChanged += ThemeChanged;
        }

        private void ThemeChanged(Theme theme)
        {
            _masaBlazor.SetTheme(theme == Theme.Light);
        }
    }
}
