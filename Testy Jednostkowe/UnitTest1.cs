using API;
using OpenQA.Selenium.Firefox;
using Xunit;

namespace Testy_Jednostkowe
{
    public class UnitTest1
    {
        FirefoxDriver driver = new FirefoxDriver();
        [Fact]
        public void Test1()
        {
            WeatherAPI api = new WeatherAPI();
        }
    }
}