using API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pogodynka
{
    internal class Menu
    {
        private StringBuilder welcomeText = new StringBuilder();
        private StringBuilder optionText = new StringBuilder();
        public void welcome()
        {
        
            Console.Clear();
            welcomeText.Append("\u001b[38;2;230;190;16m ▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
            welcomeText.AppendLine();
            welcomeText.Append("\x1b[38;2;73;230;16m \r\n  \r\n                        _____   ____   _____  ____  _______     ___   _ _  __          \r\n                       |  __ \\ / __ \\ / ____|/ __ \\|  __ \\ \\   / / \\ | | |/ /    /\\    \r\n                       | |__) | |  | | |  __| |  | | |  | \\ \\_/ /|  \\| | ' /    /  \\   \r\n                       |  ___/| |  | | | |_ | |  | | |  | |\\   / | . ` |  <    / /\\ \\  \r\n                       | |    | |__| | |__| | |__| | |__| | | |  | |\\  | . \\  / ____ \\ \r\n                       |_|     \\____/ \\_____|\\____/|_____/  |_|  |_| \\_|_|\\_\\/_/    \\_\\\r\n                                                                                       \r\n                                                                                       \r\n     ");
            welcomeText.AppendLine();
            welcomeText.Append("\u001b[38;2;230;190;16m ▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
            Console.WriteLine(welcomeText);
            Console.ForegroundColor = ConsoleColor.Black;
            option();
        }
        public void option()
        {
            optionText.AppendLine("");
            optionText.Append("\u001b[38;2;237;149;40m"); 
            optionText.Append("                                           1. Aktualna prognoza pogody\n");
            optionText.Append("                                           2. Pogoda długoterminowa");
            Console.WriteLine(optionText);
            choiceOption();
        }
        public void choiceOption()
        {
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.W:
                        WeatherAPI api = new WeatherAPI("Tarnobrzeg");
                        api.connect();
                        Weather forecast = new Weather(api.City(), api.getCurrentWeatherCondition(), api.getCurrentTemperature(), api.getCurrentPressure(), api.getCurrentWind(), api.getCurrentAirHumidity());
                        forecast.actualForeCast();
                        break;
                    case ConsoleKey.S:
                        break;
                }
            }
        }
    }
}
