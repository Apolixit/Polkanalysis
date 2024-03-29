﻿using Polkanalysis.Domain.Contracts.Repository;
using Polkanalysis.Infrastructure.DirectAccess.Repository;
using Polkanalysis.SubstrateDecode.Event;
using Polkanalysis.Maui.Data;
using Microsoft.Extensions.Logging;

namespace Polkanalysis.Maui
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

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<WeatherForecastService>();
            builder.Services.AddScoped<IEventRepository, EventRepositoryDirectAccess>();
            builder.Services.AddScoped<ISubstrateNodeRepository, SubstrateNodeRepositoryDirectAccess>();
            builder.Services.AddScoped<IEventListener, SubstrateDecode>();

            return builder.Build();
        }
    }
}