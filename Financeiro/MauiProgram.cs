using Financeiro.Repositories;
using LiteDB;
using Microsoft.Extensions.Logging;

namespace Financeiro
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .RegisterDatabaseRepositories()
                .RegisterViews()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        public static MauiAppBuilder RegisterDatabaseRepositories(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<LiteDatabase>(options =>
            {
                return new LiteDatabase($"Filename={AppSettings.DatabasePath}; Connection=Shared;");
            });

            builder.Services.AddTransient<ITransactionRepository, TransactionRepository>();
            return builder;
        }

        public static MauiAppBuilder RegisterViews(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<Views.TransactionList>();
            builder.Services.AddTransient<Views.TransactionNew>();
            builder.Services.AddTransient<Views.TransactionEdit>();
            return builder;
        }
    }
}
