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
        public string ApiKey { get; set; }

        /// <summary>
        /// Gets info about the curent weather
        /// </summary>
        /// <param name="cityName">Name of the city</param>
        /// <returns>Info about the current weather</returns>
		public async Task<WeatherInfo> GetCurrentAsync(string cityName)
        {
            return await GetWeatherAsync("http://api.openweathermap.org/data/2.5/weather?q=" + cityName + "&appid=" + ApiKey + "&mode=xml");
        }

        /// <summary>
        /// Gets info about the current weather
        /// </summary>
        /// <param name="coords">Coordinates for the location</param>
        /// <returns>Info about the current weather</returns>
        public async Task<WeatherInfo> GetCurrentAsync(Coord coords)
        {
            return await GetWeatherAsync("http://api.openweathermap.org/data/2.5/weather?lat=" + coords.Lat + "&lon=" + coords.Lon + "&appid=" + ApiKey + "&mode=xml");
        }

        /// <summary>
        /// Gets info about the current weather
        /// </summary>
        /// <param name="lat">Latitude</param>
        /// <param name="lon">Longitude</param>
        /// <returns>Info about the current weather</returns>
		public async Task<WeatherInfo> GetCurrentAsync(double lat, double lon)
        {
            return await GetWeatherAsync("http://api.openweathermap.org/data/2.5/weather?lat=" + lat + "&lon=" + lon + "&appid=" + ApiKey + "&mode=xml");
        }

        /// <summary>
        /// Gets info about the current weather
        /// </summary>
        /// <param name="zipCode">Zip code</param>
        /// <param name="countryCode">Country code</param>
        /// <returns>Info about the current weather</returns>
		public async Task<WeatherInfo> GetCurrentAsync(int zipCode, string countryCode)
        {
            return await GetWeatherAsync("http://api.openweathermap.org/data/2.5/weather?zip=" + zipCode + "," + countryCode + "&appid=" + ApiKey + "&mode=xml");
        }

        internal static async Task<WeatherInfo> GetWeatherAsync(string url)
        {
            WeatherInfo weatherInfo = new WeatherInfo();

            XmlDocument xmlDoc = new XmlDocument();
            using (HttpClient httpclient1 = new HttpClient())
            {
                xmlDoc.Load(await httpclient1().GetStreamAsync(url));
            }

            weatherInfo.City.Id = Convert.ToInt32(xmlDoc.DocumentElement["city"].Attributes["id"].InnerText);
            weatherInfo.City.Name = xmlDoc.DocumentElement["city"].Attributes["name"].InnerText;
            weatherInfo.City.Coord.Lon = Convert.ToDouble(xmlDoc.DocumentElement["city"]["coord"].Attributes["lon"].InnerText);
            weatherInfo.City.Coord.Lat = Convert.ToDouble(xmlDoc.DocumentElement["city"]["coord"].Attributes["lat"].InnerText);
            weatherInfo.City.Country = xmlDoc.DocumentElement["city"]["country"].InnerText;
            weatherInfo.City.Sun.Rise = Convert.ToDateTime(xmlDoc.DocumentElement["city"]["sun"].Attributes["rise"].InnerText);
            weatherInfo.City.Sun.Set = Convert.ToDateTime(xmlDoc.DocumentElement["city"]["sun"].Attributes["set"].InnerText);

            weatherInfo.Temperature.Value = Convert.ToDouble(xmlDoc.DocumentElement["temperature"].Attributes["value"].InnerText);
            weatherInfo.Temperature.Min = Convert.ToDouble(xmlDoc.DocumentElement["temperature"].Attributes["min"].InnerText);
            weatherInfo.Temperature.Max = Convert.ToDouble(xmlDoc.DocumentElement["temperature"].Attributes["max"].InnerText);
            if (xmlDoc.DocumentElement["temperature"].Attributes["unit"].InnerText == "kelvin") { weatherInfo.Temperature.Unit = TemperatureScale.Kelvin; }
            else if (xmlDoc.DocumentElement["temperature"].Attributes["unit"].InnerText == "celsius") { weatherInfo.Temperature.Unit = TemperatureScale.Celsius; }
            else if (xmlDoc.DocumentElement["temperature"].Attributes["unit"].InnerText == "fahrenheit") { weatherInfo.Temperature.Unit = TemperatureScale.Fahrenheit; }

            weatherInfo.Humidity.Value = Convert.ToInt32(xmlDoc.DocumentElement["humidity"].Attributes["value"].InnerText);
            weatherInfo.Humidity.Unit = xmlDoc.DocumentElement["humidity"].Attributes["unit"].InnerText;

            weatherInfo.Pressure.Value = Convert.ToInt32(xmlDoc.DocumentElement["pressure"].Attributes["value"].InnerText);
            weatherInfo.Pressure.Unit = xmlDoc.DocumentElement["pressure"].Attributes["unit"].InnerText;

            weatherInfo.Wind.Speed.Value = Convert.ToDouble(xmlDoc.DocumentElement["wind"]["speed"].Attributes["value"].InnerText);
            weatherInfo.Wind.Speed.Name = xmlDoc.DocumentElement["wind"]["speed"].Attributes["name"].InnerText;

            //TODO: Add gusts if (xmlDoc.SelectSingleNode("current/wind/gusts").HasChildNodes) { gusts_TextBox.Text = xmlDoc.SelectSingleNode("current/wind/gusts").Attributes["value"].InnerText + "m/s"; }

            weatherInfo.Wind.Direction.Value = Convert.ToDouble(xmlDoc.DocumentElement["wind"]["direction"].Attributes["value"].InnerText);
            weatherInfo.Wind.Direction.Code = xmlDoc.DocumentElement["wind"]["direction"].Attributes["code"].InnerText;
            weatherInfo.Wind.Direction.Name = xmlDoc.DocumentElement["wind"]["direction"].Attributes["name"].InnerText;

            weatherInfo.Clouds.Value = Convert.ToInt32(xmlDoc.DocumentElement["clouds"].Attributes["value"].InnerText);
            weatherInfo.Clouds.Name = xmlDoc.DocumentElement["clouds"].Attributes["name"].InnerText;

            //TODO: Add visibility

            if (xmlDoc.DocumentElement["precipitation"].Attributes["value"] != null)
            {
                weatherInfo.Precipitation.Value = Convert.ToDouble(xmlDoc.DocumentElement["precipitation"].Attributes["value"].InnerText);
            }
            weatherInfo.Precipitation.Mode = xmlDoc.DocumentElement["precipitation"].Attributes["mode"].InnerText;
            if (xmlDoc.DocumentElement["precipitation"].Attributes["unit"] != null)
            {
                weatherInfo.Precipitation.Unit = xmlDoc.DocumentElement["precipitation"].Attributes["unit"].InnerText;
            }

            weatherInfo.Weather.Number = Convert.ToInt32(xmlDoc.DocumentElement["weather"].Attributes["number"].InnerText);
            weatherInfo.Weather.Value = xmlDoc.DocumentElement["weather"].Attributes["value"].InnerText;
            weatherInfo.Weather.Icon = xmlDoc.DocumentElement["weather"].Attributes["icon"].InnerText;
            weatherInfo.IconURL = "http://openweathermap.org/img/w/" + weatherInfo.Weather.Icon + ".png";
            //TODO: Add icon

            weatherInfo.Lastupdate = Convert.ToDateTime(xmlDoc.DocumentElement["lastupdate"].Attributes["value"].InnerText);

            return weatherInfo;
        }
    }
}
