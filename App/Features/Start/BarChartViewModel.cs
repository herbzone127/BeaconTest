using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using App.Features.Base;
using App.Models;
using App.Services.Interfaces;
using App.Services.Navigation;
using CommunityToolkit.Mvvm.Input;

namespace App.Features.Start;

public class BarChartViewModel : ViewModelBase
{
    INavigationService _navigationService;
    IWeatherService _weatherService;
    public BarChartViewModel(INavigationService navigationService,IWeatherService weatherService):base(navigationService)
	{
        _navigationService = navigationService;
        _weatherService = weatherService;
         InitializeAsyncCommand.Execute(this);
   
    }
    #region Properties
    private string _chartXAxisType;

    public string ChartXAxisType
    {
        get { return _chartXAxisType; }
        set { SetProperty(ref _chartXAxisType , value); }
    }

    private string _chartType;

    public string ChartType
    {
        get { return _chartType; }
        set {SetProperty(ref _chartType , value);
        if(ChartType =="Daily" && !string.IsNullOrEmpty( Month))
            {
                InitializeAsyncCommand.Execute(this);
            }
        }
    }
    private string _month;

    public string Month
    {
        get { return _month; }
        set {SetProperty(ref _month , value);
        if(ChartType=="Monthly" && !string.IsNullOrEmpty(Month))
            {
                UpdateChart(Month);
            }
           
        }
    }

    private void UpdateChart(string month)
    {
        ChartXAxisType = "Date";
        var result = WeatherForecasts;

        var reesultBySelectedMonth= result.Where(u=>u.Month==month).ToList();
        WeatherForecasts = new ObservableCollection<WeatherForecast>(reesultBySelectedMonth);
    }

    #endregion
    #region Collection
    private ObservableCollection<WeatherForecast> _WeatherForecasts;

    public ObservableCollection<WeatherForecast> WeatherForecasts
    {
        get { return _WeatherForecasts; }
        set { SetProperty(ref _WeatherForecasts , value); }
    }
    private ObservableCollection<string> _ChartTypes;

    public ObservableCollection<string> ChartTypes
    {
        get { return _ChartTypes; }
        set { SetProperty(ref _ChartTypes, value); }
    }
    private ObservableCollection<string> _Months;

    public ObservableCollection<string> Months
    {
        get { return _Months; }
        set { SetProperty(ref _Months, value); }
    }
    #endregion
    public override async Task InitializeAsync()
    {
       var result =await _weatherService.GetWeatherForecasts();
        result.ForEach(x => { 
        x.Month= x.Date.Split('-')[1];
        });
        Month = "";
        ChartType = "Daily";
        ChartXAxisType = "Month";
      
        WeatherForecasts = new ObservableCollection<WeatherForecast>(result);
        GetTypes();
        GetMonths();
    }

    public  void GetTypes()
    {
ChartTypes = new ObservableCollection<string>()
{
    "Daily",
    "Monthly"
};
    }
    public void GetMonths()
    {
        Months=new ObservableCollection<string>( WeatherForecasts.DistinctBy(x=>x.Month).Select(x=>x.Month));
    }
}

