using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OpenWeather
{
    public class OpenWeatherClient : IDisposable
    {
        HttpClient httpclient = new HttpClient();

        public OpenWeatherClient(string apiKey, Unit units = Unit.Standard, Language language = Language.EN)
        {
            httpclient.BaseAddress = new Uri(Endpoints.BaseUrl);
            this.ApiKey = apiKey;
            this.Units = units;
            this.Language = language;
        }

        /// <summary>
        /// OpenWeatherMap api key
        /// </summary>
        public string ApiKey { get; set; }
        /// <summary>
        /// Temperature is available in Fahrenheit, Celsius and Kelvin units.
        /// For temperature in Fahrenheit use units=imperial
        /// For temperature in Celsius use units=metric
        /// Temperature in Kelvin is used by default
        /// </summary>
        public Unit Units { get; set; }
        /// <summary>
        /// Output in your language
        /// NOTE: Translation is only applied for the "description" field.
        /// </summary>
        public Language Language { get; set; }

        /// <summary>
        /// Gets info about the curent weather
        /// </summary>
        /// <param name="cityName">Name of the city</param>
        /// <param name="countryCode">Country code</param>
        /// <returns>Info about the current weather</returns>
        public async Task<WeatherData> GetWeatherAsync(string cityName, string countryCode = null)
        {
            if (string.IsNullOrEmpty(cityName)) { throw new ArgumentNullException("cityName"); }
            if (!string.IsNullOrEmpty(countryCode))
            {
                cityName += "," + countryCode;
            }

            return await GetWeatherAsync(
                new Dictionary<string, string>
                {
                    { "q", cityName }
                });
        }

        /// <summary>
        /// Gets info about the curent weather
        /// </summary>
        /// <param name="cityID">Name of the city</param>
        /// <returns>Info about the current weather</returns>
        public async Task<WeatherData> GetWeatherAsync(int cityID)
        {
            return await GetWeatherAsync(
                new Dictionary<string, string> {{"id", cityID.ToString()}}
            );
        }

        /// <summary>
        /// Gets info about the current weather
        /// </summary>
        /// <param name="coords">Coordinates for the location</param>
        /// <returns>Info about the current weather</returns>
        public async Task<WeatherData> GetWeatherAsync(Coordinates coordinates)
        {
            return await GetWeatherAsync(
                new Dictionary<string, string>()
                {
                    {"lat", coordinates.Latitude.ToString()},
                    {"lon", coordinates.Longitude.ToString()}
                });
        }

        /// <summary>
        /// Gets info about the current weather
        /// </summary>
        /// <param name="lat">Latitude</param>
        /// <param name="lon">Longitude</param>
        /// <returns>Info about the current weather</returns>
        public async Task<WeatherData> GetWeatherAsync(double lat, double lon)
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
        public async Task<WeatherData> GetWeatherAsync(int zipCode, string countryCode)
        {
            if (string.IsNullOrEmpty(countryCode)) { throw new ArgumentNullException("countryCode"); }

            return await GetWeatherAsync(
                new Dictionary<string, string>() {{"zip", zipCode + "," + countryCode}});
        }

        private async Task<WeatherData> GetWeatherAsync(Dictionary<string, string> parameters)
        {
            parameters.Add("appid", ApiKey);
            parameters.Add("mode", "json");
            parameters.Add("lang", Language.ToString());

            if (Units != Unit.Standard) parameters.Add("units", Units.ToString());
            

            return await await Task.Factory.StartNew(async () =>
                JsonConvert.DeserializeObject<WeatherData>(
                    await httpclient.GetStringAsync(Endpoints.Weather + "?" + string.Join("&", parameters.Select(x => x.Key + "=" + x.Value)
            ))));
        }
        /*
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
            parameters.Add("mode", "json");

            return await await Task.Factory.StartNew(async () =>
                JsonConvert.DeserializeObject<WeatherData>(
                    await httpclient.GetStringAsync(Endpoints.Forecast + "?" + string.Join("&", parameters.Select(x => x.Key + "=" + x.Value)
            ))));
        }
        */

        /// <summary>
        /// Gets the url for the icon
        /// </summary>
        /// <param name="icon">icon</param>
        /// <returns>Url to the icon</returns>
        public string GetIconURL(string icon) => Endpoints.BaseUrl + Endpoints.W + "/" + icon + ".png";

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
