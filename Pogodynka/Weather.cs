using API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Pogodynka
{
    public class Weather
    {
        private string city { get; init; }

        private Menu menu;
        private string weatherCondition { get; init; }
        private int temperature { get; init; }
        private int pressure { get; init; }
        private int wind { get; init; }
        private string airHumidity;
        List<KeyValuePair<string, string>> dayForecastList;
        StringBuilder forecastText = new StringBuilder();
        private ASCIGenerator ascitext;

        public Weather(string city,List<KeyValuePair<string, string>> dayForecastList)
        {
            this.city = city;
            this.dayForecastList = dayForecastList;
        }

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
            Console.Clear();
            ascitext = new(city);
            Console.WriteLine("\u001b[38;2;230;190;16m\n");
            ascitext.printASCICity();
            forecastText.Append($"Stan pogody: {weatherCondition}");
            forecastText.AppendLine("");
            forecastText.Append($"Temperatura: {temperature}°C  \nCiśnienie: {pressure}hPa");
            forecastText.AppendLine("");
            forecastText.Append($"Prędkość Wiatru: {wind}km/h \nWilgotność powietrza: {airHumidity}");
            Console.WriteLine(forecastText);
            menu = new Menu();
            menu.backToMenu();
        }
        public string longForeCast()
        {  
            ascitext = new(city);
            Console.Clear();
            Console.WriteLine("\u001b[38;2;230;190;16m\n");
            ascitext.printASCICity();
            
            forecastText.AppendLine("");
            int i = 0;
           
            foreach (var dayForecast in dayForecastList)
            {
                if(i%5==0)
                {
                    forecastText.AppendLine("");
                }
                forecastText.Append(dayForecast.Value + "   ");
                i++;
            }
            return forecastText.ToString();
        }
    }
}
