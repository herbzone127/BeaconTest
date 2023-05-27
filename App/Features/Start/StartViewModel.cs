using System.Collections.ObjectModel;
using System.Windows.Input;
using App.Features.Base;
using App.Models;
using App.Services.Interfaces;
using App.Services.Navigation;
using CommunityToolkit.Mvvm.Input;

namespace App.Features.Start;

public class StartViewModel:ViewModelBase
{
    INavigationService _navigationService;
    IWeatherService _weatherService;
    public StartViewModel(INavigationService navigationService,IWeatherService weatherService):base(navigationService)
	{
        _navigationService = navigationService;
        _weatherService = weatherService;
         InitializeAsyncCommand.Execute(this);
   
    }

    #region Collection
    private ObservableCollection<WeatherForecast> _WeatherForecasts;

    public ObservableCollection<WeatherForecast> WeatherForecasts
    {
        get { return _WeatherForecasts; }
        set { SetProperty(ref _WeatherForecasts , value); }
    }

    #endregion
    public override async Task InitializeAsync()
    {
       var result =await _weatherService.GetWeatherForecasts();
        WeatherForecasts = new ObservableCollection<WeatherForecast>(result);
    }

    #region Commands
   
    public IAsyncRelayCommand GotoBarChartView => new AsyncRelayCommand(async () =>
    {
        await NavigationService.NavigateToAsync("BarChart");

    });
    #endregion
}

