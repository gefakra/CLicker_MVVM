using ClickerMVVM;
using ClickerMVVM.Model;
using ClickerMVVM.ViewModel;
using Microsoft.Extensions.Logging;

namespace Clicker_MVVM
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .ConfigureMauiHandlers(handlers =>
                {
                    #if ANDROID || IOS || WINDOWS
                        handlers.AddHandler(typeof(Image), typeof(Microsoft.Maui.Handlers.ImageHandler));
                    #endif
                })
                .RegisterViewModels()
                .RegisterPages(); 

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        private static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<GameState>();
            builder.Services.AddSingleton<ClickerViewModel>();
            builder.Services.AddSingleton<StatsViewModel>();
            builder.Services.AddSingleton<StocksListViewModel>();
            return builder;
        }

        private static MauiAppBuilder RegisterPages(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<ClickerPage>();
            builder.Services.AddSingleton<StatsPage>();
            builder.Services.AddSingleton<StocksPage>();
            return builder;
        }
    }
}
