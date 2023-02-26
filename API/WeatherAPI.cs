using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Collections.Generic;

namespace API
{
    public class WeatherAPI
    {
        private ChromeDriver driver;
        private string city;
        public WeatherAPI(string city)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--window-size=1920,1080");
            options.AddArgument("--start-maximized");
            options.AddArgument("log-level=3");
            options.AddArgument("--headless");
            options.AddArgument("no-sandbox");
            driver = new ChromeDriver(options);
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
            Thread.Sleep(500);
            string searchInput = "//*[@id=\"query\"]";
            driver.FindElement(By.XPath("//*[@id=\"query\"]")).Click();
            driver.FindElement(By.XPath(searchInput)).SendKeys(city);
            Thread.Sleep(1000);
            driver.FindElement(By.XPath(searchInput)).SendKeys(Keys.Enter);
            Thread.Sleep(3000);
        }
        
        public void connectToCurrentForeCast()
        {
            driver.Navigate().GoToUrl("https://pogoda.wp.pl");
            Thread.Sleep(1000);
            acceptCookies();
            fillInput();
            Thread.Sleep(5000);
        }
        public void connectToLongTermForeCast()
        {
            driver.Navigate().GoToUrl("https://pogoda.wp.pl");
            Thread.Sleep(1000);
            acceptCookies();
            fillInput();
            Thread.Sleep(1500);
            string longTermForeCastXPath = "//*[@id=\"__layout\"]/div/div[7]/div[2]/a[2]";
            driver.FindElement(By.XPath(longTermForeCastXPath)).Click();        
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
        //Delete units from downloaded data
        public string deleteTextFromData(string value,int convLength)
        {
            string newvalue = "";
            for (int i = 0; i < convLength; i++)
            {
                newvalue += value[i];
            }
            return newvalue;
        }
        public List<KeyValuePair<string, string>> getDayForeCast(int countForecastDays)
        {    
            List<KeyValuePair<string,string>> dayForeCast = new List<KeyValuePair<string,string>>();
            int i = 1;
            while(i<=countForecastDays)
            {
                //date
                dayForeCast.Add(new KeyValuePair<string, string>("Data","Data: " + driver.FindElement(By.XPath($"//*[@id=\"__layout\"]/div/div[7]/div[3]/div[2]/div[1]/div/ul/li[{i}]/div/div[1]/span[2]")).Text));
                //temperature
                dayForeCast.Add(new KeyValuePair<string, string>("Temperatura", " Temperatura " +driver.FindElement(By.XPath($"//*[@id=\"__layout\"]/div/div[7]/div[3]/div[2]/div[1]/div/ul/li[{i}]/div/div[2]/div/span")).Text));
                //pressure
                dayForeCast.Add(new KeyValuePair<string, string>("Ciśnienie"," Ciśnienie " + driver.FindElement(By.XPath($"//*[@id=\"__layout\"]/div/div[7]/div[3]/div[2]/div[1]/div/ul/li[{i}]/div/div[4]/span[2]")).Text));
                //AirHumidity
                dayForeCast.Add(new KeyValuePair<string, string>("Wilgotność"," Wilgotność " + driver.FindElement(By.XPath($"//*[@id=\"__layout\"]/div/div[7]/div[3]/div[2]/div[1]/div/ul/li[{i}]/div/div[6]/span[2]")).Text));
                //weatherCondition
                dayForeCast.Add(new KeyValuePair<string, string>("stanPogody","[" + driver.FindElement(By.XPath($"//*[@id=\"__layout\"]/div/div[7]/div[3]/div[2]/div[1]/div/ul/li[{i}]/div/div[2]/div/div/span[2]")).Text+"]"));
                i++;
            }
            return dayForeCast;
        }
    }
}