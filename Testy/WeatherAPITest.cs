using API;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace Testy;

public class WeatherAPITests
{
    private string city = "Warszawa";
    private WeatherAPI weatherAPI;

    public WeatherAPITests()
    {
        weatherAPI = new WeatherAPI(city);
    }

    [Fact]
    public void TestGetCurrentTemperature()
    {
        weatherAPI.connectToCurrentForeCast();
        Assert.InRange(weatherAPI.getCurrentTemperature(), -40, 40);
    }

    [Fact]
    public void TestGetCurrentWeatherCondition()
    {
        weatherAPI.connectToCurrentForeCast();
        Assert.NotEmpty(weatherAPI.getCurrentWeatherCondition());
    }

    [Fact]
    public void TestGetCurrentAirHumidity()
    {
        weatherAPI.connectToCurrentForeCast();
        Assert.NotEmpty(weatherAPI.getCurrentAirHumidity());
    }
    [Fact]
    public void TestGetCurrentPressure()
    {
        weatherAPI.connectToCurrentForeCast();
        Assert.InRange(weatherAPI.getCurrentPressure(), 990, 1050);
    }
    [Fact]
    public void TestGetCurrentWind()
    {
        weatherAPI.connectToCurrentForeCast();
        Assert.InRange(weatherAPI.getCurrentWind(), 0, 100);
    }
    [Fact]
    public void TestGetDayForeCast()
    {
        weatherAPI.connectToLongTermForeCast();
        Thread.Sleep(5000);
        int dayCount = 10;
        int expected = dayCount;
        Assert.Equal(expected*5, weatherAPI.getDayForeCast(dayCount).Count);
    }
}