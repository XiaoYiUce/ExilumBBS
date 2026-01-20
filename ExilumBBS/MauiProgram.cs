using ExilumBBS.Services;
using ExilumBBS.State;
using ExilumBBS.Utils;
using Masa.Blazor;
using Microsoft.Extensions.Logging;
using SqlSugar;

namespace ExilumBBS
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
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
            builder.Services.AddSingleton<PostListState>();

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
            });

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
