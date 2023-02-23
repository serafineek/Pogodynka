using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;


namespace API
{
    public class WeatherAPI
    {
        private FirefoxDriver driver;
        private string city;
        public WeatherAPI(string city)
        {
            FirefoxOptions options = new FirefoxOptions();
            options.AddArgument("--no-sandbox");
            options.AddArgument("--headless");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--disable-crash-reporter");
            options.AddArgument("--disable-extensions");
            options.AddArgument("--disable-in-process-stack-traces");
            options.AddArgument("--disable-logging");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--log-level=3");
            driver = new FirefoxDriver(options);
            this.city = city;
        }
        public string City()
        {
            return city;
        }
        public void acceptCookies()
        {
            
            driver.FindElement(By.XPath("/html/body/div[3]/div/div[2]/div[3]/div/button[2]")).Click();
        }
        public void fillInput()
        {
            Thread.Sleep(1000);
            string searchInput = "//*[@id=\"query\"]";
            driver.FindElement(By.XPath("//*[@id=\"query\"]")).Click();
            driver.FindElement(By.XPath(searchInput)).SendKeys(city);
            Thread.Sleep(1000);
            driver.FindElement(By.XPath(searchInput)).SendKeys(Keys.Enter);
        }
        public void connect()
        {
           
            driver.Navigate().GoToUrl("https://pogoda.wp.pl");
            Thread.Sleep(1000);
            acceptCookies();
            fillInput();
            Thread.Sleep(2000);
        }
        public int getCurrentTemperature()
        {
            string temperatureXPath = "//*[@id=\"__layout\"]/div/div[7]/div[3]/div[2]/div[1]/div[1]/ul/li[1]/div/div[2]/div/div/span[1]/strong";
            string temperature = driver.FindElement(By.XPath(temperatureXPath)).Text;
            string newtemperature = deleteTextFromData(temperature, temperature.Length-2);
            return int.Parse(newtemperature);            
        }
        public string getCurrentWeatherCondition()
        {
            string weatherConditionXPath = "//*[@id=\"__layout\"]/div/div[7]/div[1]/div/div[2]/div/div/table/tbody/tr/td[2]/div/small";
            return driver.FindElement(By.XPath(weatherConditionXPath)).Text;
        }
        public string getCurrentAirHumidity()
        {
            string airBoxXPath = "//*[@id=\"__layout\"]/div/div[7]/div[3]/div[2]/div[1]/div[1]/ul/li[1]/div/div[6]/span[2]";
            return driver.FindElement(By.XPath(airBoxXPath)).Text;
        }
        public int getCurrentPressure()
        {
            string pressureXPath = "//*[@id=\"__layout\"]/div/div[7]/div[3]/div[2]/div[1]/div[1]/ul/li[1]/div/div[4]/span[2]";
            string pressure = driver.FindElement(By.XPath(pressureXPath)).Text;
            string newpressue = deleteTextFromData(pressure, 4);
            return int.Parse(newpressue); 
        }
        public int getCurrentWind()
        {
            string windXPath = "//*[@id=\"__layout\"]/div/div[7]/div[1]/div/div[2]/div/div/table/tbody/tr/td[4]/div/small/span";
            int wind = Convert.ToInt32(driver.FindElement(By.XPath(windXPath)).Text);
            return wind;
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