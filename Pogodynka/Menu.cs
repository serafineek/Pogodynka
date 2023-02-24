using API;
using OpenQA.Selenium;
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
        private StringBuilder loadingBar = new StringBuilder();
        Weather forecast;
        private WeatherAPI api;
        List<Weather> weathersList;
        public void welcome()
        {
        
            Console.Clear();
            welcomeText.Append("\u001b[38;2;230;190;16m ▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
            welcomeText.Append("\x1b[38;2;73;230;16m   \r\n \r\n                      ██████╗  ██████╗  ██████╗  ██████╗ ██████╗ ██╗   ██╗███╗   ██╗██╗  ██╗ █████╗ \r\n                      ██╔══██╗██╔═══██╗██╔════╝ ██╔═══██╗██╔══██╗╚██╗ ██╔╝████╗  ██║██║ ██╔╝██╔══██╗\r\n                      ██████╔╝██║   ██║██║  ███╗██║   ██║██║  ██║ ╚████╔╝ ██╔██╗ ██║█████╔╝ ███████║\r\n                      ██╔═══╝ ██║   ██║██║   ██║██║   ██║██║  ██║  ╚██╔╝  ██║╚██╗██║██╔═██╗ ██╔══██║\r\n                      ██║     ╚██████╔╝╚██████╔╝╚██████╔╝██████╔╝   ██║   ██║ ╚████║██║  ██╗██║  ██║\r\n                      ╚═╝      ╚═════╝  ╚═════╝  ╚═════╝ ╚═════╝    ╚═╝   ╚═╝  ╚═══╝╚═╝  ╚═╝╚═╝  ╚═╝\r\n                                                                                                    \r\n");
            welcomeText.Append("\u001b[38;2;230;190;16m ▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
            Console.WriteLine(welcomeText);
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
                        Console.Clear();
                        api = new WeatherAPI("Londyn");
                        api.connectToCurrentForeCast();
                        forecast = new Weather(api.City(), api.getCurrentWeatherCondition(), api.getCurrentTemperature(), api.getCurrentPressure(), api.getCurrentWind(), api.getCurrentAirHumidity());
                        forecast.actualForeCast();
                        
                        break;
                    case ConsoleKey.S:
                        Console.Clear();
                        api = new WeatherAPI("Londyn");
                        api.connectToLongTermForeCast();
                        Thread.Sleep(3000);
                        var list = api.getDayForeCast(5);
                        forecast = new Weather("Londyn",list);
                        Console.Clear();
                        forecast.longForeCast();
                        break;
                }
            }
        }
        
    }
}
