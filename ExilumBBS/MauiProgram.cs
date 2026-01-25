using ExilumBBS.Services;
using ExilumBBS.Services.SettingService;
using ExilumBBS.Services.ThemeService;
using ExilumBBS.State;
using ExilumBBS.Utils;
using Masa.Blazor;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using SqlSugar;
using CommunityToolkit.Maui;
using ExilumBBS.Services.StateService;

namespace ExilumBBS
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            //注入数据库
            var db = DbContext.CreateSugarScope();
            DbContext.InitDb(db);
            builder.Services.AddSingleton<ISqlSugarClient>(s => db);
            builder.Services.AddScoped(typeof(Repository<>));
            //状态机注入
            builder.Services.AddSingleton<INavigationService, NavigationService>();
            builder.Services.AddSingleton<PostListState>();
            builder.Services.AddSingleton<IThemeService, ThemeService>();
            builder.Services.AddSingleton<ISettingService, SettingService>();
            builder.Services.AddSingleton<IStateService, StateService>();

            //注入Services
            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddScoped<IUserService, UserService>();
            //注入工具类
            builder.Services.AddScoped<HttpClient>();
            builder.Services.AddScoped<HttpTools>();
            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddMasaBlazor(options =>
            {
                options.Locale = new Masa.Blazor.Locale("zh-CN");
                options.ConfigureTheme(theme =>
                {
                    theme.Themes.Light.Primary = "#FF5722";
                    theme.Themes.Dark.Primary = "#FF5722";
                    theme.Themes.Light.OnPrimary = "#FFFFFF";
                    theme.Themes.Dark.OnPrimary = "#FFFFFF";
                });
            }, ServiceLifetime.Singleton);
            // 注入用户状态信息类
            builder.Services.AddSingleton<UserState>();
            builder.Services.AddSingleton<AppState>();
#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}