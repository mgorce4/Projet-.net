using CommunityToolkit.Maui;
using EdithMaxApp.Services;
using Microsoft.Extensions.Logging;

namespace EdithMaxApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkitMediaElement(true)
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // Enregistrer HttpClient et le service Refit
        builder.Services.AddScoped(_ => 
        {
            var httpClient = new HttpClient { BaseAddress = new Uri("https://restasaurus.herokuapp.com") };
            return new RestasaurusApiService(httpClient);
        });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}