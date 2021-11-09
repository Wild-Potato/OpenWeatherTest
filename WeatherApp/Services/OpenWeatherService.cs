using OpenWeatherAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    class OpenWeatherService : IWindDataService
    {
        private static OpenWeatherProcessor owp;
        public WindDataModel LastwindData;
        public OpenWeatherService(string apiKey)
        {
            owp = OpenWeatherProcessor.Instance;
            owp.ApiKey = apiKey;
        }
        public async Task<WindDataModel> GetDataAsync()
        {
            OWCurrentWeaterModel currentWeaterModel = await owp.GetCurrentWeatherAsync();
            WindDataModel windDataModel = new WindDataModel();

            windDataModel.DateTime = DateTime.FromBinary(currentWeaterModel.DateTime);
            windDataModel.Direction = currentWeaterModel.Wind.Deg;
            windDataModel.MetrePerSec = currentWeaterModel.Wind.Speed;

            LastwindData = windDataModel;
            return LastwindData;

            
        }
        
    }
}
