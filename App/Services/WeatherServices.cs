using App.Constants;
using App.Models;
using App.Services.Data;
using App.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services
{
    public class WeatherServices : IWeatherService
    {
        public Task<List<WeatherForecast>> GetWeatherForecasts()
        {
            return HTTPClientWrapper<List<WeatherForecast>>.Get(UrlHelper.WeatherApi);
        }
    }
}
