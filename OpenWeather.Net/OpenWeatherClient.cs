using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OpenWeather
{
    public class OpenWeatherClient : IDisposable
    {
        HttpClient httpclient = new HttpClient();

        public OpenWeatherClient(string apiKey)
        {
            httpclient.BaseAddress = new Uri("http://api.openweathermap.org");
            this.ApiKey = apiKey;
        }

        /// <summary>
        /// OpenWeatherMap api key
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// Gets info about the curent weather
        /// </summary>
        /// <param name="cityName">Name of the city</param>
        /// <param name="countryCode">Country code</param>
        /// <returns>Info about the current weather</returns>
        public async Task<WeatherInfo> GetWeatherAsync(string cityName, string countryCode = null)
        {
            if (string.IsNullOrEmpty(cityName)) { throw new ArgumentNullException("cityName"); }
            if (!string.IsNullOrEmpty(countryCode))
            {
                cityName += "," + countryCode;
            }

            return await GetWeatherAsync(
                new Dictionary<string, string> {{"q", cityName}});
        }

        /// <summary>
        /// Gets info about the curent weather
        /// </summary>
        /// <param name="cityID">Name of the city</param>
        /// <returns>Info about the current weather</returns>
        public async Task<WeatherInfo> GetWeatherAsync(int cityID)
        {
            return await GetWeatherAsync(
                new Dictionary<string, string> {{"id", cityID.ToString()}});
        }

        /// <summary>
        /// Gets info about the current weather
        /// </summary>
        /// <param name="coords">Coordinates for the location</param>
        /// <returns>Info about the current weather</returns>
        public async Task<WeatherInfo> GetWeatherAsync(Coord coords)
        {
            return await GetWeatherAsync(
                new Dictionary<string, string>()
                {
                    {"lat", coords.Lat.ToString()},
                    {"lon", coords.Lon.ToString()}
                });
        }

        /// <summary>
        /// Gets info about the current weather
        /// </summary>
        /// <param name="lat">Latitude</param>
        /// <param name="lon">Longitude</param>
        /// <returns>Info about the current weather</returns>
        public async Task<WeatherInfo> GetWeatherAsync(double lat, double lon)
        {
            return await GetWeatherAsync(
                new Dictionary<string, string>()
                {
                    {"lat", lat.ToString()},
                    {"lon", lon.ToString()}
                });
        }

        /// <summary>
        /// Gets info about the current weather
        /// </summary>
        /// <param name="zipCode">Zip code</param>
        /// <param name="countryCode">Country code</param>
        /// <returns>Info about the current weather</returns>
        public async Task<WeatherInfo> GetWeatherAsync(int zipCode, string countryCode)
        {
            if (string.IsNullOrEmpty(countryCode)) { throw new ArgumentNullException("countryCode"); }

            return await GetWeatherAsync(
                new Dictionary<string, string>() {{"zip", zipCode + "," + countryCode}});
        }

        private async Task<WeatherInfo> GetWeatherAsync(Dictionary<string, string> parameters)
        {
            parameters.Add("appid", ApiKey);
            parameters.Add("mode", "xml");

            using (Stream stream = await httpclient.GetStreamAsync(
                Endpoints.Weather + "?" + string.Join("&", parameters.Select(x => x.Key + "=" + x.Value))))
            {
                return (WeatherInfo)new XmlSerializer(typeof(WeatherInfo)).Deserialize(stream);
            }
        }

        /// <summary>
        /// Gets the weather forecast for the next 5 days
        /// </summary>
        /// <param name="cityName">Name of the city</param>
        /// <param name="countryCode">Country code</param>
        /// <returns>Gets the weather forecast for the next 5 days</returns>
        public async Task<WeatherData> GetForecastAsync(string cityName, string countryCode = null)
        {
            if (string.IsNullOrEmpty(cityName)) { throw new ArgumentNullException("cityName"); }
            if (!string.IsNullOrEmpty(countryCode))
            {
                cityName += "," + countryCode;
            }

            return await GetForecastAsync(
                new Dictionary<string, string> {{"q", cityName}});
        }

        /// <summary>
        /// Gets the weather forecast for the next 5 days
        /// </summary>
        /// <param name="cityID">Name of the city</param>
        /// <returns>Gets the weather forecast for the next 5 days</returns>
        public async Task<WeatherData> GetForecastAsync(int cityID)
        {
            return await GetForecastAsync(
                new Dictionary<string, string> {{"id", cityID.ToString()}});
        }

        /// <summary>
        /// Gets the weather forecast for the next 5 days
        /// </summary>
        /// <param name="coords">Coordinates for the location</param>
        /// <returns>Gets the weather forecast for the next 5 days</returns>
        public async Task<WeatherData> GetForecastAsync(Coord coords)
        {
            return await GetForecastAsync(
                new Dictionary<string, string>()
                {
                    {"lat", coords.Lat.ToString()},
                    {"lon", coords.Lon.ToString()}
                });
        }

        /// <summary>
        /// Gets the weather forecast for the next 5 days
        /// </summary>
        /// <param name="lat">Latitude</param>
        /// <param name="lon">Longitude</param>
        /// <returns>Gets the weather forecast for the next 5 days</returns>
        public async Task<WeatherData> GetForecastAsync(double lat, double lon)
        {
            return await GetForecastAsync(
                new Dictionary<string, string>()
                {
                    {"lat", lat.ToString()},
                    {"lon", lon.ToString()}
                });
        }

        /// <summary>
        /// Gets the weather forecast for the next 5 days
        /// </summary>
        /// <param name="zipCode">Zip code</param>
        /// <param name="countryCode">Country code</param>
        /// <returns>Gets the weather forecast for the next 5 days</returns>
        public async Task<WeatherData> GetForecastAsync(int zipCode, string countryCode)
        {
            if (string.IsNullOrEmpty(countryCode)) { throw new ArgumentNullException("countryCode"); }

            return await GetForecastAsync(
                new Dictionary<string, string>() {{"zip", zipCode + "," + countryCode}});
        }

        private async Task<WeatherData> GetForecastAsync(Dictionary<string, string> parameters)
        {
            parameters.Add("appid", ApiKey);
            parameters.Add("mode", "xml");

            using (Stream stream = await httpclient.GetStreamAsync(
                Endpoints.Forecast + "?" + string.Join("&", parameters.Select(x => x.Key + "=" + x.Value))))
            {
                return (WeatherData)new XmlSerializer(typeof(WeatherData)).Deserialize(stream);
            }
        }

        /// <summary>
        /// Gets the url for the icon
        /// </summary>
        /// <param name="icon">icon</param>
        /// <returns>Url to the icon</returns>
        public string GetIconURL(string icon) => Endpoints.W + "/" + icon + ".png";

        /// <summary>
        /// Releases the unmanaged resources and disposes of the managed resources used.
        /// </summary>
        public void Dispose()
        {
            ApiKey = null;
            httpclient.Dispose();
        }
    }
}
