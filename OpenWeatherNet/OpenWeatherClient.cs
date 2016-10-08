namespace OpenWeatherNet
{
    public class OpenWeatherClient
	{
		public OpenWeatherClient(string apiKey)
		{
			key = apiKey;
		}

		string key;

		public WeatherInfo GetByCityName(string cityName)
		{
			return new WeatherInfo("http://api.openweathermap.org/data/2.5/weather?q=" + cityName + "&appid=" + key + "&mode=xml");
		}
    }
}