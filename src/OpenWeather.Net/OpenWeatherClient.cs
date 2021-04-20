using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace OpenWeather
{
    /// <summary>
    /// Provides a base class for retrieving information from the OpenWeather API.
    /// </summary>
    public class OpenWeatherClient : IDisposable
    {
        private HttpClient _httpClient = new HttpClient();
        private bool _disposed = false;

        /// <summary>
        /// Creates a new instance of the OpenWeatherClient class
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="units"></param>
        /// <param name="language"></param>
        public OpenWeatherClient(string apiKey, Unit units = Unit.Standard, Language language = Language.EN)
        {
            _httpClient.BaseAddress = new Uri(Endpoints.BaseUrl);
            ApiKey = apiKey;
            Units = units;
            Language = language;
        }

        /// <summary>
        /// OpenWeatherMap api key.
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// Temperature is available in Fahrenheit, Celsius and Kelvin units.
        /// For temperature in Fahrenheit use Imperial
        /// For temperature in Celsius use Metric
        /// For temperature in Kelvin use Default
        /// </summary>
        public Unit Units { get; set; }

        /// <summary>
        /// Output in your language
        /// NOTE: Translation is only applied for the "description" field.
        /// </summary>
        public Language Language { get; set; }

        /// <summary>
        /// Gets info about the current weather.
        /// </summary>
        /// <param name="cityName">Name of the city</param>
        /// <param name="countryCode">Country code</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Info about the current weather</returns>
        public Task<WeatherData> GetWeatherAsync(
            string cityName,
            string countryCode = null,
            CancellationToken cancellationToken = default)
        {
            if (cityName == null)
            {
                throw new ArgumentNullException(nameof(cityName));
            }

            if (!string.IsNullOrEmpty(countryCode))
            {
                cityName += "," + countryCode;
            }

            return GetWeatherAsync(
                new Dictionary<string, string>
                {
                    { "q", cityName }
                },
                cancellationToken);
        }

        /// <summary>
        /// Gets info about the current weather
        /// </summary>
        /// <param name="cityID">Name of the city</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Info about the current weather</returns>
        public Task<WeatherData> GetWeatherAsync(
            int cityID,
            CancellationToken cancellationToken = default)
        {
            return GetWeatherAsync(
                new Dictionary<string, string>
                {
                    { "id", cityID.ToString(CultureInfo.InvariantCulture) }
                },
                cancellationToken);
        }

        /// <summary>
        /// Gets info about the current weather
        /// </summary>
        /// <param name="coordinates">Coordinates for the location</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Info about the current weather</returns>
        public Task<WeatherData> GetWeatherAsync(
            Coordinates coordinates,
            CancellationToken cancellationToken = default)
        {
            return GetWeatherAsync(
                new Dictionary<string, string>()
                {
                    {"lat", coordinates.Latitude.ToString(CultureInfo.InvariantCulture)},
                    {"lon", coordinates.Longitude.ToString(CultureInfo.InvariantCulture)}
                },
                cancellationToken);
        }

        /// <summary>
        /// Gets info about the current weather
        /// </summary>
        /// <param name="latitude">Latitude</param>
        /// <param name="longitude">Longitude</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Info about the current weather</returns>
        public Task<WeatherData> GetWeatherAsync(
            double latitude,
            double longitude,
            CancellationToken cancellationToken = default)
        {
            return GetWeatherAsync(
                new Dictionary<string, string>()
                {
                    {"lat", latitude.ToString(CultureInfo.InvariantCulture)},
                    {"lon", longitude.ToString(CultureInfo.InvariantCulture)}
                },
                cancellationToken);
        }

        /// <summary>
        /// Gets info about the current weather
        /// </summary>
        /// <param name="zipCode">Zip code</param>
        /// <param name="countryCode">Country code</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Info about the current weather</returns>
        public Task<WeatherData> GetWeatherAsync(
            int zipCode,
            string countryCode,
            CancellationToken cancellationToken = default)
        {
            if (countryCode == null)
            {
                throw new ArgumentNullException(nameof(countryCode));
            }

            return GetWeatherAsync(
                new Dictionary<string, string>()
                {
                    {"zip", zipCode + "," + countryCode}
                },
                cancellationToken);
        }

        private async Task<WeatherData> GetWeatherAsync(
            Dictionary<string, string> parameters,
            CancellationToken cancellationToken)
        {
            parameters.Add("appid", ApiKey);
            parameters.Add("mode", "json");
            parameters.Add("lang", Language.ToString());

            if (Units != Unit.Standard)
            {
                parameters.Add("units", Units.ToString());
            }

            using (HttpResponseMessage res = await _httpClient.GetAsync(
                    Endpoints.Weather + "?" + string.Join('&', parameters.Select(x => x.Key + "=" + x.Value)),
                    cancellationToken
                ).ConfigureAwait(false))
            using (Stream stream = await res.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false))
            {
                return await JsonSerializer.DeserializeAsync<WeatherData>(
                    stream,
                    cancellationToken: cancellationToken).ConfigureAwait(false);
            }
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

        /// <inheritdoc />
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">Whether or not the managed resources should be disposed.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _httpClient.Dispose();
            }

            _httpClient = null;
            ApiKey = null;

            _disposed = true;
        }
    }
}
