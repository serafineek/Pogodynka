using API;
WeatherAPI api = new WeatherAPI("Rzeszów");
api.connect();
Console.Clear();
Console.Clear();
Console.WriteLine("["+api.City()+"] " + "(" + api.getCurrentWeatherCondition() + ") " + "Temperatura Odczuwalna: " + api.getCurrentTemperature() + "  Ciśnienie: " + api.getCurrentPressure() + " Wiatr: " + api.getCurrentWind() + " Wilgotność: " + api.getCurrentAirHumidity());
