using Bookie.Pages.Book;
using Bookie.Services.Domain.Book;
using Bookie.ViewModels;
using Bookie.ViewModels.Book;

namespace Bookie
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .RegisterViews()
                .RegisterViewModels()
                .RegisterServices()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddHttpClient();

            return builder.Build();
        }

        private static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<MainPage>();
            mauiAppBuilder.Services.AddTransient<BookSearch>();
            mauiAppBuilder.Services.AddTransient<BookFinishedListView>();
            mauiAppBuilder.Services.AddTransient<BookDetailsView>();

            return mauiAppBuilder;
        }

        private static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<MainViewModel>();
            mauiAppBuilder.Services.AddSingleton<BookSearchViewModel>();
            mauiAppBuilder.Services.AddSingleton<BookFinishedViewModel>();
            mauiAppBuilder.Services.AddSingleton<BookDetailsViewModel>();

            return mauiAppBuilder;
        }

        private static MauiAppBuilder RegisterServices(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<IBookService, BookService>();
            mauiAppBuilder.Services.AddTransient<IBookHttpService, BookHttpService>();

            return mauiAppBuilder;
        }
    }
}
