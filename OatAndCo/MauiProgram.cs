using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using OatAndCo.Services;
using OatAndCo.ViewModels;
using OatAndCo.Pages;

namespace OatAndCo
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif
            AddKaseServices(builder.Services);

            return builder.Build();
        }

        private static IServiceCollection AddKaseServices(IServiceCollection services) 
        {
            services.AddSingleton<KaseService>();
            
            services.AddSingletonWithShellRoute<HomePage, HomeViewModel>(nameof(HomePage));
            services.AddTransientWithShellRoute<AllKasePage, AllKaseViewModel>(nameof(AllKasePage));
            services.AddTransientWithShellRoute<DetailPage, DetailsViewModel>(nameof(DetailPage));
            return services;
        }
    }
}
