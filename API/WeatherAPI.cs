using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Numerics;


namespace API
{
    public class WeatherAPI
    {
        private ChromeDriver driver;
        private string city;
        public WeatherAPI(string city)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--log-level=3");
            options.AddArgument("--disable-web-security");
            driver = new ChromeDriver(options);
            this.city = city;
        }
        public string City()
        {
            return city;
        }
        public void acceptCookies()
        {
            driver.FindElement(By.ClassName("rodo__button")).Click();
        }
        public void fillInput()
        {
            driver.FindElement(By.ClassName("search-input")).SendKeys(city);
            driver.FindElement(By.ClassName("hint-link")).Click();
        }
        public void connect()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.twojapogoda.pl/");
            acceptCookies();
            fillInput();
            Thread.Sleep(2000);
            string hourlyDataXPath = "//*[@id=\"page-wrap\"]/div[2]/section[1]/div/ul/span/li[1]/a";
            driver.FindElement(By.XPath(hourlyDataXPath)).Click();
            Thread.Sleep(500);

        }
        public int getCurrentTemperature()
        {
            string temperatureXPath = "//*[@id=\"page-wrap\"]/div[2]/div[1]/main/section[1]/div[2]/div[1]/ul/li[1]/div[4]/ul/li[1]/span[2]/span";
            int temperature = Convert.ToInt32(driver.FindElement(By.XPath(temperatureXPath)).Text);
            return temperature;            
        }
        public string getCurrentWeatherCondition()
        {
            string weatherConditionXPath = "//*[@id=\"page-wrap\"]/div[2]/div[1]/main/section[1]/div[2]/div[1]/ul/li[1]/div[3]/div[2]";
            return driver.FindElement(By.XPath(weatherConditionXPath)).Text;
        }
        public string getCurrentAirHumidity()
        {
            string airBoxXPath = "//*[@id=\"page-wrap\"]/div[2]/div[1]/main/section[1]/div[2]/div[1]/ul/li[1]/div[4]/ul/li[6]/span[2]/span";
            return driver.FindElement(By.XPath(airBoxXPath)).Text;
        }
        public int getCurrentPressure()
        {
            string pressureXPath = "//*[@id=\"page-wrap\"]/div[2]/div[1]/main/section[1]/div[2]/div[1]/ul/li[1]/div[4]/ul/li[5]/span[2]/span";
            string pressure = driver.FindElement(By.XPath(pressureXPath)).Text;
            string newpressue = "";
            newpressue = deleteTextFromData(pressure, 4);
            return int.Parse(newpressue); 
        }
        public int getCurrentWind()
        {
            string windXPath = "//*[@id=\"page-wrap\"]/div[2]/div[1]/main/section[1]/div[2]/div[1]/ul/li[1]/div[4]/ul/li[3]/span[2]/span";
            string wind = driver.FindElement(By.XPath(windXPath)).Text;
            string newwind = "";
            
            newwind = deleteTextFromData(wind, 2);
            return int.Parse(newwind);
        }
        public string deleteTextFromData(string value,int convLength)
        {
            string newvalue = "";
            for (int i = 0; i < convLength; i++)
            {
                newvalue += value[i];
            }
            return newvalue;
        }
    }
}