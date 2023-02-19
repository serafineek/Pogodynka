using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pogodynka
{
    public class Weather
    {
        private string city;
        private string weatherCondition;
        private int temperature;
        private int pressure;
        private int wind;
        private string airHumidity;

        public Weather(string city, string weatherCondition, int temperature, int pressure, int wind, string airHumidity)
        {
            this.city = city;
            this.weatherCondition = weatherCondition;
            this.temperature = temperature;
            this.pressure = pressure;
            this.wind = wind;
            this.airHumidity = airHumidity;
        }
    }
}
