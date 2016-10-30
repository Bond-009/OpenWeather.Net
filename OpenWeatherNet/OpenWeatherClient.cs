namespace OpenWeatherNet
{
    public class OpenWeatherClient
	{
		public OpenWeatherClient(string apiKey)
		{
			Key = apiKey;
		}

		public string Key;

		public WeatherInfo GetByCityName(string cityName)
		{
			return new WeatherInfo("http://api.openweathermap.org/data/2.5/weather?q=" + cityName + "&appid=" + Key + "&mode=xml");
		}

		public WeatherInfo GetByCoords(Coord coords)
		{
			return new WeatherInfo("http://api.openweathermap.org/data/2.5/weather?lat=" + coords.lat + "&lon=" + coords.lon + "&appid=" + Key + "&mode=xml");
		}

		public WeatherInfo GetByCoords(double lat, double lon)
		{
			return new WeatherInfo("http://api.openweathermap.org/data/2.5/weather?lat=" + lat + "&lon=" + lon + "&appid=" + Key + "&mode=xml");
		}

		public WeatherInfo GetByZipCode(int zipCode, string countryCode)
		{
			return new WeatherInfo("http://api.openweathermap.org/data/2.5/weather?zip=" + zipCode + "," + countryCode + "&appid=" + Key + "&mode=xml");
		}
	}
}