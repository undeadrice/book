﻿using Bookie.Pages.Book;
using Bookie.Services;
using Bookie.Services.Domain.Book;
using Bookie.ViewModels;
using Bookie.ViewModels.Book;
using CommunityToolkit.Maui;

namespace Bookie
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
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
            mauiAppBuilder.Services.AddTransient<BookReadListView>();
            mauiAppBuilder.Services.AddTransient<BookDetailsView>();

            return mauiAppBuilder;
        }

        private static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<MainViewModel>();
            mauiAppBuilder.Services.AddSingleton<BookSearchViewModel>();
            mauiAppBuilder.Services.AddSingleton<BookReadViewModel>();
            mauiAppBuilder.Services.AddSingleton<BookDetailsViewModel>();

            return mauiAppBuilder;
        }

        private static MauiAppBuilder RegisterServices(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<IBookService, BookService>();
            mauiAppBuilder.Services.AddTransient<IBookHttpService, BookHttpService>();
            mauiAppBuilder.Services.AddTransient<IInitializable, BookFileRepository>();
            mauiAppBuilder.Services.AddTransient<IBookRepository, BookFileRepository>();

            return mauiAppBuilder;
        }
    }
}
