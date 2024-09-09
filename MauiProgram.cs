using Maui.Blazor.Boilerplate.Helpers;
using Microsoft.Extensions.Logging;

namespace Maui.Blazor.Boilerplate
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

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:7008/") });
            builder.Services.AddScoped<AuthService>();
            builder.Services.AddSingleton<SettingsService>();           
            builder.Services.AddSingleton<MessageService>();
            builder.Services.AddSingleton<AppState>();


            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
