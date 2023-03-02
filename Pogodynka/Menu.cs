using API;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pogodynka
{
    internal class Menu
    {
        private StringBuilder welcomeText = new StringBuilder();
        private StringBuilder optionText = new StringBuilder();
        private Weather forecast;
        string city;
        int days;
        private WeatherAPI api;
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
            optionText.Append("\u001b[38;2;237;149;40m                                            Naciśnij, by wybrać opcje:");
            optionText.AppendLine("");
            optionText.AppendLine("");
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
                    case ConsoleKey.D1:
                        city = writeCity();
                        Console.WriteLine("\n\nPobieranie danych meteorologicznych...");
                        Console.ForegroundColor = ConsoleColor.Black;
                        api = new WeatherAPI(city);
                        api.connectToCurrentForeCast();
                        forecast = new Weather(api.City(), api.getCurrentWeatherCondition(), api.getCurrentTemperature(), api.getCurrentPressure(), api.getCurrentWind(), api.getCurrentAirHumidity());
                        forecast.actualForeCast();
                        break;
                    case ConsoleKey.D2:
                        city = writeCity();
                        days = writeCountDays();
                        Console.WriteLine("\n\nPobieranie danych meteorologicznych...");
                        Console.ForegroundColor = ConsoleColor.Black;
                        api = new WeatherAPI(city);
                        api.connectToLongTermForeCast();
                        Thread.Sleep(3000);
                        var list = api.getDayForeCast(days);
                        forecast = new Weather(city, list);
                        Console.Clear();
                        string forecastText = forecast.longForeCast();
                        Console.WriteLine(forecastText);
                        Thread.Sleep(2000);
                        FileWritter file = new FileWritter(@"../../../ForeCasts/", forecastText, city);
                        file.saveForeCast();
                        break;
                }
            }
        }
        public void backToMenu()
        {
            Console.WriteLine("\nCzy chcesz wrócić do Menu? Y/N");
            while (true)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Y:
                        welcome();
                        Thread.Sleep(500);
                        option();
                        break;
                    case ConsoleKey.N:
                        Console.Clear();
                        Console.WriteLine("\u001b[38;2;255;71;15m\r\n██████   ██████   ██████   ██████  ██████  ██    ██ ███    ██ ██   ██  █████      \r\n██   ██ ██    ██ ██       ██    ██ ██   ██  ██  ██  ████   ██ ██  ██  ██   ██     \r\n██████  ██    ██ ██   ███ ██    ██ ██   ██   ████   ██ ██  ██ █████   ███████     \r\n██      ██    ██ ██    ██ ██    ██ ██   ██    ██    ██  ██ ██ ██  ██  ██   ██     \r\n██       ██████   ██████   ██████  ██████     ██    ██   ████ ██   ██ ██   ██     \r\n                                                                                  \r\n                                                                                  \r\n██     ██ ██    ██ ██       █████   ██████ ███████  ██████  ███    ██  █████      \r\n██     ██  ██  ██  ██      ██   ██ ██         ███  ██    ██ ████   ██ ██   ██     \r\n██  █  ██   ████   ██      ███████ ██        ███   ██    ██ ██ ██  ██ ███████     \r\n██ ███ ██    ██    ██      ██   ██ ██       ███    ██    ██ ██  ██ ██ ██   ██     \r\n ███ ███     ██    ███████ ██   ██  ██████ ███████  ██████  ██   ████ ██   ██     \r\n                                                                                  \r\n                                                                                  \r\n");
                        Environment.Exit(0);
                        break;
                }
            }
        }
        public string writeCity()
        {
            do
            {
                Console.Write("\n\u001b[38;2;237;149;40mPodaj nazwę miasta:  ");
                city = Console.ReadLine();
            } while (city.Length == 0);
            return city;
        }
        public int writeCountDays()
        {
            do
            {
                try
                {
                    Console.Write("\n\u001b[38;2;237;149;40mPodaj liczbę dni prognozy:  ");
                    days = Convert.ToInt32(Console.ReadLine());
                }
                catch(Exception e)
                {
                    writeCountDays();
                }
            } while (days == null || days > 20 || days < 0||days==0);
            return days;
        }
    }
}
