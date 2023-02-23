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
        StringBuilder forecastText = new StringBuilder();

        public Weather(string city, string weatherCondition, int temperature, int pressure, int wind, string airHumidity)
        {
            this.city = city;
            this.weatherCondition = weatherCondition;
            this.temperature = temperature;
            this.pressure = pressure;
            this.wind = wind;
            this.airHumidity = airHumidity;
        }
        public void actualForeCast()
        {
            //Console.WriteLine($"[{city}] ({weatherCondition}) Temperatura: {temperature}°C Ciśnienie: {pressure}hPa Wiatr w porywach do: {wind}km/h Wilgotność powietrza: {airHumidity}");
            Console.Clear();
            forecastText.Append($"[{city}] ({weatherCondition})");
            forecastText.AppendLine("");
            forecastText.Append($"Temperatura: {temperature}°C  \nCiśnienie: {pressure}hPa");
            forecastText.AppendLine("");
            forecastText.Append($"Prędkość Wiatru: {wind}km/h \nWilgotność powietrza: {airHumidity}");
            Console.WriteLine(forecastText);
        }
    }
}
