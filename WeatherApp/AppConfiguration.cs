using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    public static class AppConfiguration
    {
        private static IConfiguration configuration;
        private static void initConfig()
        {
           
            configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").AddUserSecrets("5c3c345e-f5a5-497d-8b70-44f2326e4861").Build();
        }
        public static string GetValue(string key)
        {
            if (configuration == null)
            {
                initConfig();
            }
            return configuration[key];
        }
    }
}
