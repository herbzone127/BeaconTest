﻿using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.Interfaces
{
    public interface IWeatherService
    {
        public Task<List<WeatherForecast>> GetWeatherForecasts();
    }
}
