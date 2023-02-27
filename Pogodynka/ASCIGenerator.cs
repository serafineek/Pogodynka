using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace API
{
    public class ASCIGenerator
    {
        ChromeDriver driver;
        private string city;
        public ASCIGenerator(string city)
        {
            this.city = city;
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--window-size=1920,1080");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--headless");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--disable-crash-reporter");
            options.AddArgument("--disable-extensions");
            options.AddArgument("--disable-in-process-stack-traces");
            options.AddArgument("--disable-logging");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--log-level=3");
            options.AddArgument("--output=/dev/null");
            driver = new ChromeDriver(options);
        }
        public void printASCICity()
        {
            Console.Clear();
            string city = removePolishLetters();
            driver.Navigate().GoToUrl($"https://patorjk.com/software/taag/#p=display&f=ANSI%20Regular&t={city}");
            Thread.Sleep(500);
            Console.WriteLine();
            Console.WriteLine("\n" + driver.FindElement(By.Id("taag_output_text")).Text);
        }
        public string removePolishLetters()
        {
            city = city.ToUpper();
            string newcity = "";
            for (int i = 0; i < city.Length; i++)
            {
                if (city[i].Equals('Ó'))
                {
                    newcity += 'O';
                }
                else if (city[i].Equals('Ł'))
                {
                    newcity += 'L';
                }
                else if (city[i].Equals('Ż'))
                {
                    newcity += 'Z';
                }
                else if (city[i].Equals('Ź'))
                {
                    newcity += 'Z';
                }
                else if (city[i].Equals('Ń'))
                {
                    newcity += 'N';
                }
                else if (city[i].Equals('Ć'))
                {
                    newcity += 'C';
                }
                else if (city[i].Equals('Ą'))
                {
                    newcity += 'A';
                }
                else if (city[i].Equals('Ę'))
                {
                    newcity += 'E';
                }
                else
                {
                    newcity += city[i];
                }
            }
            return newcity;
        }
    }
}
