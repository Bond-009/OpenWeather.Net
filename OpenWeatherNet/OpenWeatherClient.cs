using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;

namespace OpenWeatherNet
{
	public class OpenWeatherClient
	{
		public OpenWeatherClient(string apiKey)
		{
			ApiKey = apiKey;
		}

		/// <summary>
		/// OpenWeatherMap api key
		/// </summary>
		public string ApiKey { private get; set; }

		public async Task<WeatherInfo> GetByCityNameAsync(string cityName)
		{
			return await GetWeatherAsync("http://api.openweathermap.org/data/2.5/weather?q=" + cityName + "&appid=" + ApiKey + "&mode=xml");
		}
		
		public async Task<WeatherInfo> GetByCoordsAsync(Coord coords)
		{
			return await GetWeatherAsync("http://api.openweathermap.org/data/2.5/weather?lat=" + coords.lat + "&lon=" + coords.lon + "&appid=" + ApiKey + "&mode=xml");
		}

		public async Task<WeatherInfo> GetByCoordsAsync(double lat, double lon)
		{
			return await GetWeatherAsync("http://api.openweathermap.org/data/2.5/weather?lat=" + lat + "&lon=" + lon + "&appid=" + ApiKey + "&mode=xml");
		}

		public async Task<WeatherInfo> GetByZipCodeAsync(int zipCode, string countryCode)
		{
			return await GetWeatherAsync("http://api.openweathermap.org/data/2.5/weather?zip=" + zipCode + "," + countryCode + "&appid=" + ApiKey + "&mode=xml");
		}

		internal static async Task<WeatherInfo> GetWeatherAsync(string url)
		{
			WeatherInfo weatherInfo = new WeatherInfo();

			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load(await new HttpClient().GetStreamAsync(url));

			weatherInfo.city.id = Convert.ToInt32(xmlDoc.DocumentElement["city"].Attributes["id"].InnerText);
			weatherInfo.city.name = xmlDoc.DocumentElement["city"].Attributes["name"].InnerText;
			weatherInfo.city.coord.lon = Convert.ToDouble(xmlDoc.DocumentElement["city"]["coord"].Attributes["lon"].InnerText);
			weatherInfo.city.coord.lat = Convert.ToDouble(xmlDoc.DocumentElement["city"]["coord"].Attributes["lat"].InnerText);
			weatherInfo.city.country = xmlDoc.DocumentElement["city"]["country"].InnerText;
			weatherInfo.city.sun.rise = Convert.ToDateTime(xmlDoc.DocumentElement["city"]["sun"].Attributes["rise"].InnerText);
			weatherInfo.city.sun.set = Convert.ToDateTime(xmlDoc.DocumentElement["city"]["sun"].Attributes["set"].InnerText);

			weatherInfo.temperature.value = Convert.ToDouble(xmlDoc.DocumentElement["temperature"].Attributes["value"].InnerText);
			weatherInfo.temperature.min = Convert.ToDouble(xmlDoc.DocumentElement["temperature"].Attributes["min"].InnerText);
			weatherInfo.temperature.max = Convert.ToDouble(xmlDoc.DocumentElement["temperature"].Attributes["max"].InnerText);
			if (xmlDoc.DocumentElement["temperature"].Attributes["unit"].InnerText == "kelvin") { weatherInfo.temperature.unit = TemperatureScale.Kelvin; }
			else if (xmlDoc.DocumentElement["temperature"].Attributes["unit"].InnerText == "celsius") { weatherInfo.temperature.unit = TemperatureScale.Celsius; }
			else if (xmlDoc.DocumentElement["temperature"].Attributes["unit"].InnerText == "fahrenheit") { weatherInfo.temperature.unit = TemperatureScale.Fahrenheit; }

			weatherInfo.humidity.value = Convert.ToInt32(xmlDoc.DocumentElement["humidity"].Attributes["value"].InnerText);
			weatherInfo.humidity.unit = xmlDoc.DocumentElement["humidity"].Attributes["unit"].InnerText;

			weatherInfo.pressure.value = Convert.ToInt32(xmlDoc.DocumentElement["pressure"].Attributes["value"].InnerText);
			weatherInfo.pressure.unit = xmlDoc.DocumentElement["pressure"].Attributes["unit"].InnerText;

			weatherInfo.wind.speed.value = Convert.ToDouble(xmlDoc.DocumentElement["wind"]["speed"].Attributes["value"].InnerText);
			weatherInfo.wind.speed.name = xmlDoc.DocumentElement["wind"]["speed"].Attributes["name"].InnerText;

			//TODO: Add gusts if (xmlDoc.SelectSingleNode("current/wind/gusts").HasChildNodes) { gusts_TextBox.Text = xmlDoc.SelectSingleNode("current/wind/gusts").Attributes["value"].InnerText + "m/s"; }

			weatherInfo.wind.direction.value = Convert.ToDouble(xmlDoc.DocumentElement["wind"]["direction"].Attributes["value"].InnerText);
			weatherInfo.wind.direction.code = xmlDoc.DocumentElement["wind"]["direction"].Attributes["code"].InnerText;
			weatherInfo.wind.direction.name = xmlDoc.DocumentElement["wind"]["direction"].Attributes["name"].InnerText;

			weatherInfo.clouds.value = Convert.ToInt32(xmlDoc.DocumentElement["clouds"].Attributes["value"].InnerText);
			weatherInfo.clouds.name = xmlDoc.DocumentElement["clouds"].Attributes["name"].InnerText;

			//TODO: Add visibility

			if (xmlDoc.DocumentElement["precipitation"].Attributes["value"] != null)
			{
				weatherInfo.precipitation.value = Convert.ToDouble(xmlDoc.DocumentElement["precipitation"].Attributes["value"].InnerText);
			}
			weatherInfo.precipitation.mode = xmlDoc.DocumentElement["precipitation"].Attributes["mode"].InnerText;
			if (xmlDoc.DocumentElement["precipitation"].Attributes["unit"] != null)
			{
				weatherInfo.precipitation.unit = xmlDoc.DocumentElement["precipitation"].Attributes["unit"].InnerText;
			}

			weatherInfo.weather.number = Convert.ToInt32(xmlDoc.DocumentElement["weather"].Attributes["number"].InnerText);
			weatherInfo.weather.value = xmlDoc.DocumentElement["weather"].Attributes["value"].InnerText;
			weatherInfo.weather.icon = xmlDoc.DocumentElement["weather"].Attributes["icon"].InnerText;
			weatherInfo.iconURL = "http://openweathermap.org/img/w/" + weatherInfo.weather.icon + ".png";
			//TODO: Add icon

			weatherInfo.lastupdate = Convert.ToDateTime(xmlDoc.DocumentElement["lastupdate"].Attributes["value"].InnerText);
			
			return weatherInfo;
		}
	}
}