
using App.Features.Start;
using App.Services;
using App.Services.Interfaces;
using App.Services.Navigation;
using App.Services.Settings;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Core.Hosting;

namespace App;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
      => MauiApp
            .CreateBuilder()
            .UseMauiApp<App>()
        .ConfigureSyncfusionCore()
            .ConfigureEffects(
                effects =>
                {
                })
            .UseMauiCommunityToolkit()
            .ConfigureFonts(
                fonts =>
                {
                    fonts.AddFont("Roboto-Black.ttf", "RobotoBlack");
                    fonts.AddFont("Roboto-Medium.ttf", "RobotoMedium");
                    fonts.AddFont("Roboto-Regular.ttf", "RobotoRegular");
                })
            .RegisterAppServices()
            .RegisterViewModels()
            .RegisterViews()
            .Build();
    public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder mauiAppBuilder)
	{
        mauiAppBuilder.Services.AddScoped<ISettingsService, SettingsService>();
        mauiAppBuilder.Services.AddScoped<INavigationService, MauiNavigationService>();
        mauiAppBuilder.Services.AddScoped<IWeatherService, WeatherServices>();
        return mauiAppBuilder;
	}
    public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
	{
        mauiAppBuilder.Services.AddTransient<StartViewModel>();
       
        mauiAppBuilder.Services.AddTransient<BarChartViewModel>();

        return mauiAppBuilder;
	}
    public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
	{
        mauiAppBuilder.Services.AddTransient<StartView>();
       
        mauiAppBuilder.Services.AddTransient<BarChart>();

        return mauiAppBuilder;
	}
}

