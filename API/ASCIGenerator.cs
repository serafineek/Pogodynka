using OpenQA.Selenium;
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
        FirefoxDriver driver;
        private string city;

        public ASCIGenerator(string city)
        {
            this.city = city;
            FirefoxOptions options = new FirefoxOptions();
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
            driver = new FirefoxDriver(options);
        }
        public void printASCICity()
        {
           
            Console.Clear();
            driver.Navigate().GoToUrl($"https://patorjk.com/software/taag/#p=display&f=ANSI%20Regular&t={city}");
            Thread.Sleep(1000);
            Console.WriteLine();
            Console.WriteLine("\n" + driver.FindElement(By.Id("taag_output_text")).Text);
        }
        
    }
}
