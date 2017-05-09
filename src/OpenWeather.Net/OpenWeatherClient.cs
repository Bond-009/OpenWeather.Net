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

        public OpenWeatherClient(string apiKey)
        {
            httpclient.BaseAddress = new Uri(Endpoints.BaseUrl);
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
        public async Task<WeatherData> GetWeatherAsync(string cityName, string countryCode = null, Unit units = Unit.Standard, Language language = Language.EN)
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
                },
                units,
                language);
        }

        /// <summary>
        /// Gets info about the curent weather
        /// </summary>
        /// <param name="cityID">Name of the city</param>
        /// <returns>Info about the current weather</returns>
        public async Task<WeatherData> GetWeatherAsync(int cityID, Unit units = Unit.Standard, Language language = Language.EN)
        {
            return await GetWeatherAsync(
                new Dictionary<string, string> {{"id", cityID.ToString()}},
                units,
                language);
        }

        /// <summary>
        /// Gets info about the current weather
        /// </summary>
        /// <param name="coords">Coordinates for the location</param>
        /// <returns>Info about the current weather</returns>
        public async Task<WeatherData> GetWeatherAsync(Coordinates coordinates, Unit units = Unit.Standard, Language language = Language.EN)
        {
            return await GetWeatherAsync(
                new Dictionary<string, string>()
                {
                    {"lat", coordinates.Latitude.ToString()},
                    {"lon", coordinates.Longitude.ToString()}
                },
                units,
                language);
        }

        /// <summary>
        /// Gets info about the current weather
        /// </summary>
        /// <param name="lat">Latitude</param>
        /// <param name="lon">Longitude</param>
        /// <returns>Info about the current weather</returns>
        public async Task<WeatherData> GetWeatherAsync(double lat, double lon, Unit units = Unit.Standard, Language language = Language.EN)
        {
            return await GetWeatherAsync(
                new Dictionary<string, string>()
                {
                    {"lat", lat.ToString()},
                    {"lon", lon.ToString()}
                },
                units,
                language);
        }

        /// <summary>
        /// Gets info about the current weather
        /// </summary>
        /// <param name="zipCode">Zip code</param>
        /// <param name="countryCode">Country code</param>
        /// <returns>Info about the current weather</returns>
        public async Task<WeatherData> GetWeatherAsync(int zipCode, string countryCode, Unit units = Unit.Standard, Language language = Language.EN)
        {
            if (string.IsNullOrEmpty(countryCode)) { throw new ArgumentNullException("countryCode"); }

            return await GetWeatherAsync(
                new Dictionary<string, string>() {{"zip", zipCode + "," + countryCode}},
                units,
                language);
        }

        private async Task<WeatherData> GetWeatherAsync(Dictionary<string, string> parameters, Unit units = Unit.Standard, Language language = Language.EN)
        {
            parameters.Add("appid", ApiKey);
            parameters.Add("mode", "json");
            parameters.Add("lang", language.ToString());

            if (units != Unit.Standard) parameters.Add("units", units.ToString());
            

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
