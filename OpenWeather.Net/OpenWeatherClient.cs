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
        public OpenWeatherClient(string apiKey)
            => this.ApiKey = apiKey;

        /// <summary>
        /// OpenWeatherMap api key
        /// </summary>
        public string ApiKey { get; set; }

        HttpClient httpclient = new HttpClient();
        XmlSerializer ser = new XmlSerializer(typeof(WeatherInfo));

        /// <summary>
        /// Gets info about the curent weather
        /// </summary>
        /// <param name="cityName">Name of the city</param>
        /// <param name="countryCode">Country code</param>
        /// <returns>Info about the current weather</returns>
        public async Task<WeatherInfo> GetCurrentAsync(string cityName, string countryCode = null)
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
        /// Gets info about the current weather
        /// </summary>
        /// <param name="coords">Coordinates for the location</param>
        /// <returns>Info about the current weather</returns>
        public async Task<WeatherInfo> GetCurrentAsync(Coord coords)
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
        public async Task<WeatherInfo> GetCurrentAsync(double lat, double lon)
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
        public async Task<WeatherInfo> GetCurrentAsync(int zipCode, string countryCode)
        {
            if (string.IsNullOrEmpty(countryCode)) { throw new ArgumentNullException("countryCode"); }

            return await GetWeatherAsync(
                new Dictionary<string, string>() {{"zip", zipCode + "," + countryCode}});
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
            ser = null;
            httpclient.Dispose();
        }

        private async Task<WeatherInfo> GetWeatherAsync(Dictionary<string, string> parameters)
        {
            parameters.Add("appid", ApiKey);
            parameters.Add("mode", "xml");

            using (Stream stream = await httpclient.GetStreamAsync(
                Endpoints.Weather + "?" + string.Join("&", parameters.Select(x => x.Key + "=" + x.Value))))
            {
                return (WeatherInfo)ser.Deserialize(stream);
            }
        }
    }
}
