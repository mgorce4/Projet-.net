using CommunityToolkit.Maui;
using EdithMaxApp.Services;
using Microsoft.Extensions.Logging;
using Refit;
using EdithMaxApp.ViewModels;
using Newtonsoft.Json;

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

        builder.Services.AddTransient<DinosaurDetailsViewModel>();
        builder.Services.AddTransient<GalleryViewModel>();
        builder.Services.AddTransient<GalleryPage>();
        builder.Services.AddTransient<DinosaurImageDetailViewModel>();
        builder.Services.AddTransient<DinosaurImageDetailPage>();
        builder.Services.AddTransient<BonusPageViewModel>();
        builder.Services.AddTransient<BonusPage>();
        builder.Services.AddTransient<LoggingHandler>();

        // Enregistrer HttpClient et le service Refit
        var refitSettings = new RefitSettings
        {
            ContentSerializer = new NewtonsoftJsonContentSerializer(
                new JsonSerializerSettings
                {
                    ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
                })
        };
        builder.Services.AddRefitClient<IRestasaurusApi>(refitSettings)
            .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://restasaurus.onrender.com"))
            .AddHttpMessageHandler<LoggingHandler>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}